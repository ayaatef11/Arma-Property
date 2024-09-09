
var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(connectionString));



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IServices<Owner>, Services<Owner>>();
builder.Services.AddScoped<IServices<Catch>, Services<Catch>>();
builder.Services.AddScoped<IServices<Contract>, Services<Contract>>();
//builder.Services.AddScoped<IServices<ContractDetails>, Services<ContractDetails>>();
builder.Services.AddScoped<IServices<ContractStatus>, Services<ContractStatus>>();
builder.Services.AddScoped<IServices<Payment>, Services<Payment>>();
builder.Services.AddScoped<IServices<PaymentMethod>, Services<PaymentMethod>>();
builder.Services.AddScoped<IServices<Property>, Services<Property>>();
builder.Services.AddScoped<IServices<PropertyType>, Services<PropertyType>>();
builder.Services.AddScoped<IServices<PropertyStatus>, Services<PropertyStatus>>();
builder.Services.AddScoped<IServices<Tenant>, Services<Tenant>>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
