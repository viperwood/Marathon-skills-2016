using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace MarathonSkills2016;

public partial class RegistrationConfirmation : Window
{
    private DispatcherTimer _timer = new DispatcherTimer();
    public RegistrationConfirmation()
    {
        InitializeComponent();
        _timer.Tick += TimerTick;
        _timer.Interval = TimeSpan.FromSeconds(0);
        _timer.Start();
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        TimerMarafon timerMarafon = new TimerMarafon();
        Timers.Text = timerMarafon.Timer1();
    }

    private void Logout(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        SaveUser.User.Clear();
        mainWindow.Show();
        Close();
    }

    private void Beack(object? sender, RoutedEventArgs e)
    {
        RunnerMenu runnerMenu = new RunnerMenu();
        runnerMenu.Show();
        Close();
    }

    private void OkButton(object? sender, RoutedEventArgs e)
    {
        RunnerMenu runnerMenu = new RunnerMenu();
        runnerMenu.Show();
        Close();
    }
}