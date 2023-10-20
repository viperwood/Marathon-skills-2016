using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace MarathonSkills2016;

public partial class SponsorARunner : Window
{
    public int sum = 50;
    public SponsorARunner()
    {
        InitializeComponent();
        Timerblock();
        SumBox();
        SumText.Text = $"{sum}";
        
        
    }

    public void SumBox()
    {/*
        sum = Convert.ToInt32(SumText);*/
        
    }
    
    

    public void Timerblock()
    {
        Timers.Text = Timer.Timerstart;
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
            
            
                
                DateTime date1 = new DateTime(Convert.ToInt32(Year),Convert.ToInt32(Day), 20, 18, 30, 25);
                Yearchak.Text = date1.ToString();



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
                
            }
            else
            {
                CVCchak.Text = "";
            }
        }
    }
}