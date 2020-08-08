using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Xml;
using WebApp.Models;

namespace WebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static bool LOGED_IN = false;
        public static string URL_PATH = "api/restaurant/web";
        public static string URL_LOGIN_PATH = "api/restaurant/web/login";
        public static string URL_REGISTRATION_PATH = "api/restaurant/web/reg";
        public static List<RestaurantModel> restorani;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static Stream BackendPost<T>(T model, string urlPath)
        {

            MemoryStream ms = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(ms);

            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(writer, model);
            writer.Close();

            byte[] data = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(ms.ToArray()));

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"http://fineoicar.azurewebsites.net/{urlPath}");
            req.Method = "POST";
            req.Accept = "application/xml";
            req.ContentType = "application/xml";

            Stream reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream respStream = resp.GetResponseStream();

            return respStream;
        }

        public static X BackendPostWithReturn<T, X>(T model, string urlPath)
        {
            Stream respStream = BackendPost<T>(model, urlPath);

            DataContractSerializer serializer2 = new DataContractSerializer(typeof(X));
            X returnObject = (X)serializer2.ReadObject(respStream);

            return returnObject;
        }
        public static X BackendGetRestaurantData<T, X>(string restaurantName, string data)
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"http://fineoicar.azurewebsites.net/{URL_PATH}/{restaurantName}/{data}");
            req.Accept = "application/xml";

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream respStream = resp.GetResponseStream();

            DataContractSerializer serializer = new DataContractSerializer(typeof(X));
            X returnData = (X)serializer.ReadObject(respStream);

            return returnData;
        }

    }
}
