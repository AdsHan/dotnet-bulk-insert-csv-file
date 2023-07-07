using BulkInsertCsv.API.Application.Messages.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BulkInsertCsv.API.Controllers;

[Route("api/organizations")]
[ApiController]
public class OrganizationsController : ControllerBase
{

    private readonly IMediator _mediator;

    public OrganizationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/organization/
    /// <summary>
    /// Grava a organização
    /// </summary>   
    /// <remarks>
    /// Exemplo request:
    ///
    ///     POST / Organização
    ///     {
    ///         "organizationId": "FAB0d41d5b5d22c",
    ///         "name": "Ferrell LLC",
    ///         "website": "https://price.net/",
    ///         "country": "Papua New Guinea",
    ///         "description": "Horizontal empowering knowledgebase",
    ///         "founded": "1990",
    ///         "industry": "Plastics",
    ///         "numberOfEmployees": 3498
    ///     }
    /// </remarks>        
    /// <returns>Retorna objeto criado da classe Organização</returns>
    /// <response code="201">O produto foi incluído corretamente</response>
    /// <response code="400">Falha na requisição</response>         
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ActionName("NewOrganizationCreate")]
    public async Task<IActionResult> PostCreateAsync([FromBody] CreateOrganizationCommand command)
    {
        var result = await _mediator.Send(command);

        return result.IsValid() ? CreatedAtAction("NewOrganizationCreate", new { id = result.Response }, command) : BadRequest(result.Errors);
    }


    // POST api/organization/import
    /// <summary>
    /// Grava a organização
    /// </summary>       
    /// <response code="201">A importação doi concluída com sucesso</response>
    /// <response code="400">Falha na importação</response>         
    [HttpPost("import")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ActionName("NewOrganizationImport")]
    public async Task<IActionResult> PostImportAsync([FromForm] ImportRequest request)
    {
        var result = await _mediator.Send(new ImportOrganizationCommand(request.File));

        return result.IsValid() ? CreatedAtAction("NewOrganizationImport", new { Records = result.Response }, request) : BadRequest(result.Errors);
    }

    public class ImportRequest
    {
        public IFormFile File { get; set; }
    }
}
