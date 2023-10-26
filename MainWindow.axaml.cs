using System;
using System.Linq;
using System.Timers;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Threading;
using Timer = System.Timers.Timer;
namespace MarathonSkills2016;

public partial class MainWindow : Window
{
    private DispatcherTimer _disTimer = new DispatcherTimer();
    public MainWindow()
    {
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
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Show();
        Close();
    }
}