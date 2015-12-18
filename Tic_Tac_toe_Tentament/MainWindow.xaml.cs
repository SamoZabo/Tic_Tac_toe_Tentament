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

namespace Tic_Tac_Toe_Tentament
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button[] _buttonArray;
        private bool _isGameOver = false;
        private bool _isX = true;
        public MainWindow()
        {
            InitializeComponent();
            _buttonArray = new Button[9] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            for (int i = 0; i < 9; i++)
                _buttonArray[i].Click += ClickHandler;
        }

        private void ClickHandler(object sender, EventArgs e)
        {
            Button tempButton = (Button)sender;

            if (this._isGameOver)
            {
                MessageBox.Show("Game Over... Go to File --> new game for a new game!",
                                "Game Over", MessageBoxButton.OK);
                return;
            }

            if (tempButton.Content != null)
            {
                MessageBox.Show("Button already has value!", "Ops!", MessageBoxButton.OK);
                return;
            }

            if (_isX)
                tempButton.Content = "X";
            else
                tempButton.Content = "O";

            _isX = !_isX;
            _isGameOver = CheckTheWinner(_buttonArray);
        }

        static private int[,] Winners = new int[,]
        {
            {0,1,2},
            {3,4,5},
            {6,7,8},
            {0,3,6},
            {1,4,7},
            {2,5,8},
            {0,4,8},
            {2,4,6}
        };

        static public bool CheckTheWinner(Button[] myControls)
        {
            bool _isGameOver = false;
            for (int i = 0; i < 8; i++)
            {
                int a = Winners[i, 0], b = Winners[i, 1], c = Winners[i, 2];
                Button b1 = myControls[a], b2 = myControls[b], b3 = myControls[c];

                if (b1.Content == null || b2.Content == null || b3.Content == null)
                    continue;

                if (b1.Content == b2.Content && b2.Content == b3.Content)
                {
                    b1.Background = b2.Background = b3.Background = Brushes.Brown;
                    _isGameOver = true;
                    break;
                }
            }
            return _isGameOver;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            for (int i = 0; i < 9; i++)
            {
                _buttonArray[i].Content = null;
                _buttonArray[i].Background = (Brush)bc.ConvertFrom("#FFDDDDDD");
            }
            _isX = true;
            _isGameOver = false;

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
