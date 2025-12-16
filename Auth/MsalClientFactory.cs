using Microsoft.Identity.Client;

namespace MauiAzureB2C.Auth;

public static class MsalClientFactory
{
    private static IPublicClientApplication? _pca;

    public static IPublicClientApplication Get()
    {
        if (_pca != null)
            return _pca;

        var builder = PublicClientApplicationBuilder
            .Create(AuthConfig.ClientId)
            .WithB2CAuthority(AuthConfig.Authority);

#if WINDOWS
        builder = builder.WithRedirectUri("http://localhost");
#else
        builder = builder.WithRedirectUri($"msal{AuthConfig.ClientId}://auth");
#endif

        _pca = builder.Build();
        return _pca;
    }
}
