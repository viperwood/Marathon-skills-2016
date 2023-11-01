using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Threading;
using MarathonSkills2016.Models;

namespace MarathonSkills2016;

public partial class LoginWindow : Window
{
    private DispatcherTimer _timer = new DispatcherTimer();
    public LoginWindow()
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

    private void Login(object? sender, RoutedEventArgs e)
    {
            int chack = 0;
                    if (EmailBox.Text == "" || EmailBox.Text == null)
                    {
                        EmailChack.Foreground = Brushes.Red;
                        EmailChack.Text = "Поле должно быть заполнено";
                        chack = 1;
                    }
                    else
                    {
                        EmailChack.Text = "";
                        chack = 0;
                    }
                    if (PasswordBox.Text == "" || PasswordBox.Text == null)
                    {
                        PasswordChack.Foreground = Brushes.Red;
                        PasswordChack.Text = "Поле должно быть заполнено";
                        chack = 1;
                    }
                    else
                    {
                        PasswordChack.Text = "";
                        chack = 0;
                    }
            
                    if (chack == 0)
                    {
                        var users = Helper.Database.Users
                            .Where( x => x.Email == EmailBox.Text && x.Password == PasswordBox.Text)
                            .ToList();
                        if (users.Count == 1)
                        {
                            SaveUser.User = users.ToList();
                            var userinf = Helper.Database.Runners.Where(x => x.Email == EmailBox.Text).ToList();
                            SaveUser.Userinf = userinf.ToList();
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
                        else
                        {
                            Eror.Foreground = Brushes.Red;
                            Eror.Text = "Неправильно введен логин или пароль";
                        }
                    }
    }

    private void Cancel(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}