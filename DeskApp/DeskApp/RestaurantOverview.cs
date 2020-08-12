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
            tbFood.Text = Program.CurrentResturantOwner.Restaurant.Food[0].Name;
            tbWine.Text = Program.CurrentResturantOwner.Restaurant.Wine[0].Name;
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
            Program.CurrentResturantOwner.Restaurant.Food[0].Name = tbFood.Text;
            Program.CurrentResturantOwner.Restaurant.Wine[0].Name = tbWine.Text;
            Program.BackendConnect<RestaurantOwner>(Program.CurrentResturantOwner, Program.URL_REGISTRATION_PATH);
        }
    }
}
