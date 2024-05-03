using System.Collections.ObjectModel;
using System;

public class DayItemViewModel : ObservableObject
{
    private DayItem _dayItem;

    public DateTime Date => _dayItem.Date;
    public ObservableCollection<SelectionItemViewModel> Selections { get; }

    public DayItemViewModel(DateTime date)
    {
        _dayItem = new DayItem { Date = date };
        Selections = new ObservableCollection<SelectionItemViewModel>();
    }

    // Методы для добавления или изменения SelectionItem
    public void AddOrUpdateSelection(SelectionItem item)
    {
        var viewModel = Selections.FirstOrDefault(si => si.Title == item.Title);
        if (viewModel == null)
        {
            Selections.Add(new SelectionItemViewModel(item));
        }
        else
        {
            viewModel.IsSelected = item.IsSelected;
        }
    }
}
