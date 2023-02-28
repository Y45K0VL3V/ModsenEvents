using Web.Configuration;
using Web.Configuration.ServiceInstallers;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.InstallServices(config, typeof(IServiceInstaller).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();