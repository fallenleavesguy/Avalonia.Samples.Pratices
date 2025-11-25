using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ReactiveUI;

namespace ValidationSample.ViewModels;

public class ValidationUsingINotifyDataErrorInfoViewModel: ViewModelBase, INotifyDataErrorInfo
{
    private string? E
    public IEnumerable GetErrors(string? propertyName)
    {
        if (string.IsNullOrEmpty(propertyName))
        {
            return errors.Values.SelectMany(static errors => errors);
        }

        if (this.errors.TryGetValue(propertyName, out var result))
        {
            return result;
        }

        return Array.Empty<ValidationResult>();
    }

    public bool HasErrors => errors.Count > 0;
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
    private Dictionary<string, List<ValidationResult>> errors = new();

    protected void ClearErrors(string? propertyName = null)
    {
        if (string.IsNullOrEmpty(propertyName))
        {
            errors.Clear();
        }
        else
        {
            errors.Remove(propertyName);
        }
        
        ErrorsChanged?.Invoke(this, new(propertyName));
        this.RaisePropertyChanged(nameof(HasErrors));
    }

    protected void AddError(string propertyName, string errorMessage)
    {
        if (!errors.TryGetValue(propertyName, out var propertyErrors))
        {
            propertyErrors = new();
            errors.Add(propertyName, propertyErrors);
        }
        
        propertyErrors.Add(new(errorMessage));
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        this.RaisePropertyChanged(nameof(HasErrors));
    }
}