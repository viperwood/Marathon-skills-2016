using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MarathonSkills2016;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Timerblock();
    }

    public void Timerblock()
    {
        Timers.Text = Timer.Timerstart;
    }

    private void IHaveStateRuner(object? sender, RoutedEventArgs e)
    {
        
    }

    private void IHaveStateSponsor(object? sender, RoutedEventArgs e)
    {
        SponsorARunner sponsorARunner = new SponsorARunner();
        sponsorARunner.Show();
        Close();
    }

    private void MoreInform(object? sender, RoutedEventArgs e)
    {
        
    }

    private void Login(object? sender, RoutedEventArgs e)
    {
        
    }
}