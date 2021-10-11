using AssemblyBrowserLib.Levels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab3.View
{
    public class NamespaceView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private List<ClassView> _classes;
        public List<ClassView> Classes
        {
            get { return _classes; }
            set
            {
                _classes = value;
                OnPropertyChanged("Classes");
            }
        }

        public NamespaceView(NamespaceLevel namespaceNode)
        {
            Name = namespaceNode.Name;
            Classes = namespaceNode.Classes.ConvertAll(classLevel => new ClassView(classLevel));
        }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
