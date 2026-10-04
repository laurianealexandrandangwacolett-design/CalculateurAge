using System.Windows.Input;

namespace CalculateurAge.ViewModels;

public class CalculateurViewModel : BaseViewModel
{
    private string _nom = string.Empty;
    private DateTime _dateNaissance = DateTime.Today;
    private string _resultat = string.Empty;
    private bool _resultatVisible = false;
    private string _message = string.Empty;          // Majeur / Mineur
    private string _messageErreur = string.Empty;    // Date future

    public string Nom
    {
        get => _nom;
        set
        {
            if (SetProperty(ref _nom, value))
            {
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

    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value);
    }

    public string MessageErreur
    {
        get => _messageErreur;
        set => SetProperty(ref _messageErreur, value);
    }

    public ICommand CalculerCommand { get; }
    public ICommand EffacerCommand { get; }

    public CalculateurViewModel()
    {
        CalculerCommand = new RelayCommand(Calculer, PeutCalculer);
        EffacerCommand = new RelayCommand(Effacer);
    }

    private bool PeutCalculer()
    {
        return !string.IsNullOrWhiteSpace(Nom);
    }

    private async void Calculer()
    {
        // Réinitialiser les messages
        MessageErreur = string.Empty;
        Message = string.Empty;
        ResultatVisible = false;

        // Fonctionnalité 3 : Refus date future
        if (DateNaissance.Date > DateTime.Today)
        {
            MessageErreur = "La date de naissance ne peut pas être dans le futur !";
            return;
        }

        int age = DateTime.Today.Year - DateNaissance.Year;

        if (DateNaissance.Date > DateTime.Today.AddYears(-age))
            age--;

        Resultat = $"{Nom}, vous avez {age} ans.";
        ResultatVisible = true;

        // Fonctionnalité 1 : Majeur / Mineur
        Message = age >= 18 ? "Majeur" : "Mineur";

        // Navigation (tu peux commenter cette ligne si tu veux rester sur la même page)
        await Shell.Current.GoToAsync($"ResultatPage?Nom={Nom}&Age={age}");
    }

    // Fonctionnalité 2 : Effacer
    private void Effacer()
    {
        Nom = string.Empty;
        DateNaissance = DateTime.Today;
        Resultat = string.Empty;
        ResultatVisible = false;
        Message = string.Empty;
        MessageErreur = string.Empty;
    }
}