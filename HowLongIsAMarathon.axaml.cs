using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace MarathonSkills2016;

public partial class HowLongIsAMarathon : Window
{
    public HowLongIsAMarathon()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void Beack(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}