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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        MainWindow Mw2;
        private string[] correctTranslations = { "Собака", "Будинок" };
        private string[] englishWords = { "Dog", "House" };
        private int correctCount = 0;
        public Window2(MainWindow w2)
        {
            InitializeComponent();
            Mw2 = w2;
            englishLabel1.Content = "English Word: " + englishWords[0];
            englishLabel2.Content = "English Word: " + englishWords[1];
        }
        private void CheckTranslations_Click(object sender, RoutedEventArgs e)
        {
            string selectedTranslation1 = GetSelectedTranslation(option1_1, option1_2, option1_3);
            string selectedTranslation2 = GetSelectedTranslation(option2_1, option2_2, option2_3);



            if (selectedTranslation1 == correctTranslations[0])
                correctCount++;
            if (selectedTranslation2 == correctTranslations[1])
                correctCount++;



            if (correctCount == 2)
            {
                MessageBox.Show("All translations are correct!");
            }
            else
            {
                MessageBox.Show("Some translations are incorrect. Please try again.");
            }



            MessageBox.Show("Your score: " + correctCount + " / 2");
            correctCount = 0; // Reset the count for next attempt
        }



        private string GetSelectedTranslation(params RadioButton[] options)
        {
            foreach (RadioButton option in options)
            {
                if (option.IsChecked == true)
                    return option.Content.ToString();
            }
            return "";
        }
    }
}
