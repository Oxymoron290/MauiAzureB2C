namespace MauiAzureB2C.Auth;

public static class PlatformConfig
{
#if WINDOWS
    // MSAL on Windows requires a real HWND (IntPtr)
    public static IntPtr ParentWindowHandle { get; set; }
#else
    // Android: Activity
    // iOS: UIWindow
    public static object? ParentWindow { get; set; }
#endif
}
