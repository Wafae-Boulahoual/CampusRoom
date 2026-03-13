

using CampusRoom.Application.Interfaces;
using CampusRoom.Presentation.Helpers;
using CampusRoom.Presentation.ViewModels;
using Domain.Models.Entities;
using System.Threading.Tasks;


namespace CampusRoom.Presentation.Views;

[QueryProperty(nameof(RoomId), "roomId")]
public partial class RoomDetailsPage : ContentPage
{
    private readonly IRoomService _roomService;
    private readonly IBookingService _bookingService;
    private readonly RoomDetailsViewModel _roomDetailsViewModel;

    public string RoomId { get; set; }
    public RoomDetailsPage(IRoomService roomService, IBookingService bookingService)
	{
		InitializeComponent();
        _roomService = roomService;
        _bookingService = bookingService;
        _roomDetailsViewModel = new RoomDetailsViewModel(roomService, bookingService);
        BindingContext = _roomDetailsViewModel;
        
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var rooms = await _roomService.GetAllRoomsAsync();

        var room = rooms.FirstOrDefault(r => r.Id == RoomId);

        if (room != null)
        {
            await _roomDetailsViewModel.LoadRoom(room);
        }
    }
    
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//StudyRoomsPage");
    }

    private async void OnBookClicked(object sender, EventArgs e)
    {
        var page = new BookRoomPage(_roomDetailsViewModel.Room, _bookingService);
        await Navigation.PushAsync(page);
    }
}