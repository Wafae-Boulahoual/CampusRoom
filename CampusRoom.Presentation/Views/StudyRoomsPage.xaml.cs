using CampusRoom.Presentation.ViewModels;
using Domain.Models.Entities;

namespace CampusRoom.Presentation.Views;

public partial class StudyRoomsPage : ContentPage
{
    private readonly StudyRoomsViewModel _studyRoomsViewModel;
    public StudyRoomsPage(StudyRoomsViewModel studyRoomsViewModel)
	{
		InitializeComponent();
        _studyRoomsViewModel = studyRoomsViewModel;
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
            string filter = FilterPicker.SelectedItem.ToString();

            _studyRoomsViewModel.ApplyFilter(filter);
        }
    }

    private async void OnMyBookingsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(MyBookingPage));
    }

    private async void OnRoomTapped(object sender, EventArgs e)
    {
        Frame frame = (Frame)sender;

        Room room = (Room)frame.BindingContext;
        if (room == null)
        {
            return;
        }

        var roomPage = new RoomDetailsPage();
        roomPage.SetRoom(room);

        await Shell.Current.GoToAsync(nameof(RoomDetailsPage));
    }

    private void OnLogoutClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//LoginPage");
    }
}