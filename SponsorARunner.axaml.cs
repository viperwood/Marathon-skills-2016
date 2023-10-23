using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Timers;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using MarathonSkills2016.Models;
using Microsoft.EntityFrameworkCore;
using Timer = System.Threading.Timer;

namespace MarathonSkills2016;

public partial class SponsorARunner : Window
{
    public int sum = 50;
    public SponsorARunner()
    {
        InitializeComponent();
        System.Timers.Timer aTimer = new System.Timers.Timer(1000);
        aTimer.Elapsed += Timerblock;
        qwe();
    }

    public void qwe()
    {
        List<Runner> services = Helper.Database.Runners.ToList();
        
        RunerComboBox.Items = services.Select(x => new
        {
            Name = x.Runnerid
        });
        
        
        
        
        
        
    }
    
    
    
    public void Timerblock(Object source, ElapsedEventArgs e)
    {
        TimerMarafon timerMarafon = new TimerMarafon();
        Timers.Text = timerMarafon.Timer1();
    }

    private void Minus(object? sender, RoutedEventArgs e)
    {
        if (sum > 10)
        {
            sum -= 10;
            SumSpons.Text = $"${sum}";
            SumText.Text = $"{sum}";
        }
    }

    
    
    
    
    private void Plus(object? sender, RoutedEventArgs e)
    {
        sum += 10;
        SumSpons.Text = $"${sum}";
        SumText.Text = $"{sum}";
    }

    private void Beack(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void Pay(object? sender, RoutedEventArgs e)
    {
        if (UserName.Text == "" || UserName.Text == null)
        {
            UserNamechak.Foreground = Brushes.Red;
            UserNamechak.Text = "Все поля обязательны!";
        }
        else
        {
            UserNamechak.Text = "";
        }

        if (Owner.Text == "" || Owner.Text == null)
        {
            Ownerchak.Foreground = Brushes.Red;
            Ownerchak.Text = "Все поля обязательны!";
        }
        else
        {
            Ownerchak.Text = "";
        }

        if (Number.Text == "" || Number.Text == null)
        {
            Numberchak.Foreground = Brushes.Red;
            Numberchak.Text = "Все поля обязательны!";
        }
        else
        {
            Numberchak.Text = "";
        }

        if (Year.Text == "" || Day.Text == "" || Year.Text == null || Day.Text == null)
        {
            Yearchak.Foreground = Brushes.Red;
            Yearchak.Text = "Все поля обязательны!";
        }
        else
        {
            int monthe = Convert.ToInt32(Day.Text);
            int years = Convert.ToInt32(Year.Text);
            if (monthe < 13 && monthe > 0 && Year.Text.Length < 5)
            {
                DateTime date1 = new DateTime(years, monthe, 10, 10, 10, 10);
                int year = date1.Year;
                int month = date1.Month;
                if ((DateTime.Now.Year - year == 1 && DateTime.Now.Month - month == 0) || (DateTime.Now.Year - year == 0 &&
                        DateTime.Now.Month - month >= 0 && DateTime.Now.Month - month < 13))
                {
                    CVCchak.Text = "";
                }
                else
                {
                    Yearchak.Foreground = Brushes.Red;
                    Yearchak.Text = "Карта не действительна";
                }
            }
        }

        if (CVC.Text == "" || CVC.Text == null)
        {
                CVCchak.Foreground = Brushes.Red;
                CVCchak.Text = "Все поля обязательны!";
        }
        else
        {

            if (CVC.Text.Length == 3)
            {
                CVCchak.Text = "";
            }
            else
            {
                CVCchak.Foreground = Brushes.Red;
                CVCchak.Text = "CVC код должен содержать три цифры!"; 
            }
        }
    }
}