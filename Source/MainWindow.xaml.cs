
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ImperiumGalacticaEditor
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public SavedGame SavedGame { get; set; }

    public MainWindow()
    {
      InitializeComponent();
      SavedGame = new SavedGame();
      DataContext = SavedGame;
      //SavedGame.Open(@"C:\Gry\Imperium\SAVE\SAVE1.SAV");
    }

    private void OpenBtn_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();
      dialog.InitialDirectory = @"C:\Gry\Imperium\SAVE\";
      if (dialog.ShowDialog(this).Value)
      {
        SavedGame.Open(dialog.FileName);
      }
    }

    void DrawPlanets()
    {
      //foreach (Planet planet in SavedGame.Planets)
      //{
      //  TextBlock a = new TextBlock();
      //  a.Text = planet.Name;
      //  //a.TextWrapping = TextWrapping.Wrap;
      //  //a.Width = 40;
      //  //a.Height = ;
      //  a.HorizontalAlignment = HorizontalAlignment.Left;
      //  a.VerticalAlignment = VerticalAlignment.Top;

      //  Thickness margin = a.Margin;
      //  margin.Left = planet.X;
      //  margin.Top = planet.Y;
      //  a.Margin = margin;

      //  SpaceGrd.Children.Add(a);
      //}
    }

    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
      SavedGame.Save();
    }

    private void StackPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      StackPanel pan = (StackPanel)sender;
      Planet p = (Planet)pan.Tag;
      PlanetsGrid.SelectedItem = p;
      PlanetsGrid.ScrollIntoView(p);
    }

    private void PlanetsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      foreach (Planet planet in PlanetsGrid.Items)
      {
        if (planet.IsSelected) planet.IsSelected = false;

        if (planet == PlanetsGrid.SelectedItem)
          planet.IsSelected = true;
      }
    }
  }
}
