   namespace CalculateurAge;

   public partial class AppShell : Shell
   {
      public AppShell()
{
    InitializeComponent();

    // Ajoute cette ligne :
    Routing.RegisterRoute(nameof(ResultatPage), typeof(ResultatPage));
}
   }