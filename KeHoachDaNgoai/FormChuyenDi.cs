
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using KeHoachDaNgoai.Models;
using KeHoachDaNgoai.Services;
using System.Drawing;

namespace KeHoachDaNgoai
{
    public partial class FormChuyenDi : Form
    {
        private readonly QLDaNgoaiContext _db = new QLDaNgoaiContext();

        private readonly ThoiTietService _thoiTietService = new ThoiTietService();

        private int? _maChuyenDangChon = null;

        private UserSettings _settings = new UserSettings();
        private bool _dangKhoiTaoNgonNgu = false;

        private bool LaTiengAnh =>
            _settings.Language == "en";
        public FormChuyenDi()
        {
            InitializeComponent();

            Load += FormChuyenDi_Load;
            dgvChuyenDi.CellClick += dgvChuyenDi_CellClick;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnLoc.Click += btnLoc_Click;
            btnXemThoiTiet.Click += btnXemThoiTiet_Click;
            cboNgonNgu.SelectedIndexChanged += cboNgonNgu_SelectedIndexChanged;

            txtTimKiem.TextChanged += (s, e) => TaiDanhSach();
            chkChuaHoanThanh.CheckedChanged += (s, e) => TaiDanhSach();
        }

        private void FormChuyenDi_Load(object sender, EventArgs e)
        {
            TaiDanhSach();
        }

        private void TaiDanhSach()
        {
            try
            {
                var query = _db.ChuyenDis.AsNoTracking().AsQueryable();

                string tuKhoa = txtTimKiem.Text.Trim();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query = query.Where(x =>
                        x.TenChuyen.Contains(tuKhoa) ||
                        x.DiaDiem.Contains(tuKhoa));
                }

                if (chkChuaHoanThanh.Checked)
                    query = query.Where(x => !x.DaHoanThanh);

                if (dtpTuNgay.Checked)
                    query = query.Where(x => x.NgayDi >= DateOnly.FromDateTime(dtpTuNgay.Value));

                if (dtpDenNgay.Checked)
                    query = query.Where(x => x.NgayDi <= DateOnly.FromDateTime(dtpDenNgay.Value));

                var danhSach = query
                    .OrderBy(x => x.NgayDi)
                    .Select(x => new
                    {
                        x.MaChuyen,
                        x.TenChuyen,
                        x.DiaDiem,
                        NgayDi = x.NgayDi.ToString("dd/MM/yyyy"),
                        x.SoNguoi,
                        x.NganSach,
                        x.PhuongTien,
                        DaHoanThanh = x.DaHoanThanh ? "Có" : "Không",
                        x.GhiChu
                    })
                    .ToList();

                dgvChuyenDi.DataSource = danhSach;

                if (dgvChuyenDi.Columns["MaChuyen"] != null)
                    dgvChuyenDi.Columns["MaChuyen"].HeaderText = "Mã chuyến";

                if (dgvChuyenDi.Columns["TenChuyen"] != null)
                    dgvChuyenDi.Columns["TenChuyen"].HeaderText = "Tên chuyến";

                if (dgvChuyenDi.Columns["DiaDiem"] != null)
                    dgvChuyenDi.Columns["DiaDiem"].HeaderText = "Địa điểm";

                if (dgvChuyenDi.Columns["NgayDi"] != null)
                    dgvChuyenDi.Columns["NgayDi"].HeaderText = "Ngày đi";

                if (dgvChuyenDi.Columns["SoNguoi"] != null)
                    dgvChuyenDi.Columns["SoNguoi"].HeaderText = "Số người";

                if (dgvChuyenDi.Columns["NganSach"] != null)
                    dgvChuyenDi.Columns["NganSach"].HeaderText = "Ngân sách";

                if (dgvChuyenDi.Columns["PhuongTien"] != null)
                    dgvChuyenDi.Columns["PhuongTien"].HeaderText = "Phương tiện";

                if (dgvChuyenDi.Columns["DaHoanThanh"] != null)
                    dgvChuyenDi.Columns["DaHoanThanh"].HeaderText = "Hoàn thành";

                if (dgvChuyenDi.Columns["GhiChu"] != null)
                    dgvChuyenDi.Columns["GhiChu"].HeaderText = "Ghi chú";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách chuyến đi.\n" + ex.Message,
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvChuyenDi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvChuyenDi.Rows[e.RowIndex];

            _maChuyenDangChon = Convert.ToInt32(row.Cells["MaChuyen"].Value);

            var chuyenDi = _db.ChuyenDis
                .AsNoTracking()
                .FirstOrDefault(x => x.MaChuyen == _maChuyenDangChon.Value);

            if (chuyenDi == null) return;

            txtTenChuyen.Text = chuyenDi.TenChuyen;
            txtDiaDiem.Text = chuyenDi.DiaDiem;

            DateTime ngay = chuyenDi.NgayDi.ToDateTime(TimeOnly.MinValue);
            if (ngay < dtpNgayDi.MinDate)
                dtpNgayDi.MinDate = ngay;

            dtpNgayDi.Value = ngay;
            nudSoNguoi.Value = Math.Max(
                nudSoNguoi.Minimum,
                Math.Min(nudSoNguoi.Maximum, chuyenDi.SoNguoi));

            nudNganSach.Value = Math.Max(
                nudNganSach.Minimum,
                Math.Min(nudNganSach.Maximum, chuyenDi.NganSach));

            cboPhuongTien.SelectedItem = chuyenDi.PhuongTien;
            chkDaHoanThanh.Checked = chuyenDi.DaHoanThanh;
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtTenChuyen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chuyến đi.");
                txtTenChuyen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaDiem.Text))
            {
                MessageBox.Show("Vui lòng nhập địa điểm.");
                txtDiaDiem.Focus();
                return false;
            }

