using System;
using System.Windows.Forms;

namespace QuickseatClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


      

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnMakeReservation_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn MainForm trước
            Form1 reservationForm = new Form1();
            reservationForm.ShowDialog(); // Hiển thị Form1 dạng modal
            this.Show();
        }

        private void btnManageReservations_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn MainForm trước
            Login login = new Login();
            login.ShowDialog(); // Hiển thị Form1 dạng modal
            
        }
    }
}
