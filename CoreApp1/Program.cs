using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



string? mykey = builder.Configuration.GetValue<string>("MyCustomeKey", "DefaultValue");

string? myvalue = builder.Configuration["MyCustomeKey"];

app.MapGet("/", () =>
$"Hello World!  {mykey}  {myvalue}" + " " +
System.Diagnostics.Process.GetCurrentProcess().ProcessName) ;



app.Run();
