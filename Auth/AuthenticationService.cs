using Microsoft.Identity.Client;

namespace MauiAzureB2C.Auth;

public sealed class AuthenticationService
{
    private readonly IPublicClientApplication _pca;

    public AuthenticationService()
    {
        _pca = MsalClientFactory.Get();
    }

    public async Task<AuthenticationResult> AcquireTokenAsync()
    {
        var accounts = await _pca.GetAccountsAsync();
        var account = accounts.FirstOrDefault();

        try
        {
            // Attempt silent auth first
            return await _pca
                .AcquireTokenSilent(AuthConfig.Scopes, account)
                .ExecuteAsync();
        }
        catch (MsalUiRequiredException)
        {
            // Interactive fallback
#if WINDOWS
            return await _pca
                .AcquireTokenInteractive(AuthConfig.Scopes)
                .WithUseEmbeddedWebView(true)
                .WithParentActivityOrWindow(
                    PlatformConfig.ParentWindowHandle)
                .ExecuteAsync();
#else
            return await _pca
                .AcquireTokenInteractive(AuthConfig.Scopes)
                .WithParentActivityOrWindow(
                    PlatformConfig.ParentWindow)
                .ExecuteAsync();
#endif
        }
    }
}
