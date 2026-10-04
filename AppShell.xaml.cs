namespace CalculateurAge;

public partial class AppShell : Shell
{
	public AppShell()
{
    InitializeComponent();

    // Ajoute cette ligne juste après InitializeComponent()
    Routing.RegisterRoute(nameof(ResultatPage), typeof(ResultatPage));
}
}
