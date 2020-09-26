using DeskApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            int Fvid = Program.GetVid<int>(Program.URL_GENERATE_VID_PATH);

            List<Food> hrana = new List<Food>();
            //hrana.Add(new Food("Njoke", new GradeSpread(1, 2, 3, 40, 50), 45.99, "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/chorizo-mozarella-gnocchi-bake-cropped-9ab73a3.jpg?quality=90&resize=700%2C636",0));
            List<Wine> vina = new List<Wine>();
            //vina.Add(new Wine("Riojas", new GradeSpread(1, 2, 3, 49, 150), 450.50, "https://www.chicagotribune.com/resizer/HMeCjL9nZGdSkbNDYr5IPIOSfAA=/1200x675/top/www.trbimg.com/img-5a8d6e51/turbine/ct-1519218254-hmtw3mzmjp-snap-image", 1));
            //Register();
            RestaurantOwner owner = new RestaurantOwner(tbUserName.Text, tbPass.Text,
                                    new RestaurantModel(tbRestaurantName.Text, tbRestaurantDetails.Text, 
                                    hrana, 
                                    vina, 
                                    new GradeSpread(0,0,0,0,0), "https://www.klikcup.com/images/objects/2022/mlynec-restaurant-2.jpg",
                                    Program.GetVid<int>(Program.URL_GENERATE_VID_PATH)));
            //System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(owner.GetType());
            //x.Serialize(Console.Out, owner);
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
