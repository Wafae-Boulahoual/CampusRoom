using CampusRoom.Presentation.ViewModels;
using Domain.Models.Entities;

namespace CampusRoom.Presentation.Views;

public partial class MyBookingsPage : ContentPage
{
    private readonly MyBookingsViewModel _viewModel;

    public MyBookingsPage(MyBookingsViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
        LoadBookings();
    }
    private async void LoadBookings()
    {
        await _viewModel.LoadBookings();
    }
    protected override async void OnAppearing() // updaterar sidan
    {
        base.OnAppearing();
        await _viewModel.LoadBookings();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.BindingContext is Booking booking)
        {
            bool confirm = await DisplayAlert("Avboka", "Är du säker på att du vill avboka?", "Ja", "Nej");
            if (confirm == true)
            {
                await _viewModel.CancelBookingAsync(booking);
            }
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//StudyRoomsPage");
    }
}