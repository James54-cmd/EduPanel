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

- **`<FieldGroup>`**: Groups multiple related fields with standard vertical gap spacing.
- **`<Field>`**: Standard wrapper block for an individual input field.
- **`<FieldLabel>`**: Standardized font weights and color parameters for labels.
- **`<FieldSeparator>`**: Divider line with centered secondary styling text (e.g. "Or continue with").
- **`<FieldDescription>`**: Standard secondary descriptive text beneath/above forms.

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

- **Validator Helper**: We implement the `ValidateValue` helper in our inline validator class:
  ```csharp
  public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
  {
      var result = await ValidateAsync(ValidationContext<T>.CreateWithOptions((T)model, x => x.IncludeProperties(propertyName)));
      if (result.IsValid)
          return Array.Empty<string>();
      return result.Errors.Select(e => e.ErrorMessage);
  };
  ```
- **MudForm binding**: We bind the validator's helper function to the `Validation` property of `MudForm`:
  ```razor
  <MudForm Model="@model" Validation="@(validator.ValidateValue)">
      <MudTextField @bind-Value="model.Property" For="@(() => model.Property)" />
  </MudForm>
  ```
- **Asynchronous Execution**: We always trigger form validation using the non-obsolete `await form.ValidateAsync()` method on form submission.

---

## 🎨 Premium Theme & Typography

EduPanel implements a clean, premium Shadcn-like Slate aesthetic:

