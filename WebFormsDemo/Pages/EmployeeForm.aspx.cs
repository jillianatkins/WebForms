﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace WebFormsDemo.Pages
{
    public partial class EmployeeForm : System.Web.UI.Page
    {

        private static List<Employee> Employee = new List<Employee>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        protected void ShowMessage(string message, string cssclass)
        {
            MessageLabel1.Attributes.Add("class", cssclass);
            MessageLabel1.InnerHtml = message;
        }
        protected bool Validation(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID.Text))
            {
                ShowMessage("ID is required", "alert alert-danger");
                return false;
            }
            string input1 = ID.Text;
            Match match1 = Regex.Match(input1, @"^[1-9][1-9][1-9]$");
            if (!match1.Success)
            {
                ShowMessage("ID must be three non 0 digits long", "alert alert-danger");
                return false;
            }
            if (string.IsNullOrEmpty(Name.Text))
            {
                ShowMessage("Name is required", "alert alert-danger");
                return false;
            }
            if (string.IsNullOrEmpty(Phone.Text))
            {
                ShowMessage("Phone Number is required", "alert alert-danger");
                return false;
            }
            string input2 = Phone.Text;
            Match match2 = Regex.Match(input2, @"^[1-9][0-9][0-9][.][1-9][0-9][0-9][.][0-9][0-9][0-9][0-9]$");
            if (!match2.Success)
            {
                ShowMessage("Phone Number must be like 123.123.1234", "alert alert-danger");
                return false;
            }
            return true;
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            var isValid = Validation(sender, e);
            if (isValid)
            {
                bool found = false;
                foreach (var item in Employee)
                {
                    if (item.ID == ID.Text)
                    {
                        found = true;
                    }
                }
                if (found)
                {
                    ShowMessage("Record already exists.", "alert alert-warning");
                }
                else
                {
                    Employee newitem = new Employee(ID.Text, Name.Text, Phone.Text);
                    Employee.Add(newitem);
                    EmployeeGridView.DataSource = Employee;
                    EmployeeGridView.DataBind();
                    ShowMessage("Record added.", "alert alert-success");
                }
            }
        }
        protected void Clear_Click(object sender, EventArgs e)
        {
            ID.Text = "";
            Name.Text = "";
            Phone.Text = "";
        }
    }
}