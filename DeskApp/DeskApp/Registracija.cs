﻿using DeskApp.Models;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DeskApp
{
    public partial class Registracija : Form
    {

        public Registracija()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //Register();
            RestaurantOwner owner = new RestaurantOwner(tbUserName.Text, tbPass.Text,
                                    new RestaurantModel(tbRestaurantName.Text, tbRestaurantDetails.Text, "nema hrane", "nema vina", 4.3, "nema slike"));
            Program.BackendConnect<RestaurantOwner>(owner, Program.URL_REGISTRATION_PATH);
            this.Close();
            Program.previousForm.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Program.previousForm.Show();

        }

        //private void Register()
        //{
        //RestaurantOwner owner = new RestaurantOwner(tbUserName.Text, tbPass.Text,
        //            new RestaurantModel(tbRestaurantName.Text, tbRestaurantDetails.Text, "nema hrane", "nema vina", 4.3, "nema slike"));

        //    MemoryStream ms = new MemoryStream();
        //    XmlWriter writer = XmlWriter.Create(ms);

        //    DataContractSerializer serializer = new DataContractSerializer(typeof(RestaurantOwner));
        //    serializer.WriteObject(writer, owner);
        //    writer.Close();

        //    byte[] data = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(ms.ToArray()));

        //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://fineoicar.azurewebsites.net/api/restaurant/desktop/insert");
        //    req.Method = "POST";
        //    req.Accept = "application/xml";
        //    req.ContentType = "application/xml";

        //    Stream reqStream = req.GetRequestStream();
        //    reqStream.Write(data, 0, data.Length);

        //    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        //    Stream respStream = resp.GetResponseStream();

        //    System.Diagnostics.Debug.WriteLine("Server = " + resp.Server);
        //    System.Diagnostics.Debug.WriteLine("Status Code = " + resp.StatusCode);
        //    System.Diagnostics.Debug.WriteLine("Headers = " + resp.Headers);
        //    System.Diagnostics.Debug.WriteLine("Resp = " + resp.ToString());
        //}
    }
}
