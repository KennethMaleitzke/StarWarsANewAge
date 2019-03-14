using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StarWarsANewAge.Models;
using StarWarsANewAge.DataLayer;
using StarWarsANewAge.BusinessLayer;

namespace StarWarsANewAge.PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerSetupView.xaml
    /// </summary>
    public partial class PlayerSetupView : Window
    {
        Player _player;

        public PlayerSetupView(Player player)
        {
            _player = player;

            InitializeComponent();

            SetupWindow();
        }

        private void SetupWindow()
        {
            List<string> races = Enum.GetNames(typeof(Character.RaceType)).ToList();
            List<string> jobTitles = Enum.GetNames(typeof(Player.JobTitleName)).ToList();
            JobTitleComboBox.ItemsSource = jobTitles;
            RaceComboBox.ItemsSource = races;

            ErrorMessageTextBlock.Visibility = Visibility.Hidden;
        }

        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";

            if (NameTextBox.Text == "")
            {
                errorMessage += "Player Name is required.\n";
            }
            else
            {
                _player.Name = NameTextBox.Text;
            }
            if (!int.TryParse(AgeTextBox.Text, out int age))
            {
                errorMessage += "Player Age is required and must be an integer.\n";
            }
            else
            {
                _player.Age = age;
            }

            return errorMessage == "" ? true : false;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;

            if (IsValidInput(out errorMessage))
            {
                Enum.TryParse(JobTitleComboBox.SelectionBoxItem.ToString(), out Player.JobTitleName jobTitle);
                Enum.TryParse(RaceComboBox.SelectionBoxItem.ToString(), out Player.RaceType race);

                _player.JobTitle = jobTitle;
                _player.Race = race;

                Visibility = Visibility.Hidden;
            }
            else
            {
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                ErrorMessageTextBlock.Text = errorMessage;
            }
        }

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
