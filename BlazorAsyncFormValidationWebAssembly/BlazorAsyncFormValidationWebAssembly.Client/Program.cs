using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorAsyncFormValidationWebAssembly.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSingleton<IBookingAvailabilityService, MockBookingAvailabilityService>();

await builder.Build().RunAsync();
