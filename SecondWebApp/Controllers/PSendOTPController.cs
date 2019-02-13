using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SecondWebApp.Controllers
{
    public class PSendOTPController : Controller
    {
        // GET: PSendOTP
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SendOTP()
        {
            int otpValue = new Random().Next(100000, 999999);
            string status = "";
            try
            {
                string recipient = ConfigurationManager.AppSettings["RecipientNumber"].ToString();
                string APIKey = ConfigurationManager.AppSettings["APIKey"].ToString();

                string message = "Your OTP Number is " + otpValue + " Send by Camilo";
                string encodedMessage = HttpUtility.UrlEncode(message);

                using (var webClient = new WebClient())
                {
                    byte[] response = webClient.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
                    {
                        {"apikey", APIKey },
                        {"numbers", recipient },
                        {"message", encodedMessage },
                        {"sender", "TXTLCL" }
                    });

                    string result = System.Text.Encoding.UTF8.GetString(response);
                    var jsonObject = JObject.Parse(result);
                    status = jsonObject["status"].ToString();
                    Session["CurrentOTP"] = otpValue;
                }


                return Json(status, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public ActionResult EnterOTP()
        {
            return View();
        }

        public JsonResult VerifyOTP(string otp)
        {
            bool result = false;
            string sessionOTP = Session["CurrentOTP"].ToString();

            if(otp == sessionOTP)
            {
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}