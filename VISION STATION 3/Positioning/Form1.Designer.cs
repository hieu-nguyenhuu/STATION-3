namespace Positioning
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
            this.lbl_Dec = new System.Windows.Forms.Label();
            this.lbl_Acc = new System.Windows.Forms.Label();
            this.lbl_Pos = new System.Windows.Forms.Label();
            this.lbl_Spd = new System.Windows.Forms.Label();
            this.lbl_Axis3 = new System.Windows.Forms.Label();
            this.lbl_Axis2 = new System.Windows.Forms.Label();
            this.btn_PosingStart = new System.Windows.Forms.Button();
            this.lbl_Axis1 = new System.Windows.Forms.Label();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.txt_A1_Pos = new System.Windows.Forms.TextBox();
            this.lbl_Cpu = new System.Windows.Forms.Label();
            this.txt_A1_Vel = new System.Windows.Forms.TextBox();
            this.grb_Prm = new System.Windows.Forms.GroupBox();
            this.txt_A1_Dec = new System.Windows.Forms.TextBox();
            this.txt_A2_Dec = new System.Windows.Forms.TextBox();
            this.txt_A2_Acc = new System.Windows.Forms.TextBox();
            this.txt_A2_Pos = new System.Windows.Forms.TextBox();
            this.txt_A2_Vel = new System.Windows.Forms.TextBox();
            this.txt_A3_Dec = new System.Windows.Forms.TextBox();
            this.txt_A3_Acc = new System.Windows.Forms.TextBox();
            this.txt_A1_Acc = new System.Windows.Forms.TextBox();
            this.txt_A3_Pos = new System.Windows.Forms.TextBox();
            this.txt_A3_Vel = new System.Windows.Forms.TextBox();
            this.spn_Axis = new System.Windows.Forms.NumericUpDown();
            this.lbl_Axis = new System.Windows.Forms.Label();
            this.btn_PosingStop = new System.Windows.Forms.Button();
            this.spn_CpuNo = new System.Windows.Forms.NumericUpDown();
            this.grb_Prm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spn_Axis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn_CpuNo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Dec
            // 
            this.lbl_Dec.Location = new System.Drawing.Point(425, 20);
            this.lbl_Dec.Name = "lbl_Dec";
            this.lbl_Dec.Size = new System.Drawing.Size(110, 30);
            this.lbl_Dec.TabIndex = 25;
            this.lbl_Dec.Text = "Deceleration [ms]";
            this.lbl_Dec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Acc
            // 
            this.lbl_Acc.Location = new System.Drawing.Point(310, 20);
            this.lbl_Acc.Name = "lbl_Acc";
            this.lbl_Acc.Size = new System.Drawing.Size(105, 30);
            this.lbl_Acc.TabIndex = 21;
            this.lbl_Acc.Text = "Acceleration [ms]";
            this.lbl_Acc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Pos
            // 
            this.lbl_Pos.Location = new System.Drawing.Point(190, 20);
            this.lbl_Pos.Name = "lbl_Pos";
            this.lbl_Pos.Size = new System.Drawing.Size(105, 30);
            this.lbl_Pos.TabIndex = 17;
            this.lbl_Pos.Text = "Positional data";
            this.lbl_Pos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Spd
            // 
            this.lbl_Spd.Location = new System.Drawing.Point(65, 20);
            this.lbl_Spd.Name = "lbl_Spd";
            this.lbl_Spd.Size = new System.Drawing.Size(110, 30);
            this.lbl_Spd.TabIndex = 13;
            this.lbl_Spd.Text = "Speed [unit/sec]";
            this.lbl_Spd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Axis3
            // 
            this.lbl_Axis3.Location = new System.Drawing.Point(15, 115);
            this.lbl_Axis3.Name = "lbl_Axis3";
            this.lbl_Axis3.Size = new System.Drawing.Size(35, 20);
            this.lbl_Axis3.TabIndex = 11;
            this.lbl_Axis3.Text = "Axis3";
            this.lbl_Axis3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Axis2
            // 
            this.lbl_Axis2.Location = new System.Drawing.Point(15, 85);
            this.lbl_Axis2.Name = "lbl_Axis2";
            this.lbl_Axis2.Size = new System.Drawing.Size(35, 20);
            this.lbl_Axis2.TabIndex = 9;
            this.lbl_Axis2.Text = "Axis2";
            this.lbl_Axis2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_PosingStart
            // 
            this.btn_PosingStart.Location = new System.Drawing.Point(12, 214);
            this.btn_PosingStart.Name = "btn_PosingStart";
            this.btn_PosingStart.Size = new System.Drawing.Size(95, 30);
            this.btn_PosingStart.TabIndex = 11;
            this.btn_PosingStart.Text = "Start";
            this.btn_PosingStart.Click += new System.EventHandler(this.btn_PosingStart_Click);
            // 
            // lbl_Axis1
            // 
            this.lbl_Axis1.Location = new System.Drawing.Point(15, 55);
            this.lbl_Axis1.Name = "lbl_Axis1";
            this.lbl_Axis1.Size = new System.Drawing.Size(35, 20);
            this.lbl_Axis1.TabIndex = 7;
            this.lbl_Axis1.Text = "Axis1 ";
            this.lbl_Axis1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(467, 214);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(95, 30);
            this.btn_Quit.TabIndex = 16;
            this.btn_Quit.Text = "End";
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // txt_A1_Pos
            // 
            this.txt_A1_Pos.Location = new System.Drawing.Point(185, 55);
            this.txt_A1_Pos.Name = "txt_A1_Pos";
            this.txt_A1_Pos.Size = new System.Drawing.Size(110, 19);
            this.txt_A1_Pos.TabIndex = 12;
            this.txt_A1_Pos.Text = "10000";
            this.txt_A1_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_Cpu
            // 
            this.lbl_Cpu.Location = new System.Drawing.Point(12, 9);
            this.lbl_Cpu.Name = "lbl_Cpu";
            this.lbl_Cpu.Size = new System.Drawing.Size(110, 20);
            this.lbl_Cpu.TabIndex = 18;
            this.lbl_Cpu.Text = "CPU No   [ 1 - 4 ]";
            this.lbl_Cpu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_A1_Vel
            // 
            this.txt_A1_Vel.Location = new System.Drawing.Point(65, 55);
            this.txt_A1_Vel.Name = "txt_A1_Vel";
            this.txt_A1_Vel.Size = new System.Drawing.Size(110, 19);
            this.txt_A1_Vel.TabIndex = 11;
            this.txt_A1_Vel.Text = "10000";
            this.txt_A1_Vel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grb_Prm
            // 
            this.grb_Prm.Controls.Add(this.lbl_Dec);
            this.grb_Prm.Controls.Add(this.lbl_Acc);
            this.grb_Prm.Controls.Add(this.lbl_Pos);
            this.grb_Prm.Controls.Add(this.lbl_Spd);
            this.grb_Prm.Controls.Add(this.lbl_Axis3);
            this.grb_Prm.Controls.Add(this.lbl_Axis2);
            this.grb_Prm.Controls.Add(this.lbl_Axis1);
            this.grb_Prm.Controls.Add(this.txt_A1_Pos);
            this.grb_Prm.Controls.Add(this.txt_A1_Vel);
            this.grb_Prm.Controls.Add(this.txt_A1_Dec);
            this.grb_Prm.Controls.Add(this.txt_A2_Dec);
            this.grb_Prm.Controls.Add(this.txt_A2_Acc);
            this.grb_Prm.Controls.Add(this.txt_A2_Pos);
            this.grb_Prm.Controls.Add(this.txt_A2_Vel);
            this.grb_Prm.Controls.Add(this.txt_A3_Dec);
            this.grb_Prm.Controls.Add(this.txt_A3_Acc);
            this.grb_Prm.Controls.Add(this.txt_A1_Acc);
            this.grb_Prm.Controls.Add(this.txt_A3_Pos);
            this.grb_Prm.Controls.Add(this.txt_A3_Vel);
            this.grb_Prm.Location = new System.Drawing.Point(12, 39);
            this.grb_Prm.Name = "grb_Prm";
            this.grb_Prm.Size = new System.Drawing.Size(550, 160);
            this.grb_Prm.TabIndex = 15;
            this.grb_Prm.TabStop = false;
            this.grb_Prm.Text = "Parameter setting for positioning";
            // 
            // txt_A1_Dec
            // 
            this.txt_A1_Dec.Location = new System.Drawing.Point(425, 55);
            this.txt_A1_Dec.Name = "txt_A1_Dec";
            this.txt_A1_Dec.Size = new System.Drawing.Size(110, 19);
            this.txt_A1_Dec.TabIndex = 14;
            this.txt_A1_Dec.Text = "100";
            this.txt_A1_Dec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A2_Dec
            // 
            this.txt_A2_Dec.Location = new System.Drawing.Point(425, 85);
            this.txt_A2_Dec.Name = "txt_A2_Dec";
            this.txt_A2_Dec.Size = new System.Drawing.Size(110, 19);
            this.txt_A2_Dec.TabIndex = 18;
            this.txt_A2_Dec.Text = "200";
            this.txt_A2_Dec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A2_Acc
            // 
            this.txt_A2_Acc.Location = new System.Drawing.Point(305, 85);
            this.txt_A2_Acc.Name = "txt_A2_Acc";
            this.txt_A2_Acc.Size = new System.Drawing.Size(110, 19);
            this.txt_A2_Acc.TabIndex = 17;
            this.txt_A2_Acc.Text = "200";
            this.txt_A2_Acc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A2_Pos
            // 
            this.txt_A2_Pos.Location = new System.Drawing.Point(185, 85);
            this.txt_A2_Pos.Name = "txt_A2_Pos";
            this.txt_A2_Pos.Size = new System.Drawing.Size(110, 19);
            this.txt_A2_Pos.TabIndex = 16;
            this.txt_A2_Pos.Text = "20000";
            this.txt_A2_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A2_Vel
            // 
            this.txt_A2_Vel.Location = new System.Drawing.Point(65, 85);
            this.txt_A2_Vel.Name = "txt_A2_Vel";
            this.txt_A2_Vel.Size = new System.Drawing.Size(110, 19);
            this.txt_A2_Vel.TabIndex = 15;
            this.txt_A2_Vel.Text = "20000";
            this.txt_A2_Vel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A3_Dec
            // 
            this.txt_A3_Dec.Location = new System.Drawing.Point(425, 115);
            this.txt_A3_Dec.Name = "txt_A3_Dec";
            this.txt_A3_Dec.Size = new System.Drawing.Size(110, 19);
            this.txt_A3_Dec.TabIndex = 22;
            this.txt_A3_Dec.Text = "300";
            this.txt_A3_Dec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A3_Acc
            // 
            this.txt_A3_Acc.Location = new System.Drawing.Point(305, 115);
            this.txt_A3_Acc.Name = "txt_A3_Acc";
            this.txt_A3_Acc.Size = new System.Drawing.Size(110, 19);
            this.txt_A3_Acc.TabIndex = 21;
            this.txt_A3_Acc.Text = "300";
            this.txt_A3_Acc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A1_Acc
            // 
            this.txt_A1_Acc.Location = new System.Drawing.Point(305, 55);
            this.txt_A1_Acc.Name = "txt_A1_Acc";
            this.txt_A1_Acc.Size = new System.Drawing.Size(110, 19);
            this.txt_A1_Acc.TabIndex = 13;
            this.txt_A1_Acc.Text = "100";
            this.txt_A1_Acc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A3_Pos
            // 
            this.txt_A3_Pos.Location = new System.Drawing.Point(185, 115);
            this.txt_A3_Pos.Name = "txt_A3_Pos";
            this.txt_A3_Pos.Size = new System.Drawing.Size(110, 19);
            this.txt_A3_Pos.TabIndex = 20;
            this.txt_A3_Pos.Text = "30000";
            this.txt_A3_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A3_Vel
            // 
            this.txt_A3_Vel.Location = new System.Drawing.Point(65, 115);
            this.txt_A3_Vel.Name = "txt_A3_Vel";
            this.txt_A3_Vel.Size = new System.Drawing.Size(110, 19);
            this.txt_A3_Vel.TabIndex = 19;
            this.txt_A3_Vel.Text = "30000";
            this.txt_A3_Vel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // spn_Axis
            // 
            this.spn_Axis.Location = new System.Drawing.Point(417, 9);
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
            this.spn_Axis.Size = new System.Drawing.Size(60, 19);
            this.spn_Axis.TabIndex = 12;
            this.spn_Axis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spn_Axis.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_Axis
            // 
            this.lbl_Axis.Location = new System.Drawing.Point(207, 9);
            this.lbl_Axis.Name = "lbl_Axis";
            this.lbl_Axis.Size = new System.Drawing.Size(205, 20);
            this.lbl_Axis.TabIndex = 13;
            this.lbl_Axis.Text = "Number of axes [ 1 - 3 ]";
            this.lbl_Axis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_PosingStop
            // 
            this.btn_PosingStop.Location = new System.Drawing.Point(127, 214);
            this.btn_PosingStop.Name = "btn_PosingStop";
            this.btn_PosingStop.Size = new System.Drawing.Size(95, 30);
            this.btn_PosingStop.TabIndex = 14;
            this.btn_PosingStop.Text = "Stop";
            this.btn_PosingStop.Click += new System.EventHandler(this.btn_PosingStop_Click);
            // 
            // spn_CpuNo
            // 
            this.spn_CpuNo.Location = new System.Drawing.Point(127, 9);
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
            this.spn_CpuNo.Size = new System.Drawing.Size(60, 19);
            this.spn_CpuNo.TabIndex = 17;
            this.spn_CpuNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spn_CpuNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 261);
            this.Controls.Add(this.btn_PosingStart);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.lbl_Cpu);
            this.Controls.Add(this.grb_Prm);
            this.Controls.Add(this.spn_Axis);
            this.Controls.Add(this.lbl_Axis);
            this.Controls.Add(this.btn_PosingStop);
            this.Controls.Add(this.spn_CpuNo);
            this.Name = "Form1";
            this.Text = "Positioning Sample";
            this.grb_Prm.ResumeLayout(false);
            this.grb_Prm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spn_Axis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn_CpuNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Dec;
        private System.Windows.Forms.Label lbl_Acc;
        private System.Windows.Forms.Label lbl_Pos;
        private System.Windows.Forms.Label lbl_Spd;
        private System.Windows.Forms.Label lbl_Axis3;
        private System.Windows.Forms.Label lbl_Axis2;
        private System.Windows.Forms.Button btn_PosingStart;
        private System.Windows.Forms.Label lbl_Axis1;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.TextBox txt_A1_Pos;
        private System.Windows.Forms.Label lbl_Cpu;
        private System.Windows.Forms.TextBox txt_A1_Vel;
        private System.Windows.Forms.GroupBox grb_Prm;
        private System.Windows.Forms.TextBox txt_A1_Dec;
        private System.Windows.Forms.TextBox txt_A2_Dec;
        private System.Windows.Forms.TextBox txt_A2_Acc;
        private System.Windows.Forms.TextBox txt_A2_Pos;
        private System.Windows.Forms.TextBox txt_A2_Vel;
        private System.Windows.Forms.TextBox txt_A3_Dec;
        private System.Windows.Forms.TextBox txt_A3_Acc;
        private System.Windows.Forms.TextBox txt_A1_Acc;
        private System.Windows.Forms.TextBox txt_A3_Pos;
        private System.Windows.Forms.TextBox txt_A3_Vel;
        private System.Windows.Forms.NumericUpDown spn_Axis;
        private System.Windows.Forms.Label lbl_Axis;
        private System.Windows.Forms.Button btn_PosingStop;
        private System.Windows.Forms.NumericUpDown spn_CpuNo;
    }
}