            if (nudSoNguoi.Value < 1)
            {
                MessageBox.Show("Số người phải lớn hơn hoặc bằng 1.");
                return false;
            }

            if (nudNganSach.Value < 0)
            {
                MessageBox.Show("Ngân sách không được âm.");
                return false;
            }

            if (cboPhuongTien.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phương tiện.");
                return false;
            }

            return true;
        }

        private ChuyenDi LayDuLieuTuForm()
        {
            return new ChuyenDi
            {
                TenChuyen = txtTenChuyen.Text.Trim(),
                DiaDiem = txtDiaDiem.Text.Trim(),
                NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value),
                SoNguoi = (int)nudSoNguoi.Value,
                NganSach = nudNganSach.Value,
                PhuongTien = cboPhuongTien.SelectedItem!.ToString()!,
                DaHoanThanh = chkDaHoanThanh.Checked
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            if (dtpNgayDi.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Ngày đi khi thêm mới không được nhỏ hơn hôm nay.");
                return;
            }

            try
            {
                var chuyenDi = LayDuLieuTuForm();
                _db.ChuyenDis.Add(chuyenDi);
                _db.SaveChanges();

                MessageBox.Show("Thêm chuyến đi thành công.");
                LamMoiForm();
                TaiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm chuyến đi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_maChuyenDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn chuyến đi cần sửa.");
                return;
            }

            if (!KiemTraDuLieu()) return;

            try
            {
                var chuyenDi = _db.ChuyenDis
                    .FirstOrDefault(x => x.MaChuyen == _maChuyenDangChon.Value);

                if (chuyenDi == null)
                {
                    MessageBox.Show("Không tìm thấy chuyến đi.");
                    return;
                }

                chuyenDi.TenChuyen = txtTenChuyen.Text.Trim();
                chuyenDi.DiaDiem = txtDiaDiem.Text.Trim();
                chuyenDi.NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value);
                chuyenDi.SoNguoi = (int)nudSoNguoi.Value;
                chuyenDi.NganSach = nudNganSach.Value;
                chuyenDi.PhuongTien = cboPhuongTien.SelectedItem!.ToString()!;
                chuyenDi.DaHoanThanh = chkDaHoanThanh.Checked;

                _db.SaveChanges();

                MessageBox.Show("Cập nhật chuyến đi thành công.");
                LamMoiForm();
                TaiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật chuyến đi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maChuyenDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn chuyến đi cần xóa.");
                return;
            }

            var xacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa chuyến đi này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes) return;

            try
            {
                var chuyenDi = _db.ChuyenDis
                    .FirstOrDefault(x => x.MaChuyen == _maChuyenDangChon.Value);

                if (chuyenDi != null)
                {
                    _db.ChuyenDis.Remove(chuyenDi);
                    _db.SaveChanges();
                }

                MessageBox.Show("Xóa chuyến đi thành công.");
                LamMoiForm();
                TaiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa chuyến đi: " + ex.Message);
            }
        }


        private async void btnXemThoiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiaDiem.Text))
            {
                MessageBox.Show("Vui lòng nhập địa điểm trước.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaDiem.Focus();
                return;
            }

            btnXemThoiTiet.Enabled = false;
            prgThoiTiet.Style = ProgressBarStyle.Marquee;
            prgThoiTiet.Visible = true;

            try
            {
                var ketQua = await _thoiTietService.LayThoiTietAsync(
                    txtDiaDiem.Text,
                    dtpNgayDi.Value.Date);

                lblBieuTuong.Text = ketQua.BieuTuong;
                lblMoTaThoiTiet.Text = ketQua.MoTa;

                lblNhietDo.Text =
                    $"Nhiệt độ: {ketQua.NhietDoThap:0.#}°C – {ketQua.NhietDoCao:0.#}°C";

                lblKhaNangMua.Text =
                    $"Khả năng mưa: {ketQua.KhaNangMua}%";

                lblCanhBao.Text = ketQua.ThongBao;

                if (ketQua.CoCanhBao)
                {
                    lblCanhBao.BackColor = Color.Orange;
                    lblCanhBao.ForeColor = Color.Black;
                }
                else
                {
                    lblCanhBao.BackColor = SystemColors.Control;
                    lblCanhBao.ForeColor = SystemColors.ControlText;
                }
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Kết nối quá thời gian chờ. Vui lòng thử lại.",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Không thể kết nối API thời tiết.\n" + ex.Message,
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                btnXemThoiTiet.Enabled = true;
                prgThoiTiet.Style = ProgressBarStyle.Blocks;
                prgThoiTiet.Visible = false;
            }
        }




        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            TaiDanhSach();
        }

        private void LamMoiForm()
        {
            _maChuyenDangChon = null;
            txtTenChuyen.Clear();
            txtDiaDiem.Clear();
            dtpNgayDi.MinDate = DateTime.Today;
            dtpNgayDi.Value = DateTime.Today.AddDays(1);
            nudSoNguoi.Value = 1;
            nudNganSach.Value = 0;
            cboPhuongTien.SelectedIndex = 1;
            chkDaHoanThanh.Checked = false;
            dgvChuyenDi.ClearSelection();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Checked && dtpDenNgay.Checked &&
                dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.");
                return;
            }

            TaiDanhSach();
        }

        private void CapNhatNgonNgu()
        {
            bool en = LaTiengAnh;

            Text = en ? "Outdoor Trip Planner" : "Kế hoạch dã ngoại";

            lblTieuDe.Text = en
                ? "OUTDOOR TRIP PLANNER"
                : "KẾ HOẠCH DÃ NGOẠI";

            lblThongTin.Text = en
                ? "Trip information"
                : "Thông tin chuyến đi";

            lblTenChuyen.Text = en ? "Trip name:" : "Tên chuyến đi:";
            lblDiaDiem.Text = en ? "Destination:" : "Địa điểm:";
            lblNgayDi.Text = en ? "Departure date:" : "Ngày đi:";
            lblSoNguoi.Text = en ? "People:" : "Số người:";
            lblNganSach.Text = en ? "Budget (VND):" : "Ngân sách (VNĐ):";
            lblPhuongTien.Text = en ? "Transport:" : "Phương tiện:";
            lblNgonNgu.Text = en ? "Language:" : "Ngôn ngữ:";

            btnThem.Text = en ? "Add" : "Thêm";
            btnSua.Text = en ? "Update" : "Sửa";
            btnXoa.Text = en ? "Delete" : "Xóa";
            btnLamMoi.Text = en ? "Reset" : "Làm mới";
            btnXemThoiTiet.Text = en ? "View weather" : "Xem thời tiết";
            btnLoc.Text = en ? "Filter" : "Lọc";

            chkDaHoanThanh.Text = en ? "Completed" : "Đã hoàn thành";
            chkChuaHoanThanh.Text = en
                ? "Show incomplete trips only"
                : "Chỉ hiện chuyến chưa hoàn thành";

            lblTimKiem.Text = en ? "Search:" : "Tìm kiếm:";
            lblTuNgay.Text = en ? "From date:" : "Từ ngày:";
            lblDenNgay.Text = en ? "To date:" : "Đến ngày:";

            grpThoiTiet.Text = en ? "Weather forecast" : "Dự báo thời tiết";


            string phuongTienDangChon = cboPhuongTien.SelectedItem?.ToString() ?? "";

            cboPhuongTien.Items.Clear();

            if (en)
            {
                cboPhuongTien.Items.AddRange(new object[]
                {
        "Motorbike",
        "Car",
        "Bus",
        "Bicycle",
        "Walking",
        "Other"
                });
            }
            else
            {
                cboPhuongTien.Items.AddRange(new object[]
                {
        "Xe máy",
        "Ô tô",
        "Xe buýt",
        "Xe đạp",
        "Đi bộ",
        "Khác"
                });
            }

            if (cboPhuongTien.Items.Count > 0)
                cboPhuongTien.SelectedIndex = 0;


            // Cập nhật tiêu đề cột DataGridView.
            if (dgvChuyenDi.Columns.Count > 0)
            {
                DatTieuDeCot("MaChuyen", en ? "Trip ID" : "Mã chuyến");
                DatTieuDeCot("TenChuyen", en ? "Trip name" : "Tên chuyến");
                DatTieuDeCot("DiaDiem", en ? "Destination" : "Địa điểm");
                DatTieuDeCot("NgayDi", en ? "Departure date" : "Ngày đi");
                DatTieuDeCot("SoNguoi", en ? "People" : "Số người");
                DatTieuDeCot("NganSach", en ? "Budget" : "Ngân sách");
                DatTieuDeCot("PhuongTien", en ? "Transport" : "Phương tiện");
                DatTieuDeCot("DaHoanThanh", en ? "Completed" : "Hoàn thành");
            }

            // Cập nhật nội dung khu vực thời tiết.
            if (lblNhietDo.Text.StartsWith("Nhiệt độ:") ||
                lblNhietDo.Text.StartsWith("Temperature:"))
            {
                lblNhietDo.Text = en
                    ? lblNhietDo.Text.Replace("Nhiệt độ:", "Temperature:")
                    : lblNhietDo.Text.Replace("Temperature:", "Nhiệt độ:");
            }

            if (lblKhaNangMua.Text.StartsWith("Khả năng mưa:") ||
                lblKhaNangMua.Text.StartsWith("Rain probability:"))
            {
                lblKhaNangMua.Text = en
                    ? lblKhaNangMua.Text.Replace("Khả năng mưa:", "Rain probability:")
                    : lblKhaNangMua.Text.Replace("Rain probability:", "Khả năng mưa:");
            }

            if (lblMoTaThoiTiet.Text == "Trời quang" ||
                lblMoTaThoiTiet.Text == "Clear")
                lblMoTaThoiTiet.Text = en ? "Clear" : "Trời quang";
            else if (lblMoTaThoiTiet.Text == "Có mây" ||
                     lblMoTaThoiTiet.Text == "Cloudy")
                lblMoTaThoiTiet.Text = en ? "Cloudy" : "Có mây";
            else if (lblMoTaThoiTiet.Text == "Có sương mù" ||
                     lblMoTaThoiTiet.Text == "Fog")
                lblMoTaThoiTiet.Text = en ? "Fog" : "Có sương mù";
            else if (lblMoTaThoiTiet.Text == "Có mưa" ||
                     lblMoTaThoiTiet.Text == "Rain")
                lblMoTaThoiTiet.Text = en ? "Rain" : "Có mưa";
            else if (lblMoTaThoiTiet.Text == "Có giông" ||
                     lblMoTaThoiTiet.Text == "Thunderstorm")
                lblMoTaThoiTiet.Text = en ? "Thunderstorm" : "Có giông";
            else if (lblMoTaThoiTiet.Text == "Thời tiết khác" ||
                     lblMoTaThoiTiet.Text == "Other weather")
                lblMoTaThoiTiet.Text = en ? "Other weather" : "Thời tiết khác";

            if (lblCanhBao.Text.Contains("mang áo mưa") ||
                lblCanhBao.Text.Contains("raincoat"))
            {
                lblCanhBao.Text = en
                    ? "Bring a raincoat or consider rescheduling."
                    : "Nên mang áo mưa hoặc cân nhắc dời lịch.";
            }
            else if (lblCanhBao.Text.Contains("Chưa có cảnh báo") ||
                     lblCanhBao.Text.Contains("No rain warning"))
            {
                lblCanhBao.Text = en
                    ? "No rain warning at the configured threshold."
                    : "Chưa có cảnh báo mưa lớn theo ngưỡng đã đặt.";
            }
        }
        private void cboNgonNgu_SelectedIndexChanged(
    object sender, EventArgs e)
        {
            if (_dangKhoiTaoNgonNgu || cboNgonNgu.SelectedIndex < 0)
                return;

            _settings.Language =
                cboNgonNgu.SelectedIndex == 1 ? "en" : "vi";

            _settings.Save();

            CapNhatNgonNgu();
        }

        private void DatTieuDeCot(string tenCot, string tieuDe)
        {
            if (dgvChuyenDi.Columns.Contains(tenCot))
                dgvChuyenDi.Columns[tenCot].HeaderText = tieuDe;
        }



        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db.Dispose();
            base.OnFormClosed(e);
        }
    }
}
