using ClientStrategyWorkbench.Api.Domain;

namespace ClientStrategyWorkbench.Api.Application.Contracts;

public interface IStrategyService
{
    StrategyResult BuildStrategy(StrategyRequest request);
}

public interface IOfficeWorkflowService
{
    DeliverableLinks GenerateDeliverables(StrategyRequest request, StrategyResult strategyResult);
}
