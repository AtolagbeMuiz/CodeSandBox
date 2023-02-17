using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeSandBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            executeButton.Click += delegate (object sender, EventArgs e)
            {
                executeButton_Click(sender, e, filePathTextBox.Text,
                untrustedAssemblyTxt.Text, untrustedClassTxt.Text, entryPointTxt.Text, parameterTxt.Text);
            };

            //executeButton.Click += delegate (object sender, EventArgs e) { executeButton_Click(sender, e, filePathTextBox.Text); };


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            try
            {
                //creante an instance of the OpenFileDialog
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "exe files (*.exe)|*.exe* |dll files (*.dll)|*.dll* |All files (*.*)|*.*";
                dialog.InitialDirectory = @"C:\";
                string folderPath = dialog.InitialDirectory;
                dialog.Title = "Browse For Assembly Files";

                if (Directory.Exists(folderPath))
                {
                    dialog.ShowDialog();

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFileFromDialog = dialog.FileName;
                        filePathTextBox.Text = selectedFileFromDialog;
                    }

                }
                else
                {
                    MessageBox.Show(string.Format("{0} Directory does not exist!", folderPath));
                }



            }
            catch (Exception)
            {

                throw;
            }
           
        }

        //public PermissionSet LoadPermissions()
        //{
        //    try
        //    {

        //        PermissionSet permissionSet = new PermissionSet(PermissionState.None);
        //        //PermissionSet permissionSet = null;
        //        permissionSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
        //        permissionSet.AddPermission(new FileIOPermission((PermissionState)FileIOPermissionAccess.Read));
        //        permissionSet.AddPermission(new EnvironmentPermission((PermissionState)EnvironmentPermissionAccess.Read));

        //        return permissionSet;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}



        private void executeButton_Click(object sender, EventArgs e, string selectedfilePath,
                            string untrustedAssembly, string untrustedClass, string entryPoint, string parameters)

        // private void executeButton_Click(object sender, EventArgs e, string selectedfilePath)

        {
            try
            {
                Object[] parames = null;

                PermissionSet permissionSet = new PermissionSet(PermissionState.None);
                permissionSet.AddPermission(new EnvironmentPermission((PermissionState)EnvironmentPermissionAccess.Read));
               // permissionSet.AddPermission(new EnvironmentPermission((PermissionState)EnvironmentPermissionAccess.Write));

                if (executionAccesscheckBox.Checked)
                {
                    permissionSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));

                }
                if (readAccesscheckBox.Checked)
                {
                    permissionSet.AddPermission(new FileIOPermission((PermissionState)FileIOPermissionAccess.Read));
                }
                if (writeAccesscheckBox.Checked)
                {
                    permissionSet.AddPermission(new FileIOPermission((PermissionState)FileIOPermissionAccess.AllAccess));

                }
                Sandboxer sb = new Sandboxer();

                if(!String.IsNullOrEmpty(parameters))
                {
                    //parames = new Object[] { Convert.ToInt32(parameters) };
                    int parsedResult;
                    bool doubleResultTryParse = int.TryParse(parameters, out parsedResult);
                    if(doubleResultTryParse == true)
                    {
                        parames = new Object[] { parsedResult };

                    }
                    else
                    {
                        parames = new Object[] { parameters };

                    }

                }

                sb.executeSandboxer(selectedfilePath, untrustedAssembly, untrustedClass, entryPoint, permissionSet, parames);
                // sb.executeSandboxer(selectedfilePath);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}", ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error));

                throw;
            }
        }

       
    }
}
