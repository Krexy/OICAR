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
            Program.CurrentResturantOwner = Program.BackendConnectWithReturn<Login, RestaurantOwner>(login, Program.URL_LOGIN_PATH);

            //MessageBox.Show("Ime = " + owner.Username);
            //MessageBox.Show("Ime = " + owner.Restaurant.Grade);
            this.Hide();
            Program.previousForm = this;
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
        //    Program.CurrentResturantOwner = (RestaurantOwner)serializer2.ReadObject(respStream);

        //}
    }
}
