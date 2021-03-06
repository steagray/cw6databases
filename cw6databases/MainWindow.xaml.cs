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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;

namespace cw6databases
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\cw6db.accdb");
        }

        private void dataButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }
            cn.Close();

            data += "----------\n";

            string query2 = "select AssetID from Assets";
            OleDbCommand cmd2 = new OleDbCommand(query2, cn);
            cn.Open();
            read = cmd2.ExecuteReader(); 
            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }
            cn.Close();

            data += "----------\n";

            string query3 = "select Description from Assets";
            OleDbCommand cmd3 = new OleDbCommand(query3, cn);
            cn.Open();
            read = cmd3.ExecuteReader();
            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }
            dataBlock.Text = data;
            cn.Close();
        }

        private void employeeButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }
            cn.Close();

            string query2 = "select [Last Name] from Employees";
            OleDbCommand cmd2 = new OleDbCommand(query2, cn);
            cn.Open();
            read = cmd2.ExecuteReader();
            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }
            cn.Close();

            string query3 = "select [First Name] from Employees";
            OleDbCommand cmd3 = new OleDbCommand(query3, cn);
            cn.Open();
            read = cmd3.ExecuteReader();
            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }
            employeeBlock.Text = data;
            cn.Close();
        }
    }
}
