using System;
using System.Runtime.Serialization;
using System.Windows;
using MahApps.Metro.Controls;

namespace Kiwi.Wpf
{
    public static class WindowHelper
    {
        public static MetroWindow GetMainWindow()
        {
            if (!(Application.Current.MainWindow is MetroWindow window))
            {
                throw new MainWindowIsNotMetroWindowException();
            }

            return window;
        }
    }

    [Serializable]
    public class MainWindowIsNotMetroWindowException : Exception
    {
        public MainWindowIsNotMetroWindowException() { }
        public MainWindowIsNotMetroWindowException(string message) : base(message) { }
        public MainWindowIsNotMetroWindowException(string message, Exception inner) : base(message, inner) { }

        protected MainWindowIsNotMetroWindowException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}