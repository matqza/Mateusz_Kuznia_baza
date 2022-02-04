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
using System.Data.SqlClient;
using bazadanych;
using System.Data;

namespace Mateusz_Kuźnia_baza
{
    /// <summary>
    /// Logika interakcji dla klasy InsertWindow.xaml
    /// </summary>
    public partial class InsertWindow : Window
    {
        public InsertWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
 try
            {
                if (IsValid())
                {
                    Connection connection = new();
                    SqlCommand cmd = new("INSERT INTO FirstTable VALUES(@Name, @Type, @Level, @Base_dmg, @Total_dmg, @Description)", connection.con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", name.Text);
                    cmd.Parameters.AddWithValue("@Type", type.Text);
                    cmd.Parameters.AddWithValue("@Level", level.Text);
                    cmd.Parameters.AddWithValue("@Base_dmg", bdmg.Text);
                    cmd.Parameters.AddWithValue("@Total_dmg", tdmg.Text);
                    cmd.Parameters.AddWithValue("@Description", description.Text);

                    connection.con.Open();
                    cmd.ExecuteNonQuery();
                    connection.con.Close();
                    LoadGrid();
                    MessageBox.Show("Succesfully registred", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    Cleardata();

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadGrid()
        {
            MainWindow data = new();

            Connection connection = new();
            SqlCommand cmd = new("select * from FirstTable", connection.con);
            DataTable dt = new();
            connection.con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            connection.con.Close();
            data.datagrid.ItemsSource = dt.DefaultView;
        }


        private bool IsValid()
        {
            if (name.Text == string.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (type.Text == string.Empty)
            {
                MessageBox.Show("Type is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (level.Text == string.Empty)
            {
                MessageBox.Show("Level is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (bdmg.Text == string.Empty)
            {
                MessageBox.Show("bdmg is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (tdmg.Text == string.Empty)
            {
                MessageBox.Show("Tdmg is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (description.Text == string.Empty)
            {
                MessageBox.Show("Description is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public void Cleardata()
        {
            name.Clear();
            type.Clear();
            bdmg.Clear();
            tdmg.Clear();
            description.Clear();
            level.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
