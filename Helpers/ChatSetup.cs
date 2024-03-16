using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
namespace Barracuda2.Helpers;

public class ChatSetup
{
    public Task OpenAIMultiChatCompletionAsync(string modelId, string apiKey)
    {
        Console.WriteLine("======== Open AI - Multiple Chat Completion ========");

        OpenAIChatCompletionService chatCompletionService = new(modelId: modelId, apiKey);

        return RunChatAsync(chatCompletionService);
    }
    private async Task RunChatAsync(IChatCompletionService chatCompletionService)
    {
        var chatHistory = new ChatHistory("@\"\r\n        You are an expert on C# and a coauthor of the Essential C# book. Using your the excerpts from the book below,\r\n        answer the questions asked by the user. Additionally, include a code example when applicable.\r\n        If you don't know the answer, say so.\r\n\r\n        Excerpts from book:\r\n        {{$relevant_information}}\r\n\r\n        Chat:\r\n        {{$chat_history}}\r\n        User: {{$user_input}}\r\n        ChatBot: \";");

        // First user message
        chatHistory.AddUserMessage("What is C#?");
        await MessageOutputAsync(chatHistory);

        var chatExecutionSettings = new OpenAIPromptExecutionSettings()
        {
            MaxTokens = 1024,
            ResultsPerPrompt = 2,
            Temperature = 1,
            TopP = 0.5,
            FrequencyPenalty = 0,
        };

        // First bot assistant message
        foreach (var chatMessageChoice in await chatCompletionService.GetChatMessageContentsAsync(chatHistory, chatExecutionSettings))
        {
            chatHistory.Add(chatMessageChoice!);
            await MessageOutputAsync(chatHistory);
        }

        Console.WriteLine();
    }
    private Task MessageOutputAsync(ChatHistory chatHistory)
    {
        var message = chatHistory.Last();

        Console.WriteLine($"{message.Role}: {message.Content}");
        Console.WriteLine("------------------------");

        return Task.CompletedTask;
    }

}



