# CarbonBlazor

CarbonBlazor is a simple, opinionated implementation of the IBM Carbon Design System for Blazor.  
The Carbon Design System website is https://carbondesignsystem.com.
CarbonBlazor should try and implement all components listed on the website.
Each component has documentation available on the website which covers Usage, Style, Code and Accessibility. 

For example:

- Accordion:
  - Usage: https://carbondesignsystem.com/components/accordion/usage/
  - Style: https://carbondesignsystem.com/components/accordion/style/
  - Code: https://carbondesignsystem.com/components/accordion/code/
  - Accessibility: https://carbondesignsystem.com/components/accordion/accessibility/

## Components

Several components have already been implemented to some degree with some further work required to get them to properly align with the Carbon Design System standards, particularly around Accessibility.
The following components have not yet been implemented:

- Content Switcher
- File Uploader
- Inline Loading
- Link
- Menu
- Menu Buttons
- Pagination
- Popover
- Progress Bar
- Slider
- Tile
- Toggle
- Toggletip
- Tooltip
- Tree view

## Conventions

Components should be named with the 'CarbonBlazor' prefix, e.g. 'CarbonBlazorAccordion'.
Components should be located in the Components folder in the Synonms.CarbonBlazor project.
Components should make use of isolated CSS, e.g. 'CarbonBlazorAccordion.razor.css'.
Components should avoid the use of JavaScript wherever possible and instead use HTML, CSS and C#.
Cascading Style Sheets should be plain CSS, not a compiled abstraction like SCSS, SASS or LESS.
Cascading Style Sheets should reference the variables defined in carbonblazor.css where possible.

C# code should use explicit declarations and avoid 'var'.

## Icons

Icons are available from https://carbondesignsystem.com/elements/icons/library/.
When required by a component, icons should be downloaded to the Icons folder in the Synonms.CarbonBlazor project as svg files.
The icon file svg markup should be copied to a public const string property on the IconSvgTags class. 
The markup copied to IconSvgTags should be edited so that the following opening and closing tags are removed: '?xml', 'svg', 'style', 'rect'.
The markup copied to IconSvgTags should be edited so that a 'title' tag is added if one is not present, containing the icon name.
For example, the icon file add.svg contains the following markup:

```svg
<?xml version="1.0" encoding="utf-8"?>
<!-- Generator: Adobe Illustrator 24.0.3, SVG Export Plug-In . SVG Version: 6.00 Build 0)  -->
<svg version="1.1" id="icon" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"
width="32px" height="32px" viewBox="0 0 32 32" style="enable-background:new 0 0 32 32;" xml:space="preserve">
<style type="text/css">
	.st0{fill:none;}
</style>
<polygon points="17,15 17,8 15,8 15,15 8,15 8,17 15,17 15,24 17,24 17,17 24,17 24,15 "/>
<rect class="st0" width="32" height="32"/>
</svg>
```

The corresponding property on the IconSvgTags class should be:

```csharp
public const string Add = "<title>add</title><polygon points=\"17,15 17,8 15,8 15,15 8,15 8,17 15,17 15,24 17,24 17,17 24,17 24,15 \"/>"
```

A corresponding entry should be added to the 'CarbonBlazorIcon' enum and to the ToSvg method of the 'CarbonBlazorIconMapper' class to map the enum value to the icon markup.

## Storybook

The component CarbonBlazorStorybook is an aggregation of the core components that can be used for demonstration and testing. All components should be added to the Storybook.
Placeholder sections have been added for components which have not yet been implemented simply containing the text "TODO".
