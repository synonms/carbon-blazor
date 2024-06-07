using Synonms.CarbonBlazor.Icons;

namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorIcon
{
    None,
    Add,
    Apps,
    Building,
    Calendar,
    Cancel,
    Checkmark,
    CheckmarkFilled,
    ChevronDown,
    ChevronLeft,
    ChevronRight,
    ChevronUp,
    ColourPalette,
    Dashboard,
    Database,
    Edit,
    Enterprise,
    ErrorFilled,
    Group,
    Gui,
    InformationFilled,
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
    UserRole,
    View,
    WarningAltFilled,
    WarningFilled
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
            CarbonBlazorIcon.Calendar => IconSvgTags.Calendar,
            CarbonBlazorIcon.Cancel => IconSvgTags.Cancel,
            CarbonBlazorIcon.Checkmark => IconSvgTags.Checkmark,
            CarbonBlazorIcon.CheckmarkFilled => IconSvgTags.CheckmarkFilled,
            CarbonBlazorIcon.ChevronDown => IconSvgTags.ChevronDown,
            CarbonBlazorIcon.ChevronLeft => IconSvgTags.ChevronLeft,
            CarbonBlazorIcon.ChevronRight => IconSvgTags.ChevronRight,
            CarbonBlazorIcon.ChevronUp => IconSvgTags.ChevronUp,
            CarbonBlazorIcon.ColourPalette => IconSvgTags.ColourPalette,
            CarbonBlazorIcon.Dashboard => IconSvgTags.Dashboard,
            CarbonBlazorIcon.Database => IconSvgTags.Database,
            CarbonBlazorIcon.Edit => IconSvgTags.Edit,
            CarbonBlazorIcon.Enterprise => IconSvgTags.Enterprise,
            CarbonBlazorIcon.ErrorFilled => IconSvgTags.ErrorFilled,
            CarbonBlazorIcon.Group => IconSvgTags.Group,
            CarbonBlazorIcon.Gui => IconSvgTags.Gui,
            CarbonBlazorIcon.InformationFilled => IconSvgTags.InformationFilled,
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
            CarbonBlazorIcon.View => IconSvgTags.View,
            CarbonBlazorIcon.WarningAltFilled => IconSvgTags.WarningAltFilled,
            CarbonBlazorIcon.WarningFilled => IconSvgTags.WarningFilled,
            _ => string.Empty
        }
        + IconSvgTags.ClosingTag;
}
