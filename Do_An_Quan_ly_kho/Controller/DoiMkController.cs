using Do_An_Quan_ly_kho.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Quan_ly_kho.Controller
{
    internal class DoiMkController

    {
        public void XulyDoiMk(string mkcu, string mkmoi, string mknhaplai ,Form t ) 
        {
           
            if (mkcu == "" || mkmoi == "" || mknhaplai == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

          
            if (mkmoi != mknhaplai)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp với mật khẩu mới", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DatabaseDataContext db = new DatabaseDataContext();

           
            var mkreal = db.NguoiDungs
                .Where(x => x.MaNguoiDung == LoginController.userId)
                .Select(x => x.MatKhau)
                .FirstOrDefault();

           
            if (mkreal == mkcu)
            {
             
                var userToUpdate = db.NguoiDungs.FirstOrDefault(x => x.MaNguoiDung == LoginController.userId);
                if (userToUpdate != null)
                {
                    userToUpdate.MatKhau = mkmoi; 
                    db.SubmitChanges(); 
                    MessageBox.Show("Mật khẩu đã được cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    t.Hide();

                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
