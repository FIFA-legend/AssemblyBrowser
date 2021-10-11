using AssemblyBrowserLib.Levels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace lab3.View
{
    public class AppView : INotifyPropertyChanged
    {
        private List<NamespaceView> _namespaces;

        public List<NamespaceView> Namespaces
        {
            get { return _namespaces; }
            set
            {
                _namespaces = value;
                OnPropertyChanged("Namespaces");
            }
        }

        private Command _openFile;

        public Command OpenFile
        {
            get
            {
                return _openFile ??= new Command(obj =>
                {
                    IDialogService dialogService = new DialogService();
                    if (!dialogService.Open()) return;
                    try
                    {
                        Namespaces =
                            new AssemblyLevel(dialogService.FilePath).Namespaces.ConvertAll(assemblyNamespace =>
                                new NamespaceView(assemblyNamespace));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}