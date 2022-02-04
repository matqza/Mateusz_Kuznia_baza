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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            InsertWindow okno = new InsertWindow();
            okno.ShowDialog();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow okno = new UpdateWindow();
            okno.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteWindow okno = new DeleteWindow();
            okno.ShowDialog();
        }

        private void Raport_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Generalne chciałem dodać raport ręcznie poprzez instalowanie czegoś do Visuala, lecz po kilkukrotnej próbie instalacji Visual dalej nie widział tego więc się poddałem");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Connection connection = new();
            SqlCommand cmd = new("select * from FirstTable WHERE ID ='" + search.Text + "' ", connection.con);
            DataTable dt = new();
            connection.con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            connection.con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        public void LoadGrid()
        {
            Connection connection = new();
            SqlCommand cmd = new("select * from FirstTable", connection.con);
            DataTable dt = new();
            connection.con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            connection.con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        private void refresh(object sender, RoutedEventArgs e)
        {
            LoadGrid();
        }
    }
}
