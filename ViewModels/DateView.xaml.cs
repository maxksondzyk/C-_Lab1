using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_1_Ksondzyk.Views.date
{
    /// <summary>
    /// Interaction logic for DateView.xaml
    /// </summary>
    public partial class DateView : UserControl
    {
        public DateView()
        {
            InitializeComponent();
        }
        private void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Birthday(sender, e);
        }
        private async void Birthday(object sender, SelectionChangedEventArgs e)
        {
            int ydiff = (DateTime.Now.Year - PickDate.SelectedDate.Value.Year) / 4;
            int ldays = ydiff * 366;
            TimeSpan res = (DateTime.Today - PickDate.SelectedDate.Value);
            int totdays = res.Days;
            totdays -= ldays;
            int years = ydiff + totdays / 365;
            if (DateTime.Today.DayOfYear.Equals(PickDate.SelectedDate.Value.DayOfYear))
            {
                MessageBox.Show("З днем народження!");
            }
            if (years > 135 || res.Days < 0)
            {
                MessageBox.Show("Некоректна дата!");
                SelectedDateTextBox.Text = "";
                EasternZodiac.Text = "";
                WesternZodiac.Text = "";
            }
            else
            {
                SelectedDateTextBox.Text = "Ваш вік: " + years.ToString();
                Zodiac(sender, e);
            }
        }
        private void Zodiac(object sender, SelectionChangedEventArgs e)
        {
            int year = PickDate.SelectedDate.Value.Year;
            int Day = PickDate.SelectedDate.Value.Day;
            String wres = PickDate.SelectedDate.Value.Month switch
            {
                3 => (Day >= 21 ? "Овен" : "Риби"),
                4 => (Day <= 20 ? "Овен" : "Телець"),
                5 => (Day <= 21 ? "Телець" : "Близнюки"),
                6 => (Day <= 21 ? "Близнюки" : "Рак"),
                7 => (Day <= 22 ? "Рак" : "Лев"),
                8 => (Day <= 23 ? "Лев" : "Діва"),
                9 => (Day <= 23 ? "Діва" : "Терези"),
                10 => (Day <= 23 ? "Терези" : "Скорпіон"),
                11 => (Day <= 22 ? "Скорпіон" : "Стрілець"),
                12 => (Day <= 21 ? "Стрілець" : "Козеріг"),
                1 => (Day <= 20 ? "Козеріг" : "Водолій"),
                2 => (Day <= 18 ? "Водолій" : "Риби"),
            };
            WesternZodiac.Text = "Ваш західний знак зодіаку: "+wres;

            String eres = (year % 12) switch
            {
                4 => "Щур",
                5 => "Бик",
                6 => "Тигр",
                7 => "Кролик",
                8 => "Дракон",
                9 => "Змія",
                10 => "Кінь",
                11 => "Вівця",
                0 => "Мавпа",
                1 => "Півень",
                2 => "Собака",
                3 => "Свиня",
            };
            EasternZodiac.Text = "Ваш східний знак зодіаку: " + eres;
        }
    }
}
