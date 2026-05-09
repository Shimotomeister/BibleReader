using System.Collections.Generic;
using Avalonia.Media;
using BibleReader.App.Controls;

namespace BibleReader.App.Services;

public class ColumnBalancer
{
    private readonly VerseMeasurer _measurer = new();

    public (List<string> left, List<string> right) Balance(
        List<string> verses,
        double columnHeight,
        double columnWidth,
        Typeface typeface,
        double fontSize)
    {
        var left = new List<string>();
        var right = new List<string>();

        double used = 0;

        foreach (var verse in verses)
        {
            double h = _measurer.MeasureVerse(verse, columnWidth, typeface, fontSize);

            if (used + h < columnHeight)
            {
                left.Add(verse);
                used += h;
            }
            else
            {
                right.Add(verse);
            }
        }

        return (left, right);
    }
}
