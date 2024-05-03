
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

public class MainViewModel : ObservableObject
{
    private ObservableCollection<DayItemViewModel> _days;
    private DateTime _currentMonth = DateTime.Now;

    public ObservableCollection<DayItemViewModel> Days
    {
        get => _days;
        set => SetField(ref _days, value);
    }

    public DateTime CurrentMonth
    {
        get => _currentMonth;
        set
        {
            if (SetField(ref _currentMonth, value))
            {
                UpdateCalendar();
            }
        }
    }

    public ICommand NextMonthCommand { get; }
    public ICommand PreviousMonthCommand { get; }

    public MainViewModel()
    {
        _days = new ObservableCollection<DayItemViewModel>();
        NextMonthCommand = new RelayCommand(NextMonth);
        PreviousMonthCommand = new RelayCommand(PrevMonth);
        UpdateCalendar();
    }

    private void NextMonth()
    {
        CurrentMonth = CurrentMonth.AddMonths(1);
    }

    private void PrevMonth()
    {
        CurrentMonth = CurrentMonth.AddMonths(-1);
    }

    private void UpdateCalendar()
    {
        _days.Clear();
        int daysCount = DateTime.DaysInMonth(CurrentMonth.Year, CurrentMonth.Month);
        for (int day = 1; day <= daysCount; day++)
        {
            _days.Add(new DayItemViewModel(new DateTime(CurrentMonth.Year, CurrentMonth.Month, day)));
        }
    }
}



