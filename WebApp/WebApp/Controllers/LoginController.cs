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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(Login user)
        {
            //user se spaja preko name taga
            System.Diagnostics.Debug.WriteLine(user.Username);
            System.Diagnostics.Debug.WriteLine(user.Pass);

            MemoryStream ms = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(ms);

            DataContractSerializer serializer = new DataContractSerializer(typeof(Login));
            serializer.WriteObject(writer, user);
            writer.Close();

            byte[] data = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(ms.ToArray()));

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://fineoicar.azurewebsites.net/api/restaurant/web/login");
            req.Method = "POST";
            req.Accept = "application/xml";
            req.ContentType = "application/xml";

            Stream reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream respStream = resp.GetResponseStream();

            DataContractSerializer serializer2 = new DataContractSerializer(typeof(List<RestaurantModel>));
            List<RestaurantModel> restorani = (List<RestaurantModel>)serializer2.ReadObject(respStream);

            foreach (RestaurantModel r in restorani)
            {
                System.Diagnostics.Debug.WriteLine("Ime = " + r.RestaurantName);
                System.Diagnostics.Debug.WriteLine("Ocjena = " + r.Grade);


            }

            System.Diagnostics.Debug.WriteLine("Server = " + resp.Server);
            System.Diagnostics.Debug.WriteLine("Status Code = " + resp.StatusCode);
            System.Diagnostics.Debug.WriteLine("Headers = " + resp.Headers);
            System.Diagnostics.Debug.WriteLine("Resp = " + resp.ToString());

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registration()
        {
            return View("Registration");
        }
    }
}