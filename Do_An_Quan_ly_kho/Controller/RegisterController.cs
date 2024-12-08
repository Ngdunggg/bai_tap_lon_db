using Do_An_Quan_ly_kho.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormDemo;

namespace Do_An_Quan_ly_kho.Controller
{
    internal class RegisterController
    {
        private DatabaseDataContext db = new DatabaseDataContext();
        public void XulyDangKi(string username,string password,string epassword , Form t)
        {
            if(username=="" || password=="" || epassword=="" ) 
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin ", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {
                var user = db.NguoiDungs.FirstOrDefault(x => x.TenDangNhap == username);
                if (user != null)
                {
                    MessageBox.Show("Tên đăng nhập đã bị trùng", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    if(password != epassword)
                    {
                        MessageBox.Show("Nhập lại mật khẩu không chính xác", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        NguoiDung newuser = new NguoiDung();
                        newuser.TenDangNhap=username;
                        newuser.MatKhau = password;
                        db.NguoiDungs.InsertOnSubmit(newuser);
                        db.SubmitChanges();
                        MessageBox.Show("Đăng kí thành công", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Login login = new Login();
                        login.Show();
                        t.Hide();


                    }


                }
                

            }

            

        }

    }
}
