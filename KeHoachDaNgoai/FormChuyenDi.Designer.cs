
namespace KeHoachDaNgoai
{
    partial class FormChuyenDi
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblThongTin;
        private System.Windows.Forms.Label lblTenChuyen;
        private System.Windows.Forms.Label lblDiaDiem;
        private System.Windows.Forms.Label lblNgayDi;
        private System.Windows.Forms.Label lblSoNguoi;
        private System.Windows.Forms.Label lblNganSach;
        private System.Windows.Forms.Label lblPhuongTien;
        private System.Windows.Forms.Label lblNgonNgu;

        private System.Windows.Forms.TextBox txtTenChuyen;
        private System.Windows.Forms.TextBox txtDiaDiem;
        private System.Windows.Forms.DateTimePicker dtpNgayDi;
        private System.Windows.Forms.NumericUpDown nudSoNguoi;
        private System.Windows.Forms.NumericUpDown nudNganSach;
        private System.Windows.Forms.ComboBox cboPhuongTien;
        private System.Windows.Forms.ComboBox cboNgonNgu;
        private System.Windows.Forms.CheckBox chkDaHoanThanh;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXemThoiTiet;

        private System.Windows.Forms.GroupBox grpThoiTiet;
        private System.Windows.Forms.Label lblBieuTuong;
        private System.Windows.Forms.Label lblMoTaThoiTiet;
        private System.Windows.Forms.Label lblNhietDo;
        private System.Windows.Forms.Label lblKhaNangMua;
        private System.Windows.Forms.Label lblCanhBao;
        private System.Windows.Forms.ProgressBar prgThoiTiet;

        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.CheckBox chkChuaHoanThanh;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.DataGridView dgvChuyenDi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTieuDe = new System.Windows.Forms.Label();
            lblThongTin = new System.Windows.Forms.Label();
            lblTenChuyen = new System.Windows.Forms.Label();
            lblDiaDiem = new System.Windows.Forms.Label();
            lblNgayDi = new System.Windows.Forms.Label();
            lblSoNguoi = new System.Windows.Forms.Label();
            lblNganSach = new System.Windows.Forms.Label();
            lblPhuongTien = new System.Windows.Forms.Label();
            lblNgonNgu = new System.Windows.Forms.Label();

            txtTenChuyen = new System.Windows.Forms.TextBox();
            txtDiaDiem = new System.Windows.Forms.TextBox();
            dtpNgayDi = new System.Windows.Forms.DateTimePicker();
            nudSoNguoi = new System.Windows.Forms.NumericUpDown();
            nudNganSach = new System.Windows.Forms.NumericUpDown();
            cboPhuongTien = new System.Windows.Forms.ComboBox();
            cboNgonNgu = new System.Windows.Forms.ComboBox();
            chkDaHoanThanh = new System.Windows.Forms.CheckBox();

            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            btnXemThoiTiet = new System.Windows.Forms.Button();

            grpThoiTiet = new System.Windows.Forms.GroupBox();
            lblBieuTuong = new System.Windows.Forms.Label();
            lblMoTaThoiTiet = new System.Windows.Forms.Label();
            lblNhietDo = new System.Windows.Forms.Label();
            lblKhaNangMua = new System.Windows.Forms.Label();
            lblCanhBao = new System.Windows.Forms.Label();
            prgThoiTiet = new System.Windows.Forms.ProgressBar();

