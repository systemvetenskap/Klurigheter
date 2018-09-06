using Klurigheter.Models;
using Npgsql;
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
using static Klurigheter.Database.PgEngine;

namespace Klurigheter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            List<Player> players = new List<Player>();
            try
            {
                //int id =  SavePlayer(new Player() { Name = "Erik", Nickname = "Maestro" });
                //int id = SavePlayer2(new Player() { Name = "Erik", Nickname = "Maestro" });

                Player p;
                p = new Player() { Name = "Erik", Nickname = "Maestro123" };
                players.Add(p);
                p = new Player() { Name = "Erik", Nickname = "Maestro124" };
                players.Add(p);
                players = SavePlayers(players);
                //MessageBox.Show($"Spelaren är tillagd med id-nummer: {id}");
            }
            catch (PostgresException ex)
            {
                string errorMessage = ErrorMessage(ex);
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
