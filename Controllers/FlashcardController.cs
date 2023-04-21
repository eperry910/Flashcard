using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;
namespace Controllers;

[ApiController]
[Route("[controller]")]
public class FlashcardController : ControllerBase
{

    private readonly ILogger<Flashcard> _logger;
    private readonly FlashcardServices _service;

    public FlashcardController(ILogger<Flashcard> logger, FlashcardServices service)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet(Name = "GetCards")]
    public IActionResult GetFlashcards()
    {
        try
        {
            return Ok(_service.GetFlashcards());

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Ok(null);
        }
    }
    [HttpGet]
    [Route("GetCards/{id}")]
    public IActionResult GetFlashcards(int id)
    {
        return Ok(_service.GetFlashcardById(id));
    }
    [HttpPost]
    [Route("CreateCards")]
    public IActionResult CreateFlashcards([FromBody] Flashcard card)
    {
        if (card.Answer != null && card.Prompt != null)
        {
            card.DayCreated = DateTime.Now;
            return Ok(_service.AddFlashcard(card));

        }
        else
        {
            return Ok(null);
        }
    }
    [HttpPut]
    [Route("UpdateCard")]
    public IActionResult UpdateFlashcards([FromBody] Flashcard card)
    {
        card.DayCreated = DateTime.Now;
        return Ok(_service.UpdateFlashcard(card));
    }
    [HttpDelete]
    [Route("DeleteCards")]
    public IActionResult DeleteFlashcards([FromBody] Flashcard card)
    {
        return Ok(_service.DeleteFlashcard(card));
    }
}
