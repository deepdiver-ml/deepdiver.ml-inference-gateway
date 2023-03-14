using deepdiver.Application.Factories.PredictorFactory;
using deepdiver.Application.Factories.PredictorFactory.Ports;
using deepdiver.Application.Factories.PredictorInputFileFactory;
using deepdiver.Application.Factories.PredictorInputFileFactory.Ports;
using deepdiver.Application.Services.DescriptionService;
using deepdiver.Application.Services.DescriptionService.Ports;
using deepdiver.Application.Services.InferenceExecutionService;
using deepdiver.Application.Services.InferenceExecutionService.Ports;
using deepdiver.Application.Services.PredictorValidationService;
using deepdiver.Application.Services.PredictorValidationService.Ports;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.CommandExecutor;
using deepdiver.Infrastructure.Adapters.FileDestroyerAdapter;
using deepdiver.Infrastructure.Adapters.FileDestroyerAdapter.Ports;
using deepdiver.Infrastructure.Adapters.FileReaderAdapter;
using deepdiver.Infrastructure.Adapters.FileReaderAdapter.Ports;
using deepdiver.Infrastructure.Adapters.FileWriterAdapter;
using deepdiver.Infrastructure.Adapters.FileWriterAdapter.Ports;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();

var predictorsHome = Environment.GetEnvironmentVariable("PREDICTORS_HOME")!;
var descriptorExtension = Environment.GetEnvironmentVariable("DESCRIPTOR_EXTENSION")!;
var inferenceExecutable = Environment.GetEnvironmentVariable("INFERENCE_EXECUTABLE")!;
var inferenceScriptExtension = Environment.GetEnvironmentVariable("INFERENCE_SCRIPT_EXTENSION")!;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<InferenceExecutor, InferenceExecutionServiceImpl>();
builder.Services.AddScoped<PredictorNameValidator, PredictorValidationServiceImpl>();
builder.Services.AddScoped<Descriptor, DescriptionServiceImpl>();
builder.Services.AddScoped<CommandExecutor, CommandExecutionAdapterImpl>();
builder.Services.AddScoped<FileWriter, FileWriterAdapterImpl>();
builder.Services.AddScoped<FileReader, FileReaderAdapterImpl>();
builder.Services.AddScoped<FileDestroyer, FileDestroyerAdapterImpl>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<PredictorCreator, PredictorFactoryImpl>(provider => {
    return new PredictorFactoryImpl(predictorsHome, descriptorExtension, inferenceExecutable, inferenceScriptExtension);
});
builder.Services.AddScoped<PredictorInputFileCreator, PredictorInputFileFactoryImpl>();

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
