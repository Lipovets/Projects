using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace InspectionBoard.Domain.BuisnessLogic.Admin
{
    public class MailSend
    {
        public void SendMail(string userAddres, string bodyText, string specialty) //Sending message. 
        {                                                                          //Function get 3 parameters, email to user, text of message, anf information about specialty
            MailAddress from = new MailAddress("lipavetsalexandr@gmail.com", "Результат вступної кампанії");
            MailAddress to = new MailAddress(userAddres);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Вступна кампанія";
            message.Body = bodyText + specialty;
            message.IsBodyHtml = false;

            SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587); 
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("lipavetsalexandr@gmail.com", "eputob37");

            smtp.Send(message);
        }

        public void Sending(List<int> list, string body) //geting list of applicants and sending message them about result of selection
        {
            StatementRepository statement = new StatementRepository();
            
            foreach(int item in list)
            {
                if (statement.FindById(item).isConfirmed)
                {
                    SendMail(statement.ApplicantToStatement(item).Email, body, statement.FindById(item).Specialty.Name.ToString());
                }
            }
        }
    }
}
