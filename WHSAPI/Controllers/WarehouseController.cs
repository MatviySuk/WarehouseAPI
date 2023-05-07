using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

    [HttpPost("fullload")]
    public async Task<IActionResult> FullLoad()
    {
        var result = await _dbService.FullLoadWHS();
        if (result >= 0)
        {
            return Ok(new { RowsAffected = result });
        }
        else
        {
            return BadRequest($"Full load failed. Code: {result}");
        }
    }
    
    [HttpPost("newupdate")]
    public async Task<IActionResult> NewUpdate()
    {
        var result = await _dbService.UpdateNewWHS();
        if (result >= 0)
        {
            return Ok(new { RowsAffected = result });
        }
        else
        {
            return BadRequest($"Update New failed. Code: {result}");
        }
    }
}