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
        List<Player> players = new List<Player>();

        private void AddPlayer(Player p)
        {
            players.Add(p);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //int id =  SavePlayer(new Player() { Name = "Erik", Nickname = "Maestro" });
                //id = SavePlayer2(new Player() { Name = "Erik", Nickname = "Maestro" });

                Player p;
                p = new Player() { Name = "Erik", Nickname = "Maestro126" };
                AddPlayer(p);
                p = new Player() { Name = "Erik", Nickname = "Maestro124" };
                AddPlayer(p);
                Adult a = new Adult();



                players = SavePlayers(players);
                //MessageBox.Show($"Spelaren är tillagd med id-nummer: {id}");
            }
            catch (PostgresException ex)
            {
                //string errorMessage = ErrorMessage(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            Papper p = new Papper();
            Databasskrivare db = new Databasskrivare();

            List<IWrite> minaKlubbkompisar = new List<IWrite>();
            minaKlubbkompisar.Add(p);
            minaKlubbkompisar.Add(db);

            foreach (var item in minaKlubbkompisar)
            {
                MessageBox.Show(item.Skriv("hej"));
            }
        }
    }
}
