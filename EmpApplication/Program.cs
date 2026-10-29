using EmpApplication.BusinessLogic;
using EmpApplication.Data.Repository;

var builder = WebApplication.CreateBuilder(args);


//Register the Data Acess layer and Businees Access Layer
builder.Services.AddSingleton<IEmployeeDAL,EmployeeDAL>();
builder.Services.AddSingleton<EmpBL>();
builder.Services.AddScoped<StudentBL>();
builder.Services.AddScoped<IStudentDAL,StudentDAL>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

//app.MapStaticAssets();


//Remove Default Route and Just defined the pattern and also Defined the dafault 
// route for the defualt routing 
app.MapControllerRoute(
    name: "CustomeRoute",
    pattern: "{controller}/{action}/{id:int?}",
    defaults: new {controller="Employee" , action="Index"}
    );
    


app.Run();
