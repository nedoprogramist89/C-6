public class SelectionItemViewModel : ObservableObject
{
    private SelectionItem _item;

    public string Title
    {
        get => _item.Title;
        set => _item.Title = value;
    }

    public string IconPath
    {
        get => _item.IconPath;
        set => _item.IconPath = value;
    }

    public bool IsSelected
    {
        get => _item.IsSelected;
        set => SetField(ref _item._isSelected, value);
    }

    public SelectionItemViewModel(SelectionItem item)
    {
        _item = item;
    }
}