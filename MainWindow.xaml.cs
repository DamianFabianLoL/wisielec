using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HangmanWpf
{
    public partial class MainWindow : Window
    {
        private HangmanGame game;

        public MainWindow()
        {
            InitializeComponent();
            game = new HangmanGame();
            UpdateWord();
            DrawHangman(0);
        }

        private void UpdateWord()
        {
            WordTextBlock.Text = game.GetMaskedWord();
            UsedLettersTextBlock.Text = "Użyte litery: " + string.Join(", ", game.UsedLetters);
            ResultTextBlock.Text = "";
            DrawHangman(game.Errors);
        }

        private void GuessButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LetterTextBox.Text))
            {
                char guess = char.ToLower(LetterTextBox.Text[0]);
                var result = game.Guess(guess);

                if (game.IsWon())
                {
                    ResultTextBlock.Text = "Gratulacje! Wygrałeś!";
                    LetterTextBox.IsEnabled = false;
                }
                else if (game.IsLost())
                {
                    ResultTextBlock.Text = "Przegrałeś! Szukane słowo: " + game.Word;
                    LetterTextBox.IsEnabled = false;
                }
                UpdateWord();
            }
            LetterTextBox.Text = "";
        }

        private void DrawHangman(int errors)
        {
            HangmanCanvas.Children.Clear();

            HangmanCanvas.Children.Add(new Line() { X1 = 10, Y1 = 90, X2 = 70, Y2 = 90, Stroke = Brushes.Black, StrokeThickness = 3 });
            HangmanCanvas.Children.Add(new Line() { X1 = 40, Y1 = 90, X2 = 40, Y2 = 10, Stroke = Brushes.Black, StrokeThickness = 3 });
            HangmanCanvas.Children.Add(new Line() { X1 = 40, Y1 = 10, X2 = 90, Y2 = 10, Stroke = Brushes.Black, StrokeThickness = 3 });
            HangmanCanvas.Children.Add(new Line() { X1 = 90, Y1 = 10, X2 = 90, Y2 = 25, Stroke = Brushes.Black, StrokeThickness = 3 });

            if (errors > 0) 
                HangmanCanvas.Children.Add(new Ellipse() { Width = 20, Height = 20, Stroke = Brushes.Black, StrokeThickness = 3, Margin = new Thickness(80,25,0,0) });
            if (errors > 1) 
                HangmanCanvas.Children.Add(new Line() { X1 = 90, Y1 = 45, X2 = 90, Y2 = 75, Stroke = Brushes.Black, StrokeThickness = 3 });
            if (errors > 2) 
                HangmanCanvas.Children.Add(new Line() { X1 = 90, Y1 = 50, X2 = 75, Y2 = 65, Stroke = Brushes.Black, StrokeThickness = 3 });
            if (errors > 3) 
                HangmanCanvas.Children.Add(new Line() { X1 = 90, Y1 = 50, X2 = 105, Y2 = 65, Stroke = Brushes.Black, StrokeThickness = 3 });
            if (errors > 4) 
                HangmanCanvas.Children.Add(new Line() { X1 = 90, Y1 = 75, X2 = 80, Y2 = 95, Stroke = Brushes.Black, StrokeThickness = 3 });
            if (errors > 5) 
                HangmanCanvas.Children.Add(new Line() { X1 = 90, Y1 = 75, X2 = 100, Y2 = 95, Stroke = Brushes.Black, StrokeThickness = 3 });
        }
    }
}