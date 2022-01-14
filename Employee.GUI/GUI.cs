using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS.Foldel;
using Model.Folder;

namespace Employee.GUI
{
    public partial class GUI : Form
    {
        EmployeeBUS emBUS = new EmployeeBUS();
        DepartmentBUS dBUS = new DepartmentBUS();
        public GUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvHR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            List<EmployeeBEL> Employees = emBUS.ReadEmployee();
            foreach (EmployeeBEL em in Employees)
            {
                dgvHR.Rows.Add(em.Id, em.Name, em.Db, em.Gd, em.Pb, em.IdDName);
            }
            List<DepartmentBEL> IstDepartment = dBUS.ReadDepartmentList();
            foreach (DepartmentBEL Department in IstDepartment)
            {
                cbDepartment.Items.Add(Department);
            }
            cbDepartment.DisplayMember = "Name";
        }

        private void dgvHR_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvHR.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbIdE.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                tbDb.Text = row.Cells[2].Value.ToString();
                CbSex.Checked = (bool)row.Cells[3].Value;
                tbPb.Text = row.Cells[4].Value.ToString();
                cbDepartment.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            EmployeeBEL em = new EmployeeBEL();
            em.Id = int.Parse(tbIdE.Text);
            em.Name = tbName.Text;
            em.Db = tbDb.Text;
            em.Gd = CbSex.Checked;
            em.Pb = tbPb.Text;
            em.IdD = (DepartmentBEL)cbDepartment.SelectedItem;

            emBUS.NewEmployee(em);

            dgvHR.Rows.Add(em.Id, em.Name, em.Db, em.Gd, em.Pb, em.IdDName);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Are you sure to Delete?", "Nofication", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes) 
            { 
            EmployeeBEL em = new EmployeeBEL();
                em.Id = int.Parse(tbIdE.Text);
                em.Name = tbName.Text;

            emBUS.DeleteEmployee(em);

            int idx = dgvHR.CurrentCell.RowIndex;
            dgvHR.Rows.RemoveAt(idx);
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvHR.CurrentRow;
            if (row != null)
            {
                EmployeeBEL em = new EmployeeBEL();
                em.Id = int.Parse(tbIdE.Text);
                em.Name = tbName.Text;
                em.Db = tbDb.Text;
                em.Gd = CbSex.Checked;
                em.Pb = tbPb.Text;
                em.IdD = (DepartmentBEL)cbDepartment.SelectedItem;
                emBUS.EditEmployee(em);

                int idx = dgvHR.CurrentCell.RowIndex;

                dgvHR.Rows[idx].Cells[0].Value = em.Id;
                dgvHR.Rows[idx].Cells[1].Value = em.Name;
                dgvHR.Rows[idx].Cells[2].Value = em.Db;
                dgvHR.Rows[idx].Cells[3].Value = em.Gd;
                dgvHR.Rows[idx].Cells[4].Value = em.Pb;
                dgvHR.Rows[idx].Cells[5].Value = em.IdD;
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Are you sure to exit?", "Nofication", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
