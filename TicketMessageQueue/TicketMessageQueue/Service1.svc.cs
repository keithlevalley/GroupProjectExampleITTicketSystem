using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Messaging;

namespace TicketMessageQueue
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        // Needs to pull last ticketID information from somewhere to maintain consistency if server is shutdown
        static int ticketID = 0;

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

        public int SubmitTicket(string name, string email, string description)
        {
            string computerName = Environment.MachineName;
            string messageQ = computerName + @"\private$\klevalley2";

            XmlDocument doc = new XmlDocument();
            XmlNode ticketNode = doc.CreateElement("Ticket");
            XmlNode infoNode;
            XmlAttribute attribute;

            ticketID++;

            attribute = doc.CreateAttribute("TicketID");
            attribute.Value = ticketID.ToString();
            ticketNode.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("Date");
            attribute.Value = DateTime.Now.ToString();
            ticketNode.Attributes.Append(attribute);

            infoNode = doc.CreateElement("Name");
            infoNode.InnerText = name;

            ticketNode.AppendChild(infoNode);

            infoNode = doc.CreateElement("Email");
            infoNode.InnerText = email;

            ticketNode.AppendChild(infoNode);

            infoNode = doc.CreateElement("Description");
            infoNode.InnerText = description;

            ticketNode.AppendChild(infoNode);

            ticketNode.AppendChild(infoNode);

            doc.AppendChild(ticketNode);
            doc.Save(@"c:\users\klevalley2\desktop\ticket.xml");
            
            // Start Message queue
            if (!MessageQueue.Exists(messageQ))
            {
                MessageQueue.Create(messageQ);
            }
            try
            {
                MessageQueue myQueue = new MessageQueue(messageQ);

                myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(XmlDocument) });

                Message message = new Message();

                myQueue.Formatter.Write(message, doc);
                myQueue.Send(message);
                myQueue.Close();
            }
            catch (Exception)
            {
                return -1;
            }
            return ticketID;
        } // end submitTicket
    } // class service1
} // namespace end
