using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WpfNoXaml
{
  class Program
  {
    ViewModel GetViewModel()
      => new ViewModel
      {
         Server = "localhost",
         Format = "JSON"
      };

    Window GetWindow()
      => new Window
      {
        Content = new Grid
        {
          ColumnDefinitions = {
              new ColumnDefinition { Width = GridLength.Auto },
              new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            },
          RowDefinitions = {
              new RowDefinition { Height = GridLength.Auto },
              new RowDefinition { Height = GridLength.Auto },
              new RowDefinition { Height = GridLength.Auto },
            },
          Children = {
              new Label { Content = "Server" },
              new TextBox { }
                .SetColumn(1)
                .Bind(TextBox.TextProperty, nameof(ViewModel.Server)),
              new Label { Content = "Format" }.SetRow(1),
              new ComboBox { Items = { "CSV", "JSON" } }
                .Bind(ComboBox.SelectedItemProperty, nameof(ViewModel.Format))
                .SetRow(1).SetColumn(1),
              new Button { Content = "Start Processing" }
                .Bind(Button.CommandProperty, nameof(ViewModel.StartCommand))
                .SetRow(2).SetColumn(1),
            }
        }
      };

    public void Run()
    {
      var window = GetWindow();
      var vm = GetViewModel();

      window.DataContext = vm;

      window.ShowDialog();

      Debug.WriteLine($"Format: {vm.Format}, Server: {vm.Server}");
    }
  }
}
