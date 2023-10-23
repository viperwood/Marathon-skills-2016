using System;
using System.Timers;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MarathonSkills2016;

public partial class MainWindow : Window
{
    private static System.Timers.Timer aTimer;
    public MainWindow()
    {
        aTimer = new System.Timers.Timer(1000);
        InitializeComponent();
        aTimer.Elapsed += Timerblock;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }

    public void Timerblock(Object source, ElapsedEventArgs e)
    {
        TimerMarafon timerMarafon = new TimerMarafon();/*
        Timers.Text = timerMarafon.Timer1();*/
    }

    private void IHaveStateRuner(object? sender, RoutedEventArgs e)
    {
        
    }

    private void IHaveStateSponsor(object? sender, RoutedEventArgs e)
    {
        SponsorARunner sponsorARunner = new SponsorARunner();
        sponsorARunner.Show();
        Close();
    }

    private void MoreInform(object? sender, RoutedEventArgs e)
    {
        
    }

    private void Login(object? sender, RoutedEventArgs e)
    {
        
    }
}