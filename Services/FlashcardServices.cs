using Entities;
using Microsoft.EntityFrameworkCore;
namespace Services;
public class FlashcardServices
{
    private readonly FlashcardContext _context;
    public FlashcardServices(FlashcardContext context)
    {
        this._context = context;
    }
    public Flashcard AddFlashcard(Flashcard flashcard)
    {
        _context.Flashcards.Add(flashcard);
        _context.SaveChanges();
        return flashcard;
    }
    public Flashcard UpdateFlashcard(Flashcard flashcard)
    {
        var result = _context.Flashcards.FirstOrDefault(x => x.cardID == flashcard.cardID);
        result.DayCreated = DateTime.Now;
        if (!string.IsNullOrEmpty(flashcard.Answer))
        {
            result.Answer = flashcard.Answer;
        }
        if (!string.IsNullOrEmpty(flashcard.Prompt))
        {
            result.Prompt = flashcard.Prompt;
        }
        if (!string.IsNullOrEmpty(flashcard.Category))
        {
            result.Category = flashcard.Category;
        }
        _context.SaveChanges();
        return flashcard;
    }
    public Flashcard DeleteFlashcard(Flashcard flashcard)
    {
        Flashcard result = _context.Flashcards.FirstOrDefault(x => x.cardID == flashcard.cardID);
        _context.Flashcards.Remove(result);
        _context.SaveChanges();
        return flashcard;
    }
    public Flashcard GetFlashcardById(int id)
    {
        return _context.Flashcards.FirstOrDefault(w => w.cardID == id);
    }
    public List<Flashcard> GetFlashcards()
    {
        return _context.Flashcards.ToList();
    }
}