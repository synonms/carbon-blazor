# CarbonBlazor

CarbonBlazor is a simple, opinionated implementation of the IBM [Carbon Design System](https://carbondesignsystem.com/) for Blazor.

[![NuGet version (Synonms.CarbonBlazor)](https://img.shields.io/nuget/v/Synonms.CarbonBlazor?label=Synonms.CarbonBlazor)](https://www.nuget.org/packages/Synonms.CarbonBlazor/)

## Usage

Setup Carbon Blazor as follows:

- Install the NuGet package `Synonms.CarbonBlazor`
- Add the global and isolated CSS files to your `wwwroot/index.html` file:

```
<link rel="stylesheet" href="_content/Synonms.CarbonBlazor/css/carbonblazor.css"></link>
<link rel="stylesheet" href="_content/Synonms.CarbonBlazor/Synonms.CarbonBlazor.bundle.scp.css" />
```
- Add the global JavaScript file to your `wwwroot/index.html` file:

```
<script src="_content/Synonms.CarbonBlazor/js/carbon-blazor.js"></script>
```
- Add the CarbonBlazor dependencies in `Program.cs` or wherever you configure your dependency injection container:

`builder.Services.AddCarbonBlazor();`
- Optionally, edit `_Imports.razor` to add the namespaces (to save you having to add the using statements in your pages):
```
@using Synonms.CarbonBlazor.Components
@using Synonms.CarbonBlazor.Enumerations
@using Synonms.CarbonBlazor.Models
```
- Edit `MainLayout.razor` to use the CarbonBlazor shell, e.g.:
```htmlinblazor
@inherits LayoutComponentBase

<CarbonBlazorShell ProductName="My Product" ProductIconImagePath="images\my-logo.svg">
    <UserPanel>
        <CarbonBlazorHeaderActionLink NavigationItem="@NavigationItem.Create("Login", "/authentication/login")" />
    </UserPanel>
    <SwitcherPanel>
        <CarbonBlazorHeaderActionLink NavigationItem="@NavigationItem.Create("My Product", "https://localhost:5001")" />
        <CarbonBlazorHeaderActionLink NavigationItem="@NavigationItem.Create("My Other Product", "https://localhost:5002")" />
    </SwitcherPanel>
    <SideNav>
        <CarbonBlazorSidebarLink NavigationItem="@NavigationItem.Create(CarbonBlazorIcon.Dashboard, "Dashboard", "/")" />
        <CarbonBlazorSidebarLink NavigationItem="@NavigationItem.Create(CarbonBlazorIcon.Login, "Login", "/authentication/login")" />
    </SideNav>
    
    <Body>@Body</Body>
</CarbonBlazorShell>
```

You should be good to go.

## Components

### Button

Buttons are used to initialize an action. Button labels express what action will occur when the user interacts with it.

`<CarbonBlazorButton Display="CarbonBlazorButtonDisplay.TextOnly" Kind="CarbonBlazorButtonKind.Primary" Text="Primary"></CarbonBlazorButton>`

| Property | Option         | Notes                                                  |
|----------|----------------|--------------------------------------------------------|
| Display  | TextAndIcon    | Display both the text and icon                         |
|          | IconOnly       | Display the icon only                                  |
|          | TextOnly       | Display the text only                                  |
| Kind     | Primary        | Main call to action button e.g. 'Save'                 |
|          | Secondary      | Alternative muted action e.g. Cancel                   |
|          | Tertiary       | Additional option                                      |
|          | Ghost          | Outline button to blend with background                |
|          | Danger         | Alert button for destructive actions e.g. 'Delete'     |
|          | DangerTertiary |                                                        |
|          | DangerGhost    |                                                        |
|          | Header         | Special case for buttons in the header bar             |
|          | Input          | Special case for buttons embedded in input controls    |
|          | Body           | Special case for buttons floating in the document body |

### ButtonSet

ButtonSets group buttons together in a stack.

```htmlinblazor
<CarbonBlazorButtonSet>
    <CarbonBlazorButton Display="CarbonBlazorButtonDisplay.TextOnly" Kind="CarbonBlazorButtonKind.Primary" Text="Primary"></CarbonBlazorButton>
    <CarbonBlazorButton Display="CarbonBlazorButtonDisplay.TextOnly" Kind="CarbonBlazorButtonKind.Secondary" Text="Secondary"></CarbonBlazorButton>
    <CarbonBlazorButton Display="CarbonBlazorButtonDisplay.TextOnly" Kind="CarbonBlazorButtonKind.Tertiary" Text="Tertiary"></CarbonBlazorButton>
    <CarbonBlazorButton Display="CarbonBlazorButtonDisplay.TextOnly" Kind="CarbonBlazorButtonKind.Ghost" Text="Ghost"></CarbonBlazorButton>
</CarbonBlazorButtonSet>
```

### CheckBox

Checkboxes are used to represent a boolean value.

```htmlinblazor
<CarbonBlazorCheckBox Id="SomeCheckBox" Label="Checkbox label" @bind-Value="@_model.SomeBoolInputValue" ValidationFor="@(() => _model.SomeBoolInputValue)"></CarbonBlazorCheckBox>
```

### CheckBoxGroup

Checkbox groups are used when there are multiple items to select in a list. Users can select zero, one, or any number of items.

```htmlinblazor
<CarbonBlazorCheckBoxGroup Label="Checkbox group" @bind-Values="@_model.SomeCheckedValues" FieldIdentifier="@FieldIdentifier.Create(() => _model.SomeCheckedValues)" Items="@([CheckBoxItem.Create("Aardvark"), CheckBoxItem.Create("Chimp"), CheckBoxItem.Create("Giraffe"), CheckBoxItem.Create("Hippo")])"></CarbonBlazorCheckBoxGroup>
```

### CodeSnippet

Code snippets are strings or small blocks of reusable code that can be copied and inserted in a code file.

```htmlinblazor
<CarbonBlazorCodeSnippet Type="CarbonBlazorCodeSnippetType.SingleLine">CodeSnippet singleLine = new();</CarbonBlazorCodeSnippet>
```

### ComboButton

Combo buttons are comprised of two parts: a primary button on the left which triggers the most commonly used action, and a chevron icon button on the right which reveals a menu of additional options.

```htmlinblazor
<CarbonBlazorComboButton Label="Save" Size="CarbonBlazorMenuItemSize.Medium" PrimaryActionCallback="@OnSave">
    <Items>
        <CarbonBlazorMenuItem Label="Save as draft" ClickedCallback="@OnSaveAsDraft"></CarbonBlazorMenuItem>
        <CarbonBlazorMenuItem Label="Save as template" ClickedCallback="@OnSaveAsTemplate"></CarbonBlazorMenuItem>
        <CarbonBlazorMenuItemDivider></CarbonBlazorMenuItemDivider>
        <CarbonBlazorMenuItem Label="Discard" IsDanger="true" ClickedCallback="@OnDiscard"></CarbonBlazorMenuItem>
    </Items>
</CarbonBlazorComboButton>
```

| Property              | Option         | Notes                                                         |
|-----------------------|----------------|---------------------------------------------------------------|
| Label                 | string         | Text displayed on the primary action button                   |
| Size                  | ExtraSmall     | 24px height                                                   |
|                       | Small          | 32px height                                                   |
|                       | Medium         | 40px height (default)                                         |
|                       | Large          | 48px height                                                   |
| IsDisabled            | bool           | Disables both the primary and chevron buttons                 |
| PrimaryActionCallback | EventCallback  | Invoked when the primary button is clicked                    |
| Items                 | RenderFragment | Child `CarbonBlazorMenuItem` and `CarbonBlazorMenuItemDivider` components |

### ConfirmDeleteModal

Specialised modal used when asking the user to confirm the deletion of a RESTEasy resource.

```htmlinblazor
<CarbonBlazorConfirmDeleteModal @ref="@_deleteModal" Resource="@ActiveResource" Label="Permissions" Title="Remove a permission" CancelDeleteCallback="@CancelOperation" ConfirmDeleteCallback="@ConfirmOperation"></CarbonBlazorConfirmDeleteModal>
```

### DataTable

Data tables are used to organize and display data efficiently. The data table component allows for customization with additional functionality, as needed by your product’s users.

```htmlinblazor
<CarbonBlazorDataTable @ref="@_dataTable" TModel="PermissionResource" Title="Permissions" Models="@Resources" TotalSize="@Resources.Count" Offset="0" PageLimit="20" 
                           PaginationMode="CarbonBlazorPaginationMode.Client" FilterModelsFunc="@FilterModels">
    <ToolbarButtons>
        <CarbonBlazorButton Display="CarbonBlazorButtonDisplay.TextAndIcon" Icon="CarbonBlazorIcon.Add" Text="Add Permission" ClickedCallback="@(() => BeginOperation(Mode.Create, new PermissionResource()))"></CarbonBlazorButton>
    </ToolbarButtons>
    <HeaderRowTemplate>
        <CarbonBlazorDataTableHeaderCell>Id</CarbonBlazorDataTableHeaderCell>
        <CarbonBlazorDataTableHeaderCell>Name</CarbonBlazorDataTableHeaderCell>
        <CarbonBlazorDataTableHeaderCell></CarbonBlazorDataTableHeaderCell>
    </HeaderRowTemplate>
    <DataRowTemplate>
        <CarbonBlazorDataTableDataCell>@context.Id</CarbonBlazorDataTableDataCell>
        <CarbonBlazorDataTableDataCell>@context.Name</CarbonBlazorDataTableDataCell>
        <CarbonBlazorDataTableDataCell>
            <CarbonBlazorButtonSet>
                <CarbonBlazorButton Kind="CarbonBlazorButtonKind.Input" Display="CarbonBlazorButtonDisplay.IconOnly" Icon="CarbonBlazorIcon.View" ClickedCallback="@(() => BeginOperation(Mode.Read, context))"></CarbonBlazorButton>
                <CarbonBlazorButton Kind="CarbonBlazorButtonKind.Input" Display="CarbonBlazorButtonDisplay.IconOnly" Icon="CarbonBlazorIcon.Edit" ClickedCallback="@(() => BeginOperation(Mode.Update, context))"></CarbonBlazorButton>
                <CarbonBlazorButton Kind="CarbonBlazorButtonKind.Input" Display="CarbonBlazorButtonDisplay.IconOnly" Icon="CarbonBlazorIcon.TrashCan" ClickedCallback="@(() => BeginOperation(Mode.Delete, context))"></CarbonBlazorButton>
            </CarbonBlazorButtonSet>
        </CarbonBlazorDataTableDataCell>
    </DataRowTemplate>
</CarbonBlazorDataTable>
```

#### DataTableDataCell

Represents a table cell to be used in the `DataRowTemplate` fragment of a `DataTable`.  This fragment is rendered for each resource in the collection and `context` is the instance of the Resource displayed for a given row.

```htmlinblazor
<CarbonBlazorDataTableDataCell>@context.Name</CarbonBlazorDataTableDataCell>
```

#### DataTableHeaderCell

Represents a table header to be used in the `HeaderRowTemplate` fragment of a `DataTable`.

```htmlinblazor
<CarbonBlazorDataTableHeaderCell>Name</CarbonBlazorDataTableHeaderCell>
```

### DropDown

Dropdowns present a list of options from which a user can select one option, or several. A selected option can represent a value in a form, or can be used as an action to filter or sort existing content.
To constrain the user to a single selection, use a `Select` component instead.

```htmlinblazor
<CarbonBlazorDropDown Id="SomeDropDown" Label="Dropdown label" @bind-Values="@_model.SomeDropDownValues" FieldIdentifier="@FieldIdentifier.Create(() => _model.SomeDropDownValues)" Items="@([DropDownItem<string>.Create("One"), DropDownItem<string>.Create("Two"), DropDownItem<string>.Create("Three"), DropDownItem<string>.Create("Four")])"/>
```

### FileUploader

File uploaders let users select one or more files, or drag and drop them into a drop zone.
Drag-and-drop mode also requires the `_content/Synonms.CarbonBlazor/fileUploader.js` script to be loaded.

```htmlinblazor
<CarbonBlazorFileUploader Label="Upload files"
                          Description="Select one or more files to upload."
                          @bind-Files="@_files"
                          FieldIdentifier="@FieldIdentifier.Create(() => _files)">
</CarbonBlazorFileUploader>

<CarbonBlazorFileUploader Label="Drop zone uploader"
                          Description="Drag and drop files into the zone below."
                          Variant="CarbonBlazorFileUploaderVariant.DragAndDrop"
                          @bind-Files="@_dropZoneFiles"
                          FieldIdentifier="@FieldIdentifier.Create(() => _dropZoneFiles)">
</CarbonBlazorFileUploader>
```

| Property | Option | Notes |
|----------|--------|-------|
| Variant | Button | Default upload button |
|  | DragAndDrop | Drop zone uploader |
| Size | Small | 32px height |
|  | Medium | 40px height |
|  | Large | 48px height |
| ButtonKind | Primary | Main call to action |
|  | Tertiary | Default, less prominent action |
| AllowMultiple | bool | Select or upload multiple files |

### Form

A form is a group of related input controls that allows users to provide data or configure options.

```htmlinblazor
<CarbonBlazorForm TModel="StoryBookModel" Model="@_model" >
    <CarbonBlazorTextInput Id="SomeTextInput" Label="Text input label" HelperText="Optional help text" @bind-Value="@_model.SomeTextInputValue" ValidationFor="@(() => _model.SomeTextInputValue)"></CarbonBlazorTextInput>
    <CarbonBlazorNumberInput Id="SomeNumberInput" Label="Number input label" @bind-Value="@_model.SomeIntInputValue" ValidationFor="@(() => _model.SomeIntInputValue)" Min="0" Max="100" Step="5"></CarbonBlazorNumberInput>
    <CarbonBlazorCheckBox Id="SomeCheckBox" Label="Checkbox label" @bind-Value="@_model.SomeBoolInputValue" ValidationFor="@(() => _model.SomeBoolInputValue)"></CarbonBlazorCheckBox>
    <CarbonBlazorDropDown TValue="string" Id="SomeDropDown" Label="Dropdown label" @bind-Value="@_model.SomeDropDownValue" ValidationFor="@(() => _model.SomeDropDownValue)" FromString="@(x => x)" Options="@_dropDownOptions" />
</CarbonBlazorForm>
```

#### HeaderActionLink

Represents a link to be used in the header action panels, for example the User Profile or Switcher panels.

```htmlinblazor
<CarbonBlazorHeaderActionLink NavigationItem="@NavigationItem.Create("My Product", "https://localhost:5001")" />
```

#### HeaderActionPanelDivider

Represents a dividing line to be used to break sets of links in the header action panels, for example the User Profile or Switcher panels.

```htmlinblazor
<CarbonBlazorHeaderActionPanelDivider />
```

### Link

Links are used to navigate or trigger actions within text or standalone. They support external links, sizes, inline or block display, disabled state, and button-style (no href) interactions.

```htmlinblazor
<!-- Inline link inside text -->
<CarbonBlazorText>
  Here is an inline <CarbonBlazorLink Href="https://carbondesignsystem.com/" Target="_blank" External="true">Carbon Design</CarbonBlazorLink> link.
</CarbonBlazorText>

<!-- Default link -->
<CarbonBlazorLink Href="https://example.com">Default link</CarbonBlazorLink>

<!-- External link (adds rel noopener noreferrer and icon) -->
<CarbonBlazorLink Href="https://example.com" Target="_blank" External="true">External link</CarbonBlazorLink>

<!-- Disabled link -->
<CarbonBlazorLink IsDisabled="true">Disabled link</CarbonBlazorLink>

<!-- Button-style link (no navigation) -->
<CarbonBlazorLink Inline="false" Size="CarbonBlazorInputSize.Large" PreventDefault="true" ClickedCallback="@(() => Console.WriteLine("Clicked link"))">Button-style link</CarbonBlazorLink>
```

Properties:
- Href: URL to navigate to (optional; omit to use button-style behavior)
- Target: e.g., _blank (adds rel="noopener noreferrer" automatically)
- Rel: Additional rel tokens to merge with defaults
- External: Appends external/launch icon and, with Target _blank, adds hidden text “Opens in new tab” for screen readers
- Inline: Inline (default) vs block display
- IsDisabled: Renders an inert, non-focusable span with appropriate aria-disabled semantics
- Size: Small, Medium, Large; maps to typography tokens
- AriaLabel, Title, Id, Class, Style, Download: standard attributes
- PreventDefault: Prevents navigation when clicking the anchor (useful with ClickedCallback)
- ClickedCallback: Event handler for click

### List

Lists are vertical groupings of related content. List items begin with either a number or a bullet.

```htmlinblazor
<CarbonBlazorList IsOrdered="false">
    <CarbonBlazorListItem>
        Unordered list level 1
        <CarbonBlazorList IsOrdered="false">
            <CarbonBlazorListItem>Unordered list level 2</CarbonBlazorListItem>
            <CarbonBlazorListItem>Unordered list level 2</CarbonBlazorListItem>
            <CarbonBlazorListItem>Unordered list level 2</CarbonBlazorListItem>
        </CarbonBlazorList>
    </CarbonBlazorListItem>
    <CarbonBlazorListItem>Unordered list level 1</CarbonBlazorListItem>
    <CarbonBlazorListItem>Unordered list level 1</CarbonBlazorListItem>
</CarbonBlazorList>
```

### Inline Loading

Displays a small inline spinner and optional label to indicate background work.

```htmlinblazor
<CarbonBlazorInlineLoading Label="Loading..."></CarbonBlazorInlineLoading>
<CarbonBlazorInlineLoading Label="Success" IsSuccess="true"></CarbonBlazorInlineLoading>
<CarbonBlazorInlineLoading Label="Error" IsError="true"></CarbonBlazorInlineLoading>
```

### LoadingSpinner

Widget to use while waiting for child content to load, e.g. fetching resources from the server.

```htmlinblazor
<CarbonBlazorLoadingSpinner />
```

### Menu

A menu is a disclosure component that appears with a set of actions relevant to a specific control, interface area, or data element. Menus can be used standalone (e.g. context menus) or embedded within menu button trigger components.

```htmlinblazor
<CarbonBlazorMenu Size="CarbonBlazorMenuItemSize.Medium" IsOpen="true">
    <CarbonBlazorMenuItem Label="Cut" KeyboardShortcut="⌘X" ClickedCallback="@OnCut"></CarbonBlazorMenuItem>
    <CarbonBlazorMenuItem Label="Copy" KeyboardShortcut="⌘C" ClickedCallback="@OnCopy"></CarbonBlazorMenuItem>
    <CarbonBlazorMenuItem Label="Paste" KeyboardShortcut="⌘V" ClickedCallback="@OnPaste"></CarbonBlazorMenuItem>
    <CarbonBlazorMenuItemDivider></CarbonBlazorMenuItemDivider>
    <CarbonBlazorMenuItem Label="Delete" IsDanger="true" ClickedCallback="@OnDelete"></CarbonBlazorMenuItem>
</CarbonBlazorMenu>
```

| Property     | Option         | Notes                                           |
|--------------|----------------|-------------------------------------------------|
| Size         | ExtraSmall     | 24px item height                                |
|              | Small          | 32px item height                                |
|              | Medium         | 40px item height (default)                      |
|              | Large          | 48px item height                                |
| IsOpen       | bool           | Controls menu visibility (default: true)        |
| ChildContent | RenderFragment | Child `CarbonBlazorMenuItem` and `CarbonBlazorMenuItemDivider` components |

### MenuButton

Menu buttons open a menu with a list of interactive options. Use a menu button when all actions in the menu share the same level of importance. Supports Primary, Tertiary, and Ghost button kinds.

```htmlinblazor
<CarbonBlazorMenuButton Label="Actions" Kind="CarbonBlazorButtonKind.Primary" Size="CarbonBlazorMenuItemSize.Medium">
    <Items>
        <CarbonBlazorMenuItem Label="Option 1" ClickedCallback="@OnOption1"></CarbonBlazorMenuItem>
        <CarbonBlazorMenuItem Label="Option 2" ClickedCallback="@OnOption2"></CarbonBlazorMenuItem>
        <CarbonBlazorMenuItem Label="Delete" IsDanger="true" ClickedCallback="@OnDelete"></CarbonBlazorMenuItem>
    </Items>
</CarbonBlazorMenuButton>
```

| Property   | Option         | Notes                                                         |
|------------|----------------|---------------------------------------------------------------|
| Label      | string         | Button label text                                             |
| Kind       | Primary        | Primary button style (default)                                |
|            | Tertiary       | Tertiary button style                                         |
|            | Ghost          | Ghost button style                                            |
| Size       | ExtraSmall     | 24px height                                                   |
|            | Small          | 32px height                                                   |
|            | Medium         | 40px height (default)                                         |
|            | Large          | 48px height                                                   |
| IsDisabled | bool           | Disables the trigger button                                   |
| Items      | RenderFragment | Child `CarbonBlazorMenuItem` and `CarbonBlazorMenuItemDivider` components |

### MenuItem

An individual action item within a `CarbonBlazorMenu`. Supports danger styling, disabled state, selection indicator, keyboard shortcut display, and optional nested submenus.

```htmlinblazor
<CarbonBlazorMenuItem Label="Copy" KeyboardShortcut="⌘C" ClickedCallback="@OnCopy"></CarbonBlazorMenuItem>
<CarbonBlazorMenuItem Label="Delete" IsDanger="true" ClickedCallback="@OnDelete"></CarbonBlazorMenuItem>
<CarbonBlazorMenuItem Label="Unavailable" IsDisabled="true" ClickedCallback="@OnUnavailable"></CarbonBlazorMenuItem>
<CarbonBlazorMenuItem Label="Active option" IsSelected="true" ClickedCallback="@OnToggle"></CarbonBlazorMenuItem>

<!-- With submenu (revealed on hover) -->
<CarbonBlazorMenuItem Label="Edit">
    <SubItems>
        <CarbonBlazorMenuItem Label="Undo" KeyboardShortcut="⌘Z" ClickedCallback="@OnUndo"></CarbonBlazorMenuItem>
        <CarbonBlazorMenuItem Label="Redo" KeyboardShortcut="⌘⇧Z" ClickedCallback="@OnRedo"></CarbonBlazorMenuItem>
    </SubItems>
</CarbonBlazorMenuItem>
```

| Property          | Option         | Notes                                                          |
|-------------------|----------------|----------------------------------------------------------------|
| Label             | string         | Item display text (required)                                   |
| IsDisabled        | bool           | Renders item in disabled state; click events are suppressed    |
| IsDanger          | bool           | Applies danger/destructive styling on hover                    |
| IsSelected        | bool           | Shows a checkmark indicator and applies selected styling       |
| KeyboardShortcut  | string?        | Optional shortcut text displayed on the right                  |
| ClickedCallback   | EventCallback  | Invoked when item is activated (click or Enter/Space key)      |
| SubItems          | RenderFragment?| Optional nested submenu items, revealed on hover               |

### MenuItemDivider

A horizontal rule that visually separates groups of related menu items within a `CarbonBlazorMenu`. Takes no parameters.

```htmlinblazor
<CarbonBlazorMenuItemDivider></CarbonBlazorMenuItemDivider>
```

### Modal

Modals focus the user’s attention exclusively on one task or piece of information via a window that sits on top of the page content.

```htmlinblazor
<CarbonBlazorModal @ref="@_createModal" Label="Permissions" Title="Add a permission" Size="CarbonBlazorModalSize.Large">
    <CarbonBlazorText Type="CarbonBlazorTextType.Body01">You are about to delete resource Id @(Resource.Id) - are you sure you want to continue?</CarbonBlazorText>
    <CarbonBlazorButtonSet>
        <CarbonBlazorButton Type="CarbonBlazorButtonType.Button" Kind="CarbonBlazorButtonKind.Secondary" Display="CarbonBlazorButtonDisplay.TextOnly" Text="Cancel" Size="CarbonBlazorButtonSize.ExtraLarge" Style="width:50%;" ClickedCallback="@CancelDeleteCallback"></CarbonBlazorButton>
        <CarbonBlazorButton Type="CarbonBlazorButtonType.Button" Kind="CarbonBlazorButtonKind.Danger" Display="CarbonBlazorButtonDisplay.TextOnly" Text="Delete" Size="CarbonBlazorButtonSize.ExtraLarge" Style="width:50%;" ClickedCallback="@ConfirmDeleteCallback"></CarbonBlazorButton>
    </CarbonBlazorButtonSet>
</CarbonBlazorModal>
```

### NotificationInline (and NotificationToast)

Presents an inline notification for one-off transient messages.  Use the `Notify()` methods on the component to trigger the message.  By default messages are presented for 5 seconds before disappearing, though the user can dismiss them earlier.

Note that toast notifications are also available, which support multiple notifications simultaneously.  These are triggered using the `INotificationBroker` dependency and the components themselves are already wired into the Shell so you shouldn't need to use them.

```htmlinblazor
<CarbonBlazorNotificationInline @ref="@_notification"></CarbonBlazorNotificationInline>
```
```csharp
@code {
    private CarbonBlazorNotificationInline _notificationInline;
    
    [Inject]
    public INotificationBroker NotificationBroker { get; set; } = null!;

    public void NotifyInline() =>
        _notificationInline.Notify("Success", "The thing has succeeded!", CarbonBlazorNotificationStyle.LowContrast, CarbonBlazorNotificationLevel.Success));
    
    public void NotifyToast() =>
        NotificationBroker.Send("Hey", "An exciting thing happened!", CarbonBlazorNotificationStyle.LowContrast, CarbonBlazorNotificationLevel.Information));            
}
```

### NumberInput

Number input lets users enter a numeric value and incrementally increase or decrease the value with a two-segment control.

```htmlinblazor
<CarbonBlazorNumberInput Id="SomeNumberInput" Label="Number input label" @bind-Value="@_model.SomeIntInputValue" FieldIdentifier="@(FieldIdentifier.Create(() => _model.SomeIntInputValue))" Min="0" Max="100" Step="5"></CarbonBlazorNumberInput>
```

### OverflowMenuButton

Overflow menus reveal additional options when there is a space constraint. The trigger is an icon-only ghost button (defaulting to the three-dot vertical icon). Typically used in data table rows or cards.

```htmlinblazor
<CarbonBlazorOverflowMenuButton Size="CarbonBlazorMenuItemSize.Medium">
    <Items>
        <CarbonBlazorMenuItem Label="Edit" ClickedCallback="@OnEdit"></CarbonBlazorMenuItem>
        <CarbonBlazorMenuItem Label="Duplicate" ClickedCallback="@OnDuplicate"></CarbonBlazorMenuItem>
        <CarbonBlazorMenuItemDivider></CarbonBlazorMenuItemDivider>
        <CarbonBlazorMenuItem Label="Delete" IsDanger="true" ClickedCallback="@OnDelete"></CarbonBlazorMenuItem>
    </Items>
</CarbonBlazorOverflowMenuButton>
```

| Property     | Option         | Notes                                                         |
|--------------|----------------|---------------------------------------------------------------|
| Size         | ExtraSmall     | 24px height                                                   |
|              | Small          | 32px height                                                   |
|              | Medium         | 40px height (default)                                         |
|              | Large          | 48px height                                                   |
| IsDisabled   | bool           | Disables the trigger button                                   |
| TriggerIcon  | CarbonBlazorIcon | Icon shown on the trigger button (default: OverflowMenuVertical) |
| Items        | RenderFragment | Child `CarbonBlazorMenuItem` and `CarbonBlazorMenuItemDivider` components |

### Pane

Provides a framed container for related content with optional Title and Info headings.

```htmlinblazor
<CarbonBlazorPane Title="Typography" Info="Some descriptive text about fonts">
    <CarbonBlazorText Type="CarbonBlazorTextType.Heading01">Heading01</CarbonBlazorText>
    <CarbonBlazorText Type="CarbonBlazorTextType.Body01">Body01</CarbonBlazorText>
    <CarbonBlazorText Type="CarbonBlazorTextType.Label01">Label01</CarbonBlazorText>
</CarbonBlazorPane>
```

### Search

Search enables users to specify a word or a phrase to find relevant content without navigation.  Primarily used for filtering data tables.

```htmlinblazor
<CarbonBlazorSearch SearchTextChangedCallback="@OnSearchTextChanged"></CarbonBlazorSearch>
```

### Select

Select allows users to choose one option from a list of values.

```htmlinblazor
<CarbonBlazorSelect Id="SomeSelect" Label="Select label" @bind-Value="@_model.SomeSelectValue" FieldIdentifier="@FieldIdentifier.Create(() => _model.SomeSelectValue)" Items="@([SelectItem<string>.Create("One"), SelectItem<string>.Create("Two"), SelectItem<string>.Create("Three"), SelectItem<string>.Create("Four")])"/>
```

### Shell

The Shell provides the top level layout for your app.  It features a Header bar, sidebar for navigation and main content area.

```htmlinblazor
<CarbonBlazorShell ProductName="My Product" ProductIconImagePath="images\my-logo.svg">
    <UserPanel>
        <CarbonBlazorHeaderActionLink NavigationItem="@NavigationItem.Create("Login", "/authentication/login")" />
    </UserPanel>
    <SwitcherPanel>
        <CarbonBlazorHeaderActionLink NavigationItem="@NavigationItem.Create("My Product", "https://localhost:5001")" />
        <CarbonBlazorHeaderActionLink NavigationItem="@NavigationItem.Create("My Other Product", "https://localhost:5002")" />
    </SwitcherPanel>
    <SideNav>
        <CarbonBlazorSidebarLink NavigationItem="@NavigationItem.Create(CarbonBlazorIcon.Dashboard, "Dashboard", "/")" />
        <CarbonBlazorSidebarLink NavigationItem="@NavigationItem.Create(CarbonBlazorIcon.Login, "Login", "/authentication/login")" />
    </SideNav>

    <Body>@Body</Body>
</CarbonBlazorShell>
```

#### SidebarLink

Navigation links for use in the SideNav component of the Shell.

```htmlinblazor
<SideNav>
    <CarbonBlazorSidebarLink NavigationItem="@NavigationItem.Create(CarbonBlazorIcon.Dashboard, "Dashboard", "/")" />
    <CarbonBlazorSidebarLink NavigationItem="@NavigationItem.Create(CarbonBlazorIcon.Login, "Login", "/authentication/login")" />
</SideNav>
```

#### SidebarSubMenu

Grouped set of navigation links for use in the SideNav component of the Shell.

```htmlinblazor
<SideNav>
    <CarbonBlazorSidebarSubMenu Icon="CarbonBlazorIcon.Apps" Text="Resources" SubMenuItems="@_resourcesItems"></CarbonBlazorSidebarSubMenu>
</SideNav>
```
```csharp
@code {
    private readonly List<NavigationItem> _resourcesItems =
    [
        NavigationItem.Create("Tenants", "/tenants"),
        NavigationItem.Create("Products", "/products"),
        NavigationItem.Create("Users", "/users"),
        NavigationItem.Create("Roles", "/roles"),
        NavigationItem.Create("Permissions", "/permissions")
    ];
}
```

### Stack

Provides horizontal or vertical flex layout of content.

```htmlinblazor
<CarbonBlazorStack FlexDirection="FlexDirection.Column" Gap="1rem;">
    <CarbonBlazorText Type="CarbonBlazorTextType.Label01">Label01</CarbonBlazorText>
    <CarbonBlazorText Type="CarbonBlazorTextType.Label02">Label02</CarbonBlazorText>
</CarbonBlazorStack>
```

### StructuredList

Structured lists group content that is similar or related, such as terms and definitions.

```htmlinblazor
<CarbonBlazorStructuredList RowSize="CarbonBlazorStructuredListRowSize.Normal">
    <HeaderCells>
        <CarbonBlazorStructuredListHeaderCell>ColumnA</CarbonBlazorStructuredListHeaderCell>
        <CarbonBlazorStructuredListHeaderCell>ColumnB</CarbonBlazorStructuredListHeaderCell>
        <CarbonBlazorStructuredListHeaderCell>ColumnC</CarbonBlazorStructuredListHeaderCell>
    </HeaderCells>
    <DataRows>
        <CarbonBlazorStructuredListDataRow>
            <CarbonBlazorStructuredListDataCell>Row 1</CarbonBlazorStructuredListDataCell>
            <CarbonBlazorStructuredListDataCell>Row 1</CarbonBlazorStructuredListDataCell>
            <CarbonBlazorStructuredListDataCell>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc dui magna, finibus id tortor sed, aliquet bibendum augue. Aenean posuere sem vel euismod dignissim. Nulla ut cursus dolor. Pellentesque vulputate nisl a porttitor interdum.</CarbonBlazorStructuredListDataCell>
        </CarbonBlazorStructuredListDataRow>
        <CarbonBlazorStructuredListDataRow>
            <CarbonBlazorStructuredListDataCell>Row 2</CarbonBlazorStructuredListDataCell>
            <CarbonBlazorStructuredListDataCell>Row 2</CarbonBlazorStructuredListDataCell>
            <CarbonBlazorStructuredListDataCell>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc dui magna, finibus id tortor sed, aliquet bibendum augue. Aenean posuere sem vel euismod dignissim. Nulla ut cursus dolor. Pellentesque vulputate nisl a porttitor interdum.</CarbonBlazorStructuredListDataCell>
        </CarbonBlazorStructuredListDataRow>
    </DataRows>
</CarbonBlazorStructuredList>
```

### Tag

Use tags to label, categorize, or organize items using keywords that describe them.

```htmlinblazor
<CarbonBlazorTag Type="CarbonBlazorTagType.Operational" Text="Operational" Size="CarbonBlazorInputSize.Large" Icon="CarbonBlazorIcon.Add"></CarbonBlazorTag>
```

### Text

Provides access to pre-styled typography.

```htmlinblazor
<CarbonBlazorText Type="CarbonBlazorTextType.Heading">Heading01</CarbonBlazorText>
```

### TextInput

Text inputs enable users to enter free-form text data. You can use them for long and short-form entries.

```htmlinblazor
<CarbonBlazorTextInput Id="SomeTextInput" Label="Text input label" HelperText="Optional help text" FieldIdentifier="@(FieldIdentifier.Create(() => _model.SomeTextInputValue))" @bind-Value="@_model.SomeTextInputValue"></CarbonBlazorTextInput>
```

#### ValidationMessage

Presents validation outcome messages for related controls.  This is already wired into the standard form inputs, so you should only need it if you are making your own custom form control.

```htmlinblazor
<CarbonBlazorValidationMessage FieldIdentifier="@FieldIdentifier.Create(() => myModel.Name)"></CarbonBlazorValidationMessage>
```