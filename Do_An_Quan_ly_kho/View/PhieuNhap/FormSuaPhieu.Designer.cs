﻿namespace Do_An_Quan_ly_kho.View.PhieuNhap
{
    partial class FormSuaPhieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSuaPhieu));
            this.dgvReceiptEdit = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.text_MaPhieuNhap = new System.Windows.Forms.TextBox();
            this.text_tenhanghoa = new System.Windows.Forms.TextBox();
            this.cbSanpham = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.text_giasp = new System.Windows.Forms.TextBox();
            this.text_Diachi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.text_Sdt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_Tennhacungcap = new System.Windows.Forms.TextBox();
            this.cbNhanvien = new System.Windows.Forms.ComboBox();
            this.txt_Tongtien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptEdit)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReceiptEdit
            // 
            this.dgvReceiptEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiptEdit.Location = new System.Drawing.Point(2, 255);
            this.dgvReceiptEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvReceiptEdit.Name = "dgvReceiptEdit";
            this.dgvReceiptEdit.RowHeadersWidth = 51;
            this.dgvReceiptEdit.RowTemplate.Height = 24;
            this.dgvReceiptEdit.Size = new System.Drawing.Size(884, 370);
            this.dgvReceiptEdit.TabIndex = 5;
            this.dgvReceiptEdit.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceiptEdit_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(710, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(176, 247);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(22, 66);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(138, 32);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Sửa Phiếu";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.text_MaPhieuNhap);
            this.groupBox1.Controls.Add(this.text_tenhanghoa);
            this.groupBox1.Controls.Add(this.cbSanpham);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.text_giasp);
            this.groupBox1.Controls.Add(this.text_Diachi);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.text_Sdt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.text_Tennhacungcap);
            this.groupBox1.Controls.Add(this.cbNhanvien);
            this.groupBox1.Controls.Add(this.txt_Tongtien);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSoluong);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(711, 247);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sửa Phiếu nhập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 18);
            this.label1.TabIndex = 27;
            this.label1.Text = "Mã Phiếu Nhập:";
            // 
            // text_MaPhieuNhap
            // 
            this.text_MaPhieuNhap.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_MaPhieuNhap.Location = new System.Drawing.Point(152, 32);
            this.text_MaPhieuNhap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_MaPhieuNhap.Multiline = true;
            this.text_MaPhieuNhap.Name = "text_MaPhieuNhap";
            this.text_MaPhieuNhap.Size = new System.Drawing.Size(188, 25);
            this.text_MaPhieuNhap.TabIndex = 26;
            this.text_MaPhieuNhap.TextChanged += new System.EventHandler(this.text_MaPhieuNhap_TextChanged);
            // 
            // text_tenhanghoa
            // 
            this.text_tenhanghoa.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_tenhanghoa.Location = new System.Drawing.Point(495, 80);
            this.text_tenhanghoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_tenhanghoa.Multiline = true;
            this.text_tenhanghoa.Name = "text_tenhanghoa";
            this.text_tenhanghoa.Size = new System.Drawing.Size(188, 25);
            this.text_tenhanghoa.TabIndex = 25;
            this.text_tenhanghoa.TextChanged += new System.EventHandler(this.text_tenhanghoa_TextChanged);
            // 
            // cbSanpham
            // 
            this.cbSanpham.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSanpham.FormattingEnabled = true;
            this.cbSanpham.Location = new System.Drawing.Point(495, 35);
            this.cbSanpham.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSanpham.Name = "cbSanpham";
            this.cbSanpham.Size = new System.Drawing.Size(188, 22);
            this.cbSanpham.TabIndex = 24;
            this.cbSanpham.Text = "— Chọn loại hàng  —";
            this.cbSanpham.SelectedIndexChanged += new System.EventHandler(this.cbSanpham_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(386, 126);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 18);
            this.label10.TabIndex = 23;
            this.label10.Text = "Giá sản phẩm:";
            // 
            // text_giasp
            // 
            this.text_giasp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_giasp.Location = new System.Drawing.Point(495, 126);
            this.text_giasp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_giasp.Multiline = true;
            this.text_giasp.Name = "text_giasp";
            this.text_giasp.Size = new System.Drawing.Size(188, 25);
            this.text_giasp.TabIndex = 22;
            this.text_giasp.TextChanged += new System.EventHandler(this.text_giasp_TextChanged);
            // 
            // text_Diachi
            // 
            this.text_Diachi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_Diachi.Location = new System.Drawing.Point(152, 163);
            this.text_Diachi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_Diachi.Multiline = true;
            this.text_Diachi.Name = "text_Diachi";
            this.text_Diachi.Size = new System.Drawing.Size(188, 25);
            this.text_Diachi.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 169);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "Địa Chỉ:";
            // 
            // text_Sdt
            // 
            this.text_Sdt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_Sdt.Location = new System.Drawing.Point(152, 120);
            this.text_Sdt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_Sdt.Multiline = true;
            this.text_Sdt.Name = "text_Sdt";
            this.text_Sdt.Size = new System.Drawing.Size(188, 25);
            this.text_Sdt.TabIndex = 19;
            this.text_Sdt.TextChanged += new System.EventHandler(this.text_Sdt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Số Điện Thoại:";
            // 
            // text_Tennhacungcap
            // 
            this.text_Tennhacungcap.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_Tennhacungcap.Location = new System.Drawing.Point(152, 80);
            this.text_Tennhacungcap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_Tennhacungcap.Multiline = true;
            this.text_Tennhacungcap.Name = "text_Tennhacungcap";
            this.text_Tennhacungcap.Size = new System.Drawing.Size(188, 25);
            this.text_Tennhacungcap.TabIndex = 17;
            this.text_Tennhacungcap.TextChanged += new System.EventHandler(this.text_Tennhacungcap_TextChanged);
            // 
            // cbNhanvien
            // 
            this.cbNhanvien.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNhanvien.FormattingEnabled = true;
            this.cbNhanvien.Location = new System.Drawing.Point(152, 206);
            this.cbNhanvien.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbNhanvien.Name = "cbNhanvien";
            this.cbNhanvien.Size = new System.Drawing.Size(188, 22);
            this.cbNhanvien.TabIndex = 15;
            this.cbNhanvien.Text = "— Chọn nhân viên  —";
            this.cbNhanvien.SelectedIndexChanged += new System.EventHandler(this.cbNhanvien_SelectedIndexChanged);
            // 
            // txt_Tongtien
            // 
            this.txt_Tongtien.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Tongtien.Location = new System.Drawing.Point(495, 208);
            this.txt_Tongtien.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Tongtien.Multiline = true;
            this.txt_Tongtien.Name = "txt_Tongtien";
            this.txt_Tongtien.Size = new System.Drawing.Size(188, 25);
            this.txt_Tongtien.TabIndex = 12;
            this.txt_Tongtien.TextChanged += new System.EventHandler(this.txt_Tongtien_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(386, 208);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 11;
            this.label8.Text = "Tổng Tiền:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 208);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "Nhân Viên Tạo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(386, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tên Hàng Hoá:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(386, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Loại Hàng Hoá:";
            // 
            // txtSoluong
            // 
            this.txtSoluong.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoluong.Location = new System.Drawing.Point(495, 169);
            this.txtSoluong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSoluong.Multiline = true;
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(188, 25);
            this.txtSoluong.TabIndex = 7;
            this.txtSoluong.TextChanged += new System.EventHandler(this.txtSoluong_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(386, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số Lượng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Nhà Cung Cấp:";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(22, 120);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Hoàn Thành";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormSuaPhieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(886, 628);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvReceiptEdit);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormSuaPhieu";
            this.Text = "FormSuaPhieu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptEdit)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReceiptEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox text_tenhanghoa;
        private System.Windows.Forms.ComboBox cbSanpham;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox text_giasp;
        private System.Windows.Forms.TextBox text_Diachi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox text_Sdt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_Tennhacungcap;
        private System.Windows.Forms.ComboBox cbNhanvien;
        private System.Windows.Forms.TextBox txt_Tongtien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_MaPhieuNhap;
        private System.Windows.Forms.Button button1;
    }
}