using System.Windows;

namespace WpfNoXaml
{
  public static class FrameworkElementExtensions
  {
    public static T Bind<T>(this T element, DependencyProperty dp, string binding) where T: FrameworkElement
    {
      element.SetBinding(dp, binding);
      return element;
    }
  }
}
