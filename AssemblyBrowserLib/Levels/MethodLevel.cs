using System.Reflection;
using AssemblyBrowserLib.HelpClasses;

namespace AssemblyBrowserLib.Levels
{
    public class MethodLevel
    {
        private readonly ParameterInfo[] _parameters;
        private string Name { get; }
        private string ReturnType { get; }
        private MethodInfo MethodInfo { get; }

        internal MethodLevel(MethodInfo method)
        {
            MethodInfo = method;
            Name = method.Name;
            ReturnType = GenericDodger.GetName(method.ReturnType);
            _parameters = method.GetParameters();
        }

        private string GetSignature(MethodLevel method)
        {
            string signature = "";
            signature += method.ReturnType + " " + method.Name + "(";
            if (method._parameters.Length == 0)
                return signature + ")";
            foreach (ParameterInfo p in method._parameters)
            {
                if (p.IsOut)
                    signature += "out ";
                signature += GenericDodger.GetName(p.ParameterType) + " " + p.Name + ", ";
            }

            while (signature.IndexOf('&') != -1)
            {
                signature = signature.Replace('&', ' ');
            }

            return signature.Substring(0, signature.Length - 2) + ")";
        }

        public string GetFullName()
        {
            return Modifiers.GetMethodModifiers(MethodInfo) + GetSignature(this);
            ;
        }
    }
}