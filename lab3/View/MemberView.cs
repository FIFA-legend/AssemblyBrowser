using AssemblyBrowserLib.Levels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab3.View
{
    public class MemberView
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public MemberView(FieldLevel field)
        {
            FullName = field.GetFullName();
        }

        public MemberView(PropertyLevel prop)
        {
            FullName = prop.GetFullName();
        }

        public MemberView(MethodLevel method)
        {
            FullName = method.GetFullName();
        }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
