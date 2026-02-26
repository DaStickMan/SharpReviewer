using System.ComponentModel;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace SharpReviewer.Plugins;

public class AnalyzeCodePlugin
{
    private const string SystemPrompt = @"You are a Senior Software Architect and a .NET 8 / C# Expert.
Your mission is to analyze the provided C# code and return ONLY a valid JSON.
DO NOT include greetings, extra explanations, or markdown code blocks (```json). Return just the raw JSON.

Mandatory JSON Structure:
{
    ""score"": (integer from 0 to 100 evaluating Clean Code),
    ""summary"": ""Short summary of the overall quality"",
    ""issues"": [ ""Array of strings detailing SOLID violations, performance, or security issues"" ],
    ""refactoredCode"": ""The complete refactored and improved code""
}";

    [KernelFunction("AnalyzeCode")]
    [Description("Analyzes a snippet of C# code and returns a JSON with the evaluation, found issues, and the refactored code.")]
    public async Task<string> AnalyzeCodeAsync(
        Kernel kernel,
        [Description("The C# code pasted by the user that needs to be reviewed")] string dirtyCode)
    {
        var history = new ChatHistory();
        history.AddSystemMessage(SystemPrompt);
        history.AddUserMessage($"Here is the code for analysis:\n{dirtyCode}");
        
        var executionSettings = new OpenAIPromptExecutionSettings { Temperature = 0.0 };

        var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
        var result = await chatCompletionService.GetChatMessageContentAsync(history, executionSettings, kernel);
        
        return result.Content ?? throw new InvalidOperationException();
    }
}