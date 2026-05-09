using Avalonia;
using Avalonia.Controls;
using BibleReader.App.ViewModels;

namespace BibleReader.App.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        this.AttachedToVisualTree += (_, __) => Rebalance();
        this.PropertyChanged += (_, e) =>
        {
            if (e.Property == BoundsProperty)
                Rebalance();
        };
    }

    private void Rebalance()
    {
        if (DataContext is MainWindowViewModel vm)
        {
            double columnWidth = Bounds.Width / 2 - 20;
            double columnHeight = Bounds.Height - 40;

            vm.RebalanceColumns(columnHeight, columnWidth);
        }
    }
}
