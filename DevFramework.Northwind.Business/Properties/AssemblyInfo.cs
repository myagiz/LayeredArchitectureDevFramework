using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DevFramework.Core.Aspect.PostSharp.ExceptionLogAspects;
using DevFramework.Core.Aspect.PostSharp.LogAspects;
using DevFramework.Core.Aspect.PostSharp.PerformanceAspect;
using DevFramework.Core.CrossCuttingCorners.Logging.Log4Net.Loggers;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("DevFramework.Northwind.Business")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("DevFramework.Northwind.Business")]
[assembly: AssemblyCopyright("Copyright ©  2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: LogAspect(typeof(DatabaseLogger),AttributeTargetTypes = "DevFramework.Northwind.Business.Concrete.Managers.*")]
[assembly: LogAspect(typeof(FileLogger),AttributeTargetTypes = "DevFramework.Northwind.Business.Concrete.Managers.*")]
[assembly: ExceptionLogAspect(typeof(DatabaseLogger),AttributeTargetTypes = "DevFramework.Northwind.Business.Concrete.Managers.*")]
[assembly: PerformanceCounterAspect(AttributeTargetTypes = "DevFramework.Northwind.Business.Concrete.Managers.*")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("088a24d0-8029-49d7-af19-4e0f3a54c146")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
