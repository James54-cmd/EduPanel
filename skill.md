# Engineering & Design Standards (EduPanel)

This document catalogs the design patterns and architecture standards established for the **EduPanel** dashboard project.

---

## 🏛️ Component-Based Architecture (CBA)

To maintain a clean and modular codebase, we separate page routing and layout concerns from functional UI logic:

1. **Pages (`Components/Pages`)**:
   - Focus solely on URL mapping (`@page "/"`), layout declarations (`@layout`), and page-level wrapper styling.
   - Example: [Home.razor](file:///c:/Users/JamesFanuelNDamaso/Documents/GitHub/EduPanel/Components/Pages/Home.razor) acts purely as a responsive layout wrapper.
2. **Components (`Components/Layout` or `Components/Shared`)**:
   - Encapsulate interactive behaviors, states, and styles.
   - Example: [LoginForm.razor](file:///c:/Users/JamesFanuelNDamaso/Documents/GitHub/EduPanel/Components/Layout/LoginForm.razor) contains all validation, submission logic, and form markup.

---

## 🧩 Global Composable UI Components

To support highly customized layouts, forms are composed of small, stateless, reusable UI components located in the `Components/UI` directory and registered globally in `_Imports.razor` under the `EduPanel.Components.UI` namespace:

* **`<FieldGroup>`**: Groups multiple related fields with standard vertical gap spacing.
* **`<Field>`**: Standard wrapper block for an individual input field.
* **`<FieldLabel>`**: Standardized font weights and color parameters for labels.
* **`<FieldSeparator>`**: Divider line with centered secondary styling text (e.g. "Or continue with").
* **`<FieldDescription>`**: Standard secondary descriptive text beneath/above forms.

### Usage Example:
```razor
<FieldGroup>
    <Field>
        <FieldLabel HtmlFor="email">Email</FieldLabel>
        <MudTextField @bind-Value="email" Placeholder="m@example.com" Variant="Variant.Outlined" Margin="Margin.Dense" />
    </Field>
    <FieldSeparator>Or continue with</FieldSeparator>
</FieldGroup>
```

---

## 🛡️ FluentValidation Integration

Forms are validated using standard `FluentValidation` rules mapped to a `MudForm`:

* **Validator Helper**: We implement the `ValidateValue` helper in our inline validator class:
  ```csharp
  public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
  {
      var result = await ValidateAsync(ValidationContext<T>.CreateWithOptions((T)model, x => x.IncludeProperties(propertyName)));
      if (result.IsValid)
          return Array.Empty<string>();
      return result.Errors.Select(e => e.ErrorMessage);
  };
  ```
* **MudForm binding**: We bind the validator's helper function to the `Validation` property of `MudForm`:
  ```razor
  <MudForm Model="@model" Validation="@(validator.ValidateValue)">
      <MudTextField @bind-Value="model.Property" For="@(() => model.Property)" />
  </MudForm>
  ```
* **Asynchronous Execution**: We always trigger form validation using the non-obsolete `await form.ValidateAsync()` method on form submission.

---

## 🎨 Premium Theme & Typography

EduPanel implements a clean, premium Shadcn-like Slate aesthetic:

* **Typography**: Replaced default fonts with **Figtree** loaded from Google Fonts in [App.razor](file:///c:/Users/JamesFanuelNDamaso/Documents/GitHub/EduPanel/Components/App.razor) and bound to `DefaultTypography`.
* **Colors**: Optimized `PaletteLight` with custom Hex codes:
  - **Primary**: `#18181b` (Zinc-900 / clean dark slate)
  - **Secondary**: `#71717a` (Zinc-500)
  - **Divider**: `#e4e4e7` (Zinc-200 / subtle borders)
  - **Success**: `#10b981` (Emerald-500)
  - **Warning**: `#f59e0b` (Amber-500)
  - **Error**: `#ef4444` (Red-500)

---

## 💅 CSS Isolation & Component Structure

To maintain clean Razor files and organize components effectively:

* **Component Folders**: Each page or complex component should live in its own dedicated folder (e.g., `Dashboard/Dashboard.razor`).
* **Namespace Management**: Placing a component in a folder with the exact same name causes a C# namespace conflict (Error CS0542). To prevent this, always add the `@namespace` directive to the top of the `.razor` file specifying the parent namespace (e.g., `@namespace EduPanel.Components.Pages.Admin`).
* **Avoid Inline `<style>` Blocks**: Do not use `<style>` blocks inside `.razor` components.
* **Use Scoped CSS**: Place component-specific styles in a dedicated isolated CSS file right next to the component (e.g., `Dashboard/Dashboard.razor.css`).
* **Global Styles & DRY Principle**: Utility classes (e.g., `.text-danger`, `.bg-transparent`) and truly global styles must be kept in `wwwroot/app.css` or `wwwroot/EduPanel.styles.css`. Avoid DRY (Don't Repeat Yourself) by never duplicating the same utility classes across multiple `.razor` or isolated `.css` files.
* **Complex Page Structuring**: When dealing with massive forms or complex pages, avoid vertically scrolling monoliths. Break the page down into logical sections and use `MudTabs` (either vertical or horizontal) to simplify the user interface. Keep each tab's content in a separate sub-component within a `Tabs` directory (e.g., `Profile/Tabs/PersonalProfileTab.razor`).

---

## 🎨 Gradient Avatar Utilities

To keep avatars visually consistent and premium across the app, gradient styles are defined as global utility classes in `wwwroot/app.css`. **Never use inline `Style=` or `Color=` on `MudAvatar`** — use these classes instead:

| Class | Gradient |
|---|---|
| `avatar-gradient-primary` | Zinc-900 → Zinc-600 (dark slate) |
| `avatar-gradient-secondary` | Zinc-500 → Zinc-400 (mid grey) |
| `avatar-gradient-success` | Emerald-600 → Emerald-400 |
| `avatar-gradient-warning` | Amber-600 → Amber-400 |
| `avatar-gradient-error` | Red-600 → Red-400 |
| `avatar-gradient-info` | Sky-600 → Sky-400 |

### Usage Example:
```razor
@* ✅ Correct *@
<MudAvatar Size="Size.Small" Class="avatar-gradient-primary">AB</MudAvatar>

@* ❌ Avoid *@
<MudAvatar Color="Color.Primary" Size="Size.Small">AB</MudAvatar>
```

---

## 🏗️ Domain-Driven Organization for Dialogs & Models

To keep features maintainable and modular, avoid dumping all models or dialogs into global root folders or hiding them inside massive page components. Instead, co-locate them by domain/feature:

* **Models**: Place data transfer objects and state models in a `Models` subfolder specific to the domain (e.g., `Components/Pages/Employee/Attendance/Models/ShiftRequestModel.cs`).
* **Dialogs**: Extract complex popup forms into dedicated reusable UI components and place them in a `Dialogs` subfolder (e.g., `Components/Pages/Employee/Attendance/Dialogs/ChangeShiftDialog.razor`).
* **MudDialog Usage**: 
  - Never use inline `<MudDialog>` tags within complex page layouts.
  - Always invoke dialog components programmatically via `IDialogService.ShowAsync<T>()`.
  - Structure dialog components cleanly using `<TitleContent>`, `<DialogContent>`, and `<DialogActions>` to mimic clear, Shadcn-like pop-up aesthetics.
  - Use `[CascadingParameter] IMudDialogInstance MudDialog { get; set; } = default!;` to control the dialog state.

