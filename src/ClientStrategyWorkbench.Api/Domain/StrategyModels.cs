namespace ClientStrategyWorkbench.Api.Domain;

public sealed class HouseholdProfile
{
    public string HouseholdName { get; set; } = string.Empty;
    public string PrimaryGoal { get; set; } = string.Empty;
    public int TimeHorizonYears { get; set; }
    public string RiskTolerance { get; set; } = "Moderate";
    public int LiquidityReserveMonths { get; set; }
    public decimal AnnualIncome { get; set; }
    public decimal AnnualSpending { get; set; }
    public decimal InvestableAssets { get; set; }
    public decimal Liabilities { get; set; }
}

public sealed class IpsConstraints
{
    public int MaxEquityPercent { get; set; } = 80;
    public int MinFixedIncomePercent { get; set; } = 20;
    public int ConcentrationLimitPercent { get; set; } = 15;
    public string RestrictedHoldings { get; set; } = string.Empty;
    public string TaxSensitivity { get; set; } = "Medium";
}

public sealed class StrategyRequest
{
    public HouseholdProfile Household { get; set; } = new();
    public IpsConstraints Constraints { get; set; } = new();
    public string AdvisorName { get; set; } = string.Empty;
    public string ClientEmail { get; set; } = string.Empty;
}

public sealed class TargetAllocation
{
    public int EquityPercent { get; set; }
    public int FixedIncomePercent { get; set; }
}

public sealed class DeliverableLinks
{
    public string WordPacketPath { get; set; } = string.Empty;
    public string ExcelPlanPath { get; set; } = string.Empty;
    public string OutlookDraftReference { get; set; } = string.Empty;
    public string SharePointTargetPath { get; set; } = string.Empty;
}

public sealed class StrategyResult
{
    public string HouseholdName { get; set; } = string.Empty;
    public decimal NetWorth { get; set; }
    public TargetAllocation TargetAllocation { get; set; } = new();
    public List<string> FocusActions { get; set; } = [];
    public DeliverableLinks Deliverables { get; set; } = new();
}
