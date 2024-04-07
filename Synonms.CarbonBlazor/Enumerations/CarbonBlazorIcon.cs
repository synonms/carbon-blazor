using Synonms.CarbonBlazor.Icons;

namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorIcon
{
    None,
    Add,
    Apps,
    Building,
    Cancel,
    ChevronDown,
    ChevronLeft,
    ChevronRight,
    ChevronUp,
    Dashboard,
    Database,
    Edit,
    Enterprise,
    Group,
    Gui,
    Login,
    Menu,
    Password,
    PageFirst,
    PageLast,
    Save,
    Search,
    Settings,
    Subtract,
    Switcher,
    TrashCan,
    Upgrade,
    User,
    UserAvatar,
    UserMultiple,
    UserProfile,
    UserRole
}

public static class CarbonBlazorIconMapper
{
    public static string ToSvg(CarbonBlazorIcon icon, int sizeInPixels = 16) => 
        IconSvgTags.OpeningTag(sizeInPixels) 
        + icon switch
        {
            CarbonBlazorIcon.Add => IconSvgTags.Add,
            CarbonBlazorIcon.Apps => IconSvgTags.Apps,
            CarbonBlazorIcon.Building => IconSvgTags.Building,
            CarbonBlazorIcon.Cancel => IconSvgTags.Cancel,
            CarbonBlazorIcon.ChevronDown => IconSvgTags.ChevronDown,
            CarbonBlazorIcon.ChevronLeft => IconSvgTags.ChevronLeft,
            CarbonBlazorIcon.ChevronRight => IconSvgTags.ChevronRight,
            CarbonBlazorIcon.ChevronUp => IconSvgTags.ChevronUp,
            CarbonBlazorIcon.Dashboard => IconSvgTags.Dashboard,
            CarbonBlazorIcon.Database => IconSvgTags.Database,
            CarbonBlazorIcon.Edit => IconSvgTags.Edit,
            CarbonBlazorIcon.Enterprise => IconSvgTags.Enterprise,
            CarbonBlazorIcon.Group => IconSvgTags.Group,
            CarbonBlazorIcon.Gui => IconSvgTags.Gui,
            CarbonBlazorIcon.Login => IconSvgTags.Login,
            CarbonBlazorIcon.Menu => IconSvgTags.Menu,
            CarbonBlazorIcon.Password => IconSvgTags.Password,
            CarbonBlazorIcon.PageFirst => IconSvgTags.PageFirst,
            CarbonBlazorIcon.PageLast => IconSvgTags.PageLast,
            CarbonBlazorIcon.Save => IconSvgTags.Save,
            CarbonBlazorIcon.Search => IconSvgTags.Search,
            CarbonBlazorIcon.Settings => IconSvgTags.Settings,
            CarbonBlazorIcon.Subtract => IconSvgTags.Subtract,
            CarbonBlazorIcon.Switcher => IconSvgTags.Switcher,
            CarbonBlazorIcon.TrashCan => IconSvgTags.TrashCan,
            CarbonBlazorIcon.Upgrade => IconSvgTags.Upgrade,
            CarbonBlazorIcon.User => IconSvgTags.User,
            CarbonBlazorIcon.UserAvatar => IconSvgTags.UserAvatar,
            CarbonBlazorIcon.UserMultiple => IconSvgTags.UserMultiple,
            CarbonBlazorIcon.UserProfile => IconSvgTags.UserProfile,
            CarbonBlazorIcon.UserRole => IconSvgTags.UserRole,
            _ => string.Empty
        }
        + IconSvgTags.ClosingTag;
}
