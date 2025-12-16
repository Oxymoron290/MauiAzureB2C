namespace MauiAzureB2C.Auth;

public static class AuthConfig
{
    // Azure AD B2C settings
    public const string ClientId = "fe611aaf-fb05-4f15-953f-5066e1b1ca78";

    public const string TenantName = "sturmhouse";
    public const string Policy = "B2C_1_susi";

    public static readonly string Authority =
        $"https://{TenantName}.b2clogin.com/tfp/{TenantName}.onmicrosoft.com/{Policy}";

    // API scopes
    public static readonly string[] Scopes = Array.Empty<string>();
    // public static readonly string[] Scopes =
    // {
    //     "https://yourtenant.onmicrosoft.com/api/read"
    // };
}
