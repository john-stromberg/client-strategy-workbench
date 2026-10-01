using ClientStrategyWorkbench.Api.Application.Contracts;
using ClientStrategyWorkbench.Api.Domain;

namespace ClientStrategyWorkbench.Api.Application.Services;

public sealed class OfficeWorkflowService : IOfficeWorkflowService
{
    public DeliverableLinks GenerateDeliverables(StrategyRequest request, StrategyResult strategyResult)
    {
        var slug = request.Household.HouseholdName
            .Trim()
            .ToLowerInvariant()
            .Replace(" ", "-");

        return new DeliverableLinks
        {
            WordPacketPath = $"/outputs/word/{slug}-strategy-packet.docx",
            ExcelPlanPath = $"/outputs/excel/{slug}-allocation-plan.xlsx",
            OutlookDraftReference = $"draft://outlook/{slug}-meeting-update",
            SharePointTargetPath = $"/sharepoint/clients/{slug}/advisory-packet"
        };
    }
}
