namespace DeskApp
{
    partial class RestaurantOverview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSignOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRestaurantDetails = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRestaurantName = new System.Windows.Forms.TextBox();
            this.lblWine = new System.Windows.Forms.Label();
            this.tbWine = new System.Windows.Forms.TextBox();
            this.lblFood = new System.Windows.Forms.Label();
            this.tbFood = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSignOut
            // 
            this.btnSignOut.Font = new System.Drawing.Font("Segoe Script", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSignOut.Location = new System.Drawing.Point(622, 25);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(157, 65);
            this.btnSignOut.TabIndex = 2;
            this.btnSignOut.Text = "Odjava";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Detalji Restorana";
            // 
            // tbRestaurantDetails
            // 
            this.tbRestaurantDetails.Location = new System.Drawing.Point(111, 143);
            this.tbRestaurantDetails.Multiline = true;
            this.tbRestaurantDetails.Name = "tbRestaurantDetails";
            this.tbRestaurantDetails.Size = new System.Drawing.Size(186, 210);
            this.tbRestaurantDetails.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ime Restorana:";
            // 
            // tbRestaurantName
            // 
            this.tbRestaurantName.Location = new System.Drawing.Point(111, 82);
            this.tbRestaurantName.Name = "tbRestaurantName";
            this.tbRestaurantName.Size = new System.Drawing.Size(186, 20);
            this.tbRestaurantName.TabIndex = 10;
            // 
            // lblWine
            // 
            this.lblWine.AutoSize = true;
            this.lblWine.Location = new System.Drawing.Point(331, 240);
            this.lblWine.Name = "lblWine";
            this.lblWine.Size = new System.Drawing.Size(60, 13);
            this.lblWine.TabIndex = 17;
            this.lblWine.Text = "Popis Vina:";
            // 
            // tbWine
            // 
            this.tbWine.Location = new System.Drawing.Point(387, 263);
            this.tbWine.Multiline = true;
            this.tbWine.Name = "tbWine";
            this.tbWine.Size = new System.Drawing.Size(186, 90);
            this.tbWine.TabIndex = 16;
            // 
            // lblFood
            // 
            this.lblFood.AutoSize = true;
            this.lblFood.Location = new System.Drawing.Point(331, 59);
            this.lblFood.Name = "lblFood";
            this.lblFood.Size = new System.Drawing.Size(58, 13);
            this.lblFood.TabIndex = 15;
            this.lblFood.Text = "Popis Jela:";
            // 
            // tbFood
            // 
            this.tbFood.Location = new System.Drawing.Point(387, 82);
            this.tbFood.Multiline = true;
            this.tbFood.Name = "tbFood";
            this.tbFood.Size = new System.Drawing.Size(186, 112);
            this.tbFood.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Url Slike:";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(111, 397);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(462, 20);
            this.tbUrl.TabIndex = 18;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe Script", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnUpdate.Location = new System.Drawing.Point(622, 347);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(157, 65);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "Ažuriraj:";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // RestaurantOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.lblWine);
            this.Controls.Add(this.tbWine);
            this.Controls.Add(this.lblFood);
            this.Controls.Add(this.tbFood);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRestaurantDetails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbRestaurantName);
            this.Controls.Add(this.btnSignOut);
            this.Name = "RestaurantOverview";
            this.Text = "RestaurantOverview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRestaurantDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRestaurantName;
        private System.Windows.Forms.Label lblWine;
        private System.Windows.Forms.TextBox tbWine;
        private System.Windows.Forms.Label lblFood;
        private System.Windows.Forms.TextBox tbFood;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Button btnUpdate;
    }
}