using System.Windows;
using System.Windows.Controls;

namespace WpfNoXaml
{
  public static class UIElementExtensions
  {
    public static T SetColumn<T>(this T uiElement, int column) where T: UIElement
    {
      Grid.SetColumn(uiElement, column);
      return uiElement;
    }

    public static T SetRow<T>(this T uiElement, int row) where T: UIElement
    {
      Grid.SetRow(uiElement, row);
      return uiElement;
    }
  }
}
