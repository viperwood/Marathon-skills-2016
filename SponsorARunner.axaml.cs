using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
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
using Avalonia.Input;
using Avalonia.Threading;
using Timer = System.Timers.Timer;


namespace MarathonSkills2016;

public partial class SponsorARunner : Window
{
    private DispatcherTimer _disTimer = new DispatcherTimer();
    private int _sum = 50;
    private List<Runnerinf> _runnerinfs = Helper.Database.Runnerinfs.ToList();
    private int _contextComboBox;
    public SponsorARunner()
    {
        InitializeComponent();
        Namerunner();
        Events();
    }

    private void Events()
    {
        _disTimer.Interval = TimeSpan.FromSeconds(0);
        _disTimer.Tick += DispatcherTimer_Tick;
        _disTimer.Start();
        SumText.Text = $"{_sum}";
        SumText.KeyUp += SearchTextBoxOnKeyUp;
        RunerComboBox.SelectionChanged += RunerComboBoxSel;
    }

    private void RunerComboBoxSel(object? sender, SelectionChangedEventArgs e)
    {
        _contextComboBox = RunerComboBox.SelectedIndex;
        Fond.Text = _runnerinfs[_contextComboBox].Fundname;
        ButtonInf.IsVisible = true;
    }

    private void DispatcherTimer_Tick(object? sender, EventArgs e)
    {
        TimerMarafon timerMarafon = new TimerMarafon();
        Timers.Text = timerMarafon.Timer1();
    }

    private void SearchTextBoxOnKeyUp(object? sender, EventArgs e)
    {
        _sum = Convert.ToInt32(SumText.Text);
        if (_sum < 10)
        {
            _sum = 10;
            SumSpons.Text = $"${_sum}";
        }
        else
        {
            SumSpons.Text = $"${_sum}";
        }
    }
    

    private void Namerunner()
    {
        RunerComboBox.Items = _runnerinfs.Select(x => new
        {
            Namerun = $"{x.Lastname} {x.Firstname} - {x.Bibnumber} {x.Countrycode}"
        }).ToList();
    }
    
    
    
    
    
    
    private void Minus(object? sender, RoutedEventArgs e)
    {
        if (_sum > 10)
        {
            _sum -= 10;
            SumSpons.Text = $"${_sum}";
            SumText.Text = $"{_sum}";
        }
    }
    
    private void Plus(object? sender, RoutedEventArgs e)
    {
        _sum += 10;
        SumSpons.Text = $"${_sum}";
        SumText.Text = $"{_sum}";
    }

    private void Beack(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void Pay(object? sender, RoutedEventArgs e)
    {
        byte chak = 0;
        if (RunerComboBox.SelectedIndex == -1)
        {
            Runnerchak.Foreground = Brushes.Red;
            Runnerchak.Text = "Все поля обязательны!";
            chak += 1;
        }
        else
        {
            Runnerchak.Text = "";
        }
        
        if (UserName.Text == "" || UserName.Text == null)
        {
            UserNamechak.Foreground = Brushes.Red;
            UserNamechak.Text = "Все поля обязательны!";
            chak += 1;
        }
        else
        {
            UserNamechak.Text = "";
        }

        if (Owner.Text == "" || Owner.Text == null)
        {
            Ownerchak.Foreground = Brushes.Red;
            Ownerchak.Text = "Все поля обязательны!";
            chak += 1;
        }
        else
        {
            Ownerchak.Text = "";
        }

        if (Number.Text == "" || Number.Text == null)
        {
            Numberchak.Foreground = Brushes.Red;
            Numberchak.Text = "Все поля обязательны!";
            chak += 1;
        }
        else
        {
            if (Number.Text.Length == 16)
            {
                Numberchak.Text = "";
            }
            else
            {
                Numberchak.Foreground = Brushes.Red;
                Numberchak.Text = "Номер карты должен содержать 16 цифр!";
                chak += 1;
            }
        }

        if (Year.Text == "" || Day.Text == "" || Year.Text == null || Day.Text == null)
        {
            Yearchak.Foreground = Brushes.Red;
            Yearchak.Text = "Все поля обязательны!";
            chak += 1;
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
                    Yearchak.Text = "";
                }
                else
                {
                    Yearchak.Foreground = Brushes.Red;
                    Yearchak.Text = "Карта не действительна";
                    chak += 1;
                }
            }
        }

        if (CVC.Text == "" || CVC.Text == null)
        {
                CVCchak.Foreground = Brushes.Red;
                CVCchak.Text = "Все поля обязательны!";
                chak += 1;
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
                chak += 1;
            }
        }
        
        if (chak == 0)
        {
            SponsorshipConfirmation sponsorshipConfirmation = new SponsorshipConfirmation(_contextComboBox, _sum);
            sponsorshipConfirmation.Show();
            Close();
        }
    }

    private void Infowindow(object? sender, RoutedEventArgs e)
    {
        SponsorARunnerInfo sponsorARunnerInfo = new SponsorARunnerInfo(_contextComboBox);
        sponsorARunnerInfo.Show();
    }
}