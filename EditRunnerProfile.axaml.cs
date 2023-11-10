using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using MarathonSkills2016.Models;

namespace MarathonSkills2016;

public partial class EditRunnerProfile : Window
{
    private Runner _runners;
    private User _user;
    private List<Country> countriestable = Helper.Database.Countries.ToList();
    
    private DispatcherTimer _timer = new DispatcherTimer();
    
    
    public EditRunnerProfile()
    {
        InitializeComponent();
        _timer.Interval = TimeSpan.FromSeconds(0);
        _timer.Tick += TimerTick;
        _timer.Start();
        _email.Text = SaveUser.User[0].Email;
        CountryBox();
    }
    
private void CountryBox()
    {
        _contry.Items = countriestable.Select(x => new
        {
            CountryRunner = x.Countryname
        }).ToList();
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        TimerMarafon timerMarafon = new TimerMarafon();
        Timers.Text = timerMarafon.Timer1();
    }

    private readonly FileDialogFilter filefilter = new FileDialogFilter()
    {
        Extensions = new List<string>()
        {
            "png",
            "jpg",
            "jpeg"
        }
    };


    private async void SelectFileButton_Click(object? sender, RoutedEventArgs e)
    {
        //Открытие диологового окна
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filters?.Add(filefilter);
        string[]? result = await dialog.ShowAsync(this);
        //Если выбранный файл есть
        if (result != null)
        {
            //Создаем путь к файлу Images в папке дерриктории
            string combinFileName = Path.Combine(Directory.GetCurrentDirectory(), "Images\\");
            //Убираем из пути не нужную часть
            combinFileName = combinFileName.Replace("bin\\Debug\\net7.0\\","");
            //Берем имя выбранного файла
            string imageName = Path.GetFileName(result[0]);
            //Создаем путь для картинки в папке дерриктории
            string lastFilePath = Path.Combine(combinFileName, imageName);
            //Копирует файла в папку
            File.Copy(result[0],lastFilePath,true);
            //Перевод картинки в Avalonia ресурс и вывод ее за место текста
            using(var  memoryStream = new FileStream(result[0] , FileMode.Open))
            {
                Bitmap bit = new Bitmap(memoryStream);
                PhotoText.IsVisible = false;
                ImageServise.Source = bit;
            }

            _path.Text = imageName;
        }
    }
    /*Логика проверки введеных значение*/
    private void SaveButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        byte i = 0;
        if (_password.Text != null && _password.Text != "")
        {
            if (_password.Text.Length > 5)
            {
                
                if (_password.Text.IndexOf('!') != -1 ||
                    _password.Text.IndexOf('@') != -1 ||
                    _password.Text.IndexOf('#') != -1 ||
                    _password.Text.IndexOf('$') != -1 ||
                    _password.Text.IndexOf('%') != -1 ||
                    _password.Text.IndexOf('^') != -1)
                {
                    if (_password.Text.IndexOf('0') != -1 ||
                        _password.Text.IndexOf('1') != -1 ||
                        _password.Text.IndexOf('2') != -1 ||
                        _password.Text.IndexOf('3') != -1 ||
                        _password.Text.IndexOf('4') != -1 ||
                        _password.Text.IndexOf('5') != -1 ||
                        _password.Text.IndexOf('6') != -1 ||
                        _password.Text.IndexOf('7') != -1 ||
                        _password.Text.IndexOf('8') != -1 ||
                        _password.Text.IndexOf('9') != -1)
                    {
                        if (_password.Text.Any(c => char.IsLetter(c)) && _password.Text == _password.Text.ToUpper())
                        {
                        
                            _passwordchack.Text = "";
                            i += 1;
                        }
                        else
                        {
                            _passwordchack.Text = "Пароль должен содержать прописную букву";
                        }
                    }
                    else
                    {
                        _passwordchack.Text = "Пароль должен содержать цифру";
                    }
                }
                else
                {
                    _passwordchack.Text = "Пароль должен содержать один из следующих символов: ! @ # $ % ^";
                }
            }
            else
            {
                _passwordchack.Text = "Пароль должен быть бльше 5 символов";
            }
        }
        else
        {
            i += 2;
        }
        
