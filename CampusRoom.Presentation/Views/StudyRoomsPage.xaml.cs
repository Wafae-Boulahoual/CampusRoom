using CampusRoom.Application.Interfaces;
using CampusRoom.Application.Services;
using CampusRoom.Presentation.ViewModels;
using Domain.Models.Entities;

namespace CampusRoom.Presentation.Views;

public partial class StudyRoomsPage : ContentPage
{
    private readonly StudyRoomsViewModel _studyRoomsViewModel;
    private readonly IBookingService _bookingService;
    private readonly IRoomService _roomService;
    public StudyRoomsPage(StudyRoomsViewModel studyRoomsViewModel, IRoomService roomService, IBookingService bookingService)
	{
		InitializeComponent();
        _studyRoomsViewModel = studyRoomsViewModel;
        _roomService = roomService;
        _bookingService = bookingService;
        BindingContext = _studyRoomsViewModel;
        LoadRooms();
    }
    private async void LoadRooms()
    {
        await _studyRoomsViewModel.LoadRooms();
    }

    private void OnFilterChanged(object sender, EventArgs e)
    {
        if (FilterPicker.SelectedItem != null)
        {
            _studyRoomsViewModel.ApplyFilter(FilterPicker.SelectedItem.ToString());
        }
    }

    private async void OnMyBookingsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(MyBookingPage));
    }


    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginPage");
       // await Navigation.PopToRootAsync();
    }

    private async void OnRoomSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedRoom = (Room)e.SelectedItem;

        await Shell.Current.GoToAsync($"{nameof(RoomDetailsPage)}?roomId={selectedRoom.Id}");

        ((ListView)sender).SelectedItem = null;
    }
}