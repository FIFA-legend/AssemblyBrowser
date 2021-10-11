using AssemblyBrowserLib.Levels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab3.View
{
    public class ClassView : INotifyPropertyChanged
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

        private List<MemberView> _members;
        public List<MemberView> Members
        {
            get { return _members; }
            set
            {
                _members = value;
                OnPropertyChanged("Members");
            }
        }

        public ClassView(ClassLevel classLevel)
        {
            Name = classLevel.GetFullName();
            List<MemberView> prop = classLevel.Properties.ConvertAll(p => new MemberView(p));
            List<MemberView> methods = classLevel.Methods.ConvertAll(m => new MemberView(m));
            List<MemberView> fields = classLevel.Fields.ConvertAll(f => new MemberView(f));
            fields.AddRange(prop);
            fields.AddRange(methods);
            Members = fields;
        }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
