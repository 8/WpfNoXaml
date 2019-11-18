using System;
using System.Windows.Input;
using System.Reactive.Linq;

namespace WpfNoXaml
{
  public class AsyncObservableCommand : ICommand
  {
    readonly Action<object> action;
    readonly IDisposable subscription;
    bool canExecute;
    public AsyncObservableCommand(Action<object> action, IObservable<bool> canExecute = null)
    {
      this.action = action;
      this.canExecute = canExecute is null;
      var e = new EventArgs();
      this.subscription = canExecute?.Subscribe(canExecute =>
      {
        this.canExecute = canExecute;
        OnCanExecuteChanged(e);
      });
    }

    public bool CanExecute(object parameter)
      => this.canExecute;

    public void Execute(object parameter)
      => this.action(parameter);

    public event EventHandler CanExecuteChanged;

    protected virtual void OnCanExecuteChanged(EventArgs e)
      => this.CanExecuteChanged?.Invoke(this, e);
  }
}
