namespace Barracuda2.Helpers
{
    public class OpenAIOptions
    {
        public const string SectionName = "OPENAI";
        public required string OPENAI_API_KEY { get; set; }
        public required string Password { get; set; }
    }
}
