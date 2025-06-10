using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickseatClient
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5182/")
        };

        public Form1()
        {
            InitializeComponent();
        }

        public class Reservation
        {
            public int Id { get; set; }
            public string CustomerName { get; set; }
            public string PhoneNumber { get; set; }
            public int TableId { get; set; }
            public DateTime ReservationTime { get; set; }
        }

        private List<DateTime> timeSlots = new List<DateTime>();
        private List<int> tables = new List<int> { 1, 2, 3, 4, 5, 6 };

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadAvailableTimeSlotsAsync();
        }

        private async void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            await LoadAvailableTimeSlotsAsync();
        }

        private async void cmbTimeSlots_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadAvailableTablesAsync();
        }

        private async void btnReserve_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
                cmbTimeSlots.SelectedIndex == -1 ||
                cmbAvailableTables.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill full data");
                return;
            }

            var selectedTime = timeSlots[cmbTimeSlots.SelectedIndex];
            var selectedTable = (int)cmbAvailableTables.SelectedItem;

            var reservation = new Reservation
            {
                CustomerName = txtCustomerName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                TableId = selectedTable,
                ReservationTime = selectedTime
            };

            var res = await _httpClient.PostAsJsonAsync("api/reservations", reservation);

            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Reserve succesfull!");
            }
            else if (res.StatusCode == HttpStatusCode.Conflict)
            {
                MessageBox.Show("This table was reserved!");
            }
            else
            {
                MessageBox.Show("Error for reservation.");
            }

            ClearForm();
            await LoadAvailableTimeSlotsAsync();
        }

        private void ClearForm()
        {
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            cmbAvailableTables.Items.Clear();
            cmbAvailableTables.SelectedIndex = -1;
            cmbTimeSlots.SelectedIndex = -1;
        }

        private async Task LoadAvailableTimeSlotsAsync()
        {
            cmbTimeSlots.Items.Clear();
            timeSlots.Clear(); // clear danh sách cũ

            DateTime baseDate = dtpTime.Value.Date;
            var reservations = await _httpClient.GetFromJsonAsync<List<Reservation>>("api/reservations");

            for (int hour = 13; hour <= 18; hour++)
            {
                DateTime slot = baseDate.AddHours(hour);

                // Kiểm tra còn bàn trống trong giờ này không
                var reservedTables = reservations
                    .Where(r => r.ReservationTime == slot)
                    .Select(r => r.TableId)
                    .ToList();

                if (reservedTables.Count < 6)
                {
                    timeSlots.Add(slot);
                    cmbTimeSlots.Items.Add(slot.ToString("HH:mm"));
                }
            }

            if (cmbTimeSlots.Items.Count > 0)
            {
                cmbTimeSlots.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Please chosse another day because today full");
            }
        }

        private async Task LoadAvailableTablesAsync()
        {
            cmbAvailableTables.Items.Clear();

            if (cmbTimeSlots.SelectedIndex == -1) return;

            DateTime selectedTime = timeSlots[cmbTimeSlots.SelectedIndex];

            var reservations = await _httpClient.GetFromJsonAsync<List<Reservation>>("api/reservations");

            var reservedTables = reservations
                .Where(r => r.ReservationTime == selectedTime)
                .Select(r => r.TableId)
                .ToList();

            for (int tableId = 1; tableId <= 6; tableId++)
            {
                if (!reservedTables.Contains(tableId))
                {
                    cmbAvailableTables.Items.Add(tableId);
                }
            }

            if (cmbAvailableTables.Items.Count > 0)
            {
                cmbAvailableTables.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("There are no table for this hour!");
            }
        }
    }
}
