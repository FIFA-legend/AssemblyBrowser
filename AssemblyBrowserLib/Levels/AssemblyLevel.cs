using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace AssemblyBrowserLib.Levels
{
    public class AssemblyLevel
    {
        public readonly List<NamespaceLevel> Namespaces;

        public AssemblyLevel(string path)
        {
            var assembly = Assembly.LoadFrom(path);
            Namespaces = new List<NamespaceLevel>();
            Type[] types;
            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null).ToArray();
            }

            Dictionary<string, List<Type>> namespacesToClasses = GetNCD(types);
            foreach (KeyValuePair<string, List<Type>> pair in namespacesToClasses)
            {
                Namespaces.Add(new NamespaceLevel(pair.Key, pair.Value));
            }
        }

        private Dictionary<string, List<Type>> GetNCD(Type[] types)
        {
            Dictionary<string, List<Type>> namespacesToClassesDictionary = new Dictionary<string, List<Type>>();
            foreach (Type type in types)
            {
                var name = type.Namespace ?? "<>";
                if (!namespacesToClassesDictionary.ContainsKey(name))
                {
                    List<Type> empty = new List<Type>();
                    namespacesToClassesDictionary.Add(name, empty);
                }

                namespacesToClassesDictionary.TryGetValue(name, out List<Type> classes);
                classes?.Add(type);
            }

            return namespacesToClassesDictionary;
        }
    }
}