using Barracuda2.Helpers;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Memory;
string? endpoint = "endpoint";
string? modelId = "gpt-3.5-turbo";
string? embeddingModel = "text-embedding-3-small";
string? apiKey = "";

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json").AddEnvironmentVariables();
IMemoryStore store = MemoryStore.CreateSamplePostgresMemoryStore();
var kernel = Kernel.CreateBuilder()
            .AddOpenAIChatCompletion(modelId, apiKey)
            .AddOpenAITextEmbeddingGeneration(embeddingModel, apiKey)
            .Build();
// Create an embedding generator to use for semantic memory.
var embeddingGenerator = new OpenAITextEmbeddingGenerationService(embeddingModel, apiKey);

// The combination of the text embedding generator and the memory store makes up the 'SemanticTextMemory' object used to
// store and retrieve memories.
SemanticTextMemory textMemory = new(store, embeddingGenerator);
ChatSetup chatSetup = new ChatSetup();
await chatSetup.OpenAIMultiChatCompletionAsync(modelId, apiKey);

builder.Services.AddControllersWithViews();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
