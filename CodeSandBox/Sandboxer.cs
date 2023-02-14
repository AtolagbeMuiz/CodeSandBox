using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Runtime.Remoting;
using System.Security.Policy;
using System.Reflection;
using System.Windows.Forms;

namespace CodeSandBox
{
    class Sandboxer : MarshalByRefObject
    {
        ////const string pathToUntrusted = @"..\..\..\UntrustedCode\bin\Debug";
        //dynamic untrustedAssembly = "ConsoleApp1";
        //const string untrustedClass = "ConsoleApp1.UntrustedClass";
        //const string entryPoint = "IsFibonacci";
        //private static Object[] parameters = { 45 };

        // string untrustedCodeFilePath;


        public void executeSandboxer(string selectedUntrustedfilePath, string untrustedAssembly, string untrustedClass,
                                                        string entryPoint, Object[] parameters, PermissionSet permissionSet)
        // public void executeSandboxer(string selectedUntrustedfilePath)

        {

            //Setting the AppDomainSetup. It is very important to set the ApplicationBase to a folder
            //other than the one in which the sandboxer resides.
            AppDomainSetup adSetup = new AppDomainSetup();
            adSetup.ApplicationBase = Path.GetFullPath(selectedUntrustedfilePath);

            string untrustedCodeFilePath = adSetup.ApplicationBase;

            //We want the sandboxer assembly's strong name, so that we can add it to the full trust list.
            StrongName fullTrustAssembly = typeof(Sandboxer).Assembly.Evidence.GetHostEvidence<StrongName>();

            //PermissionSet permissionSet = new PermissionSet(PermissionState.None);
            ////permissionSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            //permissionSet.AddPermission(new FileIOPermission((PermissionState)FileIOPermissionAccess.Read));
            //permissionSet.AddPermission(new EnvironmentPermission((PermissionState)EnvironmentPermissionAccess.Read));


            //Now we have everything we need to create the AppDomain, so let's create it.
            AppDomain newDomain = AppDomain.CreateDomain("CodeSandBox", null, adSetup, permissionSet, fullTrustAssembly);



            //Use CreateInstanceFrom to load an instance of the Sandboxer class into the
            //new AppDomain.
            ObjectHandle handle = Activator.CreateInstanceFrom(
                newDomain, typeof(Sandboxer).Assembly.ManifestModule.FullyQualifiedName,
                typeof(Sandboxer).FullName
                );
            //Unwrap the new domain instance into a reference in this domain and use it to execute the
            //untrusted code.
            Sandboxer newDomainInstance = (Sandboxer)handle.Unwrap();

           
            newDomainInstance.ExecuteUntrustedCode(untrustedAssembly, untrustedClass, entryPoint, untrustedCodeFilePath, parameters);



            //var permssionSet = LoadPermissions();

            //if(permssionSet.Count > 0)
            //{
            //    foreach(var permisison in permssionSet)
            //    {
            //        checkBox1.Text = permisison.ToString();
            //        checkBox1.Name = permisison.ToString();
            //    }
            //}
        }

        public void ExecuteUntrustedCode(string assemblyName, string typeName, string entryPoint, string untrustedCodeFilePath, Object[] parameters)
        {
            //Load the MethodInfo for a method in the new Assembly. This might be a method you know, or
            //you can use Assembly.EntryPoint to get to the main function in an executable.
            //Type[] test = Assembly.Load(assemblyName).GetTypes();

            //MethodInfo target = Assembly.Load(assemblyName).GetType(typeName).GetMethod(entryPoint);

            try
            {
                MethodInfo target = Assembly.LoadFrom(untrustedCodeFilePath).GetType(typeName).GetMethod(entryPoint);

                //Now invoke the method.
                bool retVal = (bool)target.Invoke(null, parameters);
            }
            catch (Exception ex)
            {
                // When we print informations from a SecurityException extra information can be printed if we are
                //calling it with a full-trust stack.
                new PermissionSet(PermissionState.Unrestricted).Assert();
                Console.WriteLine("SecurityException caught:\n{0}", ex.ToString());

                MessageBox.Show(string.Format("{0} Permission Required!", ex.Message.ToString()));

                CodeAccessPermission.RevertAssert();
                Console.ReadLine();
            }
        }

    }
}
