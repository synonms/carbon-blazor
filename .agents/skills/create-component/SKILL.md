---
name: create-component
description: Guide for adding new Blazor components to the CarbonBlazor library. Use this when asked to add new components.
---

To add new components to CarbonBlazor, follow this process:

1. Determine the component name (singular), preferring the terminology used in the Carbon Design System documentation. For example, "Accordion".
2. Create a new Blazor component in the Components folder of the Synonms.CarbonBlazor project. The component should be named with the 'CarbonBlazor' prefix, e.g., 'CarbonBlazorAccordion'.
3. Implement the component using HTML, CSS, and C#, avoiding JavaScript wherever possible. Follow the guidelines provided in the Carbon Design System documentation for Usage, Style, Code, and Accessibility.
4. If needed, create an isolated CSS file for the component, e.g., 'CarbonBlazorAccordion.razor.css', and reference the variables defined in carbonblazor.css where possible.
5. For Form field related components, try to implement them as InputBase components to ensure they work with Blazor forms and validation.  Also try to be flexible about the underlying property types they can be bound to to improve re-use, for example:
   - Date related controls should support DateTime, DateOnly, DateTimeOffset and nullable versions of these types.
   - Number controls should support float, double and decimal and nullable versions of these types.
   - Text controls should support string, char and nullable char.
   - Boolean controls should support bool and nullable bool.
6. Create a corresponding test class in the Synonms.CarbonBlazor.Tests.Unit project to ensure it works as expected and to prevent regressions in the future.  The tests should be named with a 'Tests' suffix, for example, 'CarbonBlazorAccordionTests'.
7. Add BUnit tests for the component to verify its functionality and behaviour.
8. Update the documentation for the component in the solution readme.md file, including usage examples and any relevant information about its properties.

