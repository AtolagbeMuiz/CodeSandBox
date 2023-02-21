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
     
        public void executeSandboxer(string selectedUntrustedfilePath, string untrustedAssembly, string untrustedClass,
                                                        string entryPoint, PermissionSet permissionSet, params Object[] parameters)
        // public void executeSandboxer(string selectedUntrustedfilePath)

        {

            //Setting the AppDomainSetup. It is very important to set the ApplicationBase to a folder
            //other than the one in which the sandboxer resides.
            AppDomainSetup adSetup = new AppDomainSetup();
            adSetup.ApplicationBase = Path.GetFullPath(selectedUntrustedfilePath);

            string untrustedCodeFilePath = adSetup.ApplicationBase;

            //We want the sandboxer assembly's strong name, so that we can add it to the full trust list.
            StrongName fullTrustAssembly = typeof(Sandboxer).Assembly.Evidence.GetHostEvidence<StrongName>();

            
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


        }

        public void ExecuteUntrustedCode(string assemblyName, string typeName, string entryPoint, string untrustedCodeFilePath, params Object[] parameters)
        {
            //Load the MethodInfo for a method in the new Assembly. This might be a method you know, or
            //you can use Assembly.EntryPoint to get to the main function in an executable.
            //Type[] test = Assembly.Load(assemblyName).GetTypes();

            //MethodInfo target = Assembly.Load(assemblyName).GetType(typeName).GetMethod(entryPoint);

            try
            {
                
                //MethodInfo target = Assembly.LoadFrom(untrustedCodeFilePath).GetType(typeName).GetMethod(entryPoint);
                
                //Loads the Assembly from the File Path and get the Type(Class) using Reflection
                var target = Assembly.LoadFrom(untrustedCodeFilePath).GetType(typeName);
                
                if(parameters != null)
                {
                    //Now invoke the method.
                    // bool retVal = (bool)target.Invoke(null, parameters);

                    //This invokes a method(entry point with argument)
                    target.GetMethod(entryPoint).Invoke(null, parameters);
                }
                else
                {
                    //This will invoke entry points (methods) that are parameterless, public and static
                    target.GetMethod(entryPoint, BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
                }

            }
            catch (Exception ex)
            {
                // When we print informations from a SecurityException extra information can be printed if we are
                //calling it with a full-trust stack.
                new PermissionSet(PermissionState.Unrestricted).Assert();
                Console.WriteLine("SecurityException caught:\n{0}", ex.ToString());

                MessageBox.Show(string.Format("{0}", ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error));

                CodeAccessPermission.RevertAssert();
                Console.ReadLine();
            }
        }

    }
}
