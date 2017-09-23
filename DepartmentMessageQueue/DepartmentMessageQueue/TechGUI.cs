using DepartmentMessageQueue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DepartmentMessageQueue.emailService;
namespace TechGUI
{
    public partial class WorkFlowGUI : Form
    {
        string MachineName = System.Environment.MachineName;
        int TICKET_ID;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\klevalley2\Source\Repos\CISP 410 Class Project\TicketDB.mdf;Integrated Security=True;Connect Timeout=30";

        public WorkFlowGUI()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        //Overloaded constructor for workflow GUI
        public WorkFlowGUI(List<string> departments, List<string> employees, int ticketID, int employeeID, int departmentID , string custName, string owner, int priority, string email, string subject)
        {


            InitializeComponent();

            //Setting Labels for the ticket once the ticket opens
            NameLabel.Text = custName;
            SubjectNameLabel.Text = subject;
            TICKET_ID = ticketID;

            //Connect to the database
          
            SqlConnection conn = new SqlConnection(connectionString);

            //Statement get the name of the employy who owns the ticket
            SqlCommand getEmployees = new SqlCommand("SELECT firstName, lastName FROM Employee where EmployeeID = " + employeeID + ";", conn);

            //Statment to the current department queue the ticket is in.
            SqlCommand getDepts = new SqlCommand("SELECT  * FROM Department where DepartmentID =" + departmentID + ";", conn);

            int activeIndex = 0;

            try
            {
                //This code populates the dropDown menus with the current values of the columns from the DB
                //To populate department dropDown-------------
                conn.Open();              
                SqlDataReader readDepts = getDepts.ExecuteReader();
                readDepts.Read();
                string currentDepartment = readDepts.GetString(1);
                activeIndex = 0;
                foreach (string s in departments)
                {
                    DeptCB.Items.Add(s);
                    if (s.Equals(currentDepartment))
                    {
                        DeptCB.SelectedIndex = activeIndex;
                    }
                    activeIndex++;
                }

                readDepts.Close();
                //End Department Drop Down





                //Owner/employee dropdownm

                SqlDataReader rdr = getEmployees.ExecuteReader();
                string ownerEmployee;
                rdr.Read();
                ownerEmployee = rdr.GetString(0) + " " + rdr.GetString(1);
                rdr.Close();
                conn.Close();


                activeIndex = 0;

                foreach (string s in employees)
                {

                    OwnerCB.Items.Add(s);

                    if (s.Equals(ownerEmployee))
                    {
                        OwnerCB.SelectedIndex = activeIndex;
                    }

                    activeIndex++;
                }

                //end employee drop down.
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


     

 


            StatusCB.Items.Add("Open");
            StatusCB.SelectedIndex = 0;
            StatusCB.Items.Add("Closed");
            StatusCB.Items.Add("Awaiting Reply");

            PriorityCB.Items.Add(1);
            PriorityCB.Items.Add(2);
            PriorityCB.Items.Add(3);
            PriorityCB.SelectedIndex = 1;

            EmailTB.Text = email;



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void WorkFlowGUI_Load(object sender, EventArgs e)
        {

        }

        private void SendButton_Click(object sender, EventArgs e)
        {

            //This function updates the current status of the ticket record.
            
            SqlConnection conn = new SqlConnection(connectionString);

            //Get Department and Employee IDs
            int deptID = GetDepartmentId(DeptCB.Items[DeptCB.SelectedIndex].ToString(), conn);
            int EmpId = GetEmployeeID(OwnerCB.Items[OwnerCB.SelectedIndex].ToString(), conn);
            int priority = PriorityCB.SelectedIndex + 1;




            //Using UpdateTicket Stored procedure to update ticket contents
            conn.Open();
            SqlCommand update = new SqlCommand("UpdateTicket", conn);
            update.CommandType = CommandType.StoredProcedure;

            update.Parameters.Add(new SqlParameter("@UpdateDepartment", deptID));
            update.Parameters.Add(new SqlParameter("@UpdateEmployeeId", EmpId));
            update.Parameters.Add(new SqlParameter("@UpdateStatus", StatusCB.Items[StatusCB.SelectedIndex].ToString()));
            update.Parameters.Add(new SqlParameter("@UpdatePriority", priority));
            update.Parameters.Add(new SqlParameter("@tID", TICKET_ID));
            update.Parameters.Add(new SqlParameter("@UpdateOwner", OwnerCB.Items[OwnerCB.SelectedIndex].ToString()));

            update.ExecuteNonQuery();
            update.Parameters.Clear();

            var f1 = (Form1)this.Owner;

            SqlCommand updateGrid = new SqlCommand("Select TicketID, Subject, Status, Customer_Name, Owner from Ticket where DepartmentID =" + deptID, conn);

            f1.updateDataGridView(updateGrid, (deptID - 1));
            
            conn.Close();
            MessageBox.Show("Ticket Updated!");

            StringBuilder emailSubject = new StringBuilder();
            emailSubject.Append("Ticket #");
            emailSubject.Append(TICKET_ID);
            emailSubject.Append(" - ");
            emailSubject.Append(SubjectNameLabel.Text);

            StringBuilder emailBody = new StringBuilder();
            emailBody.Append(NameLabel.Text);
            emailBody.Append(",");
            emailBody.Append("\nTicket ID: ");
            emailBody.Append(TICKET_ID);
            emailBody.Append("\nSubject: ");
            emailBody.Append(SubjectNameLabel.Text);
            emailBody.Append("\nStatus: ");
            emailBody.Append(StatusCB.Items[StatusCB.SelectedIndex].ToString());
            emailBody.Append("\nOwner: ");
            emailBody.Append(OwnerCB.Items[OwnerCB.SelectedIndex].ToString());
            emailBody.Append("\n\nComments:\n");
            emailBody.Append(ReplyRTB.Text);

            //to email
            // decoyemail410@yahoo.com

            //from email
            // decoyemail410@yahoo.com

            //from password
            // passwordabc123

            //subject

            Service1 email = new Service1();
            email.SendEmail("decoyemail410@yahoo.com", "passwordabc123", "decoyemail410@yahoo.com", emailSubject.ToString(), emailBody.ToString());


        }

        private int GetDepartmentId(string deptName, SqlConnection conn)
        {
            try
            {
                conn.Open();

                SqlCommand getDeptId = new SqlCommand("Select DepartmentID from Department where Deptartment_Name = '" + deptName + "';", conn);
                SqlDataReader rdr = getDeptId.ExecuteReader();

                rdr.Read();
                int deptID = rdr.GetInt32(0);

                rdr.Close();
                conn.Close();

                return deptID;

            }
            catch (Exception)
            {
                MessageBox.Show("Cannot retrieve Department ID from function GetDepartmentId()");
                return -123;
            }

        }
        private int GetEmployeeID(string name, SqlConnection conn)
        {

            int empID;

            string[] firstLast = name.Split(' ');

            try
            {
                conn.Open();
                SqlCommand getDeptId = new SqlCommand("Select EmployeeID from Employee where firstName = '" + firstLast[0].Trim() + "' AND lastName = '" + firstLast[1].Trim() +"';", conn);
                SqlDataReader rdr = getDeptId.ExecuteReader();
         
                rdr.Read();

                empID = Convert.ToInt32(rdr.GetValue(0));
                rdr.Close();
                conn.Close();

                return empID;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Cannot retrieve Employee ID from function GetEmployeeId()");
                return -123;

            }

        }


    }
}
