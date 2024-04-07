namespace Synonms.CarbonBlazor.Icons;

public static class IconSvgTags
{
    public static string OpeningTag(int sizeInPixels) =>
        "<svg focusable=\"false\" preserveAspectRatio=\"xMidYMid meet\" fill=\"currentColor\" aria-label=\"Icon\" aria-hidden=\"true\" viewBox=\"0 0 32 32\" width=\"" + sizeInPixels + "px\" height=\"" + sizeInPixels + "px\" role=\"img\" class=\"cb-btn-icon\" xmlns=\"http://www.w3.org/2000/svg\">";

    public const string ClosingTag =
        "</svg>";

    public const string Add = 
        "<title>add</title><polygon points=\"17,15 17,8 15,8 15,15 8,15 8,17 15,17 15,24 17,24 17,17 24,17 24,15 \"/>";

    public const string Apps =
        "<title>apps</title><path d=\"M8,4V8H4V4Zm2-2H2v8h8Zm8,2V8H14V4Zm2-2H12v8h8Zm8,2V8H24V4Zm2-2H22v8h8ZM8,14v4H4V14Zm2-2H2v8h8Zm8,2v4H14V14Zm2-2H12v8h8Zm8,2v4H24V14Zm2-2H22v8h8ZM8,24v4H4V24Zm2-2H2v8h8Zm8,2v4H14V24Zm2-2H12v8h8Zm8,2v4H24V24Zm2-2H22v8h8Z\"/>";

    public const string Building =
        "<title>building</title><path d=\"M28,2H16a2.002,2.002,0,0,0-2,2V14H4a2.002,2.002,0,0,0-2,2V30H30V4A2.0023,2.0023,0,0,0,28,2ZM9,28V21h4v7Zm19,0H15V20a1,1,0,0,0-1-1H8a1,1,0,0,0-1,1v8H4V16H16V4H28Z\"/><rect x=\"18\" y=\"8\" width=\"2\" height=\"2\"/><rect x=\"24\" y=\"8\" width=\"2\" height=\"2\"/><rect x=\"18\" y=\"14\" width=\"2\" height=\"2\"/><rect x=\"24\" y=\"14\" width=\"2\" height=\"2\"/><rect x=\"18\" y=\"19.9996\" width=\"2\" height=\"2\"/><rect x=\"24\" y=\"19.9996\" width=\"2\" height=\"2\"/>";
    
    public const string Cancel =
        "<title>cancel</title><path d=\"M17.4141 16L24 9.4141 22.5859 8 16 14.5859 9.4143 8 8 9.4141 14.5859 16 8 22.5859 9.4143 24 16 17.4141 22.5859 24 24 22.5859 17.4141 16z\"></path>";

    public const string ChevronDown =
        "<title>chevron--down</title><polygon points=\"16,22 6,12 7.4,10.6 16,19.2 24.6,10.6 26,12 \"/>";

    public const string ChevronLeft =
        "<title>chevron--left</title><polygon points=\"10,16 20,6 21.4,7.4 12.8,16 21.4,24.6 20,26 \"/>";

    public const string ChevronRight =
        "<title>chevron--right</title><polygon points=\"22,16 12,26 10.6,24.6 19.2,16 10.6,7.4 12,6 \"/>";

    public const string ChevronUp =
        "<title>chevron--up</title><polygon points=\"16,10 26,20 24.6,21.4 16,12.8 7.4,21.4 6,20 \"/>";

    public const string Dashboard =
        "<title>dashboard</title><rect x=\"24\" y=\"21\" width=\"2\" height=\"5\"/><rect x=\"20\" y=\"16\" width=\"2\" height=\"10\"/><path d=\"M11,26a5.0059,5.0059,0,0,1-5-5H8a3,3,0,1,0,3-3V16a5,5,0,0,1,0,10Z\"/><path d=\"M28,2H4A2.002,2.002,0,0,0,2,4V28a2.0023,2.0023,0,0,0,2,2H28a2.0027,2.0027,0,0,0,2-2V4A2.0023,2.0023,0,0,0,28,2Zm0,9H14V4H28ZM12,4v7H4V4ZM4,28V13H28.0007l.0013,15Z\"/>";

