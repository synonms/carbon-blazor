# CarbonBlazor

CarbonBlazor is a simple, opinionated implementation of the IBM [Carbon Design System](https://carbondesignsystem.com/) for Blazor.

It is designed primarily for use in conjunction with a RESTEasy driven API and provides functionality specifically to simplify that integration.  You should be able to get it to work with any API though.

_Note that this is a work in progress and the components and documentation are incomplete and highly prone to change_

[![NuGet version (Synonms.CarbonBlazor)](https://img.shields.io/nuget/v/Synonms.CarbonBlazor?label=Synonms.CarbonBlazor)](https://www.nuget.org/packages/Synonms.CarbonBlazor/)

## Usage

Carbon Blazor is mostly just Blazor components and some CSS so requires very little setup.

- Install the NuGet package `Synonms.CarbonBlazor`
- Add the global and isolated CSS files to your `wwwroot/index.html` file:

```
<link rel="stylesheet" href="_content/Synonms.CarbonBlazor/css/carbonblazor.css"></link>
<link rel="stylesheet" href="_content/Synonms.CarbonBlazor/Synonms.CarbonBlazor.bundle.scp.css" />
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

## Resources Page

A common pattern in CRUD applications is to present a list of existing items (e.g. in a paginated table) with buttons to view, add, edit and remove items.

The `ResourcesPage<TResource>` base class simplifies this when working with RESTEasy resources.  It wraps a HTTP Client and a collection of resources and provides an easy way to trigger CRUD operations.

For example, the following page and component present full CRUD operations for a collection of `PermissionResource` objects using a DataTable:

#### PermissionPage.razor
```htmlinblazor
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
                    <CarbonBlazorButton Kind="CarbonBlazorButtonKind.Ghost" Size="CarbonBlazorButtonSize.LargeExpressive" Display="CarbonBlazorButtonDisplay.IconOnly" Icon="CarbonBlazorIcon.View" OnClick="@(() => BeginOperation(Mode.Read, context))"></CarbonBlazorButton>
                    <CarbonBlazorButton Kind="CarbonBlazorButtonKind.Ghost" Size="CarbonBlazorButtonSize.LargeExpressive" Display="CarbonBlazorButtonDisplay.IconOnly" Icon="CarbonBlazorIcon.Edit" OnClick="@(() => BeginOperation(Mode.Update, context))"></CarbonBlazorButton>
                    <CarbonBlazorButton Kind="CarbonBlazorButtonKind.Ghost" Size="CarbonBlazorButtonSize.LargeExpressive" Display="CarbonBlazorButtonDisplay.IconOnly" Icon="CarbonBlazorIcon.TrashCan" OnClick="@(() => BeginOperation(Mode.Delete, context))"></CarbonBlazorButton>
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
```
```csharp
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
        CloseAllDialogs();

        string message = mode switch
        {
            Mode.Create => string.Format(CreateSuccessMessageTemplate, "Permission", resource.Id),
            Mode.Update => string.Format(UpdateSuccessMessageTemplate, "Permission", resource.Id),
            Mode.Delete => string.Format(DeleteSuccessMessageTemplate, "Permission", resource.Id),
            _ => string.Empty
        };
        
        _dataTable.Notify("Success", message, CarbonBlazorNotificationStyle.LowContrast, CarbonBlazorNotificationLevel.Success);
        
        // TODO: Avoid having to make network calls to refresh the full data set each time 
        await RefreshResourcesAsync(0);

        if (Resources is not null)
        {
            _dataTable.RefreshData(Resources, Pagination?.Size ?? Resources.Count, _dataTable.Offset, _dataTable.PageLimit);
        }
    }

    protected override Task OnFault(Mode mode, PermissionResource resource, Fault fault)
    {
        string message = mode switch
        {
            Mode.Create => string.Format(CreateFaultMessageTemplate, "Permission", resource.Id, fault),
            Mode.Update => string.Format(UpdateFaultMessageTemplate, "Permission", resource.Id, fault),
            Mode.Delete => string.Format(DeleteFaultMessageTemplate, "Permission", resource.Id, fault),
            _ => string.Empty
        };
        
        _dataTable.Notify("Problem", message, CarbonBlazorNotificationStyle.LowContrast, CarbonBlazorNotificationLevel.Success);

        return Task.CompletedTask;
    }

    private IEnumerable<PermissionResource> FilterModels(IEnumerable<PermissionResource> models, string searchText) =>
        models.Where(x => x.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase));
}
```

#### PermissionForm
```htmlinblazor
<CarbonBlazorForm TModel="PermissionResource" Model="@Permission" ValidationFunc="@Validate" ValidSubmitCallback="@ValidSubmitCallback" CancelCallback="@CancelCallback" EditCallback="@EditCallback" IsReadOnly="@IsReadOnly">
    <CarbonBlazorTextInput Id="PermissionName" Label="Name" HelperText="Recommended format <resource>.<action>[.filter] e.g. 'tenant.read'" @bind-Value="@Permission.Name" FieldIdentifier="@(FieldIdentifier.Create(() => Permission.Name))" IsReadOnly="@IsReadOnly"></CarbonBlazorTextInput>
</CarbonBlazorForm>
```
```csharp
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

    private IEnumerable<ValidationOutcome> Validate(PermissionResource resource)
    {
        List<ValidationOutcome> validationOutcomes = [];
        
        if (string.IsNullOrWhiteSpace(resource.Name))
        {
            FieldIdentifier nameField = FieldIdentifier.Create(() => Permission.Name);
            validationOutcomes.Add(ValidationOutcome.Error(nameField, "Name must be populated"));
        }

        return validationOutcomes;
    }
}
```

If your domain models are simple you can get a suite of fully featured CRUD pages up and running very quickly with some judicious copy and paste action.

A couple of things to note; firstly the validation system supports warnings as well as errors.  Warnings won't prevent the valid submission of a form like errors but they will present to the user (unless an error is present for the same field in which case the error presents instead).
Secondly, the page supports client and server side filtering.  As the name suggests, server side filtering requires a call to the API to get the filtered results while client side filtering expects to have all the resources in memory and filters it locally.  RESTEasy API endpoints page by default so requests to get resources for client side filtering will need to send `&limit=0` query string parameter to force the API to send the maximum set of resources, otherwise the filtering will only happen within the single page of results.

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

If you are not using RESTEasy in your API you will need to provide your own implementation of `ICarbonBlazorHttpClient` (or skip it all together and plumb it yourself with a vanilla `HttpClient`). 


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

### LoadingSpinner

Widget to use while waiting for child content to load, e.g. fetching resources from the server.

```htmlinblazor
<CarbonBlazorLoadingSpinner />
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