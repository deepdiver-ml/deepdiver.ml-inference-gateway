using deepdiver.Application.Factories.PredictorFactory;
using deepdiver.Application.Factories.PredictorFactory.Ports.SimplePredictorFactory;
using deepdiver.Application.Services.InferenceExecutionService;
using deepdiver.Application.Services.InferenceExecutionService.Ports.StringBasedInferenceExecutor;
using deepdiver.Application.Services.PredictorValidationService;
using deepdiver.Application.Services.PredictorValidationService.Ports.PredictorNameValidator;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.StringBasedCommandExecutor;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();

var predictorsHome = Environment.GetEnvironmentVariable("PREDICTORS_HOME")!;
var descriptorFileName = Environment.GetEnvironmentVariable("DESCRIPTOR_FILE_NAME")!;
var inferenceInvoker = Environment.GetEnvironmentVariable("INFERENCE_INVOKER")!;
var inferenceScriptExtension = Environment.GetEnvironmentVariable("INFERENCE_SCRIPT_EXTENSION")!;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<PredictorNameValidator, PredictorValidationServiceImpl>();
builder.Services.AddScoped<StringBasedInferenceExecutor, InferenceExecutionServiceImpl>();
builder.Services.AddScoped<StringBasedCommandExecutor, CommandExecutionAdapterImpl>();
builder.Services.AddScoped<SimplePredictorFactory, PredictorFactoryImpl>(provider => {
    return new PredictorFactoryImpl(predictorsHome, descriptorFileName, inferenceInvoker, inferenceScriptExtension);
});

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

app.Run();
