namespace SystemControl
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
            this.label4 = new System.Windows.Forms.Label();
            this.btn_PosingStart = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.spn_Axis_2 = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.spn_CpuNo_2 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_A1_Dec = new System.Windows.Forms.TextBox();
            this.txt_A3_Vel = new System.Windows.Forms.TextBox();
            this.spn_CpuNo_1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_A2_Dec = new System.Windows.Forms.TextBox();
            this.txt_A2_Acc = new System.Windows.Forms.TextBox();
            this.txt_A2_Pos = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_A2_Vel = new System.Windows.Forms.TextBox();
            this.txt_A1_Vel = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.spn_Axis_1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_A3_Dec = new System.Windows.Forms.TextBox();
            this.btn_PosingStop = new System.Windows.Forms.Button();
            this.txt_A1_Pos = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_A3_Acc = new System.Windows.Forms.TextBox();
            this.txt_A1_Acc = new System.Windows.Forms.TextBox();
            this.txt_A3_Pos = new System.Windows.Forms.TextBox();
            this.btn_Quit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spn_Axis_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn_CpuNo_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn_CpuNo_1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spn_Axis_1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(175, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Positional data";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_PosingStart
            // 
            this.btn_PosingStart.Location = new System.Drawing.Point(12, 294);
            this.btn_PosingStart.Name = "btn_PosingStart";
            this.btn_PosingStart.Size = new System.Drawing.Size(95, 30);
            this.btn_PosingStart.TabIndex = 16;
            this.btn_PosingStart.Text = "JOG Start";
            this.btn_PosingStart.Click += new System.EventHandler(this.btn_PosingStart_Click);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(215, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 15);
            this.label12.TabIndex = 16;
            this.label12.Text = "Number Of Axis [1-3]";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(395, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 20);
            this.label18.TabIndex = 25;
            this.label18.Text = "Deceleration[ms]";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spn_Axis_2
            // 
            this.spn_Axis_2.Location = new System.Drawing.Point(345, 55);
            this.spn_Axis_2.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.spn_Axis_2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spn_Axis_2.Name = "spn_Axis_2";
            this.spn_Axis_2.Size = new System.Drawing.Size(45, 19);
            this.spn_Axis_2.TabIndex = 17;
            this.spn_Axis_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spn_Axis_2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(285, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 20);
            this.label14.TabIndex = 21;
            this.label14.Text = "Acceleration[ms]";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spn_CpuNo_2
            // 
            this.spn_CpuNo_2.Location = new System.Drawing.Point(345, 35);
            this.spn_CpuNo_2.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.spn_CpuNo_2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spn_CpuNo_2.Name = "spn_CpuNo_2";
            this.spn_CpuNo_2.Size = new System.Drawing.Size(45, 19);
            this.spn_CpuNo_2.TabIndex = 17;
            this.spn_CpuNo_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spn_CpuNo_2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(65, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Speed [unit/sec]";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(15, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 15);
            this.label15.TabIndex = 22;
            this.label15.Text = "Board 1";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(215, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "CPU number     [1-4]";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(15, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Axis3";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(15, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "CPU number     [1-4]";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(15, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Axis2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Axis1 ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_A1_Dec
            // 
            this.txt_A1_Dec.Location = new System.Drawing.Point(390, 40);
            this.txt_A1_Dec.Name = "txt_A1_Dec";
            this.txt_A1_Dec.Size = new System.Drawing.Size(105, 19);
            this.txt_A1_Dec.TabIndex = 42;
            this.txt_A1_Dec.Text = "100";
            this.txt_A1_Dec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A3_Vel
            // 
            this.txt_A3_Vel.Location = new System.Drawing.Point(60, 90);
            this.txt_A3_Vel.Name = "txt_A3_Vel";
            this.txt_A3_Vel.Size = new System.Drawing.Size(105, 19);
            this.txt_A3_Vel.TabIndex = 47;
            this.txt_A3_Vel.Text = "300000";
            this.txt_A3_Vel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // spn_CpuNo_1
            // 
            this.spn_CpuNo_1.Location = new System.Drawing.Point(145, 35);
            this.spn_CpuNo_1.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.spn_CpuNo_1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spn_CpuNo_1.Name = "spn_CpuNo_1";
            this.spn_CpuNo_1.Size = new System.Drawing.Size(45, 19);
            this.spn_CpuNo_1.TabIndex = 13;
            this.spn_CpuNo_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spn_CpuNo_1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Number Of Axis [1-3]";
            // 
            // txt_A2_Dec
            // 
            this.txt_A2_Dec.Location = new System.Drawing.Point(390, 65);
            this.txt_A2_Dec.Name = "txt_A2_Dec";
            this.txt_A2_Dec.Size = new System.Drawing.Size(105, 19);
            this.txt_A2_Dec.TabIndex = 46;
            this.txt_A2_Dec.Text = "200";
            this.txt_A2_Dec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A2_Acc
            // 
            this.txt_A2_Acc.Location = new System.Drawing.Point(280, 65);
            this.txt_A2_Acc.Name = "txt_A2_Acc";
            this.txt_A2_Acc.Size = new System.Drawing.Size(105, 19);
            this.txt_A2_Acc.TabIndex = 45;
            this.txt_A2_Acc.Text = "200";
            this.txt_A2_Acc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A2_Pos
            // 
            this.txt_A2_Pos.Location = new System.Drawing.Point(170, 65);
            this.txt_A2_Pos.Name = "txt_A2_Pos";
            this.txt_A2_Pos.Size = new System.Drawing.Size(105, 19);
            this.txt_A2_Pos.TabIndex = 44;
            this.txt_A2_Pos.Text = "200000";
            this.txt_A2_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(215, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 15);
            this.label16.TabIndex = 23;
            this.label16.Text = "Board 2";
            // 
            // txt_A2_Vel
            // 
            this.txt_A2_Vel.Location = new System.Drawing.Point(60, 65);
            this.txt_A2_Vel.Name = "txt_A2_Vel";
            this.txt_A2_Vel.Size = new System.Drawing.Size(105, 19);
            this.txt_A2_Vel.TabIndex = 43;
            this.txt_A2_Vel.Text = "200000";
            this.txt_A2_Vel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A1_Vel
            // 
            this.txt_A1_Vel.Location = new System.Drawing.Point(60, 40);
            this.txt_A1_Vel.Name = "txt_A1_Vel";
            this.txt_A1_Vel.Size = new System.Drawing.Size(105, 19);
            this.txt_A1_Vel.TabIndex = 39;
            this.txt_A1_Vel.Text = "100000";
            this.txt_A1_Vel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.spn_CpuNo_2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.spn_Axis_2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.spn_CpuNo_1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.spn_Axis_1);
            this.groupBox2.Location = new System.Drawing.Point(12, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(506, 90);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Open and GetAxisHandle";
            // 
            // spn_Axis_1
            // 
            this.spn_Axis_1.Location = new System.Drawing.Point(145, 55);
            this.spn_Axis_1.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.spn_Axis_1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spn_Axis_1.Name = "spn_Axis_1";
            this.spn_Axis_1.Size = new System.Drawing.Size(45, 19);
            this.spn_Axis_1.TabIndex = 13;
            this.spn_Axis_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spn_Axis_1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Two MP2100 is necessary. ";
            // 
            // txt_A3_Dec
            // 
            this.txt_A3_Dec.Location = new System.Drawing.Point(390, 90);
            this.txt_A3_Dec.Name = "txt_A3_Dec";
            this.txt_A3_Dec.Size = new System.Drawing.Size(105, 19);
            this.txt_A3_Dec.TabIndex = 50;
            this.txt_A3_Dec.Text = "300";
            this.txt_A3_Dec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_PosingStop
            // 
            this.btn_PosingStop.Location = new System.Drawing.Point(112, 294);
            this.btn_PosingStop.Name = "btn_PosingStop";
            this.btn_PosingStop.Size = new System.Drawing.Size(95, 30);
            this.btn_PosingStop.TabIndex = 17;
            this.btn_PosingStop.Text = "JOG Stop";
            this.btn_PosingStop.Click += new System.EventHandler(this.btn_PosingStop_Click);
            // 
            // txt_A1_Pos
            // 
            this.txt_A1_Pos.Location = new System.Drawing.Point(170, 40);
            this.txt_A1_Pos.Name = "txt_A1_Pos";
            this.txt_A1_Pos.Size = new System.Drawing.Size(105, 19);
            this.txt_A1_Pos.TabIndex = 40;
            this.txt_A1_Pos.Text = "100000";
            this.txt_A1_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_A1_Dec);
            this.groupBox1.Controls.Add(this.txt_A3_Vel);
            this.groupBox1.Controls.Add(this.txt_A2_Dec);
            this.groupBox1.Controls.Add(this.txt_A2_Acc);
            this.groupBox1.Controls.Add(this.txt_A2_Pos);
            this.groupBox1.Controls.Add(this.txt_A2_Vel);
            this.groupBox1.Controls.Add(this.txt_A1_Vel);
            this.groupBox1.Controls.Add(this.txt_A3_Dec);
            this.groupBox1.Controls.Add(this.txt_A1_Pos);
            this.groupBox1.Controls.Add(this.txt_A3_Acc);
            this.groupBox1.Controls.Add(this.txt_A1_Acc);
            this.groupBox1.Controls.Add(this.txt_A3_Pos);
            this.groupBox1.Location = new System.Drawing.Point(12, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 130);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameter Setting(Common to a board 1 and a board 2)";
            // 
            // txt_A3_Acc
            // 
            this.txt_A3_Acc.Location = new System.Drawing.Point(280, 90);
            this.txt_A3_Acc.Name = "txt_A3_Acc";
            this.txt_A3_Acc.Size = new System.Drawing.Size(105, 19);
            this.txt_A3_Acc.TabIndex = 49;
            this.txt_A3_Acc.Text = "300";
            this.txt_A3_Acc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A1_Acc
            // 
            this.txt_A1_Acc.Location = new System.Drawing.Point(280, 40);
            this.txt_A1_Acc.Name = "txt_A1_Acc";
            this.txt_A1_Acc.Size = new System.Drawing.Size(105, 19);
            this.txt_A1_Acc.TabIndex = 41;
            this.txt_A1_Acc.Text = "100";
            this.txt_A1_Acc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A3_Pos
            // 
            this.txt_A3_Pos.Location = new System.Drawing.Point(170, 90);
            this.txt_A3_Pos.Name = "txt_A3_Pos";
            this.txt_A3_Pos.Size = new System.Drawing.Size(105, 19);
            this.txt_A3_Pos.TabIndex = 48;
            this.txt_A3_Pos.Text = "300000";
            this.txt_A3_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(423, 294);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(95, 30);
            this.btn_Quit.TabIndex = 19;
            this.btn_Quit.Text = "End";
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 338);
            this.Controls.Add(this.btn_PosingStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_PosingStop);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Quit);
            this.Name = "Form1";
            this.Text = "SystemControl Sample";
            ((System.ComponentModel.ISupportInitialize)(this.spn_Axis_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn_CpuNo_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn_CpuNo_1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spn_Axis_1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_PosingStart;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown spn_Axis_2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown spn_CpuNo_2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_A1_Dec;
        private System.Windows.Forms.TextBox txt_A3_Vel;
        private System.Windows.Forms.NumericUpDown spn_CpuNo_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_A2_Dec;
        private System.Windows.Forms.TextBox txt_A2_Acc;
        private System.Windows.Forms.TextBox txt_A2_Pos;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_A2_Vel;
        private System.Windows.Forms.TextBox txt_A1_Vel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown spn_Axis_1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_A3_Dec;
        private System.Windows.Forms.Button btn_PosingStop;
        private System.Windows.Forms.TextBox txt_A1_Pos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_A3_Acc;
        private System.Windows.Forms.TextBox txt_A1_Acc;
        private System.Windows.Forms.TextBox txt_A3_Pos;
        private System.Windows.Forms.Button btn_Quit;
    }
}

