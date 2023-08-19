using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        MainWindow Mw3;
        private SqlConnection conn = null;
        SqlDataAdapter da1 = null, da2 = null, da3 = null;
        DataSet set1 = null, set2 = null, set3 = null;
        SqlCommandBuilder cmd1 = null, cmd2 = null, cmd3 = null;
        string cs = "";
        public Window3(MainWindow w3)
        {
            InitializeComponent();
            Mw3 = w3;
            conn = new SqlConnection();
            cs = @" Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = English; Integrated Security = SSPI;";
            conn.ConnectionString = cs; 
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                set2 = new DataSet();
                string sql = "select * from Words;";
                da2 = new SqlDataAdapter(sql, conn);
                Words.ItemsSource = null;
                cmd2 = new SqlCommandBuilder(da2);
                da2.Fill(set2, "mywords");
                set2.Tables[0].TableName = "Words";

                DataView Source = new DataView(set2.Tables["Words"]);
                Words.Items.Refresh();
                Words.ItemsSource = Source;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                set3 = new DataSet();
                string sql = "select * from Items;";
                da3 = new SqlDataAdapter(sql, conn);
                Items.ItemsSource = null;
                cmd3 = new SqlCommandBuilder(da3);
                da3.Fill(set3, "myItems");
                set3.Tables[0].TableName = "Items";

                DataView Source = new DataView(set3.Tables["Items"]);
                Items.Items.Refresh();
                Items.ItemsSource = Source;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                set1 = new DataSet();
                string sql = "select * from Topic;";
                da1 = new SqlDataAdapter(sql, conn);
                Topic.ItemsSource = null;
                cmd1 = new SqlCommandBuilder(da1);
                da1.Fill(set1, "mytopic");
                set1.Tables[0].TableName = "Topic";

                DataView Source = new DataView(set1.Tables["Topic"]);
                Topic.Items.Refresh();
                Topic.ItemsSource = Source;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }
    }
}
