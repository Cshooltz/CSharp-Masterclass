using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace WPF_09A
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            List<Match> matches = new List<Match>();
            matches.Add(new Match() { Team1 = "Bayern Munich", Team2 = "Real Madrid", Score1 = 3, Score2 = 2, Completion = 85 });
            matches.Add(new Match() { Team1 = "Billy", Team2 = "Sam", Score1 = 88, Score2 = 92, Completion = 20 });
            matches.Add(new Match() { Team1 = "Rodam Rockers", Team2 = "Spaceout Dancers", Score1 = 1, Score2 = 1, Completion = 56 });
            matches.Add(new Match() { Team1 = "US", Team2 = "Japan", Score1 = 6, Score2 = 7, Completion = 40 });

            lbMatches.ItemsSource = matches;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lbMatches.SelectedItem != null)
            {
                MessageBox.Show("Selected Match: "
                    + (lbMatches.SelectedItem as Match).Team1 + " "
                    + (lbMatches.SelectedItem as Match).Score1 + " "
                    + (lbMatches.SelectedItem as Match).Score2 + " "
                    + (lbMatches.SelectedItem as Match).Team2);
            }
        }
    }

    public class Match
    {
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int Completion { get; set; }
    }
}
