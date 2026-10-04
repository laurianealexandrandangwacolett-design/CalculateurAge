using System.Windows.Input;
namespace CalculateurAge.ViewModels;

public class CalculateurViewModel : BaseViewModel
{
    private string _nom = string.Empty;
    private DateTime _dateNaissance = DateTime.Today;
    private string _resultat = string.Empty;
    private bool _resultatVisible = false;

    public string Nom
    {
        get => _nom;
        set
        {
            if (SetProperty(ref _nom, value))
            {
                // Met à jour l’état du bouton
                ((RelayCommand)CalculerCommand).RaiseCanExecuteChanged();
            }
        }
    }

    public DateTime DateNaissance
    {
        get => _dateNaissance;
        set => SetProperty(ref _dateNaissance, value);
    }

    public string Resultat
    {
        get => _resultat;
        set => SetProperty(ref _resultat, value);
    }

    public bool ResultatVisible
    {
        get => _resultatVisible;
        set => SetProperty(ref _resultatVisible, value);
    }

    public ICommand CalculerCommand { get; }

    public CalculateurViewModel()
    {
        CalculerCommand = new RelayCommand(Calculer, PeutCalculer);
    }

    private bool PeutCalculer()
    {
        return !string.IsNullOrWhiteSpace(Nom);
    }

    private async void Calculer()
    {
        int age = DateTime.Today.Year - DateNaissance.Year;

        if (DateNaissance.Date > DateTime.Today.AddYears(-age))
            age--;

        // Navigation vers ResultatPage
        await Shell.Current.GoToAsync($"ResultatPage?Nom={Nom}&Age={age}");
    }
}