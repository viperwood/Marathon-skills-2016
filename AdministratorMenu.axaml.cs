using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace MarathonSkills2016;

public partial class AdministratorMenu : Window
{
    private DispatcherTimer _timer = new DispatcherTimer();
    public AdministratorMenu()
    {
        InitializeComponent();
        _timer.Interval = TimeSpan.FromSeconds(0);
        _timer.Tick += TimerTick;
        _timer.Start();
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        TimerMarafon timerMarafon = new TimerMarafon();
        Timers.Text = timerMarafon.Timer1();
    }

    private void Logout(object? sender, RoutedEventArgs e)
    {
        SaveUser.User.Clear();
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void Beack(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}