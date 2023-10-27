using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace MarathonSkills2016;

public partial class RunnerMenu : Window
{
    private DispatcherTimer _timer = new DispatcherTimer();
    public RunnerMenu()
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

    private void Beack(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void Logout(object? sender, RoutedEventArgs e)
    {
        SaveUser.User.Clear();
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void ContactButton(object? sender, RoutedEventArgs e)
    {
        ContactsWindow contactsWindow = new ContactsWindow();
        contactsWindow.Show();
    }
}