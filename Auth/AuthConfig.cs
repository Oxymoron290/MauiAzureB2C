namespace MauiAzureB2C.Auth;

public static class AuthConfig
{
    // Azure AD B2C settings
    public const string ClientId = "YOUR_CLIENT_ID";

    public const string TenantName = "yourtenant";
    public const string Policy = "B2C_1_signupsignin";

    public static readonly string Authority =
        $"https://{TenantName}.b2clogin.com/{TenantName}.onmicrosoft.com/{Policy}";

    // API scopes
    public static readonly string[] Scopes =
    {
        "https://yourtenant.onmicrosoft.com/api/read"
    };
}
