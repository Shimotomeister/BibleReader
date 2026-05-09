#nullable enable

using System.IO;

using BibleReader.Core.Models;


namespace BibleReader.Data.Services;

public class EstherLoader
{
    private readonly string _filePath;

    public EstherLoader(string filePath)
    {
        _filePath = filePath;
    }

    public Book Load()
    {
        var book = new Book("Esther");
        Chapter? currentChapter = null;

        foreach (var line in File.ReadLines(_filePath))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            // Format: Esther 1:1 | text...
            var parts = line.Split('|');
            var left = parts[0].Trim();   // "Esther 1:1"
            var text = parts[1].Trim();   // placeholder text

            var refParts = left.Split(' ')[1].Split(':');
            int chapter = int.Parse(refParts[0]);
            int verse = int.Parse(refParts[1]);

            if (currentChapter == null || currentChapter.Number != chapter)
            {
                currentChapter = new Chapter(chapter);
                book.Chapters.Add(currentChapter);
            }

            currentChapter.Verses.Add(new Verse(chapter, verse, text));
        }

        return book;
    }
}
