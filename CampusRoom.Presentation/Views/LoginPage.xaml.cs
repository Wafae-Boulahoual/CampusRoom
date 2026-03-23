using CampusRoom.Presentation.Services;
using CampusRoom.Presentation.ViewModels;

namespace CampusRoom.Presentation.Views;

public partial class LoginPage : ContentPage
{
    private readonly LoginViewModel _loginviewModel;
    public LoginPage(LoginViewModel loginviewModel)
	{
        InitializeComponent();
        _loginviewModel = loginviewModel;
        BindingContext = _loginviewModel;
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        var errorMessage = await _loginviewModel.LoginAndSaveUserAsync(email, password);

        if (errorMessage == null)
        {
            await Shell.Current.GoToAsync("StudyRoomsPage");
        }
        else
        {
            await DisplayAlert("Logning misslyckades", errorMessage, "OK");
        }
    }
}

    
