using System;
using System.Collections.Generic;
using static AssemblyBrowserLib.HelpClasses.CompilerDodger;

namespace AssemblyBrowserLib.Levels
{
    public class NamespaceLevel
    {
        public readonly string Name;
        public List<ClassLevel> Classes { get; }

        internal NamespaceLevel(string space, List<Type> types)
        {
            Name = space;
            Classes = new List<ClassLevel>();
            foreach (Type type in types)
            {
                if (!IsCompilerGenerated(type)) Classes.Add(new ClassLevel(type));
            }
        }

        public string GetFullName()
        {
            return Name;
        }
    }
}