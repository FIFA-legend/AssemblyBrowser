using System;
using System.Collections.Generic;
using System.Reflection;
using AssemblyBrowserLib.HelpClasses;
using static AssemblyBrowserLib.HelpClasses.CompilerDodger;

namespace AssemblyBrowserLib.Levels
{
    public class ClassLevel
    {
        private string Name { get; }
        private Type Type { get; }
        public List<FieldLevel> Fields { get; }
        public List<PropertyLevel> Properties { get; }
        public List<MethodLevel> Methods { get; }

        internal ClassLevel(Type type)
        {
            Type = type;
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static |
                                 BindingFlags.Instance | BindingFlags.DeclaredOnly;
            Name = GenericDodger.GetName(type);
            Properties = GetProperties(type.GetProperties(flags));
            Fields = GetFields(type.GetFields(flags));
            Methods = GetMethods(type.GetMethods(flags));
        }

        private List<MethodLevel> GetMethods(MemberInfo[] members)
        {
            List<MethodLevel> list = new List<MethodLevel>();
            foreach (MemberInfo member in members)
            {
                if (!IsCompilerGenerated(member))
                    list.Add(new MethodLevel((MethodInfo) member));
            }

            return list;
        }

        private List<FieldLevel> GetFields(MemberInfo[] members)
        {
            List<FieldLevel> list = new List<FieldLevel>();
            foreach (MemberInfo member in members)
            {
                if (!IsCompilerGenerated(member))
                    list.Add(new FieldLevel((FieldInfo) member));
            }

            return list;
        }

        private List<PropertyLevel> GetProperties(MemberInfo[] members)
        {
            List<PropertyLevel> list = new List<PropertyLevel>();
            foreach (MemberInfo member in members)
            {
                if (!IsCompilerGenerated(member))
                    list.Add(new PropertyLevel((PropertyInfo) member));
            }

            return list;
        }

        public string GetFullName()
        {
            return Modifiers.GetClassModifiers(Type) + Name;
        }
    }
}