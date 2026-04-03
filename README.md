# MusicTheoryHelper (Web)

A C# ASP.NET Core Razor Pages app for:

1. Notes -> possible chords and keys
2. Notes in a key
3. Related keys

## Projects

- `MusicTheoryHelper.Core`: domain models + services
- `MusicTheoryHelper.Web`: Razor Pages UI
- `MusicTheoryHelper.Tests`: xUnit tests for core services

## Run (when .NET SDK is installed)

```bash
dotnet build MusicTheoryHelper.sln
dotnet run --project MusicTheoryHelper.Web
```

Then open the shown local URL.
