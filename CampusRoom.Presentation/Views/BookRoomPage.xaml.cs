using CampusRoom.Application.Interfaces;
using CampusRoom.Application.Services;
using CampusRoom.Presentation.ViewModels;
using Domain.Models.Entities;

namespace CampusRoom.Presentation.Views;

public partial class BookRoomPage : ContentPage
{
    private readonly BookRoomViewModel _viewModel;
    public BookRoomPage(Room room, IBookingService bookingService)
	{
		InitializeComponent();
        _viewModel = new BookRoomViewModel(room, bookingService);
        BindingContext = _viewModel;
        LoadSlots();
    }
    private async void LoadSlots()
    {
        await _viewModel.LoadSlots();
    }

    private async void OnConfirmClicked(object sender, EventArgs e)
    {
        await _viewModel.ConfirmBookingAsync();
        await DisplayAlert("Bokning", "Bokning bekräftad!", "OK");
        await Shell.Current.GoToAsync("//StudyRoomsPage"); // torna indietro
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//BookRoomPage"); // torna indietro
    }
}