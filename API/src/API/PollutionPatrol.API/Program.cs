var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddMediator();

builder.Services.InstallServicesFromAssemblies(
    builder.Configuration,
    PollutionPatrol.Modules.Admin.Infrastructure.Configuration.ModuleDescriptor.InfrastructureAssembly,
    PollutionPatrol.Modules.Reporting.Infrastructure.Configuration.ModuleDescriptor.InfrastructureAssembly,
    PollutionPatrol.Modules.UserAccess.Infrastructure.Configuration.ModuleDescriptor.InfrastructureAssembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.Run();