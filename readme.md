# CarbonBlazor

CarbonBlazor is a simple, opinionated implementation of the IBM [Carbon Design System](https://carbondesignsystem.com/) for Blazor.

It is designed primarily for use in conjunction with a RESTEasy driven API and provides functionality specifically to simplify that integration.  You should be able to get it to work with any API though.

_Note that this is a work in progress and the components and documentation are incomplete and highly prone to change_

## Usage

Carbon Blazor is mostly just Blazor components and some CSS so requires very little setup.

- Install the NuGet package `Synonms.CarbonBlazor`
- Add the stylesheet to your `wwwroot/index.html` file:

`<link rel="stylesheet" href="_content/Synonms.CarbonBlazor/css/carbonblazor-white.css"></link>`
- Edit `_Imports.razor` to add the namespaces:
```
@using Synonms.CarbonBlazor.Components
@using Synonms.CarbonBlazor.Enumerations
@using Synonms.CarbonBlazor.Models
```
- Edit `MainLayout.razor` to use the CarbonBlazor shell:
```htmlinblazor
@inherits LayoutComponentBase

<CarbonBlazorShell ProductName="My Product" ProductIconImagePath="images\my-logo.svg">
    <UserPanel>
        <UserProfile />
    </UserPanel>
    <SwitcherPanel>
        <CarbonBlazorNavItem Text="My Product" Href="https://localhost:5000" />
        <CarbonBlazorNavItem Text="My Other Product" Href="https://localhost:6000" />
    </SwitcherPanel>
    <SideNav>
        <CarbonBlazorNavItem Text="Dashboard" Href="/" />

        <CarbonBlazorNavDivider Text="Admin" />
        <CarbonBlazorNavItem Text="Widgets" Href="/widgets" />
        <CarbonBlazorNavItem Text="Bobbins" Href="/bobbins" />
    </SideNav>
    
    <Body>@Body</Body>
</CarbonBlazorShell>
```

## Resources Page

A common pattern in CRUD applications is to present a list of existing items (e.g. in a paginated table) with buttons to view, add, edit and remove items.

The `ResourcesPage<TResource>` base class simplifies this when working with RESTEasy resources.  It wraps a HTTP Client and a collection of resources and provides an easy way to trigger CRUD operations.

For example, the following page and component present full CRUD operations for a collection of `PermissionResource` objects, including client side filtering:

#### PermissionPage.razor
```csharp
@page "/permissions"
@using Synonms.Functional
@inherits Synonms.CarbonBlazor.Pages.ResourcesPage<PermissionResource>
@attribute [Authorize]

@if (Resources is null)
{
    <CarbonBlazorLoadingSpinner/>
}
else
{
    <CarbonBlazorDataTable @ref="@_dataTable" TModel="PermissionResource" Title="Permissions" Models="@Resources" TotalSize="@Resources.Count" Offset="0" PageLimit="20" 
                           PaginationMode="CarbonBlazorPaginationMode.Client" FilterModelsFunc="@FilterModels">
        <ToolbarButtons>
            <CarbonBlazorButton Display="CarbonBlazorButtonDisplay.TextAndIcon" Icon="CarbonBlazorIcon.Add" Text="Add Permission" OnClick="@(() => BeginOperation(Mode.Create, new PermissionResource()))"></CarbonBlazorButton>
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
                    <CarbonBlazorButton Kind="CarbonBlazorButtonKind.Input" Display="CarbonBlazorButtonDisplay.IconOnly" Icon="CarbonBlazorIcon.View" OnClick="@(() => BeginOperation(Mode.Read, context))"></CarbonBlazorButton>
                    <CarbonBlazorButton Kind="CarbonBlazorButtonKind.Input" Display="CarbonBlazorButtonDisplay.IconOnly" Icon="CarbonBlazorIcon.Edit" OnClick="@(() => BeginOperation(Mode.Update, context))"></CarbonBlazorButton>
                    <CarbonBlazorButton Kind="CarbonBlazorButtonKind.Input" Display="CarbonBlazorButtonDisplay.IconOnly" Icon="CarbonBlazorIcon.TrashCan" OnClick="@(() => BeginOperation(Mode.Delete, context))"></CarbonBlazorButton>
                </CarbonBlazorButtonSet>
            </CarbonBlazorDataTableDataCell>
        </DataRowTemplate>
    </CarbonBlazorDataTable>
    
    <CarbonBlazorModal @ref="@_createModal" Label="Permissions" Title="Add a permission" Size="CarbonBlazorModalSize.Large">
        <PermissionForm Permission="@ActiveResource" CancelCallback="@CancelOperation" ValidSubmitCallback="@(_ => ConfirmOperation())"></PermissionForm>
    </CarbonBlazorModal>

    <CarbonBlazorModal @ref="@_readModal" Label="Permissions" Title="View a permission" Size="CarbonBlazorModalSize.Large">
        <PermissionForm Permission="@ActiveResource" CancelCallback="@CancelOperation" EditCallback="@(() => BeginOperation(Mode.Update, ActiveResource))" IsReadOnly="true"></PermissionForm>
    </CarbonBlazorModal>

    <CarbonBlazorModal @ref="@_updateModal" Label="Permissions" Title="Edit a permission" Size="CarbonBlazorModalSize.Large">
        <PermissionForm Permission="@ActiveResource" CancelCallback="@CancelOperation" ValidSubmitCallback="@(_ => ConfirmOperation())"></PermissionForm>
    </CarbonBlazorModal>
    
    <CarbonBlazorConfirmDeleteModal @ref="@_deleteModal" Resource="@ActiveResource" Label="Permissions" Title="Remove a permission" CancelDeleteCallback="@CancelOperation" ConfirmDeleteCallback="@ConfirmOperation"></CarbonBlazorConfirmDeleteModal>
}

@code
{
    private CarbonBlazorDataTable<PermissionResource> _dataTable = null!;
    private CarbonBlazorModal _createModal = null!;
    private CarbonBlazorModal _readModal = null!;
    private CarbonBlazorModal _updateModal = null!;
    private CarbonBlazorConfirmDeleteModal<PermissionResource> _deleteModal = null!;
    
    public PermissionsPage() : base("Permissions", "permissions")
    {
    }

    private void CloseAllDialogs()
    {
        _createModal.Hide();
        _readModal.Hide();
        _updateModal.Hide();
        _deleteModal.Hide();
    }
    
    protected override void OnBeginCreate()
    {
        _createModal.Show();
    }

    protected override void OnBeginRead()
    {
        _readModal.Show();
    }

    protected override void OnBeginUpdate()
    {
        _updateModal.Show();
    }

    protected override void OnBeginDelete()
    {
        _deleteModal.Show();
    }

    protected override Task OnCancel(Mode mode, PermissionResource? resource)
    {
        CloseAllDialogs();
        
        return Task.CompletedTask;
    }
    
    protected override async Task OnSuccess(Mode mode, PermissionResource resource)
    {
        // TODO - Notification
        
        CloseAllDialogs();

        await RefreshResourcesAsync(0);

        if (Resources is not null)
        {
            _dataTable.RefreshData(Resources, Pagination?.Size ?? Resources.Count, _dataTable.Offset, _dataTable.PageLimit);
        }
    }

    protected override Task OnFault(Mode mode, PermissionResource resource, Fault fault)
    {
        // TODO: Notification
        
        return Task.CompletedTask;
    }

    private IEnumerable<PermissionResource> FilterModels(IEnumerable<PermissionResource> models, string searchText) =>
        models.Where(x => x.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase));
}
```

#### PermissionForm
```csharp
<CarbonBlazorForm TModel="PermissionResource" Model="@Permission" ValidateAction="@Validate" ValidSubmitCallback="@ValidSubmitCallback" CancelCallback="@CancelCallback" EditCallback="@EditCallback" IsReadOnly="@IsReadOnly">
    <CarbonBlazorTextInput Id="PermissionName" Label="Name" HelperText="Recommended format <resource>.<action>[.filter] e.g. 'tenant.read'" @bind-Value="@Permission.Name" ValidationFor="@(() => Permission.Name)" IsReadOnly="@IsReadOnly"></CarbonBlazorTextInput>
</CarbonBlazorForm>

@code {
    [Parameter] 
    [EditorRequired] 
    public PermissionResource Permission { get; set; } = default!;

    [Parameter]
    public EventCallback<PermissionResource> ValidSubmitCallback { get; set; } = EventCallback<PermissionResource>.Empty;

    [Parameter] 
    public EventCallback CancelCallback { get; set; } = EventCallback.Empty;

    [Parameter] 
    public EventCallback EditCallback { get; set; } = EventCallback.Empty;

    [Parameter]
    public bool IsReadOnly { get; set; } = false;

    private void Validate(ValidationMessageStore validationMessageStore, PermissionResource resource)
    {
        if (string.IsNullOrWhiteSpace(resource.Name))
        {
            FieldIdentifier nameField = new(resource, nameof(resource.Name));
            validationMessageStore.Add(nameField, "Name must be populated");
        }
    }
}
```

If your domain models are simple you can get a suite of fully featured CRUD pages up and running very quickly with some judicious copy and paste action.


## HTTP Client

CarbonBlazor provides the `ICarbonBlazorHttpClient` interface with methods to interact with all the CRUD endpoints RESTEasy provides.  Two implementations are provided out of the box (`DefaultCarbonBlazorHttpClient` and `IonCarbonBlazorHttpClient`) which wrap a HttpClient and have the relevant serialisation plumbing in place.

Wire this into your Blazor app in `Program.cs`:

```csharp
builder.Services
    .AddHttpClient<ICarbonBlazorHttpClient, DefaultCarbonBlazorHttpClient>("MyRestEasyWebApi", client =>
    {
        client.BaseAddress = new Uri("https://localhost:5001");                                         // The address of your API
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypes.Json));  // Add the appropriate Accept header in requests to the API
        client.DefaultRequestHeaders.Add("X-MyFavouriteBiscuit", "Hob Nob");                            // Add any other default headers your API may need
    });

builder.Services.AddTransient(serviceProvider => serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient("MyRestEasyWebApi")); 
```

You can then inject the interface into your pages and use it to call the API as required:

```csharp
@code {
    [Inject] 
    public ICarbonBlazorHttpClient HttpClient { get; set; } = null!;
    
    private async Task GetStuffFromTheApi()
    {
        Result<ResourceCollectionDocument<MyResource>> response = await HttpClient.GetAllAsync<MyResource>("my-resources", CancellationToken.None);

        response.Match(
            resourceCollectionDocument =>
            {
                // Access the Resources and Pagination from the document
            },
            fault =>
            {
                // Something went wonky - display errors for client
            });    
    }
}
```

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

//TODO

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

Checkboxes are used when there are multiple items to select in a list. Users can select zero, one, or any number of items.

```htmlinblazor
<CarbonBlazorCheckBox Id="SomeCheckBox" Label="Checkbox label" @bind-Value="@_model.SomeBoolInputValue" ValidationFor="@(() => _model.SomeBoolInputValue)"></CarbonBlazorCheckBox>
```

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
        <CarbonBlazorButton Display="CarbonBlazorButtonDisplay.TextAndIcon" Icon="CarbonBlazorIcon.Add" Text="Add Permission" OnClick="@(() => BeginOperation(Mode.Create, new PermissionResource()))"></CarbonBlazorButton>
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
                <CarbonBlazorButton Kind="CarbonBlazorButtonKind.Input" Display="CarbonBlazorButtonDisplay.IconOnly" Icon="CarbonBlazorIcon.View" OnClick="@(() => BeginOperation(Mode.Read, context))"></CarbonBlazorButton>
                <CarbonBlazorButton Kind="CarbonBlazorButtonKind.Input" Display="CarbonBlazorButtonDisplay.IconOnly" Icon="CarbonBlazorIcon.Edit" OnClick="@(() => BeginOperation(Mode.Update, context))"></CarbonBlazorButton>
                <CarbonBlazorButton Kind="CarbonBlazorButtonKind.Input" Display="CarbonBlazorButtonDisplay.IconOnly" Icon="CarbonBlazorIcon.TrashCan" OnClick="@(() => BeginOperation(Mode.Delete, context))"></CarbonBlazorButton>
            </CarbonBlazorButtonSet>
        </CarbonBlazorDataTableDataCell>
    </DataRowTemplate>
</CarbonBlazorDataTable>
```

### DropDown

Dropdowns present a list of options from which a user can select one option, or several. A selected option can represent a value in a form, or can be used as an action to filter or sort existing content.

```htmlinblazor
<CarbonBlazorDropDown TValue="string" Id="SomeDropDown" Label="Dropdown label" @bind-Value="@_model.SomeDropDownValue" ValidationFor="@(() => _model.SomeDropDownValue)" FromString="@(x => x)" Options="@_dropDownOptions" />
```

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

### Modal

Modals focus the user’s attention exclusively on one task or piece of information via a window that sits on top of the page content.

```htmlinblazor
<CarbonBlazorModal @ref="@_createModal" Label="Permissions" Title="Add a permission" Size="CarbonBlazorModalSize.Large">
    <CarbonBlazorText Type="CarbonBlazorTextType.Body01">You are about to delete resource Id @(Resource.Id) - are you sure you want to continue?</CarbonBlazorText>
    <CarbonBlazorButtonSet>
        <CarbonBlazorButton Type="CarbonBlazorButtonType.Button" Kind="CarbonBlazorButtonKind.Secondary" Display="CarbonBlazorButtonDisplay.TextOnly" Text="Cancel" Size="CarbonBlazorButtonSize.ExtraLarge" Style="width:50%;" OnClick="@CancelDeleteCallback"></CarbonBlazorButton>
        <CarbonBlazorButton Type="CarbonBlazorButtonType.Button" Kind="CarbonBlazorButtonKind.Danger" Display="CarbonBlazorButtonDisplay.TextOnly" Text="Delete" Size="CarbonBlazorButtonSize.ExtraLarge" Style="width:50%;" OnClick="@ConfirmDeleteCallback"></CarbonBlazorButton>
    </CarbonBlazorButtonSet>
</CarbonBlazorModal>
```

### NavDivider

Breaks navigation link lists with a small heading.

```htmlinblazor
<SideNav>
    <CarbonBlazorNavItem Text="Dashboard" Href="/" />

    <CarbonBlazorNavDivider Text="Admin" />
    <CarbonBlazorNavItem Text="Tenants" Href="/tenants" />
    <CarbonBlazorNavItem Text="Products" Href="/products" />
</SideNav>
```

### NavItem

Navigation links intended for use in the SideNav or Header menu panels.

```htmlinblazor
<SideNav>
    <CarbonBlazorNavItem Text="Dashboard" Href="/" />

    <CarbonBlazorNavDivider Text="Admin" />
    <CarbonBlazorNavItem Text="Tenants" Href="/tenants" />
    <CarbonBlazorNavItem Text="Products" Href="/products" />
</SideNav>
```

### NumberInput

Number input lets users enter a numeric value and incrementally increase or decrease the value with a two-segment control.

```htmlinblazor
<CarbonBlazorNumberInput Id="SomeNumberInput" Label="Number input label" @bind-Value="@_model.SomeIntInputValue" ValidationFor="@(() => _model.SomeIntInputValue)" Min="0" Max="100" Step="5"></CarbonBlazorNumberInput>
```

### Pane

Provides a framed container for related content with optional Title and Info headings.

```htmlinblazor
<CarbonBlazorPane Title="Typography">
    <CarbonBlazorText Type="CarbonBlazorTextType.Heading01">Heading01</CarbonBlazorText>
    <CarbonBlazorText Type="CarbonBlazorTextType.Body01">Body01</CarbonBlazorText>
    <CarbonBlazorText Type="CarbonBlazorTextType.Label01">Label01</CarbonBlazorText>
</CarbonBlazorPane>
```

### Search

Search enables users to specify a word or a phrase to find relevant content without navigation.

```htmlinblazor
<CarbonBlazorSearch SearchTextChangedCallback="@OnSearchTextChanged"></CarbonBlazorSearch>
```

### Shell

The Shell provides the top level layout for your app.  It features a Header bar, side bar for navigation and main content area.

```htmlinblazor
<CarbonBlazorShell ProductName="My Product" ProductIconImagePath="images\my-logo.svg">
    <UserPanel>
        <UserProfile />
    </UserPanel>
    <SwitcherPanel>
        <CarbonBlazorNavItem Text="My Product" Href="https://localhost:5000" />
        <CarbonBlazorNavItem Text="My Other Product" Href="https://localhost:6000" />
    </SwitcherPanel>
    <SideNav>
        <CarbonBlazorNavItem Text="Dashboard" Href="/" />

        <CarbonBlazorNavDivider Text="Admin" />
        <CarbonBlazorNavItem Text="Widgets" Href="/widgets" />
        <CarbonBlazorNavItem Text="Bobbins" Href="/bobbins" />
    </SideNav>
    
    <Body>@Body</Body>
</CarbonBlazorShell>
```

### Stack

Provides horizontal or vertical flex layout of content.

```htmlinblazor
<CarbonBlazorStack FlexDirection="FlexDirection.Column" Gap="1rem;">
    <CarbonBlazorText Type="CarbonBlazorTextType.Label01">Label01</CarbonBlazorText>
    <CarbonBlazorText Type="CarbonBlazorTextType.Label02">Label02</CarbonBlazorText>
</CarbonBlazorStack>
```

### Text

Provides access to pre-styled typography.

```htmlinblazor
<CarbonBlazorText Type="CarbonBlazorTextType.Heading01">Heading01</CarbonBlazorText>
```

### TextInput

Text inputs enable users to enter free-form text data. You can use them for long and short-form entries.

```htmlinblazor
<CarbonBlazorTextInput Id="SomeTextInput" Label="Text input label" HelperText="Optional help text" @bind-Value="@_model.SomeTextInputValue" ValidationFor="@(() => _model.SomeTextInputValue)"></CarbonBlazorTextInput>
```
