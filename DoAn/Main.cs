using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.Class;

namespace DoAn
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            DanhSachSanPham danhSachSanPham = new DanhSachSanPham();
            danhSachSanPham.ShowDialog();
        }

        private void mnuNhanVien_Click_1(object sender, EventArgs e)
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien.ShowDialog();
        }

        private void mnuKhachHang_Click_1(object sender, EventArgs e)
        {
            KhachHang khachHang = new KhachHang();
            khachHang.ShowDialog();
        }

        private void mnuHangHoa_Click_1(object sender, EventArgs e)
        {
            Hang hang = new Hang();
            hang.ShowDialog();
        }

        private void mnuHoaDonBan_Click_1(object sender, EventArgs e)
        {

            HoaDonBan hoaDonBan = new HoaDonBan();
            hoaDonBan.ShowDialog();
        }

        private void mnuFindHoaDon_Click_1(object sender, EventArgs e)
        {
            TimHDBan timHDBan = new TimHDBan();
            timHDBan.ShowDialog();
        }

        private void mnuFindHang_Click(object sender, EventArgs e)
        {

        }

        private void mnuThoat_Click_1(object sender, EventArgs e)
        {
            DoAn.Class.Functions.Disconnect();
            Application.Exit();
        }
    }
}

