using MediatR;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Vocabularies;

namespace API.Controllers
{
  public class VocabularyController : BaseApiController
  {
    private readonly IMediator _mediator;
    public VocabularyController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<Vocabulary>>> GetVocabularies() // should return by languageId
    {
      return await _mediator.Send(new GetAll.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vocabulary>> GetVocabularyById(Guid id)
    {
      return Ok(await _mediator.Send(new Get.Query { Id = id }));
    }

  }
}