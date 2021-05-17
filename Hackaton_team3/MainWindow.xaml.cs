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

namespace Hackaton_team3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Core _core;
        private Point _point;
        private List<Point> _points;

        public MainWindow()
        {

            InitializeComponent();
            _core = Core.GetCore();
            _core.CurrentTournament = Tournament.Create("Name", 8, new DateTime(), new DateTime());
            MatchListForDrawing.ItemsSource = _core.CurrentTournament.Matches;
        }

        private void Button_Autorisation_Window_Click(object sender, RoutedEventArgs e)
        {
            AutorisationWindow autorisationWindow = new AutorisationWindow();
            autorisationWindow.Show();
            this.Hide();
        }

        private void Button_Tournament_Window_Click(object sender, RoutedEventArgs e)
        {
            TournamentCreator tournamentCreator = new TournamentCreator();
            tournamentCreator.Show();
            this.Hide();
        }

        private void Button_Participant_Windows_Click(object sender, RoutedEventArgs e)
        {
            ParticipantWindow participantWindow = new ParticipantWindow();
            participantWindow.Show();
            this.Hide();
        }
    }
}
