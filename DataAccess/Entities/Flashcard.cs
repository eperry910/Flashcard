using System;

namespace Entities;

public class Flashcard
{
    public int cardID { get; set; }
    public string Category { get; set; }
    public DateTime DayCreated { get; set; }

    public string Prompt { get; set; }

    public string Answer { get; set; }

}
