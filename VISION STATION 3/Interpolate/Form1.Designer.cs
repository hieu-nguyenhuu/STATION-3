namespace Interpolate
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
            this.label14 = new System.Windows.Forms.Label();
            this.btn_ServoON = new System.Windows.Forms.Button();
            this.btn_InterpolateStop = new System.Windows.Forms.Button();
            this.btn_GetAxisHandle = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_InterpolateStart = new System.Windows.Forms.Button();
            this.btn_MotionAPI_Open = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.spn_CpuNo = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.spn_Axis = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_A1_Pos = new System.Windows.Forms.TextBox();
            this.txt_A2_Pos = new System.Windows.Forms.TextBox();
            this.txt_A3_Pos = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Vel = new System.Windows.Forms.TextBox();
            this.txt_Acc = new System.Windows.Forms.TextBox();
            this.txt_MaxVel = new System.Windows.Forms.TextBox();
            this.txt_Dec = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ServoOFF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spn_CpuNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn_Axis)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(15, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 20);
            this.label14.TabIndex = 49;
            this.label14.Text = "Acceleration [ms]";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_ServoON
            // 
            this.btn_ServoON.Location = new System.Drawing.Point(13, 92);
            this.btn_ServoON.Name = "btn_ServoON";
            this.btn_ServoON.Size = new System.Drawing.Size(100, 30);
            this.btn_ServoON.TabIndex = 42;
            this.btn_ServoON.Text = "Servo ON";
            this.btn_ServoON.Click += new System.EventHandler(this.btn_ServoON_Click);
            // 
            // btn_InterpolateStop
            // 
            this.btn_InterpolateStop.Location = new System.Drawing.Point(130, 240);
            this.btn_InterpolateStop.Name = "btn_InterpolateStop";
            this.btn_InterpolateStop.Size = new System.Drawing.Size(110, 30);
            this.btn_InterpolateStop.TabIndex = 51;
            this.btn_InterpolateStop.Text = "Stop";
            this.btn_InterpolateStop.Click += new System.EventHandler(this.btn_InterpolateStop_Click);
            // 
            // btn_GetAxisHandle
            // 
            this.btn_GetAxisHandle.Location = new System.Drawing.Point(203, 47);
            this.btn_GetAxisHandle.Name = "btn_GetAxisHandle";
            this.btn_GetAxisHandle.Size = new System.Drawing.Size(100, 30);
            this.btn_GetAxisHandle.TabIndex = 41;
            this.btn_GetAxisHandle.Text = "Get AxisHandle";
            this.btn_GetAxisHandle.Click += new System.EventHandler(this.btn_GetAxisHandle_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(15, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "Speed [unit/sec]";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_InterpolateStart
            // 
            this.btn_InterpolateStart.Location = new System.Drawing.Point(10, 240);
            this.btn_InterpolateStart.Name = "btn_InterpolateStart";
            this.btn_InterpolateStart.Size = new System.Drawing.Size(110, 30);
            this.btn_InterpolateStart.TabIndex = 50;
            this.btn_InterpolateStart.Text = "Start";
            this.btn_InterpolateStart.Click += new System.EventHandler(this.btn_InterpolateStart_Click);
            // 
            // btn_MotionAPI_Open
            // 
            this.btn_MotionAPI_Open.Location = new System.Drawing.Point(203, 12);
            this.btn_MotionAPI_Open.Name = "btn_MotionAPI_Open";
            this.btn_MotionAPI_Open.Size = new System.Drawing.Size(100, 30);
            this.btn_MotionAPI_Open.TabIndex = 40;
            this.btn_MotionAPI_Open.Text = "Open MotionAPI";
            this.btn_MotionAPI_Open.Click += new System.EventHandler(this.btn_MotionAPI_Open_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 15);
            this.label8.TabIndex = 39;
            this.label8.Text = "CPU number     [1-4]";
            // 
            // spn_CpuNo
            // 
            this.spn_CpuNo.Location = new System.Drawing.Point(148, 17);
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
            this.spn_CpuNo.TabIndex = 44;
            this.spn_CpuNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spn_CpuNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(215, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 20);
            this.label6.TabIndex = 56;
            this.label6.Text = "MaxSpeed [unit/sec]";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(368, 422);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(95, 30);
            this.btn_Quit.TabIndex = 38;
            this.btn_Quit.Text = "End";
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // spn_Axis
            // 
            this.spn_Axis.Location = new System.Drawing.Point(148, 52);
            this.spn_Axis.Maximum = new decimal(new int[] {
            4,
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
            this.spn_Axis.TabIndex = 45;
            this.spn_Axis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spn_Axis.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(15, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 20);
            this.label10.TabIndex = 47;
            this.label10.Text = "Positional data";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(315, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 46;
            this.label7.Text = "Axis3";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(220, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 45;
            this.label5.Text = "Axis2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txt_A1_Pos);
            this.groupBox3.Controls.Add(this.txt_A2_Pos);
            this.groupBox3.Controls.Add(this.txt_A3_Pos);
            this.groupBox3.Location = new System.Drawing.Point(10, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(430, 95);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Positional data";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(120, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 44;
            this.label3.Text = "Axis1 ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_A1_Pos
            // 
            this.txt_A1_Pos.Location = new System.Drawing.Point(120, 50);
            this.txt_A1_Pos.Name = "txt_A1_Pos";
            this.txt_A1_Pos.Size = new System.Drawing.Size(80, 19);
            this.txt_A1_Pos.TabIndex = 55;
            this.txt_A1_Pos.Text = "10000";
            this.txt_A1_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A2_Pos
            // 
            this.txt_A2_Pos.Location = new System.Drawing.Point(215, 50);
            this.txt_A2_Pos.Name = "txt_A2_Pos";
            this.txt_A2_Pos.Size = new System.Drawing.Size(80, 19);
            this.txt_A2_Pos.TabIndex = 56;
            this.txt_A2_Pos.Text = "20000";
            this.txt_A2_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A3_Pos
            // 
            this.txt_A3_Pos.Location = new System.Drawing.Point(310, 50);
            this.txt_A3_Pos.Name = "txt_A3_Pos";
            this.txt_A3_Pos.Size = new System.Drawing.Size(80, 19);
            this.txt_A3_Pos.TabIndex = 57;
            this.txt_A3_Pos.Text = "30000";
            this.txt_A3_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btn_InterpolateStop);
            this.groupBox1.Controls.Add(this.btn_InterpolateStart);
            this.groupBox1.Location = new System.Drawing.Point(13, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 285);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameter Setting";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_Vel);
            this.groupBox2.Controls.Add(this.txt_Acc);
            this.groupBox2.Controls.Add(this.txt_MaxVel);
            this.groupBox2.Controls.Add(this.txt_Dec);
            this.groupBox2.Location = new System.Drawing.Point(10, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 95);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MotionData (Common to each axis)";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(215, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "Deceleration [ms]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_Vel
            // 
            this.txt_Vel.Location = new System.Drawing.Point(125, 35);
            this.txt_Vel.Name = "txt_Vel";
            this.txt_Vel.Size = new System.Drawing.Size(80, 19);
            this.txt_Vel.TabIndex = 22;
            this.txt_Vel.Text = "10000";
            this.txt_Vel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_Acc
            // 
            this.txt_Acc.Location = new System.Drawing.Point(125, 65);
            this.txt_Acc.Name = "txt_Acc";
            this.txt_Acc.Size = new System.Drawing.Size(80, 19);
            this.txt_Acc.TabIndex = 53;
            this.txt_Acc.Text = "100";
            this.txt_Acc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_MaxVel
            // 
            this.txt_MaxVel.Location = new System.Drawing.Point(345, 35);
            this.txt_MaxVel.Name = "txt_MaxVel";
            this.txt_MaxVel.Size = new System.Drawing.Size(80, 19);
            this.txt_MaxVel.TabIndex = 54;
            this.txt_MaxVel.Text = "100000";
            this.txt_MaxVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_Dec
            // 
            this.txt_Dec.Location = new System.Drawing.Point(345, 65);
            this.txt_Dec.Name = "txt_Dec";
            this.txt_Dec.Size = new System.Drawing.Size(80, 19);
            this.txt_Dec.TabIndex = 55;
            this.txt_Dec.Text = "100";
            this.txt_Dec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Number Of Axis [1-3]";
            // 
            // btn_ServoOFF
            // 
            this.btn_ServoOFF.Location = new System.Drawing.Point(123, 92);
            this.btn_ServoOFF.Name = "btn_ServoOFF";
            this.btn_ServoOFF.Size = new System.Drawing.Size(100, 30);
            this.btn_ServoOFF.TabIndex = 43;
            this.btn_ServoOFF.Text = "Servo OFF";
            this.btn_ServoOFF.Click += new System.EventHandler(this.btn_ServoOFF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 458);
            this.Controls.Add(this.btn_ServoON);
            this.Controls.Add(this.btn_GetAxisHandle);
            this.Controls.Add(this.btn_MotionAPI_Open);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.spn_CpuNo);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.spn_Axis);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ServoOFF);
            this.Name = "Form1";
            this.Text = "Interpolate Sample";
            ((System.ComponentModel.ISupportInitialize)(this.spn_CpuNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn_Axis)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_ServoON;
        private System.Windows.Forms.Button btn_InterpolateStop;
        private System.Windows.Forms.Button btn_GetAxisHandle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_InterpolateStart;
        private System.Windows.Forms.Button btn_MotionAPI_Open;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown spn_CpuNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.NumericUpDown spn_Axis;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_A1_Pos;
        private System.Windows.Forms.TextBox txt_A2_Pos;
        private System.Windows.Forms.TextBox txt_A3_Pos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Vel;
        private System.Windows.Forms.TextBox txt_Acc;
        private System.Windows.Forms.TextBox txt_MaxVel;
        private System.Windows.Forms.TextBox txt_Dec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ServoOFF;
    }
}

