using RentalCars.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

_ = builder.Services.AddDomainServices();
//_ = builder.Services.AddSqlServerDatabase(builder.Configuration, true);
_ = builder.Services.AddSingletonDatabase();
//_ = builder.Services.AddRepositories();
_ = builder.Services.AddRepositoriesSingletonDatabase();
_ = builder.Services.AddAutoMapper();

_ = builder.Services.AddControllers();
_ = builder.Services.AddEndpointsApiExplorer();
_ = builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

_ = app.UseHttpsRedirection();
_ = app.UseAuthorization();
_ = app.MapControllers();

app.Run();
