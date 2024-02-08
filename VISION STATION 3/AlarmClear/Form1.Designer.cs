namespace AlarmClear
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ErrorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hAxis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_End = new System.Windows.Forms.Button();
            this.btn_SvAlmClear = new System.Windows.Forms.Button();
            this.btn_SvAlmGenerate = new System.Windows.Forms.Button();
            this.btn_AlmClear = new System.Windows.Forms.Button();
            this.btn_AlmDsp = new System.Windows.Forms.Button();
            this.btn_AlmGenerate = new System.Windows.Forms.Button();
            this.btn_MotionAPI_Open = new System.Windows.Forms.Button();
            this.btn_MotionAPI_Close = new System.Windows.Forms.Button();
            this.spn_Axis = new System.Windows.Forms.NumericUpDown();
            this.spn_CpuNo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn_Axis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn_CpuNo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ErrorCode,
            this.hDevice,
            this.hAxis,
            this.Date,
            this.Time});
            this.dataGridView1.Location = new System.Drawing.Point(12, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 15;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(400, 116);
            this.dataGridView1.TabIndex = 25;
            // 
            // ErrorCode
            // 
            this.ErrorCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ErrorCode.HeaderText = "ErrorCode";
            this.ErrorCode.Name = "ErrorCode";
            this.ErrorCode.Width = 80;
            // 
            // hDevice
            // 
            this.hDevice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.hDevice.HeaderText = "hDevice";
            this.hDevice.Name = "hDevice";
            this.hDevice.Width = 80;
            // 
            // hAxis
            // 
            this.hAxis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.hAxis.HeaderText = "hAxis";
            this.hAxis.Name = "hAxis";
            this.hAxis.Width = 80;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Width = 80;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.Width = 80;
            // 
            // btn_End
            // 
            this.btn_End.Location = new System.Drawing.Point(317, 257);
            this.btn_End.Name = "btn_End";
            this.btn_End.Size = new System.Drawing.Size(95, 30);
            this.btn_End.TabIndex = 24;
            this.btn_End.Text = "End";
            this.btn_End.UseVisualStyleBackColor = true;
            this.btn_End.Click += new System.EventHandler(this.btn_End_Click);
            // 
            // btn_SvAlmClear
            // 
            this.btn_SvAlmClear.Location = new System.Drawing.Point(172, 257);
            this.btn_SvAlmClear.Name = "btn_SvAlmClear";
            this.btn_SvAlmClear.Size = new System.Drawing.Size(115, 30);
            this.btn_SvAlmClear.TabIndex = 23;
            this.btn_SvAlmClear.Text = "Clear Servo Alarm";
            this.btn_SvAlmClear.UseVisualStyleBackColor = true;
            this.btn_SvAlmClear.Click += new System.EventHandler(this.btn_SvAlmClear_Click);
            // 
            // btn_SvAlmGenerate
            // 
            this.btn_SvAlmGenerate.Location = new System.Drawing.Point(9, 258);
            this.btn_SvAlmGenerate.Name = "btn_SvAlmGenerate";
            this.btn_SvAlmGenerate.Size = new System.Drawing.Size(155, 30);
            this.btn_SvAlmGenerate.TabIndex = 22;
            this.btn_SvAlmGenerate.Text = "Servo Alarm generating";
            this.btn_SvAlmGenerate.UseVisualStyleBackColor = true;
            this.btn_SvAlmGenerate.Click += new System.EventHandler(this.btn_SvAlmGenerate_Click);
            // 
            // btn_AlmClear
            // 
            this.btn_AlmClear.Location = new System.Drawing.Point(295, 87);
            this.btn_AlmClear.Name = "btn_AlmClear";
            this.btn_AlmClear.Size = new System.Drawing.Size(95, 30);
            this.btn_AlmClear.TabIndex = 21;
            this.btn_AlmClear.Text = "Clear Alarm";
            this.btn_AlmClear.UseVisualStyleBackColor = true;
            this.btn_AlmClear.Click += new System.EventHandler(this.btn_AlmClear_Click);
            // 
            // btn_AlmDsp
            // 
            this.btn_AlmDsp.Location = new System.Drawing.Point(172, 87);
            this.btn_AlmDsp.Name = "btn_AlmDsp";
            this.btn_AlmDsp.Size = new System.Drawing.Size(95, 30);
            this.btn_AlmDsp.TabIndex = 20;
            this.btn_AlmDsp.Text = "Alarm display";
            this.btn_AlmDsp.UseVisualStyleBackColor = true;
            this.btn_AlmDsp.Click += new System.EventHandler(this.btn_AlmDsp_Click);
            // 
            // btn_AlmGenerate
            // 
            this.btn_AlmGenerate.Location = new System.Drawing.Point(12, 87);
            this.btn_AlmGenerate.Name = "btn_AlmGenerate";
            this.btn_AlmGenerate.Size = new System.Drawing.Size(115, 30);
            this.btn_AlmGenerate.TabIndex = 19;
            this.btn_AlmGenerate.Text = "Alarm generating";
            this.btn_AlmGenerate.UseVisualStyleBackColor = true;
            this.btn_AlmGenerate.Click += new System.EventHandler(this.btn_AlmGenerate_Click);
            // 
            // btn_MotionAPI_Open
            // 
            this.btn_MotionAPI_Open.Location = new System.Drawing.Point(198, 10);
            this.btn_MotionAPI_Open.Name = "btn_MotionAPI_Open";
            this.btn_MotionAPI_Open.Size = new System.Drawing.Size(100, 30);
            this.btn_MotionAPI_Open.TabIndex = 17;
            this.btn_MotionAPI_Open.Text = "Open MotionAPI";
            this.btn_MotionAPI_Open.UseVisualStyleBackColor = true;
            this.btn_MotionAPI_Open.Click += new System.EventHandler(this.btn_MotionAPI_Open_Click);
            // 
            // btn_MotionAPI_Close
            // 
            this.btn_MotionAPI_Close.Location = new System.Drawing.Point(304, 10);
            this.btn_MotionAPI_Close.Name = "btn_MotionAPI_Close";
            this.btn_MotionAPI_Close.Size = new System.Drawing.Size(100, 30);
            this.btn_MotionAPI_Close.TabIndex = 18;
            this.btn_MotionAPI_Close.Text = "Close MotionAPI";
            this.btn_MotionAPI_Close.UseVisualStyleBackColor = true;
            this.btn_MotionAPI_Close.Click += new System.EventHandler(this.btn_MotionAPI_Close_Click);
            // 
            // spn_Axis
            // 
            this.spn_Axis.Location = new System.Drawing.Point(147, 52);
            this.spn_Axis.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.spn_Axis.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spn_Axis.Name = "spn_Axis";
            this.spn_Axis.Size = new System.Drawing.Size(45, 19);
            this.spn_Axis.TabIndex = 16;
            this.spn_Axis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spn_Axis.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // spn_CpuNo
            // 
            this.spn_CpuNo.Location = new System.Drawing.Point(147, 17);
            this.spn_CpuNo.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.spn_CpuNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spn_CpuNo.Name = "spn_CpuNo";
            this.spn_CpuNo.Size = new System.Drawing.Size(45, 19);
            this.spn_CpuNo.TabIndex = 15;
            this.spn_CpuNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spn_CpuNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Number Of Axis [1-3]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "CPU No     [1-4]";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 300);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_End);
            this.Controls.Add(this.btn_SvAlmClear);
            this.Controls.Add(this.btn_SvAlmGenerate);
            this.Controls.Add(this.btn_AlmClear);
            this.Controls.Add(this.btn_AlmDsp);
            this.Controls.Add(this.btn_AlmGenerate);
            this.Controls.Add(this.btn_MotionAPI_Open);
            this.Controls.Add(this.btn_MotionAPI_Close);
            this.Controls.Add(this.spn_Axis);
            this.Controls.Add(this.spn_CpuNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "AlarmClear Sample";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn_Axis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn_CpuNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn hDevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn hAxis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.Button btn_End;
        private System.Windows.Forms.Button btn_SvAlmClear;
        private System.Windows.Forms.Button btn_SvAlmGenerate;
        private System.Windows.Forms.Button btn_AlmClear;
        private System.Windows.Forms.Button btn_AlmDsp;
        private System.Windows.Forms.Button btn_AlmGenerate;
        private System.Windows.Forms.Button btn_MotionAPI_Open;
        private System.Windows.Forms.Button btn_MotionAPI_Close;
        private System.Windows.Forms.NumericUpDown spn_Axis;
        private System.Windows.Forms.NumericUpDown spn_CpuNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

