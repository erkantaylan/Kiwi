using JetBrains.Annotations;
using Kiwi.Mvvm;
using Prism.Commands;

namespace Kiwi.Wpf.Demos.Dialogs
{
    [UsedImplicitly]
    public class SimpleMetroDialogViewModel : DialogViewModel<string, string>
    {
        private string myParameter;

        private string myValue;

        public string MyParameter
        {
            get => myParameter;
            set => SetProperty(ref myParameter, value);
        }

        public string MyValue
        {
            get => myValue;
            set => SetProperty(ref myValue, value);
        }

        public DelegateCommand SubmitCommand => new DelegateCommand(() =>
        {
            Close(MyValue);
        }, () => !string.IsNullOrWhiteSpace(MyValue)).ObservesProperty(() => MyValue);

        public DelegateCommand CloseCommand => new DelegateCommand(() =>
        {
            Close();
        });

        public override void OnDialogOpened(string parameter)
        {
            MyParameter = $"Incoming parameter is [{parameter}]";
        }
    }
}