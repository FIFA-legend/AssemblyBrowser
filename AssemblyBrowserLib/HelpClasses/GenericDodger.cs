using System;

namespace AssemblyBrowserLib.HelpClasses
{
    internal static class GenericDodger
    {
        internal static string GetName(Type type)
        {
            return type.IsGenericType ? GetGenericName(type) : type.Name;
        }

        private static string GetGenericName(Type type)
        {
            string typeName = "";
            string tmp = type.GetGenericTypeDefinition().Name;
            int ind = tmp.LastIndexOf('`');
            typeName += tmp.Substring(0, ind) + "<";
            Type[] argTypes = type.GetGenericArguments();
            foreach (Type argType in argTypes)
            {
                if (argType.IsGenericType)
                    typeName += GetName(argType) + ", ";
                else
                    typeName += argType.Name + ", ";
            }

            typeName = typeName.Substring(0, typeName.Length - 2) + ">";
            return typeName;
        }
    }
}