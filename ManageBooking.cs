using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuickseatClient.Form1;

namespace QuickseatClient
{
    public partial class ManageBooking : Form
    {
        public ManageBooking()
        {
            InitializeComponent();
        }

        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5182/") };

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async Task LoadReservationsAsync()
        {
            listView1.Items.Clear();
            var reservations = await _httpClient.GetFromJsonAsync<List<Reservation>>("api/reservations");

            foreach (var res in reservations)
            {
                var item = new ListViewItem(res.CustomerName);
                item.SubItems.Add(res.PhoneNumber);
                item.SubItems.Add(res.TableId.ToString());
                item.SubItems.Add(res.ReservationTime.ToString("HH:mm"));
                item.SubItems.Add(res.ReservationTime.ToString("yyyy-MM-dd"));
                item.Tag = res.Id;
                listView1.Items.Add(item);
            }
        }

        private async void ManageBooking_Load(object sender, EventArgs e)
        {
            await LoadReservationsAsync();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a reservation first.");
                return;
            }

            var selectedItem = listView1.SelectedItems[0];
            int reservationId = int.Parse(selectedItem.Tag.ToString());
            string oldTable = selectedItem.SubItems[2].Text;

            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter new table number:", "Update Table", oldTable);
            if (!int.TryParse(input, out int newTable))
            {
                MessageBox.Show("Invalid table number.");
                return;
            }

            // Gửi yêu cầu PUT để cập nhật
            var updateData = new
            {
                Id = reservationId,
                NewTable = newTable
            };

            var response = await _httpClient.PutAsJsonAsync("api/reservations/update-table", updateData);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Table updated successfully.");
                await LoadReservationsAsync();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                MessageBox.Show("This table is already reserved at the selected time.");
            }
            else
            {
                MessageBox.Show("Update failed.");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a reservation first.");
                return;
            }

            var selectedItem = listView1.SelectedItems[0];
            int reservationId = int.Parse(selectedItem.Tag.ToString());

            var result = MessageBox.Show("Are you sure you want to delete this reservation?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var response = await _httpClient.DeleteAsync($"api/reservations/{reservationId}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Reservation deleted.");
                    await LoadReservationsAsync();
                }
                else
                {
                    MessageBox.Show("Failed to delete.");
                }
            }
        }
    }

   
    
}
