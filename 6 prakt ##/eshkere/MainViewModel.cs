public class MainViewModel : ObservableObject
{
    private readonly DataAccessService _dataService;
    private readonly NotificationService _notificationService;

    public MainViewModel(DataAccessService dataService, NotificationService notificationService)
    {
        _dataService = dataService;
        _notificationService = notificationService;
    }
}
