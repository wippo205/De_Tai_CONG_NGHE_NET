using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DoAn.Class;


namespace DoAn
{
    public partial class DanhSachSanPham : Form
    {
        DataTable tblSP;
        public DanhSachSanPham()
        {
            InitializeComponent();
        }

        private void DanhSachSanPham_Load(object sender, EventArgs e)
        {
            txtMaSanPham.Enabled = false;
            Class.Functions.Connect();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView(); 
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaSanPham, TenSanPham FROM SanPham";
            tblSP = Functions.GetDataToTable(sql); 
            dgvSanPham.DataSource = tblSP;            
            dgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
            dgvSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns[0].Width = 100;
            dgvSanPham.Columns[1].Width = 300;
            dgvSanPham.AllowUserToAddRows = false; 
            dgvSanPham.EditMode = DataGridViewEditMode.EditProgrammatically; 
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSanPham.Focus();
                return;
            }
            if (tblSP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaSanPham.Text = dgvSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
            txtTenSanPham.Text = dgvSanPham.CurrentRow.Cells["TenSanPham"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaSanPham.Enabled = true; //cho phép nhập mới
            txtMaSanPham.Focus();
        }

        private void ResetValue()
        {
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtMaSanPham.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSanPham.Focus();
                return;
            }
            if (txtTenSanPham.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSanPham.Focus();
                return;
            }
            sql = "Select MaSanPham From SanPham where MaSanPham=N'" + txtMaSanPham.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSanPham.Focus();
                return;
            }

            sql = "INSERT INTO SanPham VALUES(N'" +
                txtMaSanPham.Text + "',N'" + txtTenSanPham.Text + "')";
            Class.Functions.RunSQL(sql); 
            LoadDataGridView();
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaSanPham.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblSP.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSanPham.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenSanPham.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE SanPham SET TenSanPham=N'" +
                txtTenSanPham.Text.ToString() +
                "' WHERE MaSanPham=N'" + txtMaSanPham.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblSP.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSanPham.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE SanPham WHERE MaSanPham=N'" + txtMaSanPham.Text + "'";
                Class.Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaSanPham.Enabled = false;
        }

        private void txtMaSanPham_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