            lblTimKiem = new System.Windows.Forms.Label();
            txtTimKiem = new System.Windows.Forms.TextBox();
            chkChuaHoanThanh = new System.Windows.Forms.CheckBox();
            lblTuNgay = new System.Windows.Forms.Label();
            lblDenNgay = new System.Windows.Forms.Label();
            dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            btnLoc = new System.Windows.Forms.Button();
            dgvChuyenDi = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)nudSoNguoi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNganSach).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenDi).BeginInit();
            grpThoiTiet.SuspendLayout();
            SuspendLayout();

            // Form
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1120, 720);
            MinimumSize = new System.Drawing.Size(1000, 650);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Kế hoạch dã ngoại";
            Font = new System.Drawing.Font("Segoe UI", 9F);
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

            // Title
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new System.Drawing.Font(
                "Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(35, 55, 80);
            lblTieuDe.Location = new System.Drawing.Point(20, 12);
            lblTieuDe.Text = "Kế hoạch dã ngoại cuối tuần";

            // Language
            lblNgonNgu.AutoSize = true;
            lblNgonNgu.Location = new System.Drawing.Point(850, 24);
            lblNgonNgu.Text = "Ngôn ngữ:";

            cboNgonNgu.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboNgonNgu.Items.AddRange(new object[]
            {
                "Tiếng Việt", "English"
            });
            cboNgonNgu.SelectedIndex = 0;
            cboNgonNgu.Location = new System.Drawing.Point(930, 19);
            cboNgonNgu.Size = new System.Drawing.Size(165, 25);

            // Information title
            lblThongTin.AutoSize = true;
            lblThongTin.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblThongTin.Location = new System.Drawing.Point(22, 55);
            lblThongTin.Text = "Thông tin chuyến đi";

            // Labels
            lblTenChuyen.AutoSize = true;
            lblTenChuyen.Location = new System.Drawing.Point(25, 88);
            lblTenChuyen.Text = "Tên chuyến:";

            lblDiaDiem.AutoSize = true;
            lblDiaDiem.Location = new System.Drawing.Point(25, 122);
            lblDiaDiem.Text = "Địa điểm:";

            lblNgayDi.AutoSize = true;
            lblNgayDi.Location = new System.Drawing.Point(25, 156);
            lblNgayDi.Text = "Ngày đi:";

            lblSoNguoi.AutoSize = true;
            lblSoNguoi.Location = new System.Drawing.Point(25, 190);
            lblSoNguoi.Text = "Số người:";

            lblNganSach.AutoSize = true;
            lblNganSach.Location = new System.Drawing.Point(25, 224);
            lblNganSach.Text = "Ngân sách:";

            lblPhuongTien.AutoSize = true;
            lblPhuongTien.Location = new System.Drawing.Point(25, 258);
            lblPhuongTien.Text = "Phương tiện:";

            // Textboxes
            txtTenChuyen.Location = new System.Drawing.Point(125, 84);
            txtTenChuyen.Size = new System.Drawing.Size(260, 25);
            txtTenChuyen.MaxLength = 100;

            txtDiaDiem.Location = new System.Drawing.Point(125, 118);
            txtDiaDiem.Size = new System.Drawing.Size(260, 25);
            txtDiaDiem.MaxLength = 100;

            // Date
            dtpNgayDi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpNgayDi.CustomFormat = "dd/MM/yyyy";
            dtpNgayDi.Location = new System.Drawing.Point(125, 152);
            dtpNgayDi.Size = new System.Drawing.Size(260, 25);
            dtpNgayDi.MinDate = DateTime.Today;
            dtpNgayDi.Value = DateTime.Today.AddDays(1);

            // People
            nudSoNguoi.Location = new System.Drawing.Point(125, 186);
            nudSoNguoi.Size = new System.Drawing.Size(260, 25);
            nudSoNguoi.Minimum = 1;
            nudSoNguoi.Maximum = 1000;
            nudSoNguoi.Value = 1;

            // Budget
            nudNganSach.Location = new System.Drawing.Point(125, 220);
            nudNganSach.Size = new System.Drawing.Size(260, 25);
            nudNganSach.Minimum = 0;
            nudNganSach.Maximum = 999999999999999;
            nudNganSach.DecimalPlaces = 0;
            nudNganSach.ThousandsSeparator = true;
            nudNganSach.Increment = 100000;

            // Transport
            cboPhuongTien.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboPhuongTien.Items.AddRange(new object[]
            {
                "Xe máy", "Ô tô", "Xe khách", "Tàu hỏa"
            });
            cboPhuongTien.SelectedIndex = 1;
            cboPhuongTien.Location = new System.Drawing.Point(125, 254);
            cboPhuongTien.Size = new System.Drawing.Size(260, 25);

            // Completed
            chkDaHoanThanh.AutoSize = true;
            chkDaHoanThanh.Location = new System.Drawing.Point(125, 286);
            chkDaHoanThanh.Text = "Đã hoàn thành";

            // Buttons
            btnThem.Location = new System.Drawing.Point(25, 322);
            btnThem.Size = new System.Drawing.Size(82, 34);
            btnThem.Text = "Thêm";
            btnThem.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnThem.ForeColor = System.Drawing.Color.White;
            btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnThem.FlatAppearance.BorderSize = 0;

            btnSua.Location = new System.Drawing.Point(113, 322);
            btnSua.Size = new System.Drawing.Size(82, 34);
            btnSua.Text = "Sửa";

            btnXoa.Location = new System.Drawing.Point(201, 322);
            btnXoa.Size = new System.Drawing.Size(82, 34);
            btnXoa.Text = "Xóa";

            btnLamMoi.Location = new System.Drawing.Point(289, 322);
            btnLamMoi.Size = new System.Drawing.Size(96, 34);
            btnLamMoi.Text = "Làm mới";

            // Weather panel
            grpThoiTiet.Location = new System.Drawing.Point(420, 58);
            grpThoiTiet.Size = new System.Drawing.Size(675, 298);
            grpThoiTiet.Text = "Dự báo thời tiết";
            grpThoiTiet.BackColor = System.Drawing.Color.White;
            grpThoiTiet.ForeColor = System.Drawing.Color.FromArgb(35, 55, 80);

            btnXemThoiTiet.Location = new System.Drawing.Point(15, 25);
            btnXemThoiTiet.Size = new System.Drawing.Size(135, 32);
            btnXemThoiTiet.Text = "Xem thời tiết";
            btnXemThoiTiet.BackColor =
                System.Drawing.Color.FromArgb(37, 99, 235);
            btnXemThoiTiet.ForeColor = System.Drawing.Color.White;
            btnXemThoiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnXemThoiTiet.FlatAppearance.BorderSize = 0;

            prgThoiTiet.Location = new System.Drawing.Point(160, 30);
            prgThoiTiet.Size = new System.Drawing.Size(495, 20);
            prgThoiTiet.Style =
                System.Windows.Forms.ProgressBarStyle.Marquee;
            prgThoiTiet.MarqueeAnimationSpeed = 30;
            prgThoiTiet.Visible = false;

            lblBieuTuong.Location = new System.Drawing.Point(25, 85);
            lblBieuTuong.Size = new System.Drawing.Size(145, 110);
            lblBieuTuong.Font = new System.Drawing.Font("Segoe UI Emoji", 52F);
            lblBieuTuong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblBieuTuong.Text = "🌤️";

            lblMoTaThoiTiet.Location = new System.Drawing.Point(190, 82);
            lblMoTaThoiTiet.Size = new System.Drawing.Size(440, 35);
            lblMoTaThoiTiet.Font = new System.Drawing.Font(
                "Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblMoTaThoiTiet.Text = "Chưa tra cứu thời tiết";

            lblNhietDo.Location = new System.Drawing.Point(195, 125);
            lblNhietDo.Size = new System.Drawing.Size(430, 28);
            lblNhietDo.Text = "Nhiệt độ: --°C đến --°C";

            lblKhaNangMua.Location = new System.Drawing.Point(195, 160);
            lblKhaNangMua.Size = new System.Drawing.Size(430, 28);
            lblKhaNangMua.Text = "Khả năng mưa: --%";

            lblCanhBao.Location = new System.Drawing.Point(15, 220);
            lblCanhBao.Size = new System.Drawing.Size(640, 48);
            lblCanhBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblCanhBao.BackColor = System.Drawing.Color.FromArgb(255, 237, 213);
            lblCanhBao.ForeColor = System.Drawing.Color.FromArgb(154, 52, 18);
            lblCanhBao.Text = "Thông tin thời tiết sẽ hiển thị tại đây.";
            lblCanhBao.Padding = new System.Windows.Forms.Padding(5);

            grpThoiTiet.Controls.Add(btnXemThoiTiet);
            grpThoiTiet.Controls.Add(prgThoiTiet);
            grpThoiTiet.Controls.Add(lblBieuTuong);
            grpThoiTiet.Controls.Add(lblMoTaThoiTiet);
            grpThoiTiet.Controls.Add(lblNhietDo);
            grpThoiTiet.Controls.Add(lblKhaNangMua);
            grpThoiTiet.Controls.Add(lblCanhBao);

            // Search and filters
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new System.Drawing.Point(22, 382);
            lblTimKiem.Text = "Tìm địa điểm / tên chuyến:";

            txtTimKiem.Location = new System.Drawing.Point(190, 378);
            txtTimKiem.Size = new System.Drawing.Size(205, 25);

            chkChuaHoanThanh.AutoSize = true;
            chkChuaHoanThanh.Location = new System.Drawing.Point(410, 382);
            chkChuaHoanThanh.Text = "Chỉ hiện chuyến chưa hoàn thành";

            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new System.Drawing.Point(22, 418);
            lblTuNgay.Text = "Từ ngày:";

            dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.ShowCheckBox = true;
            dtpTuNgay.Checked = false;
            dtpTuNgay.Location = new System.Drawing.Point(90, 414);
            dtpTuNgay.Size = new System.Drawing.Size(150, 25);

            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new System.Drawing.Point(260, 418);
            lblDenNgay.Text = "Đến ngày:";

            dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.ShowCheckBox = true;
            dtpDenNgay.Checked = false;
            dtpDenNgay.Location = new System.Drawing.Point(330, 414);
            dtpDenNgay.Size = new System.Drawing.Size(150, 25);

            btnLoc.Location = new System.Drawing.Point(500, 410);
            btnLoc.Size = new System.Drawing.Size(95, 32);
            btnLoc.Text = "Lọc";

            // Data grid
            dgvChuyenDi.Location = new System.Drawing.Point(22, 458);
            dgvChuyenDi.Size = new System.Drawing.Size(1073, 225);
            dgvChuyenDi.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            dgvChuyenDi.AllowUserToAddRows = false;
            dgvChuyenDi.AllowUserToDeleteRows = false;
            dgvChuyenDi.ReadOnly = true;
            dgvChuyenDi.MultiSelect = false;
            dgvChuyenDi.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvChuyenDi.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvChuyenDi.RowHeadersWidth = 30;
            dgvChuyenDi.BackgroundColor = System.Drawing.Color.White;
            dgvChuyenDi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dgvChuyenDi.EnableHeadersVisualStyles = false;
            dgvChuyenDi.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(226, 232, 240);
            dgvChuyenDi.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(30, 41, 59);
            dgvChuyenDi.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            dgvChuyenDi.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(248, 250, 252);

            // Add controls
            Controls.Add(lblTieuDe);
            Controls.Add(lblNgonNgu);
            Controls.Add(cboNgonNgu);
            Controls.Add(lblThongTin);

            Controls.Add(lblTenChuyen);
            Controls.Add(lblDiaDiem);
            Controls.Add(lblNgayDi);
            Controls.Add(lblSoNguoi);
            Controls.Add(lblNganSach);
            Controls.Add(lblPhuongTien);

            Controls.Add(txtTenChuyen);
            Controls.Add(txtDiaDiem);
            Controls.Add(dtpNgayDi);
            Controls.Add(nudSoNguoi);
            Controls.Add(nudNganSach);
            Controls.Add(cboPhuongTien);
            Controls.Add(chkDaHoanThanh);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);

            Controls.Add(grpThoiTiet);

            Controls.Add(lblTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(chkChuaHoanThanh);
            Controls.Add(lblTuNgay);
            Controls.Add(dtpTuNgay);
            Controls.Add(lblDenNgay);
            Controls.Add(dtpDenNgay);
            Controls.Add(btnLoc);
            Controls.Add(dgvChuyenDi);

            ((System.ComponentModel.ISupportInitialize)nudSoNguoi).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNganSach).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenDi).EndInit();

            grpThoiTiet.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
