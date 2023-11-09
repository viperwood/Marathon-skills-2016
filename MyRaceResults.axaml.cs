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

public partial class MyRaceResults : Window
{
    private DispatcherTimer _timer = new DispatcherTimer();
    public MyRaceResults()
    {
        InitializeComponent();
        _timer.Interval = TimeSpan.FromSeconds(0);
        _timer.Tick += TimerTick;
        _timer.Start();
        InformationMyResult();
        Category();
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        TimerMarafon timerMarafon = new TimerMarafon();
        Timers.Text = timerMarafon.Timer1();
    }

    private void Beack(object? sender, RoutedEventArgs e)
    {
        RunnerMenu runnerMenu = new RunnerMenu();
        runnerMenu.Show();
        Close();
    }

    private void Logout(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        SaveUser.User.Clear();
        SaveUser.Userinf.Clear();
        Close();
    }
    
    private void InformationMyResult()
    {
        var user = SaveUser.User;
        Maraphon.Items = Helper.Database.Myresults
                .Where(x => x.Email == user[0].Email)
                .Select(x => new
        {
            NameMaraphon = x.Eventname,
            Distantion = x.Eventtypename,
            TimeRunner = x.Dateofbirth,
            GeneralPlace = x.Runnerid,
            PlaceByCategory = x.Bibnumber
        }).ToList()
            ;
    }
    
    
    
    
    private void Category()
    {
        var user = SaveUser.Userinf;
        if (user[0].Gender == "Male")
        {
            GenderRunner.Text = "Пол: Мужской";
        }
        else
        {
            GenderRunner.Text = "Пол: Женский";
        }

        
        int age = DateTime.Now.Year - user[0].Dateofbirth.Year;
        
        
        switch (age)
        {
            case < 18:
                AgeRunner.Text = "Возростная категория: <18";
                break;
            case >= 18 and < 29:
                AgeRunner.Text = "Возростная категория: 18 - 29";
                break;
            case >= 30 and < 39:
                AgeRunner.Text = "Возростная категория: 30 - 39";
                break;
            case >= 40 and < 55:
                AgeRunner.Text = "Возростная категория: 40 - 55";
                break;
            case >= 56 and < 70:
                AgeRunner.Text = "Возростная категория: 56 - 70";
                break;
            case > 70:
                AgeRunner.Text = "Возростная категория: >70";
                break;
        }
        
        
        
    }
}