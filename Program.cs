using ExpenseTrackerNET7.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// DI
builder.Services.AddDbContext<AppDBContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

var app = builder.Build();

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("@32302e342e30hWnzWMQRfZcipArTXDOtBZt8v/TCzZYMBkMpSgihsLA=;Mgo DSMBaFt/QHRqVVhjVFpFaV1KQmFJfFBmRmldflRyc0U3HVdTRHRcQlxhSH5QckRhXnhZcXw=;Mgo DSMBMAY9C3t2VVhkQlFadVdJXHxLdkx0RWFab116cFRMYltBNQtUQF1hSn5SdERjWntfcnNSQWJU;Mgo DSMBPh8sVXJ0S0J XE9HflRDQmFBYVF2R2BJfFR0dV9EZ0wgOX1dQl9gSX9Rd0VgXX5cd3NSQmg=;@32302e342e30XydrVfZv6HFMa/XTBTbWFnChVqnEp9fdYv2sxG506Kc=;NRAiBiAaIQQuGjN/V0Z WE9EaFxKVmJWfFtpR2NbfE5zflFHal5WVAciSV9jS31Td0diWXxacXZSQWdUWQ==;NT8mJyc2IWhhY31nfWN9YGtoYnxha3xhY2Fgc2BpZ2JpYWRzEh5oEjs NjccJzs Mj1qZBM8Jic/PDw4fTA8Pg==;ORg4AjUWIQA/Gnt2VVhkQlFadVdJXHxLdkx0RWFab116cFRMYltBNQtUQF1hSn5SdERjWntfcnNSTmJU;@32302e342e30pCKsJoWzLeHi77TRIzRQZvOpJP0DH5jUD7rmqTiDmKk=;@32302e342e30IEInaaSU66qen75tVAxVnE8R3YozgW6SQJuRLa SbKE=;@32302e342e30G8wg0IFCPXQchoRM3GFTjtAahUMQJqFOnh/2Eud m3A=;@32302e342e30Y9q9IRRqYs2zRq 1DTMaop gGunmbPhtS6q3a1CFqWk=;@32302e342e30hWnzWMQRfZcipArTXDOtBZt8v/TCzZYMBkMpSgihsLA= ");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Category}/{action=Index}/{id?}");

app.Run();
