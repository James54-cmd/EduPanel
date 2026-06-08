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
