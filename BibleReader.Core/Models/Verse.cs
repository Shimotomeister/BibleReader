namespace BibleReader.Core.Models;

public class Verse
{
    public int Chapter { get; }
    public int Number { get; }
    public string Text { get; }

    public Verse(int chapter, int number, string text)
    {
        Chapter = chapter;
        Number = number;
        Text = text;
    }

    public override string ToString() => $"{Chapter}:{Number} {Text}";
}
