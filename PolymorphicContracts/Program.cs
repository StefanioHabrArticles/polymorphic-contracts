using System.Reflection;
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using PolymorphicContracts.TypeDiscriminatorSwaggerSetup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters
        .Add(new JsonStringEnumConverter())
);
builder.Services.AddEndpointsApiExplorer().AddSwaggerGen()
    .AddTypeDiscriminatorToSwagger(builder.Configuration);

builder.Services.AddFluentValidationAutoValidation()
    .AddValidatorsFromAssembly(Assembly.Load("PolymorphicContracts.Validators"));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();