    public const string Database =
        "<title>database</title><path d=\"M16,3c-5.2979,0-11,1.252-11,4V25c0,2.748,5.7021,4,11,4s11-1.252,11-4V7c0-2.748-5.7021-4-11-4Zm0,2c5.7976,0,8.7949,1.4341,8.9968,2-.2019,.5659-3.1992,2-8.9968,2-5.8413,0-8.8394-1.4556-9-1.9824v-.0049c.1606-.5571,3.1587-2.0127,9-2.0127ZM7,9.4277c2.1279,1.0674,5.6426,1.5723,9,1.5723s6.8721-.5049,9-1.5723v3.5596c-.1606,.5571-3.1587,2.0127-9,2.0127-5.8501,0-8.8491-1.46-9-2v-3.5723Zm0,6c2.1279,1.0674,5.6426,1.5723,9,1.5723s6.8721-.5049,9-1.5723v3.5596c-.1606,.5571-3.1587,2.0127-9,2.0127-5.8501,0-8.8491-1.46-9-2v-3.5723Zm9,11.5723c-5.8501,0-8.8491-1.46-9-2v-3.5723c2.1279,1.0674,5.6426,1.5723,9,1.5723s6.8721-.5049,9-1.5723v3.5596c-.1606,.5571-3.1587,2.0127-9,2.0127Z\"/>";
    
    public const string Edit =
        "<title>edit</title><rect x=\"2\" y=\"26\" width=\"28\" height=\"2\"/><path d=\"M25.4,9c0.8-0.8,0.8-2,0-2.8c0,0,0,0,0,0l-3.6-3.6c-0.8-0.8-2-0.8-2.8,0c0,0,0,0,0,0l-15,15V24h6.4L25.4,9z M20.4,4L24,7.6l-3,3L17.4,7L20.4,4z M6,22v-3.6l10-10l3.6,3.6l-10,10H6z\"/>";

    public const string Enterprise =
        "<title>enterprise</title><rect x=\"8\" y=\"8\" width=\"2\" height=\"4\"/><rect x=\"8\" y=\"14\" width=\"2\" height=\"4\"/><rect x=\"14\" y=\"8\" width=\"2\" height=\"4\"/><rect x=\"14\" y=\"14\" width=\"2\" height=\"4\"/><rect x=\"8\" y=\"20\" width=\"2\" height=\"4\"/><rect x=\"14\" y=\"20\" width=\"2\" height=\"4\"/><path d=\"M30,14a2,2,0,0,0-2-2H22V4a2,2,0,0,0-2-2H4A2,2,0,0,0,2,4V30H30ZM4,4H20V28H4ZM22,28V14h6V28Z\"/>";
    
    public const string Group =
        "<title>group</title><path d=\"M31,30H29V27a3,3,0,0,0-3-3H22a3,3,0,0,0-3,3v3H17V27a5,5,0,0,1,5-5h4a5,5,0,0,1,5,5Z\" transform=\"translate(0)\"/><path d=\"M24,12a3,3,0,1,1-3,3,3,3,0,0,1,3-3m0-2a5,5,0,1,0,5,5A5,5,0,0,0,24,10Z\" transform=\"translate(0)\"/><path d=\"M15,22H13V19a3,3,0,0,0-3-3H6a3,3,0,0,0-3,3v3H1V19a5,5,0,0,1,5-5h4a5,5,0,0,1,5,5Z\" transform=\"translate(0)\"/><path d=\"M8,4A3,3,0,1,1,5,7,3,3,0,0,1,8,4M8,2a5,5,0,1,0,5,5A5,5,0,0,0,8,2Z\" transform=\"translate(0)\"/>";

    public const string Gui =
        "<circle cx=\"20\" cy=\"8\" r=\"1\"/><circle cx=\"23\" cy=\"8\" r=\"1\"/><circle cx=\"26\" cy=\"8\" r=\"1\"/><path d=\"M28,4H4A2.0023,2.0023,0,0,0,2,6V26a2.0023,2.0023,0,0,0,2,2H28a2.0023,2.0023,0,0,0,2-2V6A2.0023,2.0023,0,0,0,28,4Zm0,2v4H4V6ZM4,12h6V26H4Zm8,14V12H28V26Z\" transform=\"translate(0 0)\"/>";
    
    public const string Login =
        "<title>login</title><path d=\"M26,30H14a2,2,0,0,1-2-2V25h2v3H26V4H14V7H12V4a2,2,0,0,1,2-2H26a2,2,0,0,1,2,2V28A2,2,0,0,1,26,30Z\"/><polygon points=\"14.59 20.59 18.17 17 4 17 4 15 18.17 15 14.59 11.41 16 10 22 16 16 22 14.59 20.59\"/>";
    
    public const string Menu =
        "<title>menu</title><rect x=\"4\" y=\"6\" width=\"24\" height=\"2\"/><rect x=\"4\" y=\"24\" width=\"24\" height=\"2\"/><rect x=\"4\" y=\"12\" width=\"24\" height=\"2\"/><rect x=\"4\" y=\"18\" width=\"24\" height=\"2\"/>";

    public const string PageFirst =
        "<title>page--first</title><polygon points=\"14,16 24,6 25.4,7.4 16.8,16 25.4,24.6 24,26 \"/><rect x=\"8\" y=\"4\" width=\"2\" height=\"24\"/>";

