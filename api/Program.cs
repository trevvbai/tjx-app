using tjx_api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin",
		policy =>
		{
			policy.WithOrigins("http://localhost:4200")
				.AllowAnyHeader()
				.AllowAnyMethod();
		});
});

var dbPath = builder.Configuration.GetValue<string>("LiteDbOptions:DatabaseLocation");
builder.Services.AddSingleton<ILiteDbContext>(new LiteDbContext(dbPath));
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();

var app = builder.Build();

var dbContext = app.Services.GetService<ILiteDbContext>();
var dbInitializer = new DatabaseInitializer(dbContext);
dbInitializer.InitDb();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}else
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();

app.Run();