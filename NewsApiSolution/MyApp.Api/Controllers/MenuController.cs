using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyApp.Application.Menus.Commands;
using MyApp.Application.Menus.DTOs;  
using MyApp.Application.Menus.Queries;



[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMediator _mediator;
    public MenuController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MenuDto dto)
    {
        var id = await _mediator.Send(new CreateMenuCommand(dto.Title, dto.Slug));
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var menus = await _mediator.Send(new GetMenusQuery());
        return Ok(menus);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        // implement Query to get menu by id (omitted for brevity)
        return Ok();
    }
}
