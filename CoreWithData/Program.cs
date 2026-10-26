
//step1 create first the Instance of WebApplicationOptions Class


WebApplicationOptions option = new WebApplicationOptions()
{
    WebRootPath = "MyWebRoot",
    Args = args,
    EnvironmentName = "Production"

};

//step 2 pass the webApplicationOptions Instance to CreateBuilder Method of
//WebApplication Class to create the Instance of WebApplicationBuilder Class

var builder = WebApplication.CreateBuilder(option);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.MapGet("/", () =>

    $"EnvironmentName: {app.Environment.EnvironmentName}," + " " +
    $"ApplicationName: {app.Environment.ApplicationName}," + " " +
     $"WebRootPath: {app.Environment.WebRootPath}," + " " +
    $"ContentRootPath: {app.Environment.ContentRootPath}");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
//app.UseRouting();

//app.UseAuthorization();

//app.MapStaticAssets();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}")
//    .WithStaticAssets();


//Configuring the middleware Component using Use and Run Extension Methood
//First Middleware Component Registered using Use Extension method 

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("MiddleWare1: Incoming Request\n");
//    await next();
//    await context.Response.WriteAsync("Middleware1: Outgoing Response\n");

//});

////Second MiddleWare Component Registered using Use Extension Method

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("MiddeWare2: Incoming Request\n");
//    await next();
//    await context.Response.WriteAsync("Middleware2: Outgoing Response\n");
//});

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Middleware3: Incoming Request\n");
//});

app.Run();
