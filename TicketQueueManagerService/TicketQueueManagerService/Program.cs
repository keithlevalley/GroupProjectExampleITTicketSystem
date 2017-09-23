using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Messaging;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

namespace TicketQueueManagerService
{
    class Program
    {
        static bool waitForQueue = true;
        static void Main(string[] args)
        {
            string computerName = Environment.MachineName;
            string messageQ = computerName + @"\private$\klevalley2";

            XmlDocument doc = new XmlDocument();

            if (!MessageQueue.Exists(messageQ))
            {
                MessageQueue.Create(messageQ);
            }
            MessageQueue myQueue = new MessageQueue(messageQ);

            myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(XmlDocument) });

            //myQueue.Purge();

            

            while (waitForQueue)
            {
                try
                {
                    System.Messaging.Message message = myQueue.Receive(TimeSpan.FromSeconds(1));
                    doc = (XmlDocument)message.Body;
                    // Do stuff with XML document
                    string temp = InsertProcedure(doc);
                    Console.WriteLine(doc.InnerText + " " + temp);
                    //doc.Save(("test.xml"));
                }
                catch (Exception)
                {
                    Thread.Sleep(1000);
                }
            }
            myQueue.Close();
        }

        public void StopWorking()
        {
            waitForQueue = false;
        }

        public static string InsertProcedure(XmlDocument doc)
        {
            try
            {
                


                using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\klevalley2\Source\Repos\CISP 410 Class Project\TicketDB.mdf; Integrated Security = True; Connect Timeout = 30"))
                {
                    //Using UpdateTicket Stored procedure to update ticket contents
                    conn.Open();
                    SqlCommand insert = new SqlCommand("Procedure", conn);
                    insert.CommandType = CommandType.StoredProcedure;

                    insert.Parameters.Add(new SqlParameter("@InsertDepartmentID", 2));
                    insert.Parameters.Add(new SqlParameter("@InsertEmployeeID", 1));
                    insert.Parameters.Add(new SqlParameter("@InsertSubject", doc.FirstChild.LastChild.InnerText));
                    insert.Parameters.Add(new SqlParameter("@InsertPriority", 2));
                    insert.Parameters.Add(new SqlParameter("@InsertCustomer_Name", doc.FirstChild.FirstChild.InnerText));
                    insert.Parameters.Add(new SqlParameter("@InsertCustomer_Email", doc.FirstChild.FirstChild.NextSibling.InnerText));
                    insert.Parameters.Add(new SqlParameter("@InsertOwner", "default"));
                    insert.Parameters.Add(new SqlParameter("@InsertStatus", "open"));
                    insert.Parameters.Add(new SqlParameter("@InsertTimeStamp", DateTime.Now));
                    //insert.Parameters.Add(new SqlParameter("@InsertTicketID", 1));

                    insert.ExecuteNonQuery();
                    insert.Parameters.Clear();

                    conn.Close();

                    return "passed";
                } // end using
            }
            catch (Exception e)
            {

                return e.StackTrace;
            }
        }
    }
}
