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
        _context.Flashcards.Update(flashcard);
        _context.SaveChanges();
        return flashcard;
    }
    public Flashcard DeleteFlashcard(Flashcard flashcard)
    {
        _context.Flashcards.Remove(flashcard);
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