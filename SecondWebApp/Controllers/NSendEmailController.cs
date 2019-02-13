using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SecondWebApp.Controllers
{
    public class NSendEmailController : Controller
    {
        // GET: NSendEmail
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SendEmailToUser()
        {
            bool result = false;

            result = SendEmail("jcamilogh@outlook.com", "Hola", "<p>Saludos cordiales.<br />Pruebas de envio de correo<br />Que este bien</p>");

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public bool SendEmail(string toEmail, string subject, string emailBody)
        {
            bool result;
            result = false;
            string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
            string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

            try
            {

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 100000;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;

                smtpClient.Send(mailMessage);
                result = true;
            }
            catch (Exception e)
            {

                result = false;
            }

            return result;
        }
    }
}