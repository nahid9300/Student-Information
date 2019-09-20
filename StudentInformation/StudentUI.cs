using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace StudentInformation
{
    public partial class StudentUI : Form
    {
        List<int> studentID = new List<int> { };
        List<string> studentName = new List<string> { };
        List<string> mobile = new List<string> { };
        List<int> Age = new List<int> { };
        List<string> Address = new List<string> { };
        List<double> amolNama = new List<double> { };

        public StudentUI()
        {
            InitializeComponent();
        }
        //show single student info 
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Please enter id");
                return;
            }

            if (idTextBox.Text.Length != 4)
            {
                MessageBox.Show("Id must be in 4 character!");
                return;
            }

            //Unique
            if (studentID.Contains(Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Id already exits");
                return;
            }

            if (String.IsNullOrEmpty(nameTextBox.Text) || nameTextBox.Text.Length >= 30)
            {
                MessageBox.Show("Please enter Name and Name must be in 30 character!");
                return;
            }

            if (String.IsNullOrEmpty(mobileTextBox.Text) || mobileTextBox.Text.Length != 11)
            {

                MessageBox.Show("Please enter Mobile No and Mobile No must be in 11 character!");
                return;
            }

            if (String.IsNullOrEmpty(gpaTextBox.Text))
            {
                MessageBox.Show("Please enter valid CGPA!");
               return;
            }
            if (Convert.ToDouble(gpaTextBox.Text)<0 || Convert.ToDouble(gpaTextBox.Text)> 5)
            {
                MessageBox.Show("Please enter valid CGPA");
                return;
            }
            else
            {
                AddStudent(Convert.ToInt32(idTextBox.Text),nameTextBox.Text,mobileTextBox.Text,
                Convert.ToInt32(ageTextBox.Text),addressTextBox.Text,Convert.ToDouble(gpaTextBox.Text));
            }


            string output = "";
            for (int i = 0; i < studentID.Count(); i++)
            {
                output = "Student ID: " + studentID[i] + "\n" + "Student Name: " + studentName[i] + "\n"
                          + "Student Mobile: " + mobile[i] + "\n" + "Student Age: " + Age[i] + "\n" + "Student Address: " + Address[i] + "\n" + "GPA: " + amolNama[i] + "\n\n";
            }
            outputRichBox.Text = output;

            idTextBox.Text = "";
            nameTextBox.Text = "";
            mobileTextBox.Text = "";
            ageTextBox.Text = "";
            addressTextBox.Text = "";
            gpaTextBox.Text = "";
        }




        public void AddStudent(int id, string Name,string Mobile,int age,string address, double gpa)
        {
            studentID.Add(id);
            studentName.Add(Name);
            mobile.Add(Mobile);
            Age.Add(age);
            Address.Add(address);
            amolNama.Add(gpa);

        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            show();
            idTextBox.Text = "";
            nameTextBox.Text="";
            mobileTextBox.Text = "";
            ageTextBox.Text = "";
            addressTextBox.Text = "";
            gpaTextBox.Text = "";
        }

        //show all student info
        public void show()
        {
            string output = "";
            for (int i = 0; i < studentID.Count(); i++)
            {
                output += "Student ID: " + studentID[i] + "\n" + "Student Name: " + studentName[i] + "\n"
                          + "Student Mobile: " + mobile[i] + "\n" + "Student Age: " + Age[i] + "\n" + "Student Address: " + Address[i] + "\n" + "GPA: " + amolNama[i] + "\n\n";
            }
            outputRichBox.Text = output;

            var maxNumberName = amolNama.IndexOf(amolNama.Max());
            maxNameBox.Text = studentName[maxNumberName];

            var minNumberName = amolNama.IndexOf(amolNama.Min());
            minNameBox.Text = studentName[minNumberName];


            var min= amolNama.Min();
            var max = amolNama.Max();
            var sum = amolNama.Sum();
            var average = amolNama.Average();
            maxNumberBox.Text = max.ToString();
            minNumberBox.Text = min.ToString();
            totalBox.Text = sum.ToString();
            averageBox.Text = average.ToString();

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (idRadioButton.Checked == true)
            {
                if (studentID.Contains(Convert.ToInt32(idTextBox.Text)))
                {
                    int index = studentID.IndexOf(Convert.ToInt32(idTextBox.Text));
                    MessageBox.Show("ID: " + studentID[index] + "\n" + "Name: " + studentName[index] + "\n" +
                "Mobile No: " + mobile[index] + "\n" + "Age: " + Age[index] + "\n" + "Address: "
                + Address[index] + "\n" + "GPA: " + amolNama[index] + "\n");
                }
                else
                {
                    MessageBox.Show("Data not available");
                }

            }
            if (nameRadioButton.Checked == true)
            {
                if (studentName.Contains(nameTextBox.Text))
                {
                    int index = studentName.IndexOf(nameTextBox.Text);
                    MessageBox.Show("ID: " + studentID[index] + "\n" + "Name: " + studentName[index] + "\n" +
                 "Mobile No: " + mobile[index] + "\n" + "Age: " + Age[index] + "\n" + "Address: "
                 + Address[index] + "\n" + "GPA: " + amolNama[index] + "\n");
                }
                else
                {
                    MessageBox.Show("Data not available");
                }

            }
            if (mobileRadioButton.Checked == true)
            {
                if (mobile.Contains(mobileTextBox.Text))
                {
                    int index = mobile.IndexOf(mobileTextBox.Text);
                    MessageBox.Show("ID: " + studentID[index] + "\n" + "Name: " + studentName[index] + "\n" +
                 "Mobile No: " + mobile[index] + "\n" + "Age: " + Age[index] + "\n" + "Address: "
                 + Address[index] + "\n" + "GPA: " + amolNama[index] + "\n");
                }
                else
                {
                    MessageBox.Show("Data not available");
                }
            }
            
        }

    }
}

////search
//    if (studentID.Contains(Convert.ToInt32(idTextBox.Text)))
//    {
//        int index = studentID.IndexOf(idTextBox.TextLength);
//        MessageBox.Show(studentID[index] + "" + studentName[index]);
//        return;
//    }
////
