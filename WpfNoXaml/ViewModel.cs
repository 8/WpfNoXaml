using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfNoXaml
{
  class ViewModel : BasePropertyChanged
  {
    #region Server
    private string _Server;
    public string Server
    {
      get { return _Server; }
      set
      {
        if (_Server != value)
        {
          _Server = value;
          OnPropertyChanged(nameof(Server));
        }
      }
    }
    #endregion

    #region Format
    private string _Format;
    public string Format
    {
      get { return _Format; }
      set
      {
        if (_Format != value)
        {
          _Format = value;
          OnPropertyChanged(nameof(Format));
        }
      }
    }
    #endregion

    readonly BehaviorSubject<bool> processing;
    public IObservable<bool> IsProcessing { get { return this.processing; } }

    public ICommand StartCommand { get; }

    public ViewModel()
    {
      this.processing = new BehaviorSubject<bool>(false);
      this.StartCommand = new AsyncObservableCommand(_ => Process(), this.IsProcessing.Select(isProcessing => !isProcessing));
    }

    async Task Process()
    {
      this.processing.OnNext(true);
      await Task.Delay(3000);
      this.processing.OnNext(false);
    }
  }
}
