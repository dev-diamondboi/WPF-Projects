using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace NotificationSystem
{
    public class SendViaEmail
    {
        public string Email { get; set; }

        public SendViaEmail(string email)
        {
            Email = email;
        }

        public void SendNotification(string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("diamondpeter643@gmail.com@gmail.com"); 
                mail.To.Add(Email);
                mail.Subject = "Notification";
                mail.Body = message;

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("diamondpeter643@gmail.com@gmail.com", "nthw kzlu hfba jjui");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                MessageBox.Show($"Email sent to {Email}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
