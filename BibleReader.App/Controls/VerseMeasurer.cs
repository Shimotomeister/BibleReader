using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.TextFormatting;
using System.Globalization;
using System.Linq;

namespace BibleReader.App.Controls;

public class VerseMeasurer : Control
{
    public double MeasureVerse(string text, double width, Typeface typeface, double fontSize)
    {
        var layout = new TextLayout(
            text,
            typeface,
            fontSize,
            Brushes.Black,
            textWrapping: TextWrapping.Wrap,
            maxWidth: width);

        // Avalonia 11: measure by summing line heights
        double totalHeight = layout.TextLines.Sum(line => line.Height);

        return totalHeight;
    }
}
