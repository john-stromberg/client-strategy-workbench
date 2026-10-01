# Client Strategy Workbench

Workflow-first advisor tool for household strategy design, IPS-guided recommendations, and Office-integrated client deliverables.

## Stack
- .NET 10 ASP.NET Core Web API
- Static web UI (workflow form)
- Graph-ready service layer for Office integrations

## MVP Capabilities
- Capture household profile and IPS constraints
- Generate strategy recommendation and focus actions
- Produce deliverable references for:
  - Word strategy packet
  - Excel allocation plan
  - Outlook client-update draft
  - SharePoint/OneDrive destination path

## Run
```bash
dotnet restore client-strategy-workbench.slnx
dotnet run --project src/ClientStrategyWorkbench.Api/ClientStrategyWorkbench.Api.csproj
```

Open:
- `https://localhost:xxxx/` (workflow UI)
- `POST /api/strategy/generate` (API)

## Project Structure
- `src/ClientStrategyWorkbench.Api/Domain/StrategyModels.cs`
- `src/ClientStrategyWorkbench.Api/Application/Contracts/WorkflowContracts.cs`
- `src/ClientStrategyWorkbench.Api/Application/Services/StrategyService.cs`
- `src/ClientStrategyWorkbench.Api/Application/Services/OfficeWorkflowService.cs`
- `src/ClientStrategyWorkbench.Api/Controllers/StrategyController.cs`
- `src/ClientStrategyWorkbench.Api/wwwroot/index.html`

## Notes
Current Office outputs are represented as integration-ready references. Next step is wiring Microsoft Graph auth/app registration and live Word/Excel/Outlook/SharePoint operations.
