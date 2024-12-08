namespace Do_An_Quan_ly_kho
{
    partial class FormThemPhieuXuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThemPhieuXuat));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddChiTietPhieuBan = new System.Windows.Forms.Button();
            this.cbCustomerName = new System.Windows.Forms.ComboBox();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvCateList = new System.Windows.Forms.DataGridView();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPx_id = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDateTime = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cbTenNguoiLap = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddPhieuBan = new System.Windows.Forms.Button();
            this.dgvExport = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textMaphieuXuat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxGia = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxSoluongKho = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCateList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(844, 748);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(184, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAddChiTietPhieuBan
            // 
            this.btnAddChiTietPhieuBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddChiTietPhieuBan.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddChiTietPhieuBan.Image = ((System.Drawing.Image)(resources.GetObject("btnAddChiTietPhieuBan.Image")));
            this.btnAddChiTietPhieuBan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddChiTietPhieuBan.Location = new System.Drawing.Point(986, 477);
            this.btnAddChiTietPhieuBan.Name = "btnAddChiTietPhieuBan";
            this.btnAddChiTietPhieuBan.Size = new System.Drawing.Size(184, 40);
            this.btnAddChiTietPhieuBan.TabIndex = 0;
            this.btnAddChiTietPhieuBan.Text = "Thêm Phiếu";
            this.btnAddChiTietPhieuBan.UseVisualStyleBackColor = true;
            this.btnAddChiTietPhieuBan.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbCustomerName
            // 
            this.cbCustomerName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomerName.FormattingEnabled = true;
            this.cbCustomerName.Location = new System.Drawing.Point(189, 93);
            this.cbCustomerName.Name = "cbCustomerName";
            this.cbCustomerName.Size = new System.Drawing.Size(438, 29);
            this.cbCustomerName.TabIndex = 14;
            this.cbCustomerName.Text = "— Chọn khách hàng  —";
            // 
            // cbProduct
            // 
            this.cbProduct.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(162, 472);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(339, 29);
            this.cbProduct.TabIndex = 13;
            this.cbProduct.Text = "— Chọn hàng hóa  —";
            this.cbProduct.SelectedIndexChanged += new System.EventHandler(this.cbProduct_SelectedIndexChanged);
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(511, 745);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(250, 30);
            this.txtTotal.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(365, 748);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 21);
            this.label8.TabIndex = 11;
            this.label8.Text = "Tổng Tiền:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 472);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tên Hàng Hóa:";
            // 
            // dgvCateList
            // 
            this.dgvCateList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCateList.Location = new System.Drawing.Point(-9, 257);
            this.dgvCateList.Name = "dgvCateList";
            this.dgvCateList.RowHeadersWidth = 51;
            this.dgvCateList.RowTemplate.Height = 24;
            this.dgvCateList.Size = new System.Drawing.Size(1190, 158);
            this.dgvCateList.TabIndex = 5;
            this.dgvCateList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCateList_CellClick);
            this.dgvCateList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCateList_CellContentClick);
            // 
            // txtCount
            // 
            this.txtCount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.Location = new System.Drawing.Point(653, 477);
            this.txtCount.Multiline = true;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(250, 30);
            this.txtCount.TabIndex = 7;
            this.txtCount.TextChanged += new System.EventHandler(this.txtCount_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(507, 480);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số Lượng Xuất:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Khách Hàng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Phiếu Xuất:";
            // 
            // txtPx_id
            // 
            this.txtPx_id.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPx_id.Location = new System.Drawing.Point(189, 42);
            this.txtPx_id.Multiline = true;
            this.txtPx_id.Name = "txtPx_id";
            this.txtPx_id.Size = new System.Drawing.Size(438, 30);
            this.txtPx_id.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.cbDateTime);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbTenNguoiLap);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnAddPhieuBan);
            this.groupBox1.Controls.Add(this.cbCustomerName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPx_id);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1179, 248);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Phiếu Xuất";
            // 
            // cbDateTime
            // 
            this.cbDateTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cbDateTime.Location = new System.Drawing.Point(815, 46);
            this.cbDateTime.Name = "cbDateTime";
            this.cbDateTime.Size = new System.Drawing.Size(250, 26);
            this.cbDateTime.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(667, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 23);
            this.label9.TabIndex = 26;
            this.label9.Text = "Ngày Nhập:";
            // 
            // cbTenNguoiLap
            // 
            this.cbTenNguoiLap.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTenNguoiLap.FormattingEnabled = true;
            this.cbTenNguoiLap.Location = new System.Drawing.Point(189, 152);
            this.cbTenNguoiLap.Name = "cbTenNguoiLap";
            this.cbTenNguoiLap.Size = new System.Drawing.Size(438, 29);
            this.cbTenNguoiLap.TabIndex = 25;
            this.cbTenNguoiLap.Text = "— Người lập phiếu  —";
            this.cbTenNguoiLap.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 21);
            this.label7.TabIndex = 24;
            this.label7.Text = "Người Lập";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnAddPhieuBan
            // 
            this.btnAddPhieuBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPhieuBan.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPhieuBan.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPhieuBan.Image")));
            this.btnAddPhieuBan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPhieuBan.Location = new System.Drawing.Point(671, 141);
            this.btnAddPhieuBan.Name = "btnAddPhieuBan";
            this.btnAddPhieuBan.Size = new System.Drawing.Size(184, 40);
            this.btnAddPhieuBan.TabIndex = 23;
            this.btnAddPhieuBan.Text = "Thêm Phiếu";
            this.btnAddPhieuBan.UseVisualStyleBackColor = true;
            this.btnAddPhieuBan.Click += new System.EventHandler(this.btnAddPhieuBan_Click);
            // 
            // dgvExport
            // 
            this.dgvExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExport.Location = new System.Drawing.Point(-9, 527);
            this.dgvExport.Name = "dgvExport";
            this.dgvExport.RowHeadersWidth = 51;
            this.dgvExport.RowTemplate.Height = 24;
            this.dgvExport.Size = new System.Drawing.Size(1190, 202);
            this.dgvExport.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "Chi tiết hóa đơn:";
            // 
            // textMaphieuXuat
            // 
            this.textMaphieuXuat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMaphieuXuat.Location = new System.Drawing.Point(340, 421);
            this.textMaphieuXuat.Multiline = true;
            this.textMaphieuXuat.Name = "textMaphieuXuat";
            this.textMaphieuXuat.Size = new System.Drawing.Size(250, 30);
            this.textMaphieuXuat.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(187, 430);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 21);
            this.label6.TabIndex = 23;
            this.label6.Text = "Mã phiếu xuất:";
            // 
            // textBoxGia
            // 
            this.textBoxGia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGia.Location = new System.Drawing.Point(668, 418);
            this.textBoxGia.Multiline = true;
            this.textBoxGia.Name = "textBoxGia";
            this.textBoxGia.Size = new System.Drawing.Size(184, 30);
            this.textBoxGia.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(606, 423);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 21);
            this.label10.TabIndex = 25;
            this.label10.Text = "Giá/1:";
            // 
            // textBoxSoluongKho
            // 
            this.textBoxSoluongKho.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSoluongKho.Location = new System.Drawing.Point(986, 417);
            this.textBoxSoluongKho.Multiline = true;
            this.textBoxSoluongKho.Name = "textBoxSoluongKho";
            this.textBoxSoluongKho.Size = new System.Drawing.Size(184, 30);
            this.textBoxSoluongKho.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(899, 421);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 21);
            this.label11.TabIndex = 27;
            this.label11.Text = "Slg kho:";
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(878, 141);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(148, 40);
            this.btnEdit.TabIndex = 28;
            this.btnEdit.Text = "Sửa Phiếu";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(34, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 40);
            this.button1.TabIndex = 29;
            this.button1.Text = "Xóa";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormThemPhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1182, 831);
            this.Controls.Add(this.textBoxSoluongKho);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxGia);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textMaphieuXuat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvExport);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cbProduct);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddChiTietPhieuBan);
            this.Controls.Add(this.dgvCateList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormThemPhieuXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPhieuXuat";
            this.Load += new System.EventHandler(this.FormThemPhieuXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCateList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddChiTietPhieuBan;
        private System.Windows.Forms.ComboBox cbCustomerName;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvCateList;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPx_id;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvExport;
        private System.Windows.Forms.Button btnAddPhieuBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTenNguoiLap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker cbDateTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textMaphieuXuat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxGia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxSoluongKho;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button button1;
    }
}