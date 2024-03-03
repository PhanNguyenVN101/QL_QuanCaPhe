using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using System.Data.SqlClient;

namespace Nhom02_QuanLyNhaHang
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }
        ConnectDB db = new ConnectDB();

        string TaiKhoan;

        public string TK
        {
            get { return TaiKhoan; }
            set { TaiKhoan = value; }
        }
        public void Loadcbo_TangPH()
        {
            string sql = "select * from Tang";
            cbo_TangPH.DataSource = db.getDataTable(sql, "TangPH");
            cbo_TangPH.DisplayMember = "TenTang";
            cbo_TangPH.ValueMember = "MaTang";
            cbo_TangPH.SelectedIndex = 0;
            
        }
        public void Loadcbo_TangBan()
        {
            string sql = "select * from Tang";
            cbo_TangBan.DataSource = db.getDataTable(sql, "TangBan");
            cbo_TangBan.DisplayMember = "TenTang";
            cbo_TangBan.ValueMember = "MaTang";
            cbo_TangBan.SelectedIndex = 0;

        }
        public void Loadcbo_LoaiPhong()
        {
            string sql = "select * from LoaiPhong";
            cbo_LoaiPH.DataSource = db.getDataTable(sql, "LoaiPhong");
            cbo_LoaiPH.DisplayMember = "TenLoai";
            cbo_LoaiPH.ValueMember = "MaLoaiPH";
            cbo_LoaiPH.SelectedIndex = 0;
        }
        private void Order_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel_TK.Text = "Tài khoản: "+TK;
            Loadcbo_LoaiPhong();
            Loadcbo_TangBan();
            Loadcbo_TangPH();
            cbo_TimKiemBan.SelectedIndex = 0;
            cbo_TimKiemPH.SelectedIndex = 0;
            cbo_TrangThaiBan.SelectedIndex = 0;
            cbo_TrangThaiPH.SelectedIndex = 0;
            LoadDataGridView_XuatBan_Tang();
            LoadDataGridView_XuatPhong_Tang();
            KiemTraThongTinCaNhan(TK);
            KiemTraQuyen(TK);
            create_Ban_Chon();
            create_Phong_Chon();
            LoadDataGridView_Xuat_BanChon();
            LoadDataGridView_Xuat_PHChon();
        }
        public void LoadDataGridView_XuatPhong_Tang()
        {
            string sql = "exec XuatPH_Tang '" + cbo_TangPH.SelectedValue.ToString() + "'";
            SqlDataAdapter da_XuatPhong_Tang = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_XuatPhong_Tang = new DataTable();
            da_XuatPhong_Tang.Fill(dt_XuatPhong_Tang);
            dataGridView_Phong.DataSource = dt_XuatPhong_Tang;
        }
        public void LoadDataGridView_XuatPhong_LoaiPH()
        {
            string sql = "exec XuatPH_LoaiPH '" + cbo_LoaiPH.SelectedValue.ToString() + "'";
            SqlDataAdapter da_XuatPhong_LoaiPH = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_XuatPhong_LoaiPH = new DataTable();
            da_XuatPhong_LoaiPH.Fill(dt_XuatPhong_LoaiPH);
            dataGridView_Phong.DataSource = dt_XuatPhong_LoaiPH;
        }
        public void LoadDataGridView_XuatPhong_TrangThai()
        {
            string sql = "exec XuatPH_TrangThai N'" + cbo_TrangThaiPH.SelectedItem + "'";
            SqlDataAdapter da_XuatPhong_TrangThai = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_XuatPhong_TrangThai = new DataTable();
            da_XuatPhong_TrangThai.Fill(dt_XuatPhong_TrangThai);
            dataGridView_Phong.DataSource = dt_XuatPhong_TrangThai;
        }
        public void LoadDataGridView_XuatPhong_Tang_TrangThai()
        {
            string sql = "exec XuatPH_Tang_TrangThai '" + cbo_TangPH.SelectedValue.ToString() + "', N'" + cbo_TrangThaiPH.SelectedItem + "'";
            SqlDataAdapter da_XuatPhong_Tang_TrangThai = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_XuatPhong_Tang_TrangThai = new DataTable();
            da_XuatPhong_Tang_TrangThai.Fill(dt_XuatPhong_Tang_TrangThai);
            dataGridView_Phong.DataSource = dt_XuatPhong_Tang_TrangThai;
        }
        public void LoadDataGridView_XuatPhong_LoaiPH_TrangThai()
        {
            string sql = "exec XuatPH_LoaiPH_TrangThai '" + cbo_LoaiPH.SelectedValue.ToString() + "', N'" + cbo_TrangThaiPH.SelectedItem + "'";
            SqlDataAdapter da_XuatPhong_LoaiPH_TrangThai = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_XuatPhong_LoaiPH_TrangThai = new DataTable();
            da_XuatPhong_LoaiPH_TrangThai.Fill(dt_XuatPhong_LoaiPH_TrangThai);
            dataGridView_Phong.DataSource = dt_XuatPhong_LoaiPH_TrangThai;
        }
        public void LoadDataGridView_XuatPhong_Tang_LoaiPH()
        {
            string sql = "exec XuatPH_Tang_LoaiPH '"+cbo_TangPH.SelectedValue.ToString()+"', '"+cbo_LoaiPH.SelectedValue.ToString()+"'";
            SqlDataAdapter da_XuatPhong_Tang_LoaiPH = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_XuatPhong_Tang_LoaiPH = new DataTable();
            da_XuatPhong_Tang_LoaiPH.Fill(dt_XuatPhong_Tang_LoaiPH);
            dataGridView_Phong.DataSource = dt_XuatPhong_Tang_LoaiPH;
        }
        public void LoadDataGridView_XuatPH_LoaiPH_TrangThai_Tang()
        {
            string sql = "exec XuatPH_LoaiPH_TrangThai_Tang '"+cbo_LoaiPH.SelectedValue.ToString()+"','"+cbo_TangPH.SelectedValue.ToString()+"', N'"+cbo_TrangThaiPH.SelectedItem+"'";
            SqlDataAdapter da_XuatPH_LoaiPH_TrangThai_Tang = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_XuatPH_LoaiPH_TrangThai_Tang = new DataTable();
            da_XuatPH_LoaiPH_TrangThai_Tang.Fill(dt_XuatPH_LoaiPH_TrangThai_Tang);
            dataGridView_Phong.DataSource = dt_XuatPH_LoaiPH_TrangThai_Tang;
        }
        public void LoadDataGridView_XuatBan_Tang()
        {
            string sql = "exec XuatBan_Tang '"+cbo_TangBan.SelectedValue.ToString()+"'";
            SqlDataAdapter da_XuatBan_Tang = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_XuatBan_Tang = new DataTable();
            da_XuatBan_Tang.Fill(dt_XuatBan_Tang);
            dataGridView1.DataSource = dt_XuatBan_Tang;
        }
        public void LoadDataGridView_XuatBan_TrangThai()
        {
            string sql = "XuatBan_TrangThai N'" + cbo_TrangThaiBan.SelectedItem + "'";
            SqlDataAdapter da_XuatBan_TrangThai = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_XuatBan_TrangThai = new DataTable();
            da_XuatBan_TrangThai.Fill(dt_XuatBan_TrangThai);
            dataGridView1.DataSource = dt_XuatBan_TrangThai;
        }
        public void LoadDataGridView_XuatBan_Tang_TrangThai()
        {
            string sql = "exec XuatBan_Tang_TrangThai '" + cbo_TangBan.SelectedValue.ToString() + "',N'" + cbo_TrangThaiBan.SelectedItem + "'";
            SqlDataAdapter da_XuatBan_Tang_TrangThai = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_XuatBan_Tang_TrangThai = new DataTable();
            da_XuatBan_Tang_TrangThai.Fill(dt_XuatBan_Tang_TrangThai);
            dataGridView1.DataSource = dt_XuatBan_Tang_TrangThai;
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frmDN = new DangNhap();
            frmDN.ShowDialog();
            db.CloseDB();
            this.Close();
        }

        private void btn_TimKiemPH_Click(object sender, EventArgs e)
        {
            if (cbo_TimKiemPH.SelectedItem == "Tìm kiếm theo tầng")
                LoadDataGridView_XuatPhong_Tang();
            else
                if (cbo_TimKiemPH.SelectedItem == "Tìm kiếm theo trạng thái")
                    LoadDataGridView_XuatPhong_TrangThai();
                else
                    if (cbo_TimKiemPH.SelectedItem == "Tìm kiếm theo loại")
                        LoadDataGridView_XuatPhong_LoaiPH();
                    else
                        if (cbo_TimKiemPH.SelectedItem == "Tìm kiếm theo tầng và trạng thái")
                            LoadDataGridView_XuatPhong_Tang_TrangThai();
                        else
                            if (cbo_TimKiemPH.SelectedItem == "Tìm kiếm theo trạng thái và loại")
                                LoadDataGridView_XuatPhong_LoaiPH_TrangThai();
                            else
                                if (cbo_TimKiemPH.SelectedItem == "Tìm kiếm theo tầng và loại")
                                    LoadDataGridView_XuatPhong_Tang_LoaiPH();
                                else
                                    LoadDataGridView_XuatPH_LoaiPH_TrangThai_Tang();
        }

        private void btn_TimKiemBan_Click(object sender, EventArgs e)
        {
            if (cbo_TimKiemBan.SelectedItem == "Tìm kiếm theo tầng")
                LoadDataGridView_XuatBan_Tang();
            else
                if (cbo_TimKiemBan.SelectedItem == "Tìm kiếm theo trạng thái")
                    LoadDataGridView_XuatBan_TrangThai();
                else
                    LoadDataGridView_XuatBan_Tang_TrangThai();
        }
        public void KiemTraThongTinCaNhan(string TenTK)
        {
            db.OpenDB();
            string sql = "select count(*) from TaiKhoan where MANV is null and TenTK = '"+TenTK+"'";
            if(db.get_ExcuteScalarQuery(sql)==1)
                thôngTinCáNhânToolStripMenuItem.Enabled = false;
            else
                thôngTinCáNhânToolStripMenuItem.Enabled = true;
            db.CloseDB();
        }
        public void KiemTraQuyen(string TenTK)
        {
            db.OpenDB();
            string sql = "select Quyen from TaiKhoan where TenTK = '"+TenTK+"'";
            SqlCommand cmd = new SqlCommand(sql, db.Conn);
            string kq = (string)cmd.ExecuteScalar();
            if(kq != "User")
            {
                if (kq == "Admin")
                {
                    kháchHàngToolStripMenuItem.Enabled = true;
                    nhânViênToolStripMenuItem.Enabled = true;
                    sảnPhẩmToolStripMenuItem.Enabled = true;
                    tàiKhoảnToolStripMenuItem.Enabled = true;
                }
                else
                {
                    kháchHàngToolStripMenuItem.Enabled = true;
                    nhânViênToolStripMenuItem.Enabled = true;
                    sảnPhẩmToolStripMenuItem.Enabled = true;
                    tàiKhoảnToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                kháchHàngToolStripMenuItem.Enabled = false;
                nhânViênToolStripMenuItem.Enabled = false;
                sảnPhẩmToolStripMenuItem.Enabled = false;
                tàiKhoảnToolStripMenuItem.Enabled = false;
            }
            db.CloseDB();
        }
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongTinNV frmThongTinNV = new ThongTinNV();
            frmThongTinNV.TK = TK;
            frmThongTinNV.ShowDialog();
            db.CloseDB();
            this.Close();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HoaDon frmHD = new HoaDon();
            frmHD.TK = TK;
            frmHD.ShowDialog();
            db.CloseDB();
            this.Close();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            KhachHang frmKH = new KhachHang();
            frmKH.TK = TK;
            frmKH.ShowDialog();
            db.CloseDB();
            this.Close();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhanVien frmNV = new NhanVien();
            frmNV.TK = TK;
            frmNV.ShowDialog();
            db.CloseDB();
            this.Close();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SanPham frmSP = new SanPham();
            frmSP.TK = TK;
            frmSP.ShowDialog();
            db.CloseDB();
            this.Close();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaiKhoan frmTK = new TaiKhoan();
            frmTK.TaiKhoan1 = TK;
            frmTK.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau frmDMK = new DoiMatKhau();
            frmDMK.TK = TK;
            frmDMK.ShowDialog();
        }

        private void dataGridView_Phong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Phong.Rows[e.RowIndex];
                txt_MaBan_Phong.Text = row.Cells[0].Value.ToString();

            }
        }
        SqlDataAdapter da_Chon_PH, da_Chon_Ban;
        DataColumn[] prikey = new DataColumn[1];
        public void create_Phong_Chon()
        {
            string sql = "select * from ChonPH";
            da_Chon_PH = new SqlDataAdapter(sql, db.Conn);
            da_Chon_PH.Fill(db.DS, "PHChon");
            prikey[0] = db.DS.Tables["PHChon"].Columns["MaPHChon"];
            db.DS.Tables["PHChon"].PrimaryKey = prikey;
        }
        public void create_Ban_Chon()
        {
            string sql = "select * from ChonBan";
            da_Chon_Ban = new SqlDataAdapter(sql, db.Conn);
            da_Chon_Ban.Fill(db.DS, "BanChon");
            prikey[0] = db.DS.Tables["BanChon"].Columns["MaBanChon"];
            db.DS.Tables["BanChon"].PrimaryKey = prikey;
        }
        public void LoadDataGridView_Xuat_PHChon()
        {
            string sql = "select * from ChonPH";
            SqlDataAdapter da_Xuat_PHChon = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_Xuat_PHChon = new DataTable();
            da_Xuat_PHChon.Fill(dt_Xuat_PHChon);
            dataGridView_PHChon.DataSource = dt_Xuat_PHChon;
        }
        public void LoadDataGridView_Xuat_BanChon()
        {
            string sql = "select * from ChonBan";
            SqlDataAdapter da_Xuat_BanChon = new SqlDataAdapter(sql, db.Conn);
            DataTable dt_Xuat_BanChon = new DataTable();
            da_Xuat_BanChon.Fill(dt_Xuat_BanChon);
            dataGridView_BanChon.DataSource = dt_Xuat_BanChon;
        }
        public void CapNhat_TrangThai_PH_KoTrong(string MaPH)
        {
            db.OpenDB();
            string sql = "update Phong set TrangThaiPH = N'" + cbo_TrangThaiPH.Items[1].ToString() + "' where MaPH = '" + MaPH + "'";
            int kq = db.get_ExcuteNoneQuery(sql);
            if (kq == 1)
                LoadDataGridView_XuatPhong_Tang();
            db.CloseDB();
        }
        public void CapNhat_TrangThai_Ban_KoTrong(string MaBan)
        {
            db.OpenDB();
            string sql = "update Ban set TrangThaiBan = N'"+cbo_TrangThaiBan.Items[1].ToString()+"' where MaBan = '"+MaBan+"'";
            int kq = db.get_ExcuteNoneQuery(sql);
            if (kq == 1)
                LoadDataGridView_XuatBan_Tang();
            db.CloseDB();
        }
        public void CapNhat_TrangThai_PH_Trong(string MaPH)
        {
            db.OpenDB();
            string sql = "update Phong set TrangThaiPH = N'" + cbo_TrangThaiPH.Items[0].ToString() + "' where MaPH = '" + MaPH + "'";
            int kq = db.get_ExcuteNoneQuery(sql);
            if (kq == 1)
                LoadDataGridView_XuatPhong_Tang();
            db.CloseDB();
        }
        public void CapNhat_TrangThai_Ban_Trong(string MaBan)
        {
            db.OpenDB();
            string sql = "update Ban set TrangThaiBan = N'" + cbo_TrangThaiBan.Items[0].ToString() + "' where MaBan = '" + MaBan + "'";
            int kq = db.get_ExcuteNoneQuery(sql);
            if (kq == 1)
                LoadDataGridView_XuatBan_Tang();
            db.CloseDB();
        }
        private void btn_ChonPH_Click(object sender, EventArgs e)
        {
            string MaPH = txt_MaBan_Phong.Text;
            try
            {
                DataRow dr = db.DS.Tables["PHChon"].Rows.Find(MaPH);
                if (dr != null)
                {
                    MessageBox.Show("Đã chọn phòng này rồi !");
                    return;
                }
                DataRow newrow = db.DS.Tables["PHChon"].NewRow();
                newrow["MaPHChon"] = MaPH;
                db.DS.Tables["PHChon"].Rows.Add(newrow);

                SqlCommandBuilder cmdbuil = new SqlCommandBuilder(da_Chon_PH);
                da_Chon_PH.Update(db.DS, "PHChon");
                LoadDataGridView_Xuat_PHChon();
                CapNhat_TrangThai_PH_KoTrong(MaPH);
            }
            catch
            {
                MessageBox.Show("Chọn không thành công !");
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txt_MaBan_Phong.Text = row.Cells[0].Value.ToString();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ThemKH frmThemKH = new ThemKH();
            frmThemKH.SDTKHACH = txt_SDTKhach.Text;
            frmThemKH.ShowDialog();
        }

        private void txt_SDTKhach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btn_ChonBan_Click(object sender, EventArgs e)
        {
            string MaBan = txt_MaBan_Phong.Text;
            try
            {
                DataRow dr = db.DS.Tables["BanChon"].Rows.Find(MaBan);
                if (dr != null)
                {
                    MessageBox.Show("Đã chọn bàn này rồi !");
                    return;
                }
                DataRow newrow = db.DS.Tables["BanChon"].NewRow();
                newrow["MaBanChon"] = MaBan;
                db.DS.Tables["BanChon"].Rows.Add(newrow);

                SqlCommandBuilder cmdbuil = new SqlCommandBuilder(da_Chon_Ban);
                da_Chon_Ban.Update(db.DS, "BanChon");
                LoadDataGridView_Xuat_BanChon();
                CapNhat_TrangThai_Ban_KoTrong(MaBan);
            }
            catch
            {
                MessageBox.Show("Chọn không thành công !");
            }
        }
        public int TimBan(string MaBan)
        {
            db.OpenDB();
            string sql = "select count(*) from Ban where MaBan = '" + MaBan + "'";
            int kq = db.get_ExcuteScalarQuery(sql);
            return kq;
            db.CloseDB();
        }
        public string TimTenKH(string SDT)
        {
            db.OpenDB();
            string sql = "select HoTen from KhachHang where SoDienThoai = '"+SDT+"'";
            SqlCommand cmd = new SqlCommand(sql, db.Conn);
            string kq = (string)cmd.ExecuteScalar();
            if (kq == string.Empty)
                kq = null;
            return kq;
            db.CloseDB();
        }
        public int TimKH(string SDT)
        {
            db.OpenDB();
            string sql = "select count(*) from KhachHang where SoDienThoai = '" + SDT + "'";
            int kq = db.get_ExcuteScalarQuery(sql);
            return kq;
            db.CloseDB();
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            string Ma_Phong_Ban = txt_MaBan_Phong.Text;
            string SDTKhach = txt_SDTKhach.Text;
            string SoNguoi = txt_SoNguoi.Text;
            if (SDTKhach == string.Empty)
                SDTKhach = null;
            if (SoNguoi == string.Empty)
            {
                MessageBox.Show("Chưa nhập số người !");
                return;
            }
            if (TimBan(Ma_Phong_Ban) == 1)
            {
                    try
                    {
                        DataRow dr = db.DS.Tables["BanChon"].Rows.Find(Ma_Phong_Ban);
                        if (dr != null)
                        {
                            dr["MaBanChon"] = Ma_Phong_Ban;
                            dr["SoNguoi_Ban"] = SoNguoi;
                            if (SDTKhach == null)
                                dr["SDTKhach_Ban"] = SDTKhach;
                            else
                                if (SDTKhach != null && TimKH(SDTKhach) == 1)
                                    dr["SDTKhach_Ban"] = SDTKhach;
                                else
                                {
                                    MessageBox.Show("Khách hàng này chưa có (Nên thêm khách hàng) !");
                                    return;
                                }
                        }

                        SqlCommandBuilder cmdbuil = new SqlCommandBuilder(da_Chon_Ban);
                        da_Chon_Ban.Update(db.DS, "BanChon");
                        LoadDataGridView_Xuat_BanChon();
                    }
                    catch
                    {
                        MessageBox.Show("Thêm không thành công !");
                    }               
            }
            else
            {
                    try
                    {
                        DataRow dr = db.DS.Tables["PHChon"].Rows.Find(Ma_Phong_Ban);
                        if (dr != null)
                        {
                            dr["MaPHChon"] = Ma_Phong_Ban;
                            dr["SoNguoi_PH"] = SoNguoi;
                            if (SDTKhach == null)
                                dr["SDTKhach_PH"] = SDTKhach;
                            else
                                if (SDTKhach != null && TimKH(SDTKhach) == 1)
                                    dr["SDTKhach_PH"] = SDTKhach;
                                else
                                {
                                    MessageBox.Show("Khách hàng này chưa có (Nên thêm khách hàng) !");
                                    return;
                                }
                        }

                        SqlCommandBuilder cmdbuil = new SqlCommandBuilder(da_Chon_PH);
                        da_Chon_PH.Update(db.DS, "PHChon");
                        LoadDataGridView_Xuat_PHChon();
                    }
                    catch
                    {
                        MessageBox.Show("Thêm không thành công !");
                    }
            }
        }

        private void dataGridView_BanChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_BanChon.Rows[e.RowIndex];
                txt_MaBan_Phong.Text = row.Cells[0].Value.ToString();
                txt_SoNguoi.Text = row.Cells[1].Value.ToString();
                txt_SDTKhach.Text = row.Cells[2].Value.ToString();
                txt_TenKH.Text = TimTenKH(row.Cells[2].Value.ToString());

            }
        }

        private void dataGridView_PHChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_PHChon.Rows[e.RowIndex];
                txt_MaBan_Phong.Text = row.Cells[0].Value.ToString();
                txt_SoNguoi.Text = row.Cells[1].Value.ToString();
                txt_SDTKhach.Text = row.Cells[2].Value.ToString();
                txt_TenKH.Text = TimTenKH(row.Cells[2].Value.ToString());

            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string Ma_Phong_Ban = txt_MaBan_Phong.Text;
            DialogResult del;
            del = MessageBox.Show("Bạn có chắc muốn xóa ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (del == DialogResult.Yes)
            {
                if (TimBan(Ma_Phong_Ban) == 1)
                {
                    try
                    {
                        DataRow dr = db.DS.Tables["BanChon"].Rows.Find(Ma_Phong_Ban);
                        if (dr != null)
                            dr.Delete();

                        SqlCommandBuilder cmdbuil = new SqlCommandBuilder(da_Chon_Ban);
                        da_Chon_Ban.Update(db.DS, "BanChon");
                        LoadDataGridView_Xuat_BanChon();
                        CapNhat_TrangThai_Ban_Trong(Ma_Phong_Ban);
                    }
                    catch
                    {
                        MessageBox.Show("Xóa không thành công !");
                    }
                }
                else
                {
                    try
                    {
                        DataRow dr = db.DS.Tables["PHChon"].Rows.Find(Ma_Phong_Ban);
                        if (dr != null)
                            dr.Delete();

                        SqlCommandBuilder cmdbuil = new SqlCommandBuilder(da_Chon_PH);
                        da_Chon_PH.Update(db.DS, "PHChon");
                        LoadDataGridView_Xuat_PHChon();
                        CapNhat_TrangThai_PH_Trong(Ma_Phong_Ban);
                    }
                    catch
                    {
                        MessageBox.Show("Xóa không thành công !");
                    }
                }
            }
        }

        private void txt_SoNguoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btn_DatMon_Click(object sender, EventArgs e)
        {
            DatMon frmdatmon = new DatMon();
            frmdatmon.SDTKHACH = txt_SDTKhach.Text;
            frmdatmon.SONGUOI = txt_SoNguoi.Text;
            frmdatmon.MaPH_BAN = txt_MaBan_Phong.Text;
            frmdatmon.TAIKHOAN = TK;
            frmdatmon.ShowDialog();
        }
    }
}
