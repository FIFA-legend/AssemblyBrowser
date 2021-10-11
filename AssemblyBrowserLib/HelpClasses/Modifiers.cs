using System;
using System.Reflection;

namespace AssemblyBrowserLib.HelpClasses
{
    public static class Modifiers
    {
        public static string GetMethodModifiers(MethodInfo method)
        {
            string result = "";

            if (method.IsPrivate)
                result += "private ";
            if (method.IsFamily)
                result += "protected ";
            if (method.IsFamilyOrAssembly)
                result += "protected internal ";
            if (method.IsAssembly)
                result += "internal ";
            if (method.IsPublic)
                result += "public ";
            if (method.IsStatic)
                result += "static ";
            if (method.IsAbstract)
                result += "abstract ";
            if (method.IsVirtual)
                result += "virtual ";
            return result;
        }

        public static string GetClassModifiers(Type type)
        {
            string result = "";

            if (type.IsPublic)
                result += "public ";
            if (type.IsNestedPrivate)
                result += "private ";
            if (type.IsInterface)
                return result + "interface ";
            if (type.IsAbstract)
                result += "abstract ";
            if (type.IsNestedFamily)
                result += "protected ";
            return result;
        }

        public static string GetFieldModifiers(FieldInfo field)
        {
            string result = "";

            if (field.IsPrivate)
                result += "private ";
            if (field.IsFamily)
                result += "protected ";
            if (field.IsFamilyOrAssembly)
                result += "protected internal ";
            if (field.IsAssembly)
                result += "internal ";
            if (field.IsPublic)
                result += "public ";
            if (field.IsStatic)
                result += "static ";
            return result;
        }

        public static string GetPropertyModifiers(PropertyInfo prop)
        {
            string result = "";

            if (prop.CanRead)
                result += "public";
            else
                result += "private ";
            result += " get; ";
            if (prop.CanWrite)
                result += "public";
            else
                result += "private";
            result += " set;";
            return result;
        }
    }
}