    public const string PageLast =
        "<title>page--last</title><polygon points=\"18,16 8,26 6.6,24.6 15.2,16 6.6,7.4 8,6 \"/><rect x=\"22\" y=\"4\" width=\"2\" height=\"24\"/>";

    public const string Password =
        "<title>password</title><path d=\"M21,2a8.9977,8.9977,0,0,0-8.6119,11.6118L2,24v6H8L18.3881,19.6118A9,9,0,1,0,21,2Zm0,16a7.0125,7.0125,0,0,1-2.0322-.3022L17.821,17.35l-.8472.8472-3.1811,3.1812L12.4141,20,11,21.4141l1.3787,1.3786-1.5859,1.586L9.4141,23,8,24.4141l1.3787,1.3786L7.1716,28H4V24.8284l9.8023-9.8023.8472-.8474-.3473-1.1467A7,7,0,1,1,21,18Z\"/>\n  <circle cx=\"22\" cy=\"10\" r=\"2\"/>";
    
    public const string Save =
        "<title>save</title><path d=\"M27.71,9.29l-5-5A1,1,0,0,0,22,4H6A2,2,0,0,0,4,6V26a2,2,0,0,0,2,2H26a2,2,0,0,0,2-2V10A1,1,0,0,0,27.71,9.29ZM12,6h8v4H12Zm8,20H12V18h8Zm2,0V18a2,2,0,0,0-2-2H12a2,2,0,0,0-2,2v8H6V6h4v4a2,2,0,0,0,2,2h8a2,2,0,0,0,2-2V6.41l4,4V26Z\"/>";

    public const string Search =
        "<title>search</title><path d=\"M29,27.5859l-7.5521-7.5521a11.0177,11.0177,0,1,0-1.4141,1.4141L27.5859,29ZM4,13a9,9,0,1,1,9,9A9.01,9.01,0,0,1,4,13Z\"></path>";

    public const string Settings =
        "<title>settings</title><path d=\"M27,16.76c0-.25,0-.5,0-.76s0-.51,0-.77l1.92-1.68A2,2,0,0,0,29.3,11L26.94,7a2,2,0,0,0-1.73-1,2,2,0,0,0-.64.1l-2.43.82a11.35,11.35,0,0,0-1.31-.75l-.51-2.52a2,2,0,0,0-2-1.61H13.64a2,2,0,0,0-2,1.61l-.51,2.52a11.48,11.48,0,0,0-1.32.75L7.43,6.06A2,2,0,0,0,6.79,6,2,2,0,0,0,5.06,7L2.7,11a2,2,0,0,0,.41,2.51L5,15.24c0,.25,0,.5,0,.76s0,.51,0,.77L3.11,18.45A2,2,0,0,0,2.7,21L5.06,25a2,2,0,0,0,1.73,1,2,2,0,0,0,.64-.1l2.43-.82a11.35,11.35,0,0,0,1.31.75l.51,2.52a2,2,0,0,0,2,1.61h4.72a2,2,0,0,0,2-1.61l.51-2.52a11.48,11.48,0,0,0,1.32-.75l2.42.82a2,2,0,0,0,.64.1,2,2,0,0,0,1.73-1L29.3,21a2,2,0,0,0-.41-2.51ZM25.21,24l-3.43-1.16a8.86,8.86,0,0,1-2.71,1.57L18.36,28H13.64l-.71-3.55a9.36,9.36,0,0,1-2.7-1.57L6.79,24,4.43,20l2.72-2.4a8.9,8.9,0,0,1,0-3.13L4.43,12,6.79,8l3.43,1.16a8.86,8.86,0,0,1,2.71-1.57L13.64,4h4.72l.71,3.55a9.36,9.36,0,0,1,2.7,1.57L25.21,8,27.57,12l-2.72,2.4a8.9,8.9,0,0,1,0,3.13L27.57,20Z\" transform=\"translate(0 0)\"/><path d=\"M16,22a6,6,0,1,1,6-6A5.94,5.94,0,0,1,16,22Zm0-10a3.91,3.91,0,0,0-4,4,3.91,3.91,0,0,0,4,4,3.91,3.91,0,0,0,4-4A3.91,3.91,0,0,0,16,12Z\" transform=\"translate(0 0)\"/>";

    public const string Subtract = 
        "<title>subtract</title><rect x=\"8\" y=\"15\" width=\"16\" height=\"2\"/>";

    public const string Switcher =
        "<title>switcher</title><rect x=\"14\" y=\"4\" width=\"4\" height=\"4\"/><rect x=\"4\" y=\"4\" width=\"4\" height=\"4\"/><rect x=\"24\" y=\"4\" width=\"4\" height=\"4\"/><rect x=\"14\" y=\"14\" width=\"4\" height=\"4\"/><rect x=\"4\" y=\"14\" width=\"4\" height=\"4\"/><rect x=\"24\" y=\"14\" width=\"4\" height=\"4\"/><rect x=\"14\" y=\"24\" width=\"4\" height=\"4\"/><rect x=\"4\" y=\"24\" width=\"4\" height=\"4\"/><rect x=\"24\" y=\"24\" width=\"4\" height=\"4\"/>";
    
