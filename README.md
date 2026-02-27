# Sharp Reviewer

An AI-powered C# code review assistant built with Blazor Server and Azure OpenAI. Sharp Reviewer analyzes your C# code for Clean Code principles and SOLID violations, providing actionable feedback and refactored code suggestions.

## Features

- **AI-Powered Analysis**: Leverages Azure OpenAI to analyze C# code quality
- **Clean Code Evaluation**: Scores code from 0-100 based on Clean Code principles
- **SOLID Violations Detection**: Identifies violations of SOLID principles
- **Issue Reporting**: Provides detailed list of problems found in the code
- **Code Refactoring**: Generates improved, refactored versions of your code
- **Real-time Feedback**: Interactive UI with instant analysis results

## Technology Stack

- **Framework**: .NET 8.0
- **UI**: Blazor Server with Bootstrap 5
- **AI Integration**: Microsoft Semantic Kernel 1.72.0
- **AI Provider**: Azure OpenAI (GPT models)

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- Azure OpenAI API access with a deployed model

## Configuration

1. Clone the repository
2. Update `appsettings.Development.json` with your Azure OpenAI credentials:

```json
{
  "AzureOpenAI": {
    "ApiKey": "your-api-key-here",
    "ModelId": "your-deployment-name",
    "ApiUrl": "https://your-resource.openai.azure.com/"
  }
}
```

## Running the Application

```bash
dotnet restore
dotnet build
dotnet run --project SharpReviewer
```

The application will start on `https://localhost:5001` (or the port specified in `launchSettings.json`).

## Usage

1. Navigate to the application in your browser
2. Paste your C# code into the left text area
3. Click **Analyse Code**
4. Review the results:
   - **Score**: Overall code quality (0-100)
   - **Summary**: Brief assessment of the code
   - **Issues**: List of identified problems
   - **Refactored Code**: Improved version of your code

## Project Structure

```
SharpReviewer/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor
│   │   └── MainLayout.razor.css
│   ├── Pages/
│   │   └── Home.razor
│   ├── App.razor
│   ├── Routes.razor
│   └── _Imports.razor
├── Models/
│   └── CodeReviewResult.cs
├── Plugins/
│   └── AnalyzeCodePlugin.cs
├── wwwroot/
│   ├── bootstrap/
│   ├── app.css
│   └── favicon.png
├── Program.cs
├── SharpReviewer.csproj
└── appsettings.json
```

## How It Works

1. **User Input**: User pastes C# code into the web interface
2. **Semantic Kernel**: The code is sent to Azure OpenAI via Semantic Kernel
3. **AI Analysis**: GPT model analyzes the code for:
   - Clean Code principles
   - SOLID violations
   - Performance issues
   - Security concerns
4. **Response Processing**: JSON response is deserialized into `CodeReviewResult`
5. **UI Display**: Results are rendered with color-coded scoring:
   - 🟢 Green (80-100): Excellent code quality
   - 🟡 Yellow (50-79): Needs improvement
   - 🔴 Red (0-49): Poor code quality

## Dependencies

- **Microsoft.SemanticKernel** (1.72.0): AI orchestration framework
- **Azure.AI.OpenAI** (2.8.0-beta.1): Azure OpenAI client library

## Development

### Building

```bash
dotnet build
```

### Cleaning

```bash
dotnet clean
```

### IDE Support

This project works with:
- Visual Studio 2022
- JetBrains Rider 2024.2+
- Visual Studio Code with C# extension

## Security Notes

- Never commit `appsettings.Development.json` with real API keys
- Use environment variables or Azure Key Vault for production deployments
- The `.gitignore` file excludes sensitive configuration files

## License

This project is provided as-is for educational and development purposes.

## Contributing

Contributions are welcome! Please ensure:
- Code follows existing patterns
- All changes build successfully
- No sensitive information is committed
