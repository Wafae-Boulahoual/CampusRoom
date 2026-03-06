using CampusRoom.Application.Interfaces;
using CampusRoom.Application.Services;
using CampusRoom.Infrastructure.Data;
using CampusRoom.Infrastructure.Services;
using Domain.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.LifecycleEvents;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

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

            builder.Services.AddSingleton<ILoginService, LoginService>();
            builder.Services.AddSingleton<IBookingService, BookingService>();
            builder.Services.AddSingleton<IRoomService, RoomService>(); 

            
            



                builder.ConfigureLifecycleEvents(events =>
                {
#if WINDOWS
                    events.AddWindows(windows => windows
                        .OnWindowCreated(window =>
                        {
                            var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                            var id = Win32Interop.GetWindowIdFromWindow(handle);
                            var appWindow = AppWindow.GetFromWindowId(id);
                            
                            appWindow.Resize(new SizeInt32(550, 900)); 
                        }));
#endif
                                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
