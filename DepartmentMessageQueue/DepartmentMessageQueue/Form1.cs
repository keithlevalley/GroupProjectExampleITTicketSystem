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
using TechGUI;


namespace DepartmentMessageQueue
{
    public partial class Form1 : Form
    {
        //Store local machine name
        string MachineName = System.Environment.MachineName;
        List<string> departmentNames = new List<string>();
        List<string> employeeNames = new List<string>();

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\klevalley2\Source\Repos\CISP 410 Class Project\TicketDB.mdf;Integrated Security=True;Connect Timeout=30";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Get connection string using varibale MachineName 
           

           
            //Establish connection to local db derver 
            SqlConnection conn = new SqlConnection(connectionString);


            //This try catch is placed here to catch any exception that may occur during database loading operations.
            try
            {
                conn.Open();

                //Select all ticket in the ticket DB and display them in the DatagridView
                SqlCommand selectAllTickets = new SqlCommand("Select TicketID, Subject, Status, Customer_Name, Owner from Ticket where DepartmentID =" + 1, conn);
                updateDataGridView(selectAllTickets);

                CurrentDEPT.Text = "CSC";

                //Gets all the departments from the Department DB to load the Department side bar 
                SqlCommand getDepts = new SqlCommand("SELECT  * FROM Department", conn);
                SqlDataReader readDepts = getDepts.ExecuteReader();
                int i = 0;
                while (readDepts.Read())
                {             
                    DepartmentTV.Nodes.Add(readDepts.GetString(1));
                    DepartmentTV.Nodes[i].Nodes.Add("Open");
                    DepartmentTV.Nodes[i].Nodes.Add("Closed");
                    DepartmentTV.Nodes[i].Nodes.Add("Awaiting Reply");
                    departmentNames.Add(readDepts.GetString(1));
                    i++;               
                }

                readDepts.Close();
                conn.Close();


                //Gets all the Employees from the Employee DB 
                SqlCommand getEmployees = new SqlCommand("SELECT * FROM Employee", conn);



                //Get All Employee names from the DB to use in TechGUI dropdown list
                //------------------------------------------------
                conn.Open();
                SqlDataReader readEmployees = getEmployees.ExecuteReader();
                while (readEmployees.Read())
                {
                    employeeNames.Add(readEmployees.GetString(2) + " " + readEmployees.GetString(3));
                }
                conn.Close();
                readEmployees.Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        private void TicketGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                //Create instance of WorkFlowGui
                WorkFlowGUI wfg;


                //Establish Database connection
              
                SqlConnection conn = new SqlConnection(connectionString);

                //Select statement to find ticket # by selected id
                SqlCommand getTicket = new SqlCommand("SELECT * FROM Ticket WHERE TicketID = " + Convert.ToInt32(TicketGrid[0, e.RowIndex].Value), conn);

               


               //Get selected ticket from Data View and Pass information to TechGui Form
               //---------------------------------------------------
               conn.Open();
               SqlDataReader readTicket = getTicket.ExecuteReader();
               readTicket.Read();

                int ticketNum;
                int depID;
                int empID;
                int priority;
                string customerName;
                string email;
                string owner;
                string subject;

                if (readTicket.HasRows)
                {           
                    ticketNum = Convert.ToInt32(readTicket.GetValue(0));
                    depID = Convert.ToInt32(readTicket.GetValue(1));
                    empID = Convert.ToInt32(readTicket.GetValue(2));
                    subject = readTicket.GetString(3);
                    priority = Convert.ToInt32(readTicket.GetValue(4));
                    customerName = readTicket.GetString(5);
                    email = readTicket.GetString(6);
                    owner = readTicket.GetString(7);

                    wfg = new WorkFlowGUI(departmentNames, employeeNames, ticketNum, empID, depID, customerName, owner, priority, email, subject);
                    wfg.Owner = this;          
                    wfg.ShowDialog(this);
                    
                }
                readTicket.Close();
                conn.Close();
                //---------------------------------------------------------------                         
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void NodeClickHandler(object sender, TreeNodeMouseClickEventArgs e)
        {
            MessageBox.Show(e.Node.Text);
        }

        private void DepartmentTV_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            //This function sorts the tickets in the view based on the link clicked in the treeView
           
            SqlConnection conn = new SqlConnection(connectionString);
                          
            try
            {
                if (e.Node.Parent != null)
                {
                    //nullable int in case Select statement returns garbage values
                    int? deptID = GetDepartmentId(e.Node.Parent.Text.ToString().Trim(), conn);

                    //If no department value is found prompt with error message 
                    if(deptID < 0 || deptID == null)
                    {
                        MessageBox.Show("Department not found");

                    }
                    else
                    {
                        //Select statement that quieries dept and Status of the ticket
                        SqlCommand sortByDeptandStatus = new SqlCommand("Select TicketID, Subject, Status, Customer_Name, Owner from Ticket where DepartmentID =" + deptID + " and Status = '" + e.Node.Text.Trim() + "';", conn);
                        updateDataGridView(sortByDeptandStatus);
                        CurrentDEPT.Text = e.Node.Parent.Text.ToString().Trim();
                    }                                         
                }
                else
                {
                    //nullable int in case Select statement returns garbage values
                    int? deptID = GetDepartmentId(e.Node.Text.ToString().Trim(), conn);

                    //If no department value is found prompt with error message
                    if (deptID < 0 || deptID == null)
                    {
                        MessageBox.Show("Department not found");
                    }
                    else
                    {
                        //Select statement that quieries dept and Status of the ticket
                        SqlCommand sortByDept = new SqlCommand("Select TicketID, Subject, Status, Customer_Name, Owner from Ticket where DepartmentID =" + deptID + ";", conn);
                        updateDataGridView(sortByDept);
                        CurrentDEPT.Text = e.Node.Text.ToString().Trim();
                    }
                }              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        public void updateDataGridView(SqlCommand command)
        {


            //Create a Data adapter and give it the data from the select statement
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = command;

            //creata a DataTable variable used for binding data to the grid view
            DataTable DBtableSet = new DataTable();

            //Places Select statement data in to DataTable variable
            sda.Fill(DBtableSet);

            //Create bindingsource to convert data from DataTable to datagridView
            BindingSource bSource = new BindingSource();

            //Initialize binding source with the data in the DataTable
            bSource.DataSource = DBtableSet;

            //Give that data in the data source to the dataGridView
            TicketGrid.DataSource = bSource;


            //Creates a link in the dataGridView that will allow to open the TechGUI and load all the contents of the ticket
            foreach (DataGridViewRow row in TicketGrid.Rows)
            {
                DataGridViewLinkCell lnk = new DataGridViewLinkCell();
                lnk.Value = row.Cells[0].Value;
                TicketGrid[0, row.Index] = lnk;
            }

            //Updates that DataGridView
           // TicketGrid.Width = TicketGrid.
            //TicketGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            sda.Update(DBtableSet);
            

        }

        public void updateDataGridView(SqlCommand command, int deptId)
        {
           
            //Create a Data adapter and give it the data from the select statement
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = command;

            //creata a DataTable variable used for binding data to the grid view
            DataTable DBtableSet = new DataTable();

            //Places Select statement data in to DataTable variable
            sda.Fill(DBtableSet);

            //Create bindingsource to convert data from DataTable to datagridView
            BindingSource bSource = new BindingSource();

            //Initialize binding source with the data in the DataTable
            bSource.DataSource = DBtableSet;

            //Give that data in the data source to the dataGridView
            TicketGrid.DataSource = bSource;


            //Creates a link in the dataGridView that will allow to open the TechGUI and load all the contents of the ticket
            foreach (DataGridViewRow row in TicketGrid.Rows)
            {
                DataGridViewLinkCell lnk = new DataGridViewLinkCell();
                lnk.Value = row.Cells[0].Value;
                TicketGrid[0, row.Index] = lnk;
            }

            //Updates that DataGridView
            CurrentDEPT.Text = departmentNames[deptId];
            sda.Update(DBtableSet);

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
            catch(Exception)
            {
                MessageBox.Show("Cannot retrieve Department ID from function GetDepartmentId()");
                return -123;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            searchTextBox.Text = string.Empty;
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            if( searchTextBox.Text.Equals(string.Empty))
                 searchTextBox.Text = "Search Ticket ID";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //Get Search Text
            string ticketLookUp = searchTextBox.Text;

            //Connect to database
   
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                //Try to convert the string of input to an integer 
                int ticketNumber =  Convert.ToInt32(ticketLookUp);


                //if successful execute select statement to find the specified ticket
                SqlCommand getTicketbyId = new SqlCommand("Select * from Ticket where TicketID =" + ticketNumber, conn);
                conn.Open();
                SqlDataReader rdr = getTicketbyId.ExecuteReader(); 

                //Generate ticket window
                if(rdr.Read())
                {
                    WorkFlowGUI wfg;

                    int ticketNum;
                    int depID;
                    int empID;
                    int priority;
                    string customerName;
                    string email;
                    string owner;
                    string subject;

                        ticketNum = Convert.ToInt32(rdr.GetValue(0));
                        depID = Convert.ToInt32(rdr.GetValue(1));
                        empID = Convert.ToInt32(rdr.GetValue(2));
                        subject = rdr.GetString(3);
                        priority = Convert.ToInt32(rdr.GetValue(4));
                        customerName = rdr.GetString(5);
                        email = rdr.GetString(6);
                        owner = rdr.GetString(7);

                        wfg = new WorkFlowGUI(departmentNames, employeeNames, ticketNum, empID, depID, customerName, owner, priority, email, subject);
                             
                        wfg.Show();
            

                    searchTextBox.Text = "Search Ticket ID";

                    }
                else
                {
                    MessageBox.Show("Ticket number not found.");

                }
                rdr.Close();
                conn.Close();
            

            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid search credentials, please enter a positive whole number.");
            }
        }


    }
}
