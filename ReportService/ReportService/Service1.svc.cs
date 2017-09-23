using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.IO;
using ReportService.email;

namespace ReportService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : Reports
    {
        email.Service1 emailService = new email.Service1();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public void getBasicReport()
        {
            

            SqlConnection sqlConnection1 = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\klevalley2\\Source\\Repos\\CISP 410 Class Project\\TicketDB.mdf; Integrated Security = True; Connect Timeout = 10");
            using (sqlConnection1)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Ticket"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = sqlConnection1;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        dt.TableName = "Ticket Report";
                        sda.Fill(dt);
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dt);
                        StringWriter writer = new StringWriter();
                        ds.WriteXml(writer);
                        string result = writer.ToString();
                        emailService.SendEmail("decoyemail410@yahoo.com", "passwordabc123", "decoyemail410@yahoo.com", "ticket report", result);
                    }
                }
            }
        }

        public void getDetailedReport(string status)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\klevalley2\\Source\\Repos\\CISP 410 Class Project\\TicketDB.mdf; Integrated Security = True; Connect Timeout = 10");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Ticket WHERE Status = @val1");
            cmd.Parameters.AddWithValue("@val1", status);
            using (sqlConnection1)
            {
                using (cmd)
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = sqlConnection1;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        dt.TableName = "Ticket Report";
                        sda.Fill(dt);
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dt);
                        StringWriter writer = new StringWriter();
                        ds.WriteXml(writer);
                        string result = writer.ToString();
                        emailService.SendEmail("decoyemail410@yahoo.com", "passwordabc123", "decoyemail410@yahoo.com", "ticket report", result);
                    }
                }
            }
        }

        public void getDepartmentReport(string department, string status)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\klevalley2\\Source\\Repos\\CISP 410 Class Project\\TicketDB.mdf; Integrated Security = True; Connect Timeout = 10");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Ticket WHERE DepartmentID = @val1 AND Status = @val2");
            cmd.Parameters.AddWithValue("@val1", department);
            cmd.Parameters.AddWithValue("@val2", status);
            using (sqlConnection1)
            {
                using (cmd)
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = sqlConnection1;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        dt.TableName = "Ticket Report";
                        sda.Fill(dt);
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dt);
                        StringWriter writer = new StringWriter();
                        ds.WriteXml(writer);
                        string result = writer.ToString();
                        emailService.SendEmail("decoyemail410@yahoo.com", "passwordabc123", "decoyemail410@yahoo.com", "ticket report", result);
                    }
                }
            }
        }

        public void getTechnicianReport(string employeeID, string status)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\klevalley2\\Source\\Repos\\CISP 410 Class Project\\TicketDB.mdf; Integrated Security = True; Connect Timeout = 10");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Ticket WHERE EmployeeID = @val1 AND Status = @val2");
            cmd.Parameters.AddWithValue("@val1", employeeID);
            cmd.Parameters.AddWithValue("@val2", status);
            using (sqlConnection1)
            {
                using (cmd)
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = sqlConnection1;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        dt.TableName = "Ticket Report";
                        sda.Fill(dt);
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dt);
                        StringWriter writer = new StringWriter();
                        ds.WriteXml(writer);
                        string result = writer.ToString();
                        emailService.SendEmail("decoyemail410@yahoo.com", "passwordabc123", "decoyemail410@yahoo.com", "ticket report", result);
                    }
                }
            }
        }

    }
}
