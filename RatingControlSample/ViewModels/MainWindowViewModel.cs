using System.Dynamic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RatingControlSample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial int NumberOfStars { get; set; } = 6;
    
    [ObservableProperty]
    public partial int RatingValue { get; set; } = 2;
}