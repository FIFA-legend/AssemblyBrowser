using System.Collections.Generic;
using AssemblyBrowserLib.Levels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AssemblyBrowserLibTests
    {
        private AssemblyLevel _assembly;
        private NamespaceLevel _namespace;
        private ClassLevel _class;

        private List<string> _expectedNamespaces;
        private List<string> _expectedClasses;
        private List<string> _expectedMethods;
        private List<string> _expectedProperties;
        private List<string> _expectedFields;

        [TestInitialize]
        public void Setup()
        {
            _expectedNamespaces = new List<string> { "AssemblyBrowserLib.Levels", "AssemblyBrowserLib.HelpClasses" };
            _expectedClasses = new List<string> { "public AssemblyLevel", "public ClassLevel", "public FieldLevel", "public MethodLevel", "public NamespaceLevel", "public PropertyLevel" };
            _expectedMethods = new List<string> { "private String GetSignature(MethodLevel method)", "public String GetFullName()" };
            _expectedProperties = new List<string> { "String Name { public get; private set; }", "String Type { public get; private set; }", "MethodInfo MethodInfo { public get; private set; }" };
            _expectedFields = new List<string> { "private ParameterInfo[] _parameters" };

            _assembly = new AssemblyLevel("AssemblyBrowserLib.dll");
            _namespace = _assembly.Namespaces.Find(ns => ns.GetFullName() == _expectedNamespaces[0]);
            _class = _namespace?.Classes.Find(cl => cl.GetFullName() == _expectedClasses[3]);
        }

        [TestMethod]
        public void NamespacesTest()
        {
            Assert.AreEqual(_expectedNamespaces.Count, _assembly.Namespaces.Count, "Wrong number of namespaces");
            foreach (NamespaceLevel space in _assembly.Namespaces)
            {
                if (_expectedNamespaces.Contains(space.GetFullName()))
                {
                    _expectedNamespaces.Remove(space.GetFullName());
                }
            }
            Assert.AreEqual(0,_expectedNamespaces.Count, "Namespaces don't equal to expected");
        }

        [TestMethod]
        public void ClassesTest()
        {
            Assert.AreEqual(_expectedClasses.Count, _namespace.Classes.Count, "Wrong number of classes");
            foreach (ClassLevel classLevel in _namespace.Classes)
            {
                if (_expectedClasses.Contains(classLevel.GetFullName()))
                {
                    _expectedClasses.Remove(classLevel.GetFullName());
                }
            }
            Assert.AreEqual(0, _expectedClasses.Count, "Class names don't equal to expected");
        }

        [TestMethod]
        public void FieldsTest()
        {
            Assert.AreEqual(_expectedFields.Count, _class.Fields.Count,  "Wrong number of fields");
            foreach (FieldLevel field in _class.Fields)
            {
                if (_expectedFields.Contains(field.GetFullName()))
                {
                    _expectedFields.Remove(field.GetFullName());
                }
            }
            Assert.AreEqual(0, _expectedFields.Count, "Field names don't equal to expected");
        }

        [TestMethod]
        public void PropertiesTest()
        {
            Assert.AreEqual(_expectedProperties.Count, _class.Properties.Count,  "Wrong number of properties");
            foreach (PropertyLevel prop in _class.Properties)
            {
                if (_expectedProperties.Contains(prop.GetFullName()))
                {
                    _expectedProperties.Remove(prop.GetFullName());
                }
            }
            Assert.AreEqual(0, _expectedProperties.Count, "Property names don't equal to expected");
        }

        [TestMethod]
        public void MethodsTest()
        {
            Assert.AreEqual(_expectedMethods.Count, _class.Methods.Count, "Wrong number of methods");
            foreach (MethodLevel method in _class.Methods)
            {
                if (_expectedMethods.Contains(method.GetFullName()))
                {
                    _expectedMethods.Remove(method.GetFullName());
                }
            }
            Assert.AreEqual(0 , _expectedMethods.Count, "Method names don't equal to expected");
        }
    }
}