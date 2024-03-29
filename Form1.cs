﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInfoSystem
{
    public partial class frmStudent : Form
    {
        private SortedDictionary<int, Student> students = new SortedDictionary<int, Student>();
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            string[] items = { "Biomedical Engineering Technology",
                "Computer Repair and Maintenance",
                "Computer Systems Technician – Networking",
                "Computer Systems Technology – Networking",
                "Electronics Engineering Technician",
                "Electronics Engineering Technology",
                "Health Informatics Technology",
                "Software Engineering Technician",
                "Software Engineering Technology",
                "Software Engineering Technology – Interactive Gaming",
                "Technology Foundations (ICET)" };

            foreach (string program in items)
            {
                cboProgram.Items.Add(program);
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Student myStudent = new Student(
                int.Parse(txtId.Text), 
                txtFirstName.Text,
                txtLastName.Text,
                txtCity.Text,
                rbtnDomestic.Checked,
                cboProgram.Text,
                (int)nrudSemester.Value,
                double.Parse(txtGpa.Text),
                (chkComp123.Checked ? (chkComp123.Text + ",") : "") +
                (chkComp225.Checked ? (chkComp225.Text + ",") : "") +
                (chkComp213.Checked ? (chkComp213.Text + ",") : "") +
                (chkComp301.Checked ? (chkComp301.Text + ",") : "") +
                (chkComp391.Checked ? (chkComp391.Text + ",") : "") +
                (chkMath185.Checked ? (chkMath185.Text + ",") : "") +
                (chkComp100.Checked ? (chkComp100.Text + ",") : "")
                );
            students.Add(myStudent.Id, myStudent);
            MessageBox.Show("Object Student Created!");

            // COMP123, COMP229, MATH185
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtCity.Text = "";

            rbtnDomestic.Checked = true;
            cboProgram.Text = "";
            nrudSemester.Value = 0;
            txtGpa.Text = "0";

            chkComp123.Checked = false;
            chkComp225.Checked = false;
            chkComp213.Checked = false;
            chkComp301.Checked = false;
            chkComp391.Checked = false;
            chkMath185.Checked = false;
            chkComp100.Checked = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSearchBox.Text);
            if (students.ContainsKey(id) ) { 
                Student studentFound = students[id];
                txtId.Text = studentFound.Id.ToString();
                txtFirstName.Text = studentFound.FirstName;
                txtLastName.Text = studentFound.LastName;
                txtCity.Text = studentFound.City;

                cboProgram.Text= studentFound.Program;
                nrudSemester.Value = studentFound.Semester;
                txtGpa.Text = studentFound.Gpa.ToString();
                rbtnDomestic.Checked = studentFound.IsDomestic;
                rbtnForeign.Checked = !studentFound.IsDomestic;

                chkComp100.Checked = studentFound.Courses.Contains(chkComp100.Text);
                chkComp123.Checked = studentFound.Courses.Contains(chkComp123.Text);
                chkComp391.Checked = studentFound.Courses.Contains(chkComp391.Text);
                chkComp225.Checked = studentFound.Courses.Contains(chkComp225.Text);
                chkComp213.Checked = studentFound.Courses.Contains(chkComp213.Text);
                chkComp301.Checked = studentFound.Courses.Contains(chkComp301.Text);
                chkMath185.Checked = studentFound.Courses.Contains(chkMath185.Text);
            }
            else
            {
                MessageBox.Show("Student not fond.");
            }
        }
    }
}
