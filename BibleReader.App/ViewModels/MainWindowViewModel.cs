using System;
using System.IO;
using System.Linq;
using System.Collections.ObjectModel;
using Avalonia.Media;
using BibleReader.Data.Services;
using BibleReader.Core.Models;
using BibleReader.App.Services;

namespace BibleReader.App.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string BookTitle { get; } = "Esther";

    public ObservableCollection<string> Verses { get; } = new();

    public ObservableCollection<string> LeftColumnVerses { get; } = new();
    public ObservableCollection<string> RightColumnVerses { get; } = new();

    public MainWindowViewModel()
    {
        var dataRoot = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Data");
        var bible = new BibleService(dataRoot);

        Book esther = bible.LoadEsther();

        foreach (var chapter in esther.Chapters)
        {
            foreach (var verse in chapter.Verses)
            {
                Verses.Add($"{chapter.Number}:{verse.Number} {verse.Text}");
            }
        }
    }

    public void RebalanceColumns(double columnHeight, double columnWidth)
    {
        var balancer = new ColumnBalancer();

        var (left, right) = balancer.Balance(
            Verses.ToList(),
            columnHeight,
            columnWidth,
            new Typeface("Segoe UI"),
            16);

        LeftColumnVerses.Clear();
        RightColumnVerses.Clear();

        foreach (var v in left) LeftColumnVerses.Add(v);
        foreach (var v in right) RightColumnVerses.Add(v);
    }
}
