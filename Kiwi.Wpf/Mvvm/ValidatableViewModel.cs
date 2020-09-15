using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using Prism.Mvvm;

namespace Kiwi.Wpf.Mvvm
{
    public class ValidatableViewModel : BindableBase, IValidatableViewModel
    {
        /// <inheritdoc />
        public bool HasErrors => Errors?.Count > 0;

        /// <inheritdoc />
        public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();

        /// <inheritdoc />
        public IEnumerable GetErrors(string propertyName)
        {
            return Errors.FirstOrDefault(o => o.Key == propertyName).Value;
        }

        /// <inheritdoc />
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <inheritdoc />
        protected override bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            bool property = base.SetProperty(ref storage, value, propertyName);
            ValidateProperty(value, propertyName);
            return property;
        }

        /// <inheritdoc />
        protected override bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            bool property = base.SetProperty(ref storage, value, onChanged, propertyName);
            ValidateProperty(value, propertyName);
            return property;
        }

        private void ValidateProperty<T>(T value, [CallerMemberName] string propertyName = null)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);
            context.MemberName = propertyName;
            Validator.TryValidateProperty(value, context, results);

            if (results.Any())
            {
                Errors[propertyName] = results.Select(o => o.ErrorMessage).ToList();
            }
            else
            {
                Errors.Remove(propertyName);
            }

            RaisePropertyChanged(nameof(Errors));
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }

    public interface IValidatableViewModel : INotifyDataErrorInfo
    {
        Dictionary<string, List<string>> Errors { get; set; }
    }
}