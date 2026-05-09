namespace BibleReader.Core.Models;

public class Book
{
    public string Name { get; }
    public List<Chapter> Chapters { get; } = new();

    public Book(string name)
    {
        Name = name;
    }
}
