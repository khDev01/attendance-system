// Attendance Register system 
// created: 13/08/19
// updated: 02/11/2019

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // added for saving to txt file
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendace1v1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        // Number of Students
        int noStudents = 6;

        private void Form1_Load(object sender, EventArgs e)
        {
          
            // Main cbox 
            comboAttend.Items.Add("P - Present");
            comboAttend.Items.Add("L - Late");
            comboAttend.Items.Add("A - Absent");

            // Populates all cboxs
            for (int i = 1; i <= noStudents; i++)
            {
                ComboBox comboBox = (ComboBox)this.Controls.Find
                (string.Format("comboBox{0}", i), true)[0];
                //call method to fill cbox
                ComboBoxFill(comboBox);
            }
        }

        // Method to fill all cboxs
        private void ComboBoxFill(ComboBox comboBox)
        {
            comboBox.Items.Add("P - Present");
            comboBox.Items.Add("L - Late");
            comboBox.Items.Add("A - Absent");
        }

        private void FillPresent(ComboBox comboBox)
        {
            comboBox.Text = "P - Present";
        }

        private void FillLate(ComboBox comboBox)
        {
            comboBox.Text = "L - Late";
        }

        private void FillAbsent(ComboBox comboBox)
        {
            comboBox.Text = "A - Absent";
        }

        private void FillClear(ComboBox comboBox)
        {
            comboBox.Text = "";
        }

        // Fills all ComboBoxes Based on main combobox
        private void btnCombo_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <=noStudents; i++)
            {
                ComboBox comboBox = (ComboBox)this.Controls.Find
                        (string.Format("comboBox{0}", i), true)[0];

                // fill present if nothing is selected as well
                if (comboAttend.Text == "P - Present" || comboAttend.Text == "")
                {
                    FillPresent(comboBox);
                }

                else if (comboAttend.Text == "L - Late")
                {
                    FillLate(comboBox);
                }

                else 
                {
                    FillAbsent(comboBox);
                }
            }
        }

        // Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            // use '\\' to escape first back slash in file path
            string path = "C:\\test.txt";
            string selectedValue = comboBox1.SelectedItem.ToString();
            File.AppendAllText(path, selectedValue);

        }

        // visual test
        private void Test()
        {
            lblHeaderStudent.Text = "123";
        }

        // change back to when first openned app
        private void setToDefault()
        {
            for (int i = 1; i <= noStudents; i++)
            {
                ComboBox comboBox = (ComboBox)this.Controls.Find
                        (string.Format("comboBox{0}", i), true)[0];

                FillClear(comboBox);

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            setToDefault();
        }
    }
}
