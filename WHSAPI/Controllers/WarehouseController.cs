using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WHSAPI.Entities;
using WHSAPI.Services;
using WHSAPI.ViewModels;

namespace WHSAPI.Controllers;

[ApiController]
[Route("warehouse")]
public class WarehouseController : ControllerBase
{
    private readonly IWHSService _whsService;
    private readonly IITCompanyDBService _dbService;
    private readonly IMapper _mapper;
    private readonly ILogger<WarehouseController> _logger;

    public WarehouseController(ILogger<WarehouseController> logger, IWHSService whsService, IMapper mapper, IITCompanyDBService dbService)
    {
        _logger = logger;
        _whsService = whsService;
        _mapper = mapper;
        _dbService = dbService;
    }

    [HttpGet("allworks")]
    public async Task<IActionResult> GetAll()
    {
        var works = await _whsService.GetAll();
        return Ok(_mapper.Map<IList<FactWorksWithTaskView>>(works));
    }
    
    [HttpGet("alldates")]
    public async Task<IActionResult> GetAllDates()
    {
        var dates = await _whsService.GetAllDates();
        return Ok(_mapper.Map<IList<DimDateView>>(dates));
    }

    [HttpGet("lastload")]
    public async Task<IActionResult> LastLoadTime()
    {
        var loadDatetime = await _dbService.LastLoad();
        return Ok(new { LoadTime = loadDatetime });
    }
    
    [HttpPost("cleanup")]
    public async Task<IActionResult> WarehouseCleanUp()
    {
        var result = await _dbService.WHSCleanUp();
        return Ok(new { isExecuted = true });
    }

    [HttpPost("fullload")]
    public async Task<IActionResult> FullLoad()
    {
        var result = await _dbService.FullLoadWHS();
        var loadDatetime = await _dbService.LastLoad();
        if (result >= 0)
        {
            return Ok(new { RowsAffected = result, LoadTime = loadDatetime });
        }
        else
        {
            return BadRequest($"Full load failed. Code: {result}");
        }
    }
    
    [HttpPost("newload")]
    public async Task<IActionResult> NewUpdate()
    {
        var result = await _dbService.UpdateNewWHS();
        var loadDatetime = await _dbService.LastLoad();
        if (result >= 0)
        {
            return Ok(new { RowsAffected = result, LoadTime = loadDatetime });
        }
        else
        {
            return BadRequest($"Update New failed. Code: {result}");
        }
    }
}