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
    /// Logika interakcji dla klasy UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Connection connection = new();
            connection.con.Open();
            SqlCommand cmd = new SqlCommand("update FirstTable set Name = '" + name.Text + "', Type = '" + type.Text + "', Level = '" + level.Text + "', Base_dmg = '" + bdmg.Text + "', Total_dmg = '" + tdmg.Text + "', Description = '" + description.Text + "' WHERE ID = '" + search.Text + "' ", connection.con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated successfully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.con.Close();
                Cleardata();
                LoadGrid();
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
