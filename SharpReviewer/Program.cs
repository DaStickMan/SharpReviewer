using Microsoft.SemanticKernel;
using SharpReviewer.Components;
using SharpReviewer.Plugins;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<Kernel>(sp =>
{
    var kernelBuilder = Kernel.CreateBuilder();

    var azureOpenAiKey = builder.Configuration["AzureOpenAI:ApiKey"];
    var azureOpenAiUrl = builder.Configuration["AzureOpenAI:ApiUrl"];
    var azureOpenAiModelId = builder.Configuration["AzureOpenAI:ModelId"];
    
    if (string.IsNullOrEmpty(azureOpenAiKey) || string.IsNullOrEmpty(azureOpenAiUrl)|| string.IsNullOrEmpty(azureOpenAiModelId))
        throw new Exception("Azure OpenAI configuration is missing.");
    
    kernelBuilder.AddAzureOpenAIChatCompletion(
        deploymentName: azureOpenAiModelId,
        endpoint: azureOpenAiUrl,
        apiKey: azureOpenAiKey
    );

    kernelBuilder.Plugins.AddFromType<AnalyzeCodePlugin>("AnalyzeCodePlugin");

    return kernelBuilder.Build();
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
