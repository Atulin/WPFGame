using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace GameishThing
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Ellipse player = new Ellipse();
        double posX = 0.0;
        double posY = 0.0;
        double speed = 5.0;
        double sprintMult = 2.0;
        bool isSprinting = false;
        Ellipse currentObjective = new Ellipse();
        List<Ellipse> enemies = new List<Ellipse>();
        int score = 0;

        public MainWindow()
        {
            InitializeComponent();

            player = new Ellipse
            {
                Width = 30,
                Height = 30,
                StrokeThickness = 2,
                Stroke = Brushes.DarkGreen,
                Fill = Brushes.Green
            };

            player.SetValue(Canvas.LeftProperty, posX);
            player.SetValue(Canvas.TopProperty, posY);
            
            Canvas.Children.Add(player);

            currentObjective = MakeObjective(Canvas);
            enemies.Add(MakeEnemy(Canvas));
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.W)
            {
                posY = posY <= 0 ? 0 : posY - speed;
            }

            if (e.Key == Key.S)
            {
                posY = posY >= Canvas.Height - player.Height ? Canvas.Height - player.Height : posY + speed;
            }

            if (e.Key == Key.A)
            {
                posX = posX <= 0 ? 0 : posX - speed;
            }

            if (e.Key == Key.D)
            {
                posX = posX >= Canvas.Width - player.Width ? Canvas.Width - player.Width : posX + speed;
            }
            
            if (Math.Abs(posX - Canvas.GetLeft(currentObjective)) < player.Width
                && Math.Abs(posY - Canvas.GetTop(currentObjective)) < player.Height
                && currentObjective != null)
            {
                Canvas.Children.Remove(currentObjective);
                currentObjective = null;
                score++;
                score_tb.Text = score.ToString();
                currentObjective = MakeObjective(Canvas);
                enemies.Add(MakeEnemy(Canvas));
            }

            foreach (var enemy in enemies)
            {
                if (Math.Abs(posX - Canvas.GetLeft(enemy)) < player.Width
                    && Math.Abs(posY - Canvas.GetTop(enemy)) < player.Height)
                {
                    score--;
                    score_tb.Text = score.ToString();
                }
            }

            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                isSprinting = !isSprinting;
                speed = isSprinting ? speed *= sprintMult : speed /= sprintMult;
                player.Fill = isSprinting ? Brushes.Teal : Brushes.Green;
            }

            Canvas.SetTop(player, posY);
            Canvas.SetLeft(player, posX);
        }

        public static Ellipse MakeObjective(Canvas canvas)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            var objective = new Ellipse
            {
                Uid = "obj",
                Width = 25,
                Height = 25,
                StrokeThickness = 2,
                Stroke = Brushes.Gold,
                Fill = Brushes.Yellow
            };

            double randX = rnd.NextDouble() * canvas.Width - objective.Width;
            double randY = rnd.NextDouble() * canvas.Height - objective.Height;

            objective.SetValue(Canvas.LeftProperty, randX);
            objective.SetValue(Canvas.TopProperty, randY);
            canvas.Children.Add(objective);

            return objective;
        }

        public static Ellipse MakeEnemy(Canvas canvas)
        {
            var rnde = new Random(Guid.NewGuid().GetHashCode());

            var enemy = new Ellipse
            {
                Uid = "en",
                Width = 20,
                Height = 20,
                StrokeThickness = 2,
                StrokeDashArray = new DoubleCollection(new double[] {1.0, 2.0, 3.0, 2.0}),
                Stroke = Brushes.DarkRed,
                Fill = Brushes.Red
            };

            double randX = rnde.NextDouble() * canvas.Width - enemy.Width;
            double randY = rnde.NextDouble() * canvas.Height - enemy.Height;

            enemy.SetValue(Canvas.LeftProperty, randX);
            enemy.SetValue(Canvas.TopProperty, randY);
            canvas.Children.Add(enemy);

            return enemy;
        }

    }
}
