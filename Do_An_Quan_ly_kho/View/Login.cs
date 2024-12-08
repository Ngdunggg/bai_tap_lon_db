﻿using Do_An_Quan_ly_kho;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Quan_ly_kho.Model;
using Do_An_Quan_ly_kho.Controller;
namespace WinFormDemo
{
    public partial class Login : Form
    {
        private DatabaseDataContext db = new DatabaseDataContext();
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = cbShowPass.Checked ? '\0' : '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
           
            
                LoginController t = new LoginController();
               t.XulyLogin(name, password ,this);
               


            
           
        }
    }
}
