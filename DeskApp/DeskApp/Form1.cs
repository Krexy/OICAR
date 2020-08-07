using DeskApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class Form1 : Form
    {
        private const string URLPATH = "api/restaurant/desktop/login";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.previousForm = this;
            Registracija registracija = new Registracija();
            registracija.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Login();
            Login login = new Login(tbLoginUsername.Text, tbLoginPass.Text);
            RestaurantOwner owner = Program.BackendConnectWithReturn<Login, RestaurantOwner>(login, URLPATH);
            System.Diagnostics.Debug.WriteLine("Ime = " + owner.Username);
            System.Diagnostics.Debug.WriteLine("Ocjena = " + owner.Restaurant.Grade);

            this.Close();
            RestaurantOverview restaurantOverview = new RestaurantOverview();
            restaurantOverview.Show();

        }

        //private void Login()
        //{
        //    Login login = new Login(tbLoginUsername.Text, tbLoginPass.Text);

        //    MemoryStream ms = new MemoryStream();
        //    XmlWriter writer = XmlWriter.Create(ms);

        //    DataContractSerializer serializer = new DataContractSerializer(typeof(Login));
        //    serializer.WriteObject(writer, login);
        //    writer.Close();

        //    byte[] data = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(ms.ToArray()));

        //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://fineoicar.azurewebsites.net/api/restaurant/desktop/login");
        //    req.Method = "POST";
        //    req.Accept = "application/xml";
        //    req.ContentType = "application/xml";

        //    Stream reqStream = req.GetRequestStream();
        //    reqStream.Write(data, 0, data.Length);

        //    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        //    Stream respStream = resp.GetResponseStream();

        //    DataContractSerializer serializer2 = new DataContractSerializer(typeof(RestaurantOwner));
        //    RestaurantOwner owner = (RestaurantOwner)serializer2.ReadObject(respStream);

            
        //        System.Diagnostics.Debug.WriteLine("Ime = " + owner.Username);
        //        System.Diagnostics.Debug.WriteLine("Ocjena = " + owner.Restaurant.Grade);


        //    System.Diagnostics.Debug.WriteLine("Server = " + resp.Server);
        //    System.Diagnostics.Debug.WriteLine("Status Code = " + resp.StatusCode);
        //    System.Diagnostics.Debug.WriteLine("Headers = " + resp.Headers);
        //}
    }
}
