using Microsoft.EntityFrameworkCore;
namespace Entities;
public class FlashcardContext : DbContext
{
    public FlashcardContext(DbContextOptions<FlashcardContext> options) : base(options)
    {

    }
    public FlashcardContext() : base() { }
    public virtual DbSet<Flashcard>? Flashcards { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { //Creates a table with the necessary columns for the 
        modelBuilder.Entity<Flashcard>(entity =>
        {
            entity.HasKey(e => e.cardID).HasName("cardId");
            entity.ToTable("Flashcards");
            entity.Property(e => e.Category).HasColumnName("Category");
            entity.Property(e => e.DayCreated).HasColumnName("DayCreated");
            entity.Property(e => e.Prompt).HasColumnName("Prompt");
            entity.Property(e => e.Answer).HasColumnName("Answer");
        });
    }
}
