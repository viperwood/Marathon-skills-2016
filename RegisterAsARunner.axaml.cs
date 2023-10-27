using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace MarathonSkills2016;

public partial class RegisterAsARunner : Window
{
    private DispatcherTimer _timer = new DispatcherTimer();
    public RegisterAsARunner()
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

    private void Login(object? sender, RoutedEventArgs e)
    {
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Show();
        Close();
    }

    private void ParticipatedBefore(object? sender, RoutedEventArgs e)
    {
        if (SaveUser.User.Count == 0)
        {
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Show();
        Close();
        }
        else
        {
            var users = SaveUser.User.ToList();
            switch (users[0].Roleid.ToString())
            {
                case "R":
                    RunnerMenu runnerMenu = new RunnerMenu();
                    runnerMenu.Show();
                    Close();
                    break;
                case "A":
                    AdministratorMenu administratorMenu = new AdministratorMenu();
                    administratorMenu.Show();
                    Close();
                    break;
                case "C":
                    CoordinatorMenu coordinatorMenu = new CoordinatorMenu();
                    coordinatorMenu.Show();
                    Close();
                    break;
            }
        }
    }

    private void NewMember(object? sender, RoutedEventArgs e)
    {
        
    }
}