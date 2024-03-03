using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace Nhom02_QuanLyNhaHang
{
    public partial class DatMon : Form
    {
        public DatMon()
        {
            InitializeComponent();
        }
        ConnectDB db = new ConnectDB();
        string MaPH_Ban, SDTKhach, SoNguoi;
        SqlDataAdapter da_CTHD;
        DataColumn[] prikey = new DataColumn[2];
        string TaiKhoan;
        public string TAIKHOAN
        {
          get { return TaiKhoan; }
          set { TaiKhoan = value; }
        }
        public string SONGUOI
        {
            get { return SoNguoi; }
            set { SoNguoi = value; }
        }

        public string SDTKHACH
        {
            get { return SDTKhach; }
            set { SDTKhach = value; }
        }

        public string MaPH_BAN
        {
            get { return MaPH_Ban; }
            set { MaPH_Ban = value; }
        }
        private void DatMon_Load(object sender, EventArgs e)
        {
            lbl_Phong_Ban.Text = "Phòng/Bàn : " + MaPH_BAN;
            lbl_SDTKhach.Text = "Số điện thoại khách : " + SDTKHACH;
            lbl_SoNguoi.Text = "Số người: " + SoNguoi;
            LoadDataGridView_Xuat_SP();
            create_CTHD();
            LoadDataGridView_Xuat_CTHD();
        }
        public void LoadDataGridView_Xuat_CTHD()
        {
            string sql = "select * from ChiTietHD";
            SqlDataAdapter da_Xuat_CTHD = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_Xuat_CTHD = new DataTable();
            da_Xuat_CTHD.Fill(dt_Xuat_CTHD);
            dataGridView_DatMon.DataSource = dt_Xuat_CTHD;
        }
        public void LoadDataGridView_Xuat_SP()
        {
            string sql = "exec XuatSP";
            SqlDataAdapter da_Xuat_SP = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_Xuat_SP = new DataTable();
            da_Xuat_SP.Fill(dt_Xuat_SP);
            dataGridView_SP.DataSource = dt_Xuat_SP;
        }
        public void LoadDataGridView_Xuat_SP_TenSP()
        {
            string sql = "exec XuatSP_TenSP N'" + txt_TimTenSP.Text + "'";
            SqlDataAdapter da_Xuat_TenSP = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_Xuat_TenSP = new DataTable();
            da_Xuat_TenSP.Fill(dt_Xuat_TenSP);
            dataGridView_SP.DataSource = dt_Xuat_TenSP;
        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txt_TimTenSP.Clear();
            txt_SL.Clear();
            rdo_TimMaHD.Checked = false;
            LoadDataGridView_Xuat_SP();
            LoadDataGridView_Xuat_CTHD();
        }
        public string SelectAnh(string linkanh)
        {
            db.OpenDB();
            string sql = "select LinkHinh from SanPham where MaSP = '" + linkanh + "'";
            SqlCommand cmd = new SqlCommand(sql, db.Conn);
            string AnhSP = (string)cmd.ExecuteScalar();
            db.CloseDB();
            return AnhSP;
        }
        private void dataGridView_SP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_SP.Rows[e.RowIndex];
                txt_MaSP.Text = row.Cells[0].Value.ToString();
                string Anh = SelectAnh(row.Cells[0].Value.ToString());
                if (Anh != "None")
                    pictureBox1.ImageLocation = Anh;
                pictureBox1.Image = Nhom02_QuanLyNhaHang.Properties.Resources.Default;
            }
        }

        private void txt_SL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (txt_TimTenSP.Text == null)
                MessageBox.Show("Chưa nhập tên sản phẩm cần tìm !");
            else
                LoadDataGridView_Xuat_SP_TenSP();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult del;
            del = MessageBox.Show("Bạn có chắc muốn xóa ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (del == DialogResult.Yes)
            {
                string MaSP = txt_MaSP.Text;
                string MaHD = txt_MaHD.Text.Trim();
                if (MaHD == string.Empty)
                {
                    MessageBox.Show("Chưa nhập mã hóa đơn !");
                    return;
                }
                try
                {
                    if (KTHD_ThanhToan(MaHD) == 0)
                    {
                        string[] Primarykey = { MaHD, MaSP };
                        DataRow dr = db.DS.Tables["CTHD"].Rows.Find(Primarykey);
                        if (dr != null)
                            dr.Delete();
                        SqlCommandBuilder cmdBuil = new SqlCommandBuilder(da_CTHD);
                        da_CTHD.Update(db.DS, "CTHD");
                        LoadDataGridView_Xuat_CTHD();
                        CapNhatThanhToan(MaHD);
                    }
                    else
                        MessageBox.Show("Không xóa được món vì mã hóa đơn này đã thanh toán rồi !");
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại !");
                }
            }
        }
        public void CapNhatThanhToan(string MaHD)
        {
            db.OpenDB();
            string sql = "exec CapNhatThanhToan '" + MaHD + "'";
            if(db.get_ExcuteNoneQuery(sql)==1)
            db.CloseDB();
        }
        public void LoadDataGridView_Xuat_CTHD_MaHD()
        {
            string sql = "select * from ChiTietHD where MaCTHD = '"+txt_MaHD.Text+"'";
            SqlDataAdapter da_Xuat_CTHD_MaHD = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_Xuat_CTHD_MaHD = new DataTable();
            da_Xuat_CTHD_MaHD.Fill(dt_Xuat_CTHD_MaHD);
            dataGridView_DatMon.DataSource = dt_Xuat_CTHD_MaHD;
        }
        private void rdo_TimMaHD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_TimMaHD.Checked)
                LoadDataGridView_Xuat_CTHD_MaHD();
        }
        public void create_CTHD()
        {
            string sql = "select * from ChiTietHD";
            da_CTHD = new SqlDataAdapter(sql, db.Conn);
            da_CTHD.Fill(db.DS, "CTHD");
            prikey[0] = db.DS.Tables["CTHD"].Columns["MaCTHD"];
            prikey[1] = db.DS.Tables["CTHD"].Columns["MaSP_CTHD"];
            db.DS.Tables["CTHD"].PrimaryKey = prikey;
        }
        public void LapHD(string MaHD)
        {
            db.OpenDB();
            string sql = "insert into HoaDon(MaHD) values('" + MaHD + "')";
            if (db.get_ExcuteNoneQuery(sql) == 1)
            db.CloseDB();
        }
        public int TimHD(string MaHD)
        {
            db.OpenDB();
            string sql = "select count(*) from HoaDon where MaHD = '"+MaHD+"'";
            int kq = db.get_ExcuteScalarQuery(sql);
            db.CloseDB();
            return kq;
        }
        private void btn_DatMon_Click(object sender, EventArgs e)
        {
            string MaHD = txt_MaHD.Text.Trim();
            string MaSP = txt_MaSP.Text;
            if(MaHD==string.Empty)
            {
                MessageBox.Show("Chưa nhập mã hóa đơn !");
                return;
            }
            string SL = txt_SL.Text;
            if (SL == string.Empty)
            {
                MessageBox.Show("Chưa nhập số lượng !");
                return;
            }
            try
            {
                if (TimHD(MaHD) == 0)
                    LapHD(MaHD);
                if (KTHD_ThanhToan(MaHD) == 0)
                {
                    string[] Primarykey = { MaHD, MaSP };
                    DataRow dr = db.DS.Tables["CTHD"].Rows.Find(Primarykey);
                    if (dr != null)
                    {
                        MessageBox.Show("Đã tồn tại mã hóa đơn " + MaHD + " và mã sản phẩm " + MaSP);
                        return;
                    }
                    DataRow newRow = db.DS.Tables["CTHD"].NewRow();
                    newRow["MaCTHD"] = MaHD;
                    newRow["MaSP_CTHD"] = MaSP;
                    newRow["SoLuong"] = SL;
                    newRow["TongTien_CTHD"] = 0;
                    db.DS.Tables["CTHD"].Rows.Add(newRow);

                    SqlCommandBuilder cmdBuil = new SqlCommandBuilder(da_CTHD);
                    da_CTHD.Update(db.DS, "CTHD");
                    LoadDataGridView_Xuat_CTHD();
                    CapNhatThanhToan(MaHD);
                }
                else
                    MessageBox.Show("Không đặt được món vì mã hóa đơn này đã thanh toán rồi !");
            }
            catch
            {
                MessageBox.Show("Đặt món thất bại !");
            }
        }

        private void dataGridView_DatMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_DatMon.Rows[e.RowIndex];
                txt_MaSP.Text = row.Cells[1].Value.ToString();
                txt_MaHD.Text = row.Cells[0].Value.ToString();
                txt_SL.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string MaHD = txt_MaHD.Text.Trim();
            string MaSP = txt_MaSP.Text;
            if (MaHD == string.Empty)
            {
                MessageBox.Show("Chưa nhập mã hóa đơn !");
                return;
            }
            string SL = txt_SL.Text;
            if (SL == string.Empty)
            {
                MessageBox.Show("Chưa nhập số lượng !");
                return;
            }
            try
            {
                if (KTHD_ThanhToan(MaHD) == 0)
                {
                    string[] Primarykey = { MaHD, MaSP };
                    DataRow dr = db.DS.Tables["CTHD"].Rows.Find(Primarykey);
                    if (dr != null)
                    {
                        dr["MaCTHD"] = MaHD;
                        dr["MaSP_CTHD"] = MaSP;
                        dr["SoLuong"] = SL;
                    }

                    SqlCommandBuilder cmdbuil = new SqlCommandBuilder(da_CTHD);
                    da_CTHD.Update(db.DS, "CTHD");
                    LoadDataGridView_Xuat_CTHD();
                    CapNhatThanhToan(MaHD);
                }
                else
                    MessageBox.Show("Không sửa được món vì mã hóa đơn này đã thanh toán rồi !");
            }
            catch
            {
                MessageBox.Show("Sửa không thành công !");
            }
        }
        public string ThoiGian()
        {
            string Ngay = DateTime.Now.Day.ToString();
            string Month = DateTime.Now.Month.ToString();;
            string Year = DateTime.Now.Year.ToString();
            string TG = Ngay + '/' + Month + '/' + Year;
            return TG;
        }
        public int KTHD_ThanhToan(string MaHD)
        {
            db.OpenDB();
            string sql = "select count(*) from HoaDon where ThoiGian is not null and MaHD = '" + MaHD + "'";
            int kq = 0;
            if (db.get_ExcuteScalarQuery(sql) == 1)
                kq = 1;
            db.CloseDB();
            return kq;
        }
        public void InsertHoaDon(string MaHD)
        {
            if (SDTKHACH == string.Empty)
                SDTKHACH = null;
            db.OpenDB();
            string sql = "set dateformat dmy update HoaDon set SDTKH = '" + SDTKHACH + "', TenTK_HD ='" + TAIKHOAN + "', MaBan_Phong='" + MaPH_BAN + "',SoNguoi= "+ int.Parse(SONGUOI) + ",ThoiGian='" + ThoiGian() + "' WHERE MaHD = '" + MaHD + "'";
            if (db.get_ExcuteNoneQuery(sql) == 1)
            db.CloseDB();
        }
        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            string MaHD = txt_MaHD.Text.Trim();
            if (MaHD == string.Empty)
            {
                MessageBox.Show("Chưa nhập mã hóa đơn !");
                return;
            }
            else
            {
                this.Hide();
                Report frmrpt = new Report();
                frmrpt.MaHD1 = txt_MaHD.Text;
                InsertHoaDon(MaHD);
                frmrpt.ShowDialog();
                this.Close();
            }
        }

    }
}
