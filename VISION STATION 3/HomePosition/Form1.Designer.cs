namespace HomePosition
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
            this.rdo_A2_C = new System.Windows.Forms.RadioButton();
            this.rdo_A2_INPUT_C = new System.Windows.Forms.RadioButton();
            this.btn_Open = new System.Windows.Forms.Button();
            this.grp_A2_OB = new System.Windows.Forms.GroupBox();
            this.rdo_A2_OBOFF = new System.Windows.Forms.RadioButton();
            this.rdo_A2_OBON = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_A2_Start = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_A2_Direction = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_A2_Approach = new System.Windows.Forms.TextBox();
            this.txt_A2_Pos = new System.Windows.Forms.TextBox();
            this.txt_A2_Vel = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_A2_Creep = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grp_A1_OB = new System.Windows.Forms.GroupBox();
            this.rdo_A1_OBOFF = new System.Windows.Forms.RadioButton();
            this.rdo_A1_OBON = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdo_A1_C = new System.Windows.Forms.RadioButton();
            this.rdo_A1_INPUT_C = new System.Windows.Forms.RadioButton();
            this.spn_CpuNo = new System.Windows.Forms.NumericUpDown();
            this.btn_A1_Start = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_A1_Direction = new System.Windows.Forms.ComboBox();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_A1_Approach = new System.Windows.Forms.TextBox();
            this.txt_A1_Pos = new System.Windows.Forms.TextBox();
            this.txt_A1_Vel = new System.Windows.Forms.TextBox();
            this.txt_A1_Creep = new System.Windows.Forms.TextBox();
            this.grp_A2_OB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grp_A1_OB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spn_CpuNo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 56;
            this.label4.Text = "Speed [unit/sec]";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdo_A2_C
            // 
            this.rdo_A2_C.Checked = true;
            this.rdo_A2_C.Location = new System.Drawing.Point(105, 25);
            this.rdo_A2_C.Name = "rdo_A2_C";
            this.rdo_A2_C.Size = new System.Drawing.Size(140, 15);
            this.rdo_A2_C.TabIndex = 54;
            this.rdo_A2_C.TabStop = true;
            this.rdo_A2_C.Text = "HMETHOD_C";
            this.rdo_A2_C.CheckedChanged += new System.EventHandler(this.rdo_A2_C_CheckedChanged);
            // 
            // rdo_A2_INPUT_C
            // 
            this.rdo_A2_INPUT_C.Location = new System.Drawing.Point(105, 45);
            this.rdo_A2_INPUT_C.Name = "rdo_A2_INPUT_C";
            this.rdo_A2_INPUT_C.Size = new System.Drawing.Size(140, 15);
            this.rdo_A2_INPUT_C.TabIndex = 53;
            this.rdo_A2_INPUT_C.Text = "HMETHOD_INPUT_C";
            this.rdo_A2_INPUT_C.CheckedChanged += new System.EventHandler(this.rdo_A2_INPUT_C_CheckedChanged);
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(208, 12);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(105, 30);
            this.btn_Open.TabIndex = 59;
            this.btn_Open.Text = "MotionAPI Open";
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // grp_A2_OB
            // 
            this.grp_A2_OB.Controls.Add(this.rdo_A2_OBOFF);
            this.grp_A2_OB.Controls.Add(this.rdo_A2_OBON);
            this.grp_A2_OB.Enabled = false;
            this.grp_A2_OB.Location = new System.Drawing.Point(120, 175);
            this.grp_A2_OB.Name = "grp_A2_OB";
            this.grp_A2_OB.Size = new System.Drawing.Size(120, 50);
            this.grp_A2_OB.TabIndex = 58;
            this.grp_A2_OB.TabStop = false;
            this.grp_A2_OB.Text = "OBxx05B";
            // 
            // rdo_A2_OBOFF
            // 
            this.rdo_A2_OBOFF.Checked = true;
            this.rdo_A2_OBOFF.Location = new System.Drawing.Point(65, 20);
            this.rdo_A2_OBOFF.Name = "rdo_A2_OBOFF";
            this.rdo_A2_OBOFF.Size = new System.Drawing.Size(50, 24);
            this.rdo_A2_OBOFF.TabIndex = 1;
            this.rdo_A2_OBOFF.TabStop = true;
            this.rdo_A2_OBOFF.Text = "OFF";
            this.rdo_A2_OBOFF.CheckedChanged += new System.EventHandler(this.rdo_A2_OBOFF_CheckedChanged);
            // 
            // rdo_A2_OBON
            // 
            this.rdo_A2_OBON.Location = new System.Drawing.Point(10, 20);
            this.rdo_A2_OBON.Name = "rdo_A2_OBON";
            this.rdo_A2_OBON.Size = new System.Drawing.Size(45, 24);
            this.rdo_A2_OBON.TabIndex = 0;
            this.rdo_A2_OBON.Text = "ON";
            this.rdo_A2_OBON.CheckedChanged += new System.EventHandler(this.rdo_A2_OBON_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 55;
            this.label5.Text = "Mode";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_A2_Start
            // 
            this.btn_A2_Start.Location = new System.Drawing.Point(10, 190);
            this.btn_A2_Start.Name = "btn_A2_Start";
            this.btn_A2_Start.Size = new System.Drawing.Size(95, 30);
            this.btn_A2_Start.TabIndex = 52;
            this.btn_A2_Start.Text = "Start  Axis2";
            this.btn_A2_Start.Click += new System.EventHandler(this.btn_A2_Start_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 20);
            this.label6.TabIndex = 50;
            this.label6.Text = "Direction";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmb_A2_Direction
            // 
            this.cmb_A2_Direction.FormattingEnabled = true;
            this.cmb_A2_Direction.Items.AddRange(new object[] {
            "POSITIVE;",
            "NEGATIVE;"});
            this.cmb_A2_Direction.Location = new System.Drawing.Point(165, 150);
            this.cmb_A2_Direction.Name = "cmb_A2_Direction";
            this.cmb_A2_Direction.Size = new System.Drawing.Size(80, 20);
            this.cmb_A2_Direction.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Creep  [unit/sec]";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_A2_Approach
            // 
            this.txt_A2_Approach.Location = new System.Drawing.Point(165, 110);
            this.txt_A2_Approach.Name = "txt_A2_Approach";
            this.txt_A2_Approach.Size = new System.Drawing.Size(80, 19);
            this.txt_A2_Approach.TabIndex = 64;
            this.txt_A2_Approach.Text = "10000";
            this.txt_A2_Approach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A2_Pos
            // 
            this.txt_A2_Pos.Location = new System.Drawing.Point(165, 90);
            this.txt_A2_Pos.Name = "txt_A2_Pos";
            this.txt_A2_Pos.Size = new System.Drawing.Size(80, 19);
            this.txt_A2_Pos.TabIndex = 62;
            this.txt_A2_Pos.Text = "10000";
            this.txt_A2_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A2_Vel
            // 
            this.txt_A2_Vel.Location = new System.Drawing.Point(165, 70);
            this.txt_A2_Vel.Name = "txt_A2_Vel";
            this.txt_A2_Vel.Size = new System.Drawing.Size(80, 19);
            this.txt_A2_Vel.TabIndex = 61;
            this.txt_A2_Vel.Text = "10000";
            this.txt_A2_Vel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(10, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "Positional data";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grp_A2_OB);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.rdo_A2_C);
            this.groupBox2.Controls.Add(this.rdo_A2_INPUT_C);
            this.groupBox2.Controls.Add(this.btn_A2_Start);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmb_A2_Direction);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txt_A2_Creep);
            this.groupBox2.Controls.Add(this.txt_A2_Approach);
            this.groupBox2.Controls.Add(this.txt_A2_Pos);
            this.groupBox2.Controls.Add(this.txt_A2_Vel);
            this.groupBox2.Location = new System.Drawing.Point(268, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 235);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Axis 2";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Approach  [unit/sec]";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_A2_Creep
            // 
            this.txt_A2_Creep.Location = new System.Drawing.Point(165, 130);
            this.txt_A2_Creep.Name = "txt_A2_Creep";
            this.txt_A2_Creep.Size = new System.Drawing.Size(80, 19);
            this.txt_A2_Creep.TabIndex = 63;
            this.txt_A2_Creep.Text = "10000";
            this.txt_A2_Creep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 15);
            this.label8.TabIndex = 56;
            this.label8.Text = "CPU No   [ 1 - 4 ]";
            // 
            // grp_A1_OB
            // 
            this.grp_A1_OB.Controls.Add(this.rdo_A1_OBOFF);
            this.grp_A1_OB.Controls.Add(this.rdo_A1_OBON);
            this.grp_A1_OB.Enabled = false;
            this.grp_A1_OB.Location = new System.Drawing.Point(120, 175);
            this.grp_A1_OB.Name = "grp_A1_OB";
            this.grp_A1_OB.Size = new System.Drawing.Size(120, 50);
            this.grp_A1_OB.TabIndex = 58;
            this.grp_A1_OB.TabStop = false;
            this.grp_A1_OB.Text = "OBxx05B";
            // 
            // rdo_A1_OBOFF
            // 
            this.rdo_A1_OBOFF.Checked = true;
            this.rdo_A1_OBOFF.Location = new System.Drawing.Point(65, 20);
            this.rdo_A1_OBOFF.Name = "rdo_A1_OBOFF";
            this.rdo_A1_OBOFF.Size = new System.Drawing.Size(50, 24);
            this.rdo_A1_OBOFF.TabIndex = 1;
            this.rdo_A1_OBOFF.TabStop = true;
            this.rdo_A1_OBOFF.Text = "OFF";
            this.rdo_A1_OBOFF.CheckedChanged += new System.EventHandler(this.rdo_A1_OBOFF_CheckedChanged);
            // 
            // rdo_A1_OBON
            // 
            this.rdo_A1_OBON.Location = new System.Drawing.Point(10, 20);
            this.rdo_A1_OBON.Name = "rdo_A1_OBON";
            this.rdo_A1_OBON.Size = new System.Drawing.Size(45, 24);
            this.rdo_A1_OBON.TabIndex = 0;
            this.rdo_A1_OBON.Text = "ON";
            this.rdo_A1_OBON.CheckedChanged += new System.EventHandler(this.rdo_A1_OBON_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 56;
            this.label3.Text = "Speed [unit/sec]";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Mode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdo_A1_C
            // 
            this.rdo_A1_C.Checked = true;
            this.rdo_A1_C.Location = new System.Drawing.Point(105, 25);
            this.rdo_A1_C.Name = "rdo_A1_C";
            this.rdo_A1_C.Size = new System.Drawing.Size(140, 15);
            this.rdo_A1_C.TabIndex = 54;
            this.rdo_A1_C.TabStop = true;
            this.rdo_A1_C.Text = "HMETHOD_C";
            this.rdo_A1_C.CheckedChanged += new System.EventHandler(this.rdo_A1_C_CheckedChanged);
            // 
            // rdo_A1_INPUT_C
            // 
            this.rdo_A1_INPUT_C.Location = new System.Drawing.Point(105, 45);
            this.rdo_A1_INPUT_C.Name = "rdo_A1_INPUT_C";
            this.rdo_A1_INPUT_C.Size = new System.Drawing.Size(140, 15);
            this.rdo_A1_INPUT_C.TabIndex = 53;
            this.rdo_A1_INPUT_C.Text = "HMETHOD_INPUT_C";
            this.rdo_A1_INPUT_C.CheckedChanged += new System.EventHandler(this.rdo_A1_INPUT_C_CheckedChanged);
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
            this.spn_CpuNo.TabIndex = 58;
            this.spn_CpuNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spn_CpuNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_A1_Start
            // 
            this.btn_A1_Start.Location = new System.Drawing.Point(10, 190);
            this.btn_A1_Start.Name = "btn_A1_Start";
            this.btn_A1_Start.Size = new System.Drawing.Size(95, 30);
            this.btn_A1_Start.TabIndex = 52;
            this.btn_A1_Start.Text = "Start Axis1";
            this.btn_A1_Start.Click += new System.EventHandler(this.btn_A1_Start_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "Direction";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmb_A1_Direction
            // 
            this.cmb_A1_Direction.FormattingEnabled = true;
            this.cmb_A1_Direction.Items.AddRange(new object[] {
            "POSITIVE;",
            "NEGATIVE;"});
            this.cmb_A1_Direction.Location = new System.Drawing.Point(165, 150);
            this.cmb_A1_Direction.Name = "cmb_A1_Direction";
            this.cmb_A1_Direction.Size = new System.Drawing.Size(80, 20);
            this.cmb_A1_Direction.TabIndex = 49;
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(423, 292);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(95, 30);
            this.btn_Quit.TabIndex = 55;
            this.btn_Quit.Text = "End";
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(10, 130);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(155, 20);
            this.label18.TabIndex = 25;
            this.label18.Text = "Creep [unit/sec]";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(10, 110);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(155, 20);
            this.label14.TabIndex = 21;
            this.label14.Text = "Approach  [unit/sec]";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(10, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Positional data";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grp_A1_OB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdo_A1_C);
            this.groupBox1.Controls.Add(this.rdo_A1_INPUT_C);
            this.groupBox1.Controls.Add(this.btn_A1_Start);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_A1_Direction);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txt_A1_Approach);
            this.groupBox1.Controls.Add(this.txt_A1_Pos);
            this.groupBox1.Controls.Add(this.txt_A1_Vel);
            this.groupBox1.Controls.Add(this.txt_A1_Creep);
            this.groupBox1.Location = new System.Drawing.Point(13, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 235);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Axis 1";
            // 
            // txt_A1_Approach
            // 
            this.txt_A1_Approach.Location = new System.Drawing.Point(165, 110);
            this.txt_A1_Approach.Name = "txt_A1_Approach";
            this.txt_A1_Approach.Size = new System.Drawing.Size(80, 19);
            this.txt_A1_Approach.TabIndex = 60;
            this.txt_A1_Approach.Text = "10000";
            this.txt_A1_Approach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A1_Pos
            // 
            this.txt_A1_Pos.Location = new System.Drawing.Point(165, 90);
            this.txt_A1_Pos.Name = "txt_A1_Pos";
            this.txt_A1_Pos.Size = new System.Drawing.Size(80, 19);
            this.txt_A1_Pos.TabIndex = 58;
            this.txt_A1_Pos.Text = "10000";
            this.txt_A1_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A1_Vel
            // 
            this.txt_A1_Vel.Location = new System.Drawing.Point(165, 70);
            this.txt_A1_Vel.Name = "txt_A1_Vel";
            this.txt_A1_Vel.Size = new System.Drawing.Size(80, 19);
            this.txt_A1_Vel.TabIndex = 54;
            this.txt_A1_Vel.Text = "10000";
            this.txt_A1_Vel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_A1_Creep
            // 
            this.txt_A1_Creep.Location = new System.Drawing.Point(165, 130);
            this.txt_A1_Creep.Name = "txt_A1_Creep";
            this.txt_A1_Creep.Size = new System.Drawing.Size(80, 19);
            this.txt_A1_Creep.TabIndex = 59;
            this.txt_A1_Creep.Text = "10000";
            this.txt_A1_Creep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 334);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.spn_CpuNo);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "HomePosition Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grp_A2_OB.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grp_A1_OB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spn_CpuNo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdo_A2_C;
        private System.Windows.Forms.RadioButton rdo_A2_INPUT_C;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.GroupBox grp_A2_OB;
        private System.Windows.Forms.RadioButton rdo_A2_OBOFF;
        private System.Windows.Forms.RadioButton rdo_A2_OBON;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_A2_Start;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_A2_Direction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_A2_Approach;
        private System.Windows.Forms.TextBox txt_A2_Pos;
        private System.Windows.Forms.TextBox txt_A2_Vel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_A2_Creep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grp_A1_OB;
        private System.Windows.Forms.RadioButton rdo_A1_OBOFF;
        private System.Windows.Forms.RadioButton rdo_A1_OBON;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdo_A1_C;
        private System.Windows.Forms.RadioButton rdo_A1_INPUT_C;
        private System.Windows.Forms.NumericUpDown spn_CpuNo;
        private System.Windows.Forms.Button btn_A1_Start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_A1_Direction;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_A1_Approach;
        private System.Windows.Forms.TextBox txt_A1_Pos;
        private System.Windows.Forms.TextBox txt_A1_Vel;
        private System.Windows.Forms.TextBox txt_A1_Creep;
    }
}

