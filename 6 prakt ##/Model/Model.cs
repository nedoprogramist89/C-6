using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}

public class SelectionItem : ObservableObject
{
    private string _title;
    private string _iconPath;
    private bool _isSelected;

    public string Title
    {
        get => _title;
        set => SetField(ref _title, value);
    }

    public string IconPath
    {
        get => _iconPath;
        set => SetField(ref _iconPath, value);
    }

    public bool IsSelected
    {
        get => _isSelected;
        set => SetField(ref _isSelected, value);
    }
}

public class DayItem : ObservableObject
{
    private DateTime _date;
    private List<SelectionItem> _selections = new List<SelectionItem>();

    public DateTime Date
    {
        get => _date;
        set => SetField(ref _date, value);
    }

    public List<SelectionItem> Selections
    {
        get => _selections;
        set => SetField(ref _selections, value);
    }
}