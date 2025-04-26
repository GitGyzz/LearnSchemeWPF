using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Banana.ViewModels;

public class TimeRecordViewModel : ObservableObject
{
    public TimeSpan TimeSpan => TimeSpan.FromSeconds(Seconds);
    public string TimeSpanString => TimeSpan.ToString("g");
    public int Seconds { get; set; }
    
    public DispatcherTimer DTimer { get; }=new (){Interval = TimeSpan.FromSeconds(1)};

    public RelayCommand StartTimerCommand { get; }
    
    public RelayCommand PauseTimerCommand { get; }

    public TimeRecordViewModel()
    {
        StartTimerCommand = new RelayCommand(StartTimerButton);
        PauseTimerCommand = new RelayCommand(PauseTimerButton);
        DTimer.Tick += (sender, e) =>
        {
            Seconds += 1;
            OnPropertyChanged(nameof(TimeSpanString));
        };
    }

    public void StartTimerButton()
    {
        DTimer.Start();
    }

    public void PauseTimerButton()
    {
        DTimer.Stop();
    }
}