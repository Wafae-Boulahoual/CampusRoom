

using CampusRoom.Application.Interfaces;
using CampusRoom.Presentation.Extension;
using CampusRoom.Presentation.ServiceApi;
using CampusRoom.Presentation.Services;
using CampusRoom.Presentation.ViewModels;
using Domain.Models.Entities;
using System.Threading.Tasks;


namespace CampusRoom.Presentation.Views;

public partial class RoomDetailsPage : ContentPage
{
    private IRoomService _roomService;
    private IBookingService _bookingService;
    private RoomDetailsViewModel _viewModel;

    public RoomDetailsPage(Room selectedRoom, IRoomService roomService, IBookingService bookingService)
    {
        InitializeComponent();

        _roomService = roomService;
        _bookingService = bookingService;

        _viewModel = new RoomDetailsViewModel(roomService, bookingService)
        { 
            Room = selectedRoom
        };

        BindingContext = _viewModel;

        LblRoomNumber.Text = "Rum " + selectedRoom.RoomNumber;
        LblFloor.Text = "Våning " + selectedRoom.FloorNumber;
        LblTv.IsVisible = selectedRoom.HasTv;
        LblSpeaker.IsVisible = selectedRoom.HasSpeaker;

        SlotsCollectionView.ItemsSource = _viewModel.AvailableSlots;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadAvailableSlotsAsync();

    }

    private async void OnBookClicked(object sender, EventArgs e)
    {
        var selectedTimes = SlotsCollectionView.SelectedItems.Cast<string>().ToList();

        if (!selectedTimes.Any())
        {
            await DisplayAlert("Fel", "Välj minst en tid!", "OK");
            return;
        }

        try
        {
            await _bookingService.CreateMultipleBookingsAsync(_viewModel.Room.Id,CurrentUserService.UserId,DateTime.Today,selectedTimes,_viewModel.Room.RoomNumber, _viewModel.Room.FloorNumber);

          
            var quotes = await QuoteDataManager.GetQuotesAsync("v1/quotes?");

            var (quoteText, author) = quotes.GetSafeQuote();

            await DisplayAlert("Bokning bekräftad", $"Din bokning är klar!\n\n\"{quoteText}\"\n- {author}","OK");
           
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fel", ex.Message, "OK");
        }

        SlotsCollectionView.SelectedItems.Clear();
        
        await _viewModel.LoadAvailableSlotsAsync();
        await Navigation.PopAsync();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//StudyRoomsPage");
    }
}
