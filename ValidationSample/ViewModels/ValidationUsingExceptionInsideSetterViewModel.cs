using System;
using ReactiveUI;

namespace ValidationSample.ViewModels;

public class ValidationUsingExceptionInsideSetterViewModel: ViewModelBase
{
    private string? _EMail;

    public string? EMail
    {
        get => _EMail;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(EMail), "This field is required.");
            }

            if (!value.Contains('@'))
            {
                throw new ArgumentException("Not a valid email address.", nameof(EMail));
            }
            
            this.RaiseAndSetIfChanged(ref _EMail, value);
        }
    }
}