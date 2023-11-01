using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using MarathonSkills2016.Models;

namespace MarathonSkills2016;

public partial class RegisterForAnEvent : Window
{
    private DispatcherTimer _timer = new DispatcherTimer();
    private int cost = 0;
    private byte buf = 0;
    private Registration _registration;
    private bool v1 = false;
    private bool v2 = false;
    private bool v3 = false;
    private byte result = 0;
    public RegisterForAnEvent()
    {
        InitializeComponent();
        _timer.Interval = TimeSpan.FromSeconds(0);
        _timer.Tick += TimerTick;
        ContributionSum.KeyUp += ContributionSumKey;
        _timer.Start();
        Resultsumm.Text = $"${cost}";
        Fond();
    }

    private void ContributionSumKey(object? sender, KeyEventArgs e)
    {
        
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        TimerMarafon timerMarafon = new TimerMarafon();
        Timers.Text = timerMarafon.Timer1();
    }
    
    private void Fond()
    {
        List<Charity> charities = Helper.Database.Charities.ToList();
        FondBox.Items = charities.Select(x => new
        {
            Fonds = x.Charityname
        }).ToList();
    }

    private void Cancel(object? sender, RoutedEventArgs e)
    {
        RunnerMenu runnerMenu = new RunnerMenu();
        runnerMenu.Show();
        Close();
    }

    private void LoadDate()
    {
        var userinf = SaveUser.Userinf.ToList();
        _registration.Runnerid = userinf[0].Runnerid;
        _registration.Registrationtimestamp = DateTime.Now;
        _registration.Registrationstatusid = 1;
        _registration.Cost = result;
        _registration.Charityid = FondBox.SelectedIndex;
        _registration.Sponsorshiptarget = Convert.ToInt32(ContributionSum.Text);
    }

    private void SaveButton(object? sender, RoutedEventArgs e)
    {
        byte i = 0;
        if (rad1.IsChecked == true || rad2.IsChecked == true || rad3.IsChecked == true)
        {
            Varning2.IsVisible = false;
            i += 1;
        }
        else
        {
            Varning2.IsVisible = true;
        }
        if (variant1.IsChecked == true || variant2.IsChecked == true || variant3.IsChecked == true)
        {
            Varning1.IsVisible = false;
            i += 1;
        }
        else
        {
            Varning1.IsVisible = true;
        }

        if (ContributionSum.Text != null && ContributionSum.Text != "")
        {
            if (Convert.ToInt32(ContributionSum.Text) < 0)
            {
                Varning3.Text = "Сумма взноса не должна быть отрицательной!";
            }
            else
            {
                Varning3.Text = "";
                i += 1;
            }
        }
        else
        {
            Varning3.Text = "Все поля обязательны!";
        }
        
        if (FondBox.SelectedIndex != -1)
        {
            Varning4.Text = "";
            i += 1;
        }
        else
        {
            Varning4.Text = "Все поля обязательны!";
        }

        if (i == 4)
        {
            if (v1 == true)
            {
                _registration = new Registration();
                _registration.Racekitoptionid = 'A';
                LoadDate();
                Helper.Database.Add(_registration);
                Helper.Database.SaveChanges();
            }
            if (v2 == true)
            {
                _registration = new Registration();
                _registration.Racekitoptionid = 'B';
                LoadDate();
                Helper.Database.Add(_registration);
                Helper.Database.SaveChanges();
            }
            if (v3 == true)
            {
                _registration = new Registration();
                _registration.Racekitoptionid = 'C';
                LoadDate();
                Helper.Database.Add(_registration);
                Helper.Database.SaveChanges();
            }
        }
    }

    private void Beack(object? sender, RoutedEventArgs e)
    {
        RunnerMenu runnerMenu = new RunnerMenu();
        runnerMenu.Show();
        Close();
    }

    private void Logout(object? sender, RoutedEventArgs e)
    {
        SaveUser.User.Clear();
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void var1(object? sender, RoutedEventArgs e)
    {
        if (variant1.IsChecked == true)
        {
            v1 = true;
            cost += 145;
            Resultsumm.Text = $"${cost}";
        }
        else
        {
            v1 = false;
            cost -= 145;
            Resultsumm.Text = $"${cost}";
        }
    }

    private void var2(object? sender, RoutedEventArgs e)
    {
        if (variant2.IsChecked == true)
        {
            v2 = true;
            cost += 75;
            Resultsumm.Text = $"${cost}";
        }
        else
        {
            v2 = false;
            cost -= 75;
            Resultsumm.Text = $"${cost}";
        }
    }

    private void var3(object? sender, RoutedEventArgs e)
    {
        if (variant3.IsChecked == true)
        {
            v3 = true;
            cost += 20;
            Resultsumm.Text = $"${cost}";
        }
        else
        {
            v3 = false;
            cost -= 20;
            Resultsumm.Text = $"${cost}";
        }
    }
    
    private void option1(object? sender, RoutedEventArgs e)
    {
        if (rad1.IsChecked == true)
        {
            cost -= buf;
            result = 0;
            buf = 0;
            Resultsumm.Text = $"${cost}";
        }
    }

    private void option2(object? sender, RoutedEventArgs e)
    {
        if (rad2.IsChecked == true)
        {
            cost -= buf;
            cost += 20;
            result = 20;
            buf = 20;
            Resultsumm.Text = $"${cost}";
        }
    }

    private void option3(object? sender, RoutedEventArgs e)
    {
        if (rad3.IsChecked == true)
        {
            cost -= buf;
            result = 45;
            cost += 45;
            buf = 45;
            Resultsumm.Text = $"${cost}";
        }
    }
}