        if (_password2.Text != null && _password2.Text != "")
        {
            _passwordchack2.Text = "";
            i += 1;
        }
        else
        {
            i += 2;
        }
        
        if (_name.Text != null && _name.Text != "")
        {
            _namechack.Text = "";
            i += 1;
        }
        else
        {
            _namechack.Text = "Все поля обязательны";
        }
        
        if (_fam.Text != null && _fam.Text != "")
        {
            _famchack.Text = "";
            i += 1;
        }
        else
        {
            _famchack.Text = "Все поля обязательны";
        }
        
        if (_path.Text != null && _path.Text != "")
        {
            _pathchack.Text = "";
            i += 1;
        }
        else
        {
            _pathchack.Text = "Все поля обязательны";
        }
        
        if (_date.Text != null && _date.Text != "")
        {
            DateTime _datenow = DateTime.Now ;
            if (Convert.ToDateTime(_date.Text).AddYears(10) <= _datenow)
            {
                _datechack.Text = "";
                i += 1;
            }
            else
            {
                _datechack.Text = "Вы ввили не существующую дату или вым меньше 10 лет";
            }
        }
        else
        {
            _datechack.Text = "Все поля обязательны";
        }
        
        if (_contry.SelectedIndex != -1)
        {
            contrychack.Text = "";
            i += 1;
        }
        else
        {
            contrychack.Text = "Все поля обязательны";
        }

        if (i == 7)
        {
            
            if (_password.Text == _password2.Text)
            {
                _runners = Helper.Database.Runners.Find(SaveUser.Userinf[0].Runnerid);
                _user = Helper.Database.Users.Find(SaveUser.Userinf[0].Email);
                _runners.Imagerunner = $"Images\\{_path}";
                _runners.Email = _email.Text;
                _runners.Gender = _gender.SelectedIndex == 0 ? ("Male") : ("Female");
                _user.Email = _email.Text;
                _user.Password = _password.Text;
                _user.Firstname = _name.Text;
                _user.Roleid = 'R';
                _user.Lastname = _fam.Text;
                _runners.Dateofbirth = Convert.ToDateTime(_date.Text);
                _runners.Countrycode = countriestable[_contry.SelectedIndex].Countrycode;
                //Подгрузка в базу данных
                /*Helper.Database.Add(_runners);
                Helper.Database.Add(_user);*/
                //Сохранение базы данных
                Helper.Database.SaveChanges();
                //Закрыть
                RegisterAsARunner registerAsARunner = new RegisterAsARunner();
                registerAsARunner.Show();
                Close();
            }
            else
            {
                _passwordchack2.Text = "Пароли не совпадают";
                _passwordchack.Text = "Пароли не совпадают";
            }
            
        }
        else if (i == 9)
        {
            _runners = Helper.Database.Runners.Find(SaveUser.Userinf[0].Runnerid);
            _user = Helper.Database.Users.Find(SaveUser.Userinf[0].Email);
            _runners.Imagerunner = $"Images\\{_path}";
            _runners.Email = _email.Text;
            _runners.Gender = _gender.SelectedIndex == 0 ? ("Male") : ("Female");
            _user.Email = _email.Text;
            _user.Password = _password.Text;
            _user.Firstname = _name.Text;
            _user.Roleid = 'R';
            _user.Lastname = _fam.Text;
            _runners.Dateofbirth = Convert.ToDateTime(_date.Text);
            _runners.Countrycode = countriestable[_contry.SelectedIndex].Countrycode;
            //Подгрузка в базу данных
            /*Helper.Database.Add(_runners);
            Helper.Database.Add(_user);*/
            //Сохранение базы данных
            Helper.Database.SaveChanges();
            //Закрыть
            RegisterAsARunner registerAsARunner = new RegisterAsARunner();
            registerAsARunner.Show();
            Close();
        }
    }

    private void Beack(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void Cancel(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void Logout(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        SaveUser.User.Clear();
        mainWindow.Show();
        Close();
    }
}