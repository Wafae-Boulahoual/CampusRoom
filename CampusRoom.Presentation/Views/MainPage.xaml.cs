using CampusRoom.Application.Interfaces;
using System.Text.RegularExpressions;

namespace CampusRoom.Presentation
{
    public partial class MainPage : ContentPage
    {
        private readonly ILoginService _LoginService;
        public MainPage(ILoginService LoginService)
        {
            InitializeComponent();
            _LoginService = LoginService;
        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            Error.Text = ""; // rensa
            string email = Email.Text;
            string password = Password.Text;

            if(!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Error.Text = "Oglitig e-postadress!";
            }
            else
            {
                Error.Text = "Fel lösenord"
            }
        }
    }
}
