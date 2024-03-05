var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddMediator();

builder.Services.InstallBuildingBlocks(builder.Configuration);

builder.Services.InstallModules(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseSelectiveExceptionHandler();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();