using DeskApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DeskApp
{
    static class Program
    {
        public static Form previousForm;
        public static RestaurantOwner CurrentResturantOwner;
        public static string URL_LOGIN_PATH = "api/restaurant/desktop/login";
        public static string URL_REGISTRATION_PATH = "api/restaurant/desktop/insert";
        public static string URL_GENERATE_VID_PATH = "api/restaurant/web/vid";


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }



        public static Stream BackendConnect<T>(T model, string urlPath)
        {

            MemoryStream ms = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(ms);

            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(writer, model);
            Console.WriteLine(serializer.ToString());
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

        public static X BackendConnectWithReturn<T,X>(T model, string urlPath)
        {
            Stream respStream = BackendConnect<T>(model, urlPath);

            DataContractSerializer serializer2 = new DataContractSerializer(typeof(X));
            X returnObject = (X)serializer2.ReadObject(respStream);

            return returnObject;
        }

        public static X GetVid<X>(string urlPath)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"http://fineoicar.azurewebsites.net/{urlPath}");
            req.Method = "GET";
            req.Accept = "application/xml";
            req.ContentType = "application/xml";

            //Stream reqStream = req.GetRequestStream();


            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream respStream = resp.GetResponseStream();


            DataContractSerializer serializer2 = new DataContractSerializer(typeof(X));
            X returnObject = (X)serializer2.ReadObject(respStream);

            return returnObject;
        }

    }
}
