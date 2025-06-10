namespace QuickseatClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btnReserve = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.cmbTimeSlots = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbAvailableTables = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(192, 116);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(144, 22);
            this.txtCustomerName.TabIndex = 0;
            // 
            // dtpTime
            // 
            this.dtpTime.Location = new System.Drawing.Point(514, 116);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(200, 22);
            this.dtpTime.TabIndex = 1;
            this.dtpTime.ValueChanged += new System.EventHandler(this.dtpTime_ValueChanged);
            // 
            // btnReserve
            // 
            this.btnReserve.Location = new System.Drawing.Point(349, 278);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(100, 50);
            this.btnReserve.TabIndex = 3;
            this.btnReserve.Text = "Reserve";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Table Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(275, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 38);
            this.label3.TabIndex = 7;
            this.label3.Text = "Table Reservation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(450, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Phone Number";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(192, 160);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(144, 22);
            this.txtPhoneNumber.TabIndex = 9;
            // 
            // cmbTimeSlots
            // 
            this.cmbTimeSlots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeSlots.FormattingEnabled = true;
            this.cmbTimeSlots.Location = new System.Drawing.Point(514, 166);
            this.cmbTimeSlots.Name = "cmbTimeSlots";
            this.cmbTimeSlots.Size = new System.Drawing.Size(121, 24);
            this.cmbTimeSlots.TabIndex = 12;
            this.cmbTimeSlots.SelectedIndexChanged += new System.EventHandler(this.cmbTimeSlots_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(450, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Time";
            // 
            // cmbAvailableTables
            // 
            this.cmbAvailableTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAvailableTables.FormattingEnabled = true;
            this.cmbAvailableTables.Location = new System.Drawing.Point(192, 210);
            this.cmbAvailableTables.Name = "cmbAvailableTables";
            this.cmbAvailableTables.Size = new System.Drawing.Size(121, 24);
            this.cmbAvailableTables.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbAvailableTables);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTimeSlots);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReserve);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.txtCustomerName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.ComboBox cmbTimeSlots;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAvailableTables;
    }
}

