using CampusRoom.Application.Interfaces;
using CampusRoom.Application.Services;
using CampusRoom.Presentation.Services;
using CampusRoom.Presentation.ViewModels;
using Domain.Models.Entities;

namespace CampusRoom.Presentation.Views;

public partial class StudyRoomsPage : ContentPage
{
    private readonly StudyRoomsViewModel _studyRoomsViewModel;
    private readonly IRoomService _roomService;
    private readonly IBookingService _bookingService;
    public StudyRoomsPage(StudyRoomsViewModel studyRoomsViewModel, IRoomService roomService, IBookingService bookingService)
    {
        InitializeComponent();
        _studyRoomsViewModel = studyRoomsViewModel;
        _roomService = roomService; 
        _bookingService = bookingService; 
        BindingContext = _studyRoomsViewModel;
    }

    protected override async void OnAppearing()//updatera listan varje gång
    {
        base.OnAppearing();
        if (BindingContext is StudyRoomsViewModel studyRoomsViewModel) //utan if NullReferenceException
        {
            await _studyRoomsViewModel.LoadRooms();
        }

    }
  
    private void OnFilterChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender; // cast 
        if (picker.SelectedItem != null)
        {
            _studyRoomsViewModel.ApplyFilter(picker.SelectedItem.ToString());
        }
    }

    private async void OnMyBookingsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MyBookingsPage");
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        CurrentUserService.UserId = null;
        CurrentUserService.UserName = null;

        await Shell.Current.GoToAsync("//LoginPage"); // shell för att nållsätta navigation
    }

    private async void OnRoomSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedRoom = e.SelectedItem as Room;
        if (selectedRoom == null) return;

        ((ListView)sender).SelectedItem = null;

        var detailsPage = new RoomDetailsPage(selectedRoom, _roomService, _bookingService);

        await Navigation.PushAsync(detailsPage); // bakåtknapp som kommer ihåg var vi var tidigare
    }
}
       