    public const string TrashCan =
        "<title>trash-can</title><path d=\"M12 12H14V24H12zM18 12H20V24H18z\"></path><path d=\"M4 6V8H6V28a2 2 0 002 2H24a2 2 0 002-2V8h2V6zM8 28V8H24V28zM12 2H20V4H12z\"></path>";

    public const string Upgrade =
        "<title>upgrade</title><path d=\"M21,24H11a2,2,0,0,0-2,2v2a2,2,0,0,0,2,2H21a2,2,0,0,0,2-2V26A2,2,0,0,0,21,24Zm0,4H11V26H21Z\"/><path d=\"M28.707,14.293l-12-12a.9994.9994,0,0,0-1.414,0l-12,12A1,1,0,0,0,4,16H9v4a2.0023,2.0023,0,0,0,2,2H21a2.0027,2.0027,0,0,0,2-2V16h5a1,1,0,0,0,.707-1.707ZM21,14v6H11V14H6.4141L16,4.4141,25.5859,14Z\"/>";

    public const string User =
        "<title>user</title><path d=\"M16,4a5,5,0,1,1-5,5,5,5,0,0,1,5-5m0-2a7,7,0,1,0,7,7A7,7,0,0,0,16,2Z\"/><path d=\"M26,30H24V25a5,5,0,0,0-5-5H13a5,5,0,0,0-5,5v5H6V25a7,7,0,0,1,7-7h6a7,7,0,0,1,7,7Z\"/>";

    public const string UserAvatar =
        "<title>user--avatar</title><path d=\"M16,8a5,5,0,1,0,5,5A5,5,0,0,0,16,8Zm0,8a3,3,0,1,1,3-3A3.0034,3.0034,0,0,1,16,16Z\"/><path d=\"M16,2A14,14,0,1,0,30,16,14.0158,14.0158,0,0,0,16,2ZM10,26.3765V25a3.0033,3.0033,0,0,1,3-3h6a3.0033,3.0033,0,0,1,3,3v1.3765a11.8989,11.8989,0,0,1-12,0Zm13.9925-1.4507A5.0016,5.0016,0,0,0,19,20H13a5.0016,5.0016,0,0,0-4.9925,4.9258,12,12,0,1,1,15.985,0Z\"/>";

    public const string UserMultiple =
        "<title>user--multiple</title>\n  <path d=\"M30,30H28V25a5.0057,5.0057,0,0,0-5-5V18a7.0078,7.0078,0,0,1,7,7Z\"/>\n  <path d=\"M22,30H20V25a5.0059,5.0059,0,0,0-5-5H9a5.0059,5.0059,0,0,0-5,5v5H2V25a7.0082,7.0082,0,0,1,7-7h6a7.0082,7.0082,0,0,1,7,7Z\"/>\n  <path d=\"M20,2V4a5,5,0,0,1,0,10v2A7,7,0,0,0,20,2Z\"/>\n  <path d=\"M12,4A5,5,0,1,1,7,9a5,5,0,0,1,5-5m0-2a7,7,0,1,0,7,7A7,7,0,0,0,12,2Z\"/>";

    public const string UserProfile =
        "<title>user--profile</title><path d=\"M12,4A5,5,0,1,1,7,9a5,5,0,0,1,5-5m0-2a7,7,0,1,0,7,7A7,7,0,0,0,12,2Z\"/><path d=\"M22,30H20V25a5,5,0,0,0-5-5H9a5,5,0,0,0-5,5v5H2V25a7,7,0,0,1,7-7h6a7,7,0,0,1,7,7Z\"/><rect x=\"22\" y=\"4\" width=\"10\" height=\"2\"/><rect x=\"22\" y=\"9\" width=\"10\" height=\"2\"/><rect x=\"22\" y=\"14\" width=\"7\" height=\"2\"/>";
    
    public const string UserRole =
        "<title>user--role</title><polygon points=\"28.07 21 22 15 28.07 9 29.5 10.41 24.86 15 29.5 19.59 28.07 21\"/><path d=\"M22,30H20V25a5,5,0,0,0-5-5H9a5,5,0,0,0-5,5v5H2V25a7,7,0,0,1,7-7h6a7,7,0,0,1,7,7Z\"/><path d=\"M12,4A5,5,0,1,1,7,9a5,5,0,0,1,5-5m0-2a7,7,0,1,0,7,7A7,7,0,0,0,12,2Z\"/>";
}