using CurrentAccountService.Repositories;
using CurrentAccountService.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add custom services created in the API
builder.Services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
builder.Services.AddSingleton<IAccountRepository, InMemoryAccountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Call the Initialize method after building the app
Initialize(app.Services.GetRequiredService<ICustomerRepository>(), app.Services.GetRequiredService<IAccountRepository>());

app.Run();


// Initialize method in DummyDataInitializer class
static void Initialize(ICustomerRepository customerRepository, IAccountRepository accountRepository)
{
    DummyDataInitializer.Initialize(customerRepository, accountRepository);
}
