using ClientStrategyWorkbench.Api.Application.Contracts;
using ClientStrategyWorkbench.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ClientStrategyWorkbench.Api.Controllers;

[ApiController]
[Route("api/strategy")]
public sealed class StrategyController : ControllerBase
{
    private readonly IStrategyService _strategyService;
    private readonly IOfficeWorkflowService _officeWorkflowService;

    public StrategyController(IStrategyService strategyService, IOfficeWorkflowService officeWorkflowService)
    {
        _strategyService = strategyService;
        _officeWorkflowService = officeWorkflowService;
    }

    [HttpPost("generate")]
    public ActionResult<StrategyResult> Generate([FromBody] StrategyRequest request)
    {
        var result = _strategyService.BuildStrategy(request);
        result.Deliverables = _officeWorkflowService.GenerateDeliverables(request, result);
        return Ok(result);
    }
}
