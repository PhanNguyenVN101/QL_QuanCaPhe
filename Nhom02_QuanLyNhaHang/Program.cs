using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom02_QuanLyNhaHang
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangNhap());
            //Application.Run(new NhanVien());
            //Application.Run(new KhachHang());
            //Application.Run(new SanPham());
            //Application.Run(new HoaDon());
            //Application.Run(new Order());
            //Application.Run(new ThongTinNV());
            //Application.Run(new TaiKhoan());
            //Application.Run(new DatMon());
            //Application.Run(new Report());
        }
    }
}
