using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using MarathonSkills2016.Models;
using Microsoft.EntityFrameworkCore;
using System.Timers;
using Avalonia.Threading;
using Timer = System.Timers.Timer;


namespace MarathonSkills2016;

public partial class SponsorARunner : Window
{
    private DispatcherTimer _disTimer = new DispatcherTimer();
    public int sum = 50;
    public SponsorARunner()
    {
        InitializeComponent();
        Namerunner();
        _disTimer.Interval = TimeSpan.FromSeconds(0);
        _disTimer.Tick += DispatcherTimer_Tick;
        _disTimer.Start();
        SumText.Text = $"{sum}";
        SumText.KeyUp += SearchTextBoxOnKeyUp;
    }
    
    private void DispatcherTimer_Tick(object? sender, EventArgs e)
    {
        TimerMarafon timerMarafon = new TimerMarafon();
        Timers.Text = timerMarafon.Timer1();
    }

    private void SearchTextBoxOnKeyUp(object? sender, EventArgs e)
    {
        sum = Convert.ToInt32(SumText.Text);
        if (sum < 10)
        {
            sum = 10;
            SumSpons.Text = $"${sum}";
        }
        else
        {
            SumSpons.Text = $"${sum}";
        }
    }

    private void Namerunner()
    {
        RunerComboBox.Items = Helper.Database.Runnerinf.Select(x => new
        {
            Namerun = x.Lastname + " " + x.Firstname
        }).ToList();
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
        if (RunerComboBox.SelectedIndex == -1)
        {
            Runnerchak.Foreground = Brushes.Red;
            Runnerchak.Text = "Все поля обязательны!";
        }
        else
        {
            Runnerchak.Text = "";
        }
        
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