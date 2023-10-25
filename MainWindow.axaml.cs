using System;
using System.Timers;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Timers;
using Avalonia.Threading;
using Timer = System.Timers.Timer;
namespace MarathonSkills2016;

public partial class MainWindow : Window
{
    private DispatcherTimer _disTimer = new DispatcherTimer();
    private static System.Timers.Timer aTimer;
    public MainWindow()
    {
        aTimer = new System.Timers.Timer(1000);
        InitializeComponent();
        _disTimer.Interval = TimeSpan.FromSeconds(0);
        _disTimer.Tick += DispatcherTimer_Tick;
        _disTimer.Start();
    }

    private void DispatcherTimer_Tick(object? sender, EventArgs e)
    {
        TimerMarafon timerMarafon = new TimerMarafon();
        Timers.Text = timerMarafon.Timer1();
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
        FindOutMoreInformation findOutMoreInformation = new FindOutMoreInformation();
        findOutMoreInformation.Show();
        Close();
    }

    private void Login(object? sender, RoutedEventArgs e)
    {
        
    }
}