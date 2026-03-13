using CampusRoom.Application.Interfaces;
using CampusRoom.Application.Services;
using CampusRoom.Infrastructure.Data;
using CampusRoom.Infrastructure.Services;
using Domain.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Graphics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.LifecycleEvents;
using CampusRoom.Presentation.Views;
using CampusRoom.Application.Facades;
using CampusRoom.Presentation.ViewModels;



namespace CampusRoom.Presentation
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Configuration.AddUserSecrets<App>();
            var connectionString = builder.Configuration["MongoDB:ConnectionString"];
            var databaseName = builder.Configuration["MongoDb:DatabaseName"];

            builder.Services.AddSingleton(new CampusRoomDbContext(connectionString, databaseName));

            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IRoomRepository, RoomRepository>();
            builder.Services.AddSingleton<IFloorRepository, FloorRepository>();
            builder.Services.AddSingleton<IBookingRepository, BookingRepository>();

            builder.Services.AddSingleton<ILoginFacade, LoginFacade>();
            builder.Services.AddSingleton<IBookingService, BookingService>();
            builder.Services.AddSingleton<IRoomService, RoomService>();

            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddTransient<StudyRoomsViewModel>();

            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<MyBookingPage>();
            builder.Services.AddSingleton<RoomDetailsPage>();
            //builder.Services.AddSingleton<BookRoomPage>();




#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
