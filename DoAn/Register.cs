using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.Class;
using System.Data.SqlClient;

namespace DoAn
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            GenerateRandomID();
        }

        private void GenerateRandomID()
        {
            Random random = new Random();
            int randomID = random.Next(1000, 9999); 
            txtID.Text = randomID.ToString();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
           
        }
    }
}
