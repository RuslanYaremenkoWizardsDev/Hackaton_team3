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
        private Point _point;
        private List<Point> _points;

        public MainWindow()
        {
            InitializeComponent();
        }

        public int GetAmountOfParticipants(ParticipantsAmount participantsAmount)
        {
        
            return (int)participantsAmount;
        }

        public List<Point> GetListOfBoxes (int amountParticipants, List<Match> matches, Point p, int margin)
        {
            int gridBoxesY = amountParticipants / 2;
            _points = new List<Point>(gridBoxesY);
            int gridBoxesX = 0;
            while (gridBoxesY!=1)
            {
                gridBoxesY /= 2;
                gridBoxesX++;
            }
            gridBoxesY = amountParticipants / 2;
            
            _point.X = p.X;
            _point.Y = p.Y;

            int x = margin;

            Point startPoint = new Point(_point.X, _point.Y);
            
            _points.Add(_point);
            

            int changeY = 2;

            for(int i=0;i<gridBoxesX;i++)
            {
                for(int j=0;j<gridBoxesY;j++)
                {
                    gridBoxesY /= 2;
                    _point.Y = changeY * _point.X;
                    _points.Add(_point);
                    changeY++;
                }

                startPoint.X = startPoint.X + 3 * x;
                startPoint.Y = +x;

            }

            return _points;
        }
    }
}
