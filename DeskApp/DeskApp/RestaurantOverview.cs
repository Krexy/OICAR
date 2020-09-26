using DeskApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskApp
{
    public partial class RestaurantOverview : Form
    {
        public RestaurantOverview()
        {
            InitializeComponent();
            tbRestaurantName.Text = Program.CurrentResturantOwner.Restaurant.RestaurantName;
            tbRestaurantDetails.Text = Program.CurrentResturantOwner.Restaurant.RestaurantDetails;
            tbUrl.Text = Program.CurrentResturantOwner.Restaurant.Image;
            //tbFood.Text = Program.CurrentResturantOwner.Restaurant.Food[0].Name;
            //tbWine.Text = Program.CurrentResturantOwner.Restaurant.Wine[0].Name;

            foreach (var food in Program.CurrentResturantOwner.Restaurant.Food)
            {
                dgvFood.Rows.Add(new Object[] { food.Name, food.Price, food.Image });

            }

            foreach (var wine in Program.CurrentResturantOwner.Restaurant.Wine)
            {
                dgvWine.Rows.Add(new Object[] { wine.Name, wine.Price, wine.Image });

            }

            //foreach (DataGridViewRow row in dgvFood.Rows)
            //{
            //    row.Cells[0].Value
            //}

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (Program.previousForm != this)
            {
                Program.previousForm.Close();
            }

        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Program.previousForm.Show();
            Program.previousForm = this;
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Program.CurrentResturantOwner.Restaurant.RestaurantName = tbRestaurantName.Text;
            Program.CurrentResturantOwner.Restaurant.RestaurantDetails = tbRestaurantDetails.Text;
            Program.CurrentResturantOwner.Restaurant.Image = tbUrl.Text;



            //prvo ocisti sve koji nisu u tablici
            //foreach (DataRow row in dgvFood.Rows) {
            //    foreach (var food in Program.CurrentResturantOwner.Restaurant.Food)
            //    {
            //        if (food.Name == row[0].ToString())
            //        {

            //        }
            //    }
            //}
            Program.CurrentResturantOwner.Restaurant.Food.Clear();
            for (int i = 0; i < dgvFood.Rows.Count-1; i++)
            {
                //if (Program.CurrentResturantOwner.Restaurant.Food.Where(f => f.Name.Contains(dgvFood.Rows[i].Cells[0].Value.ToString())).Count() > 0)
                //{
                //    //postoji i onda je update
                //}
                //else if () { 
                //    //nepostoji i onda obrisi
                //}
                Boolean price = double.TryParse(dgvFood.Rows[i].Cells[1].Value?.ToString(), out double result);
                Program.CurrentResturantOwner.Restaurant.Food.Add(
                    new Food()
                    {
                        Name = dgvFood.Rows[i].Cells[0].Value?.ToString(),
                        Price = price?result:0,
                        Image = dgvFood.Rows[i].Cells[2].Value?.ToString(),
                        VID = Program.GetVid<int>(Program.URL_GENERATE_VID_PATH),
                        Grade = new GradeSpread(0,0,0,0,0)
                    });
                
            }

            Program.CurrentResturantOwner.Restaurant.Wine.Clear();
            for (int i = 0; i < dgvWine.Rows.Count - 1; i++)
            {
                //if (Program.CurrentResturantOwner.Restaurant.Food.Where(f => f.Name.Contains(dgvFood.Rows[i].Cells[0].Value.ToString())).Count() > 0)
                //{
                //    //postoji i onda je update
                //}
                //else if () { 
                //    //nepostoji i onda obrisi
                //}
                Boolean price = double.TryParse(dgvWine.Rows[i].Cells[1].Value?.ToString(), out double result);
                Program.CurrentResturantOwner.Restaurant.Wine.Add(
                    new Wine()
                    {
                        Name = dgvWine.Rows[i].Cells[0].Value?.ToString(),
                        Price = price ? result : 0,
                        Image = dgvWine.Rows[i].Cells[2].Value?.ToString(),
                        VID = Program.GetVid<int>(Program.URL_GENERATE_VID_PATH),
                        Grade = new GradeSpread(0, 0, 0, 0, 0)
                    });

            }
            //foreach (var row in dgvFood.Rows)
            //{

            //    foreach (var r in dgvFood.Rows[0].Cells)
            //    {

            //    }
            //    //if (Program.CurrentResturantOwner.Restaurant.Food.Where(f => f.Name.Contains(row[0].ToString())).Count() > 0)
            //    //{
            //    //    //postoji i onda je update
            //    //}
            //    //else
            //    //{
            //    //nepostoji i onda je add
            //    Program.CurrentResturantOwner.Restaurant.Food.Add(
            //        new Food()
            //        {
            //            Name = row[0]. ToString(),
            //            Price = double.Parse(row[1].ToString()),
            //            Image = row[2].ToString(),
            //            VID = Program.GetVid<int>(Program.URL_GENERATE_VID_PATH)
            //        });
            //    //}

            //}

            //Program.CurrentResturantOwner.Restaurant.Food[0].Name = tbFood.Text;
            //Program.CurrentResturantOwner.Restaurant.Wine[0].Name = tbWine.Text;


            Program.BackendConnect<RestaurantOwner>(Program.CurrentResturantOwner, Program.URL_REGISTRATION_PATH);
            MessageBox.Show(this,"Podaci Uspješno Ažurirani!");
        }
    }
}
