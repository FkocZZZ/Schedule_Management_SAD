namespace ScheduleManagement.GUI
{
    partial class FormSchedule
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDay = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDay = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvTasksDay = new System.Windows.Forms.DataGridView();
            this.tabWeek = new System.Windows.Forms.TabPage();
            this.dgvTasksWeek = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpWeekStart = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabDay.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasksDay)).BeginInit();
            this.tabWeek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasksWeek)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDay);
            this.tabControl1.Controls.Add(this.tabWeek);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabDay
            // 
            this.tabDay.Controls.Add(this.dgvTasksDay);
            this.tabDay.Controls.Add(this.panel1);
            this.tabDay.Location = new System.Drawing.Point(4, 25);
            this.tabDay.Name = "tabDay";
            this.tabDay.Padding = new System.Windows.Forms.Padding(3);
            this.tabDay.Size = new System.Drawing.Size(792, 421);
            this.tabDay.TabIndex = 0;
            this.tabDay.Text = "Day";
            this.tabDay.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpDay);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 100);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn Ngày:";
            // 
            // dtpDay
            // 
            this.dtpDay.CustomFormat = "dd-MM-yyyy";
            this.dtpDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDay.Location = new System.Drawing.Point(188, 36);
            this.dtpDay.Name = "dtpDay";
            this.dtpDay.Size = new System.Drawing.Size(200, 36);
            this.dtpDay.TabIndex = 1;
            this.dtpDay.ValueChanged += new System.EventHandler(this.dtpDay_ValueChanged_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(434, 32);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(116, 49);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvTasksDay
            // 
            this.dgvTasksDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasksDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTasksDay.EnableHeadersVisualStyles = false;
            this.dgvTasksDay.Location = new System.Drawing.Point(3, 103);
            this.dgvTasksDay.Name = "dgvTasksDay";
            this.dgvTasksDay.RowHeadersWidth = 51;
            this.dgvTasksDay.RowTemplate.Height = 24;
            this.dgvTasksDay.Size = new System.Drawing.Size(786, 315);
            this.dgvTasksDay.TabIndex = 3;
            this.dgvTasksDay.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTasksDay_CellContentClick);
            // 
            // tabWeek
            // 
            this.tabWeek.Controls.Add(this.dgvTasksWeek);
            this.tabWeek.Controls.Add(this.panel2);
            this.tabWeek.Location = new System.Drawing.Point(4, 25);
            this.tabWeek.Name = "tabWeek";
            this.tabWeek.Padding = new System.Windows.Forms.Padding(3);
            this.tabWeek.Size = new System.Drawing.Size(792, 421);
            this.tabWeek.TabIndex = 1;
            this.tabWeek.Text = "Week";
            this.tabWeek.UseVisualStyleBackColor = true;
            // 
            // dgvTasksWeek
            // 
            this.dgvTasksWeek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasksWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTasksWeek.Location = new System.Drawing.Point(3, 103);
            this.dgvTasksWeek.Name = "dgvTasksWeek";
            this.dgvTasksWeek.RowHeadersWidth = 51;
            this.dgvTasksWeek.RowTemplate.Height = 24;
            this.dgvTasksWeek.Size = new System.Drawing.Size(786, 315);
            this.dgvTasksWeek.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpWeekStart);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 100);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chọn Tuần:";
            // 
            // dtpWeekStart
            // 
            this.dtpWeekStart.CustomFormat = "dd-MM-yyyy";
            this.dtpWeekStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpWeekStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWeekStart.Location = new System.Drawing.Point(188, 36);
            this.dtpWeekStart.Name = "dtpWeekStart";
            this.dtpWeekStart.Size = new System.Drawing.Size(200, 36);
            this.dtpWeekStart.TabIndex = 1;
            this.dtpWeekStart.ValueChanged += new System.EventHandler(this.dtpWeekStart_ValueChanged_1);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(434, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormSchedule";
            this.Text = "FormSchedule";
            this.tabControl1.ResumeLayout(false);
            this.tabDay.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasksDay)).EndInit();
            this.tabWeek.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasksWeek)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDay;
        private System.Windows.Forms.TabPage tabWeek;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDay;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvTasksDay;
        private System.Windows.Forms.DataGridView dgvTasksWeek;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpWeekStart;
        private System.Windows.Forms.Button button1;
    }
}