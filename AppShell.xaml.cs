using MauiAzureB2C.Auth;

namespace MauiAzureB2C;

public partial class AppShell : Shell
{
    private bool _authStarted;

	public AppShell()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Guard: Shell.OnAppearing can fire more than once
        if (_authStarted)
            return;

        _authStarted = true;

        try
        {
            var authService = new AuthenticationService();
            await authService.AcquireTokenAsync();

            // Auth succeeded
            // At this point you would typically navigate:
            // await GoToAsync("//home");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(
                $"Authentication failed: {ex}");
        }
    }
}
