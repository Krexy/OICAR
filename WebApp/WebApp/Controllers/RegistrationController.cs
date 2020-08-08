using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string url)
        {
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Register(WebUser user)
        {
            System.Diagnostics.Debug.WriteLine(user.Username);
            System.Diagnostics.Debug.WriteLine(user.Pass);
            System.Diagnostics.Debug.WriteLine(user.Email);

            WebApiApplication.BackendPost<WebUser>(user, WebApiApplication.URL_REGISTRATION_PATH);

            //MemoryStream ms = new MemoryStream();
            //XmlWriter writer = XmlWriter.Create(ms);

            //DataContractSerializer serializer = new DataContractSerializer(typeof(WebUser));
            //serializer.WriteObject(writer, user);
            //writer.Close();

            //byte[] data = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(ms.ToArray()));

            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://fineoicar.azurewebsites.net/api/restaurant/web/reg");
            //req.Method = "POST";
            //req.Accept = "application/xml";
            //req.ContentType = "application/xml";

            //Stream reqStream = req.GetRequestStream();
            //reqStream.Write(data, 0, data.Length);

            //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            //Stream respStream = resp.GetResponseStream();

            //System.Diagnostics.Debug.WriteLine("Server = " + resp.Server);
            //System.Diagnostics.Debug.WriteLine("Status Code = " + resp.StatusCode);
            //System.Diagnostics.Debug.WriteLine("Headers = " + resp.Headers);
            //System.Diagnostics.Debug.WriteLine("Resp = " + resp.ToString());

            /*provjera ukoliko dode do greske ...*/


            return RedirectToAction("Index", "Login");
        }
    }
}