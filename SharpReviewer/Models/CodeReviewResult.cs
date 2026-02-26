using System.Text.Json.Serialization;

namespace SharpReviewer.Models;

public class CodeReviewResult
{
    [JsonPropertyName("score")]
    public int Score { get; set; }

    [JsonPropertyName("summary")]
    public string Summary { get; set; } = string.Empty;

    [JsonPropertyName("issues")]
    public List<string> Issues { get; set; } = [];

    [JsonPropertyName("refactoredCode")]
    public string RefactoredCode { get; set; } = string.Empty;
    
    [JsonIgnore] 
    public string ScoreColor => Score switch
    {
        >= 80 => "bg-success",
        >= 50 => "bg-warning",
        _ => "bg-danger"
    };
}