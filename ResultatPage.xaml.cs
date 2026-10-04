namespace CalculateurAge;

[QueryProperty(nameof(Nom), "Nom")]
[QueryProperty(nameof(Age), "Age")]
public partial class ResultatPage : ContentPage
{
    public string Nom { get; set; } = string.Empty;
    public string Age { get; set; } = string.Empty;

    public ResultatPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        labelMessage.Text = $"{Nom}, vous avez {Age} ans.";
    }

    private async void OnRetourClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}