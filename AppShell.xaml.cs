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

            LoadAuthenticatedShell();

            // Auth succeeded
            // At this point you would typically navigate:
            // await GoToAsync("//home");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(
                $"Authentication failed: {ex}");
            await DisplayAlertAsync(
                "Authentication failed",
                ex.Message,
                "Close");
            Application.Current?.Quit();
        }
    }

    private void LoadAuthenticatedShell()
    {
        // Remove loading content
        Items.Clear();

        // Register routes
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

        // Build authenticated shell UI
        Items.Add(new ShellContent
        {
            Title = "Home",
            ContentTemplate = new DataTemplate(typeof(MainPage))
        });
    }
}
