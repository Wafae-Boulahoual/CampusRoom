using CampusRoom.Presentation.Views;

namespace CampusRoom.Presentation
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(StudyRoomsPage), typeof(StudyRoomsPage));
            Routing.RegisterRoute(nameof(RoomDetailsPage), typeof(RoomDetailsPage));
            Routing.RegisterRoute(nameof(MyBookingPage), typeof(MyBookingPage));

            Routing.RegisterRoute(nameof(BookRoomPage), typeof(BookRoomPage));
        }
    }
}
