using Car_Rental.Business.Classes;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Classes;
using Car_Rental.Data.Interfaces;
using Car_Rental_G;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<BookingProcessor>();
builder.Services.AddSingleton<IData, CollectionData>();
builder.Services.AddSingleton<IVehicle, Vehicle>();
builder.Services.AddSingleton<IPerson, Customer>();
builder.Services.AddSingleton<IBooking, Booking>(); 


await builder.Build().RunAsync();
