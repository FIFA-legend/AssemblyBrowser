using AssemblyBrowserLib.HelpClasses;
using System.Reflection;

namespace AssemblyBrowserLib.Levels
{
    public class FieldLevel
    {
        private string Type { get; }
        private string Name { get; }
        private FieldInfo FieldInfo { get; }

        internal FieldLevel(FieldInfo field)
        {
            Type = GenericDodger.GetName(field.FieldType);
            Name = field.Name;
            FieldInfo = field;
        }

        public string GetFullName()
        {
            return Modifiers.GetFieldModifiers(FieldInfo) + Type + " " + Name;
        }
    }
}
