﻿using Do_An_Quan_ly_kho.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WinFormDemo;

namespace Do_An_Quan_ly_kho.Controller
{
    public class LoginController
    {
        public static int userId;
        public static string role = "";
         DatabaseDataContext db = new DatabaseDataContext();
        public void XulyLogin(string username , string password , bool Checksavemk , Form loginn) {

            var user = db.NguoiDungs.FirstOrDefault(x => x.TenDangNhap == username);
            
            if (username == "" || password == "") {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin ", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (user == null)
                {
                    MessageBox.Show("Không tồn tại người dùng", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var matkhau = db.NguoiDungs
               .Where(x => x.TenDangNhap == username)
               .Select(x => new { x.MatKhau, x.MaNguoiDung, x.MoTa })
               .FirstOrDefault();
                    if (matkhau.MatKhau == password)
                    {
                        MessageBox.Show("Đăng nhập thành công", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        userId = matkhau.MaNguoiDung;
                        role = matkhau.MoTa;
                        if (Checksavemk == true)
                        {
                            Do_An_Quan_ly_kho.Properties.Settings.Default.username = username;
                            Do_An_Quan_ly_kho.Properties.Settings.Default.password = password;
                            Do_An_Quan_ly_kho.Properties.Settings.Default.checkluumk = true;

                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            Do_An_Quan_ly_kho.Properties.Settings.Default.username = "";
                            Do_An_Quan_ly_kho.Properties.Settings.Default.password = "";
                            Do_An_Quan_ly_kho.Properties.Settings.Default.checkluumk = false;
                            Properties.Settings.Default.Save();
                        }



                        frmMain dashboard = new frmMain();
                        dashboard.Show();
                        loginn.Hide();
                    }
                    else { MessageBox.Show("Mật khẩu không chính xác", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }



                }
            }
        }


    }
}
