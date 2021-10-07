using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeServiceWebClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {
            EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient();
            if(txtID.Text == "")
            {
                lblMessage.Text = "Please enter valid id.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtName.Text = txtID.Text = txtGender.Text = txtDateOfBirth.Text = "";
                return;
            }
         
            EmployeeService.Employee employee = client.GetEmployee(Convert.ToInt32(txtID.Text));

            if(employee == null)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Employee not found.";
                txtName.Text = txtID.Text = txtGender.Text = txtDateOfBirth.Text = "";
                return ;
            }
            txtName.Text = employee.Name;
            txtGender.Text = employee.Gender;
            txtDateOfBirth.Text = employee.DateOfBirth.ToShortDateString();
            lblMessage.ForeColor = System.Drawing.Color.Green;

            lblMessage.Text = "Employee retrieved Successfully.";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtName.Text != "" && txtDateOfBirth.Text != "" && txtGender.Text != "")
            {
                EmployeeService.Employee employee = new EmployeeService.Employee();
                employee.Id = Convert.ToInt32(txtID.Text);
                employee.Name = txtName.Text;
                employee.Gender = txtGender.Text;
                employee.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);

                EmployeeService.EmployeeServiceClient client = new
                EmployeeService.EmployeeServiceClient();
                client.SaveEmployee(employee);
                lblMessage.ForeColor = System.Drawing.Color.Green;

                lblMessage.Text = "Employee Saved Successfully.";
            }

            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please check your all fields.";
            }
           

           
        }
    }
}