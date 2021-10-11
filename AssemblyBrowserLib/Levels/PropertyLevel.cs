using System.Reflection;
using AssemblyBrowserLib.HelpClasses;

namespace AssemblyBrowserLib.Levels
{
    public class PropertyLevel
    {
        private string Type { get; }
        private string Name { get; }
        private PropertyInfo PropertyInfo { get; }

        internal PropertyLevel(PropertyInfo property)
        {
            Type = GenericDodger.GetName(property.PropertyType);
            Name = property.Name;
            PropertyInfo = property;
        }

        public string GetFullName()
        {
            return Type + " " + Name + " { " + Modifiers.GetPropertyModifiers(PropertyInfo) + " }";
        }
    }
}
