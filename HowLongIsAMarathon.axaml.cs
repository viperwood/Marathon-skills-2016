using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Shared.PlatformSupport;
using Avalonia.Threading;

namespace MarathonSkills2016;

public partial class HowLongIsAMarathon : Window
{
    private DispatcherTimer _timer = new DispatcherTimer();
    public HowLongIsAMarathon()
    {
        InitializeComponent();
        _timer.Interval= TimeSpan.FromSeconds(0);
        _timer.Tick += TimerClick;
        _timer.Start();
    }

    private void TimerClick(object? sender, EventArgs e)
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

    private void Paragraph1(object? sender, RoutedEventArgs e)
    {
        PhotoBlock.Text = "";
        PhotoImage.Source = new Bitmap(new AssetLoader().Open(new Uri("avares://MarathonSkills2016/PhotoFromHowLong/f1-car.jpg")));
        NameParagraph.Text = "F1 Car";
    }

    private void Paragraph2(object? sender, RoutedEventArgs e)
    {
        PhotoBlock.Text = "";
        PhotoImage.Source = new Bitmap(new AssetLoader().Open(new Uri("avares://MarathonSkills2016/PhotoFromHowLong/slug.jpg")));
        NameParagraph.Text = "Slug";
    }

    private void Paragraph3(object? sender, RoutedEventArgs e)
    {
        PhotoBlock.Text = "";
        PhotoImage.Source = new Bitmap(new AssetLoader().Open(new Uri("avares://MarathonSkills2016/PhotoFromHowLong/horse.png")));
        /*PhotoImage.Source = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "PhotoFromHowLong/horse.png");*/
        NameParagraph.Text = "Horse";
    }

    private void Paragraph4(object? sender, RoutedEventArgs e)
    {
        PhotoBlock.Text = "";
        PhotoImage.Source = new Bitmap(new AssetLoader().Open(new Uri("avares://MarathonSkills2016/PhotoFromHowLong/sloth.jpg")));
        NameParagraph.Text = "Sloth";
    }

    private void Paragraph5(object? sender, RoutedEventArgs e)
    {
        PhotoBlock.Text = "";
        PhotoImage.Source = new Bitmap(new AssetLoader().Open(new Uri("avares://MarathonSkills2016/PhotoFromHowLong/capybara.jpg")));
        NameParagraph.Text = "Capybara";
    }

    private void Paragraph6(object? sender, RoutedEventArgs e)
    {
        PhotoBlock.Text = "";
        PhotoImage.Source = new Bitmap(new AssetLoader().Open(new Uri("avares://MarathonSkills2016/PhotoFromHowLong/jaguar.jpg")));
        NameParagraph.Text = "Jaguar";
    }

    private void Paragraph7(object? sender, RoutedEventArgs e)
    {
        PhotoBlock.Text = "";
        PhotoImage.Source = new Bitmap(new AssetLoader().Open(new Uri("avares://MarathonSkills2016/PhotoFromHowLong/worm.jpg")));
        NameParagraph.Text = "Worm";
    }
}