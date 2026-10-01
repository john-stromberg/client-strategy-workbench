using ClientStrategyWorkbench.Api.Application.Contracts;
using ClientStrategyWorkbench.Api.Domain;

namespace ClientStrategyWorkbench.Api.Application.Services;

public sealed class StrategyService : IStrategyService
{
    public StrategyResult BuildStrategy(StrategyRequest request)
    {
        var equity = request.Household.RiskTolerance switch
        {
            "Conservative" => 30,
            "Moderate" => 55,
            "Growth" => 70,
            "Aggressive" => 85,
            _ => 55
        };

        equity = Math.Min(equity, request.Constraints.MaxEquityPercent);
        var fixedIncome = Math.Max(100 - equity, request.Constraints.MinFixedIncomePercent);
        fixedIncome = Math.Min(fixedIncome, 100);
        equity = 100 - fixedIncome;

        var actions = new List<string>();
        if (request.Household.AnnualSpending > request.Household.AnnualIncome)
        {
            actions.Add("Close annual spending gap through expense controls or income actions.");
        }

        if (request.Household.LiquidityReserveMonths < 6)
        {
            actions.Add("Increase liquidity reserves toward at least 6 months of spending.");
        }

        if (request.Household.TimeHorizonYears <= 5)
        {
            actions.Add("Favor capital preservation for near-term objectives.");
        }

        if (request.Constraints.TaxSensitivity.Equals("High", StringComparison.OrdinalIgnoreCase))
        {
            actions.Add("Use tax-aware asset location and distribution sequencing.");
        }

        if (!string.IsNullOrWhiteSpace(request.Constraints.RestrictedHoldings))
        {
            actions.Add("Review restricted holdings for policy and concentration compliance.");
        }

        return new StrategyResult
        {
            HouseholdName = request.Household.HouseholdName,
            NetWorth = request.Household.InvestableAssets - request.Household.Liabilities,
            TargetAllocation = new TargetAllocation
            {
                EquityPercent = equity,
                FixedIncomePercent = fixedIncome
            },
            FocusActions = actions
        };
    }
}
