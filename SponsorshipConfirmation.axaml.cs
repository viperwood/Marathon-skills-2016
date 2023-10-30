using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using MarathonSkills2016.Models;

namespace MarathonSkills2016;

public partial class SponsorshipConfirmation : Window
{
    private DispatcherTimer _timer = new DispatcherTimer();
    public SponsorshipConfirmation()
    {
        InitializeComponent();
    }
    
    public SponsorshipConfirmation(int contextComboBoxId, int sum)
    {
        _timer.Interval = TimeSpan.FromSeconds(0);
        _timer.Tick += TimerTick;
        _timer.Start();
        InitializeComponent();
        List<Runnerinf> runnerinfs = Helper.Database.Runnerinfs.ToList();
        NameRunner.Text = (runnerinfs[contextComboBoxId].Lastname + " " + runnerinfs[contextComboBoxId].Firstname + "(" + runnerinfs[contextComboBoxId].Bibnumber + ") из " + runnerinfs[contextComboBoxId].Countrycode).ToString();
        CostRunner.Text = $"${sum.ToString()}";
        Fond.Text = runnerinfs[contextComboBoxId].Sponsorname;
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
}