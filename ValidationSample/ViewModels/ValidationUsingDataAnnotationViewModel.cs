using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace ValidationSample.ViewModels;

public class ValidationUsingDataAnnotationViewModel: ViewModelBase
{
    private string? _EMail;

    [Required]
    [EmailAddress]
    public string? EMail
    {
        get => _EMail;
        set => this.RaiseAndSetIfChanged(ref _EMail, value);
    }
}