using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.Runtime.InteropServices;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace GeneralFormLibrary1
{
    public class Email
    {
        public static void SendEmail(string ToEmailAddress, string Subject, string Body)
        {
            Outlook.Application app = new Outlook.Application();
            Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = Subject;
            mailItem.To = ToEmailAddress;
            mailItem.Body = Body;
            mailItem.Send();
        }

    }
}
