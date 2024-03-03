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

namespace Nhom02_QuanLyNhaHang
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        string MaHD;

        public string MaHD1
        {
            get { return MaHD; }
            set { MaHD = value; }
        }

        ConnectDB db = new ConnectDB();
        private void Report_Load(object sender, EventArgs e)
        {
            MyReport rpt = new MyReport();
            crystalReportViewer1.ReportSource = rpt;
            rpt.SetDatabaseLogon("sa", "123", "DESKTOP-MEV5PNJ\\SQLEXPRESS", "QL_NhaHang");
            crystalReportViewer1.Refresh();
            crystalReportViewer1.DisplayToolbar = false;
            crystalReportViewer1.DisplayStatusBar = false;
        }
    }
}
