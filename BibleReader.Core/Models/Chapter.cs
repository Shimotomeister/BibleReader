namespace BibleReader.Core.Models;

public class Chapter
{
    public int Number { get; }
    public List<Verse> Verses { get; } = new();

    public Chapter(int number)
    {
        Number = number;
    }
}
