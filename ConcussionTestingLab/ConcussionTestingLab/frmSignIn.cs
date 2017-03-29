using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcussionTestingLab
{
    public partial class frmSignIn : Form
    {
        public static bool valid = false;
        public frmSignIn()
        {
            InitializeComponent();
        }

        private static void ReadFile(string ID, string name)
        {
            string line = "x";
            //string[] arrayField;
            TextReader streamData = null;
            string file = "../../Data/" + ID + "_" + name; // will store the file name as M#_Name.dat
            UserClass.User userObj = new UserClass.User();

            if (File.Exists(file + ".dat"))
            {
                try
                {
                    streamData = new StreamReader(file + ".dat");

                    while(streamData.Peek() > -1)
                    {
                        line = streamData.ReadLine();
                        userObj.userID = line.Trim();
                        line = streamData.ReadLine();
                        userObj.userName = line.Trim();
                    } // while()
                } // try
                
                catch (IOException err)
                {
                    MessageBox.Show(err.Message);
                    valid = false;
                } // catch

                finally
                {
                    if (streamData != null)
                        streamData.Close();
                    MessageBox.Show("Login successful!");
                    valid = true;
                } // finally
            } // endif

            else
            {
                MessageBox.Show("Invalid M# or Name.");
                valid = false;
            } // else
        } // ReadFile()

        private static void WriteFile(string ID, string name)
        {
            StreamWriter streamData = null;
            string file = "../../Data/" + ID + "_" + name; // will store the file name as M#_Name.dat

            if (!File.Exists(file + ".dat"))
            {
                try
                {

                    streamData = new StreamWriter(file + ".dat");

                    streamData.WriteLine(ID);
                    streamData.WriteLine(name);
                } // try

                catch (IOException err)
                {
                    MessageBox.Show(err.Message);
                } // catch

                finally
                {
                    // Close the file if it is not already closed
                    if (streamData != null)
                        streamData.Close();
                    MessageBox.Show("File has been written.");
                    valid = true;
                } // finally
            } // end if

            else
            {
                MessageBox.Show("This User already Exist!");
                valid = false;
            } // else
        } // WriteFile()

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // Will take the M# and Name entered into the text boxes and create a 
            // data file as "M#_Name.dat", this will later be used to check if the 
            // login credentials are valid.

            UserClass.User userObj = new UserClass.User();
            userObj.userID = tbMNumber.Text;
            userObj.userName = tbName.Text;
            WriteFile(userObj.userID, userObj.userName);

            if (valid == true)
            {
                //THIS event opens another form

                // Hide "this" current form
                this.Hide();

                // Create a new object that will represent the next form.
                frmUser frm = new frmUser();

                // Displays the other form using its object instance
                frm.Show();

                frm = null;
            } // endif
        } // btnSignUp_Click()

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            // Checks to see if M# and Name entered in the text boxes are valid
            // by checking for a file named "M#_Name.dat". If this file exist then
            // login is successful and then the next form will load.

            ReadFile(tbMNumber.Text, tbName.Text);

            if (valid == true)
            {
                //THIS event opens another form

                // Hide "this" current form
                this.Hide();

                // Create a new object that will represent the next form.
                frmUser frm = new frmUser();

                // Displays the other form using its object instance
                frm.Show();

                frm = null;
            } // endif
        }
    }
    
}
