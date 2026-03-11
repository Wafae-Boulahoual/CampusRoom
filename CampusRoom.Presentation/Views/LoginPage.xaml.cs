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
        _loginviewModel.Email = EmailEntry.Text?.Trim();
        _loginviewModel.Password = PasswordEntry.Text; 
        var (success, message) = await _loginviewModel.LoginAsync();

        if (!success)
        {
           
            await DisplayAlert("Logning misslyckades!", message, "OK");
            return;
        }

      
        await Shell.Current.GoToAsync(nameof(StudyRoomsPage));
    }
}