- **Typography**: Replaced default fonts with **Figtree** loaded from Google Fonts in [App.razor](file:///c:/Users/JamesFanuelNDamaso/Documents/GitHub/EduPanel/Components/App.razor) and bound to `DefaultTypography`.
- **Colors**: Optimized `PaletteLight` with custom Hex codes:
  - **Primary**: `#1B4F8A` (Navy Blue)
  - **Secondary**: `#2E7D9E` (Steel Blue)
  - **Tertiary** (Accent): `#F5A623` (Warm Amber)
  - **Info** (Soft Accent): `#FFF0D0` (Pale Amber)
  - **Background**: `#F4F6F9` (Cool White)
  - **Surface**: `#FFFFFF` (White)
  - **Divider**: `#e4e4e7` (Zinc-200 / subtle borders)
  - **Success**: `#10b981` (Emerald-500)
  - **Warning**: `#f59e0b` (Amber-500)
  - **Error**: `#ef4444` (Red-500)

---

## 💅 CSS Isolation & Component Structure

To maintain clean Razor files and organize components effectively:

- **Component Folders**: Each page or complex component should live in its own dedicated folder (e.g., `Dashboard/Dashboard.razor`).
- **Namespace Management**: Placing a component in a folder with the exact same name causes a C# namespace conflict (Error CS0542). To prevent this, always add the `@namespace` directive to the top of the `.razor` file specifying the parent namespace (e.g., `@namespace EduPanel.Components.Pages.Admin`).
- **Avoid Inline `<style>` Blocks**: Do not use `<style>` blocks inside `.razor` components.
- **Use Scoped CSS**: Place component-specific styles in a dedicated isolated CSS file right next to the component (e.g., `Dashboard/Dashboard.razor.css`).
- **Global Styles & DRY Principle**: Utility classes (e.g., `.text-danger`, `.bg-transparent`) and truly global styles must be kept in `wwwroot/app.css` or `wwwroot/EduPanel.styles.css`. Avoid DRY (Don't Repeat Yourself) by never duplicating the same utility classes across multiple `.razor` or isolated `.css` files.
- **Complex Page Structuring**: When dealing with massive forms or complex pages, avoid vertically scrolling monoliths. Break the page down into logical sections and use `MudTabs` (either vertical or horizontal) to simplify the user interface. Keep each tab's content in a separate sub-component within a `Tabs` directory (e.g., `Profile/Tabs/PersonalProfileTab.razor`).

---

## 🎨 Gradient Avatar Utilities

To keep avatars visually consistent and premium across the app, gradient styles are defined as global utility classes in `wwwroot/app.css`. **Never use inline `Style=` or `Color=` on `MudAvatar`** — use these classes instead:

| Class                       | Gradient                         |
| --------------------------- | -------------------------------- |
| `avatar-gradient-primary`   | Navy Blue → Steel Blue           |
| `avatar-gradient-secondary` | Steel Blue → Light Blue          |
| `avatar-gradient-success`   | Emerald-600 → Emerald-400        |
| `avatar-gradient-warning`   | Amber-600 → Amber-400            |
| `avatar-gradient-error`     | Red-600 → Red-400                |
| `avatar-gradient-info`      | Sky-600 → Sky-400                |

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

- **Models**: Place data transfer objects and state models in a `Models` subfolder specific to the domain (e.g., `Components/Pages/Employee/Attendance/Models/ShiftRequestModel.cs`).
- **Dialogs**: Extract complex popup forms into dedicated reusable UI components and place them in a `Dialogs` subfolder (e.g., `Components/Pages/Employee/Attendance/Dialogs/ChangeShiftDialog.razor`).
- **MudDialog Usage**:
  - Never use inline `<MudDialog>` tags within complex page layouts.
  - Always invoke dialog components programmatically via `IDialogService.ShowAsync<T>()`.
  - Structure dialog components cleanly using `<TitleContent>`, `<DialogContent>`, and `<DialogActions>` to mimic clear, Shadcn-like pop-up aesthetics.
  - Use `[CascadingParameter] IMudDialogInstance MudDialog { get; set; } = default!;` to control the dialog state.
  - **Layout Aesthetics**: Use a vertical stacked form layout (`d-flex flex-column`) inside the `DialogContent` rather than a horizontally squished `MudGrid`. This looks significantly cleaner and scales far better within constrained dialog bounds. Avoid using `MaxWidth.Large` unless strictly required for massive tables; prefer `MaxWidth.Medium` or `MaxWidth.Small` to keep the UI feeling tight and focused. If using nested `MudTabs` inside a dialog, favor top tabs (`Elevation="1"`) over side navigation ribbons to maximize usable horizontal space.

---

## 📱 Mobile Responsiveness (Phones & Tablets)

EduPanel uses MudBlazor's responsive utility classes to ensure layouts gracefully adapt to phone dimensions (e.g., 390x844) and tablet dimensions (e.g., 765x1024) without breaking the desktop view.

- **Action Bars and Toolbars**:
  - Instead of forcing elements onto a single row (`d-flex align-center`), use responsive flex-direction classes: `d-flex flex-column flex-md-row`.
  - Add `gap-3` or `gap-4` to handle spacing gracefully whether stacked or in a row.
  - For groups of buttons or inputs, apply `flex-wrap justify-center` so they can wrap to the next line on narrow screens instead of overflowing horizontally.
- **Text Alignment**: Use responsive text alignment (`text-center text-md-left`) when switching from stacked headers (mobile) to row-based headers (desktop).
- **Full Width Elements**: Use `w-100` on internal toolbar wrappers so inputs span cleanly across mobile screens.

---

## 🧭 Dynamic Routing & Modular Architecture

For heavily nested modules (like Attendance or Human Resources), avoid creating a hardcoded `NavGroup` mapping directly to distinct URL-routed pages. Instead:

- **Use a Single Router Page**: Implement a central router layout (e.g., `HumanResourcePage.razor`) mapped via `@page "/employee/human-resource/{PageSlug?}"`.
- **DynamicComponent Rendering**: Use `Blazor's` `<DynamicComponent>` to swap out tabs based on the slug. 
- **Tab Directory**: Store all corresponding views inside a `Tabs` directory (e.g., `BenefitEnrollmentTab.razor`, `BenefitBalanceTab.razor`).
- **Benefits**: This prevents having to copy-paste identical outer layout wrappers, keeps URLs clean, and drastically reduces navigation/re-rendering latency.

---

## 🖱️ Interactive UI & Row-Click Expansion

When dealing with complex data that requires a parent-child relationship (e.g., tracking a user's `BenefitBalance` and breaking it down into sub-tables of what they `Earned` vs what they `Used`):

- Do not attempt to force all details directly into the columns of the main table.
- Implement an interactive **RowClick** event handler on the parent `MudTable` (`OnRowClick="OnRowClick"`).
- Capture the clicked item into a state variable (e.g., `_selectedBalance`).
- Conditionally render a beautifully padded `<MudPaper>` *below* the main table containing the related sub-tables or specific details. This approach creates a smooth, intuitive master-detail workflow without cluttered modals.
