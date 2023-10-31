using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using MarathonSkills2016.Models;

namespace MarathonSkills2016;

public partial class RegisterForAnEvent : Window
{
    private DispatcherTimer _timer = new DispatcherTimer();
    private int cost = 0;
    public RegisterForAnEvent()
    {
        InitializeComponent();
        _timer.Interval = TimeSpan.FromSeconds(0);
        _timer.Tick += TimerTick;
        _timer.Start();
        Resultsumm.Text = $"${cost}";
        Fond();
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        TimerMarafon timerMarafon = new TimerMarafon();
        Timers.Text = timerMarafon.Timer1();
    }
    
    

    private void Fond()
    {
        List<Charityfoundation> charityfoundations = Helper.Database.Charityfoundations.ToList();
        FondBox.Items = charityfoundations.Select(x => new
        {
            Fonds = x.Fundname
        }).ToList();
    }

    private void Cancel(object? sender, RoutedEventArgs e)
    {
        RunnerMenu runnerMenu = new RunnerMenu();
        runnerMenu.Show();
        Close();
    }

    private void SaveButton(object? sender, RoutedEventArgs e)
    {
        if (variant1.IsChecked == true || variant2.IsChecked == true || variant3.IsChecked == true)
        {
            Varning1.IsVisible = false;
        }
        else
        {
            Varning1.IsVisible = true;
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
            cost += 145;
            Resultsumm.Text = $"${cost}";
        }
        else
        {
            cost -= 145;
            Resultsumm.Text = $"${cost}";
        }
    }

    private void var2(object? sender, RoutedEventArgs e)
    {
        if (variant2.IsChecked == true)
        {
            cost += 75;
            Resultsumm.Text = $"${cost}";
        }
        else
        {
            cost -= 75;
            Resultsumm.Text = $"${cost}";
        }
    }

    private void var3(object? sender, RoutedEventArgs e)
    {
        if (variant3.IsChecked == true)
        {
            cost += 20;
            Resultsumm.Text = $"${cost}";
        }
        else
        {
            cost -= 20;
            Resultsumm.Text = $"${cost}";
        }
    }
    
}