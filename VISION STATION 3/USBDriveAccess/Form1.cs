//////////////////////////////////////////////////////////////////////////////////////////////////
// �{�T���v����MP3100��p�ɂȂ�܂��B
//
// MP3100�̃A���[���\����USB������������s���T���v���ł��B
// ���݂̃A���[�������L�������USB�������ڑ���Ԃ�\�����܂��B
// �܂��AMP3100���[�U�A�v���P�[�V������USB�������ւ̈ꊇ�ۑ��̎��s�A
// �����USB�����������o���\�ȏ�ԂɕύX���܂��B
//////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using MotionAPI;

namespace USBDriveAccess
{
	/// <summary>
	/// Form1 �̊T�v�̐����ł��B
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lbl_USBstatus;
		private System.Windows.Forms.Label lbl_Alarm;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.NumericUpDown spn_CpuNo;
		private System.Windows.Forms.Button btn_Open;
		private System.Windows.Forms.Button btn_Save;
		private System.Windows.Forms.Button btn_Eject;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		UInt32 g_hController;				// �R���g���[���n���h��
	    
		Image imgConnect;					// USB������������LED�C���[�W
		Image imgDisconnect;				// USB��������������LED�C���[�W

		public Form1()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent �Ăяo���̌�ɁA�R���X�g���N�^ �R�[�h��ǉ����Ă��������B
			//
		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.spn_CpuNo = new System.Windows.Forms.NumericUpDown();
            this.btn_Open = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Alarm = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Save = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_USBstatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Eject = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spn_CpuNo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "CPU No [ 1 - 4 ]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spn_CpuNo
            // 
            this.spn_CpuNo.Location = new System.Drawing.Point(145, 15);
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
            this.spn_CpuNo.TabIndex = 0;
            this.spn_CpuNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spn_CpuNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(215, 10);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(110, 30);
            this.btn_Open.TabIndex = 0;
            this.btn_Open.Text = "MotionAPI Open";
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(32, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Alarm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(167, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Application Data Controll";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(32, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "USB";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(15, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Connection Status";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(190, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "USB Operation";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_Alarm);
            this.panel1.Location = new System.Drawing.Point(15, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 70);
            this.panel1.TabIndex = 0;
            // 
            // lbl_Alarm
            // 
            this.lbl_Alarm.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Alarm.Location = new System.Drawing.Point(8, 8);
            this.lbl_Alarm.Name = "lbl_Alarm";
            this.lbl_Alarm.Size = new System.Drawing.Size(112, 52);
            this.lbl_Alarm.TabIndex = 0;
            this.lbl_Alarm.Text = "No Alarm";
            this.lbl_Alarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_Save);
            this.panel2.Location = new System.Drawing.Point(160, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 70);
            this.panel2.TabIndex = 0;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Save.Location = new System.Drawing.Point(24, 20);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(110, 30);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Save to USB Drive";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbl_USBstatus);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(15, 180);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(130, 70);
            this.panel3.TabIndex = 0;
            // 
            // lbl_USBstatus
            // 
            this.lbl_USBstatus.Location = new System.Drawing.Point(8, 53);
            this.lbl_USBstatus.Name = "lbl_USBstatus";
            this.lbl_USBstatus.Size = new System.Drawing.Size(112, 16);
            this.lbl_USBstatus.TabIndex = 0;
            this.lbl_USBstatus.Text = "disconnected";
            this.lbl_USBstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "USB";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(47, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btn_Eject);
            this.panel4.Location = new System.Drawing.Point(160, 180);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(160, 70);
            this.panel4.TabIndex = 0;
            // 
            // btn_Eject
            // 
            this.btn_Eject.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Eject.Location = new System.Drawing.Point(24, 20);
            this.btn_Eject.Name = "btn_Eject";
            this.btn_Eject.Size = new System.Drawing.Size(110, 30);
            this.btn_Eject.TabIndex = 0;
            this.btn_Eject.Text = "Eject USB Drive";
            this.btn_Eject.UseVisualStyleBackColor = false;
            this.btn_Eject.Click += new System.EventHandler(this.btn_Eject_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(342, 263);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.spn_CpuNo);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "USBDriveAccess Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spn_CpuNo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////
		//  Form1_Load
		//  ������
		//////////////////////////////////////////////////////////////////////////////////////////////////
		private void Form1_Load(object sender, System.EventArgs e)
		{
			String fileImgConnect = "IMAGE_CONNECT.bmp";		// USB������������LED�C���[�W�t�@�C����
			String fileImgDisconnect = "IMAGE_DISCONNECT.bmp";	// USB��������������LED�C���[�W�t�@�C����

			//============================================================================
			//�@�C���[�W�t�@�C���擾
			//============================================================================
			String path = System.Reflection.Assembly.GetEntryAssembly().Location;
			path = System.IO.Path.GetDirectoryName(path);
			imgConnect = System.Drawing.Image.FromFile(path + "\\" + fileImgConnect);
			imgDisconnect = System.Drawing.Image.FromFile(path + "\\" + fileImgDisconnect);
			pictureBox1.Image = imgDisconnect;

		}

		//////////////////////////////////////////////////////////////////////////////////////////////////
		//  Timer1_Tick
		//  ��������j�^
		//////////////////////////////////////////////////////////////////////////////////////////////////
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			UInt64 hReg_almCode = 0;				    // ���W�X�^�f�[�^�n���h��   ���ݔ����A���[���R�[�h
			UInt32 hReg_stsUSBMnt = 0;				    // ���W�X�^�f�[�^�n���h��	USB�����������X�e�[�^�X
			string cRegName_almCode = "SW16200";	    // ���W�X�^��				���ݔ����A���[���R�[�h
			string cRegName_stsUSBMnt = "SB6540";	    // ���W�X�^��				USB�����������X�e�[�^�X
			UInt32 RegisterDataNumber;				    // �Ǎ��݃��W�X�^��
			UInt16[] wData_almCode = new UInt16[1];		// ���W�X�^�f�[�^			���ݔ����A���[���R�[�h
			UInt16[] wData_stsUSBMnt= new UInt16[1];	// ���W�X�^�f�[�^�@�@�@		USB�����������X�e�[�^�X
			UInt32 ReadDataNumber = 0;				    // �Ǎ��݃��W�X�^���i�[�ϐ�
			UInt32 rc;								    // ���[�V����API�߂�l

			//============================================================================
			// ���W�X�^�f�[�^�n���h�����擾���܂��B
			// �擾�������W�X�^�ԍ��͑��X���b�h�ł��g�p�\�ł��B
			//============================================================================
			// extended SW register
			rc = CMotionAPI.ymcGetRegisterDataHandleEx(cRegName_almCode, ref hReg_almCode);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcGetRegisterDataHandleEx\nErrorCode [ 0x{0} ]", rc.ToString("X")));
				timer1.Enabled = false;
				return;
			}
			// SB register
			rc = CMotionAPI.ymcGetRegisterDataHandle(cRegName_stsUSBMnt, ref hReg_stsUSBMnt);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle\nErrorCode [ 0x{0} ]", rc.ToString("X")));
				timer1.Enabled = false;
				return;
			}

			//============================================================================
			// ���W�X�^����f�[�^��Ǎ��݉�ʂɕ\�����܂��B
			//============================================================================
			RegisterDataNumber = 1;
			// extended SW register
			rc = CMotionAPI.ymcGetRegisterDataEx(hReg_almCode, RegisterDataNumber, wData_almCode, ref ReadDataNumber);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcGetRegisterDataEx\nErrorCode [ 0x{0} ]", rc.ToString("X")));
				timer1.Enabled = false;
				return;
			}

			// SB register
			rc = CMotionAPI.ymcGetRegisterData(hReg_stsUSBMnt, RegisterDataNumber, wData_stsUSBMnt, ref ReadDataNumber);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcGetRegisterData\nErrorCode [ 0x{0} ]", rc.ToString("X")));
				timer1.Enabled = false;
				return;
			}

			if (wData_almCode[0] == 0)
			{
				lbl_Alarm.Text = "No Alarm";
				lbl_Alarm.ForeColor = SystemColors.ControlText;
			}
			else
			{
				lbl_Alarm.Text = "Alarm Code\n" + String.Format("{0:X4}", wData_almCode[0]);
				lbl_Alarm.ForeColor = Color.Red;
			}
			
			if (wData_stsUSBMnt[0] == 0)
			{
				pictureBox1.Image = imgDisconnect;
				lbl_USBstatus.Text = "disconnected";
			}
			else
			{
				pictureBox1.Image = imgConnect;
				lbl_USBstatus.Text = "connected";
			}

		}

		//////////////////////////////////////////////////////////////////////////////////////////////////
		//  btn_MotionAPI_Open
		//  ���[�V����API �I�[�v��
		//////////////////////////////////////////////////////////////////////////////////////////////////
		private void btn_Open_Click(object sender, System.EventArgs e)
		{
			CMotionAPI.COM_DEVICE ComDevice;	// ymcOpenController�ݒ�\����
			UInt32 rc;							// ���[�V����API�߂�l

			//============================================================================
			//�@��ʕ\������
			//============================================================================
			timer1.Enabled = false;
			lbl_Alarm.Text = "No Alarm";
			lbl_Alarm.ForeColor = SystemColors.ControlText;
			pictureBox1.Image = imgDisconnect;
			lbl_USBstatus.Text = "disconnected";
			this.Refresh();

			//============================================================================
			//�@ymcOpenController�̃p�����[�^��ݒ肵�܂��B		
			//============================================================================
			ComDevice.ComDeviceType = (UInt16)CMotionAPI.ApiDefs.COMDEVICETYPE_PCI_MODE;
			ComDevice.PortNumber    = 1;
			ComDevice.CpuNumber     = (UInt16)spn_CpuNo.Value;
			ComDevice.NetworkNumber = 0;
			ComDevice.StationNumber = 0;
			ComDevice.UnitNumber    = 0;
			ComDevice.IPAddress     = "";
			ComDevice.Timeout       = 10000;

			rc = CMotionAPI.ymcOpenController(ref ComDevice, ref g_hController);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcOpenController\nErrorCode [ 0x{0} ]", rc.ToString("X")));
				return;
			}

			//============================================================================
			//�@���[�V����API�̃^�C���A�E�g��ݒ肵�܂��B		
			//============================================================================
			rc = CMotionAPI.ymcSetAPITimeoutValue(30000);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcSetAPITimeoutValue\nErrorCode [ 0x{0} ]", rc.ToString("X")));
				return;
			}
	 	 
			// ��������j�^�J�n
			timer1.Enabled = true;
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////
		//  btn_Save_Click
		//  USB�������ւ̃A�v���P�[�V�����ꊇ�ۑ����s
		//////////////////////////////////////////////////////////////////////////////////////////////////
		private void btn_Save_Click(object sender, System.EventArgs e)
		{
			UInt32 hReg_stsUSBMnt = 0;                  // ���W�X�^�f�[�^�n���h��   USB�����������X�e�[�^�X     
			UInt32 hReg_stsUSBSv = 0;				    // ���W�X�^�f�[�^�n���h��   USB�������ꊇ�ۑ��X�e�[�^�X
			UInt32 hReg_reqUSBSv = 0;				    // ���W�X�^�f�[�^�n���h��	USB�������ꊇ�ۑ��v��
			string cRegName_stsUSBMnt = "SB6540";	    // ���W�X�^��				USB�����������X�e�[�^�X
			string cRegName_stsUSBSv = "SB6588";	    // ���W�X�^��				USB�������ꊇ�ۑ��X�e�[�^�X
			string cRegName_ReqUSBSv = "SB6681";	    // ���W�X�^��				USB�������ꊇ�ۑ��v��       
			UInt32 RegisterDataNumber;				    // �Ǎ��݃��W�X�^��
			UInt16[] wData_stsUSBMnt = new UInt16[1];	// �i�[�ϐ�					USB�����������X�e�[�^�X
			UInt16[] wData_stsUSBSv = new UInt16[1];	// �i�[�ϐ�					USB�ꊇ�ۑ��X�e�[�^�X
			UInt32 ReadDataNumber = 0;				    // �Ǎ��݃��W�X�^���i�[�ϐ�
			Int16[] RegisterData = new Int16[1];		// ���W�X�^�ݒ�l
			UInt32 rc;								    // ���[�V����API�߂�l
			bool bStsUSBSv;							    // USB�������ꊇ�ۑ��X�e�[�^�X�t���O

			//============================================================================
			// ���W�X�^�f�[�^�n���h�����擾���܂��B
			//============================================================================
			rc = CMotionAPI.ymcGetRegisterDataHandle(cRegName_stsUSBMnt, ref hReg_stsUSBMnt);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle\nErrorCode [ 0x{0}]", rc.ToString("X")));
				return;
			}
			rc = CMotionAPI.ymcGetRegisterDataHandle(cRegName_stsUSBSv, ref hReg_stsUSBSv);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle\nErrorCode [ 0x{0}]", rc.ToString("X")));
				return;
			}
			rc = CMotionAPI.ymcGetRegisterDataHandle(cRegName_ReqUSBSv, ref hReg_reqUSBSv);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle\nErrorCode [ 0x{0}]", rc.ToString("X")));
				return;
			}

			//============================================================================
			// ���W�X�^����f�[�^��Ǎ��݂܂��B
			//============================================================================
			RegisterDataNumber = 1;
			rc = CMotionAPI.ymcGetRegisterData(hReg_stsUSBMnt, RegisterDataNumber, wData_stsUSBMnt, ref ReadDataNumber);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcGetRegisterData\nErrorCode [ 0x{0}]", rc.ToString("X")));
				return;
			}

			// USB������������
			if (wData_stsUSBMnt[0] == 0)
			{
				return;
			}

			//============================================================================
			// ���W�X�^�Ƀf�[�^�������݂܂��B
			//============================================================================
			// USB�ꊇ�ۑ��v��ON
			RegisterData[0] = 1;
			rc = CMotionAPI.ymcSetRegisterData(hReg_reqUSBSv, RegisterDataNumber, RegisterData);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcSetRegisterData\nErrorCode [ 0x{0}]", rc.ToString("X")));
				return;
			}

			// �{�^���\���ؑւ�
			btn_Save.Text = "Application Data\nis Saving";
			btn_Save.BackColor = Color.Yellow;
			btn_Save.Enabled = false;
			this.Refresh();

			// 1�b�ԑҋ@
			rc = CMotionAPI.ymcWaitTime(1000, "");
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcWaitTime\nErrorCode [ 0x{0}]", rc.ToString("X")));
				return;
			}

			// USB�������ꊇ�ۑ��X�e�[�^�X�Ď�
			bStsUSBSv = true;
			while(bStsUSBSv)
			{
				rc = CMotionAPI.ymcGetRegisterData(hReg_stsUSBSv, RegisterDataNumber, wData_stsUSBSv, ref ReadDataNumber);
				if (rc != CMotionAPI.MP_SUCCESS)
				{
					MessageBox.Show(String.Format("Error ymcGetRegisterData\nErrorCode [ 0x{0}]", rc.ToString("X")));
					return;
				}
				
				bStsUSBSv = Convert.ToBoolean(wData_stsUSBSv[0]);
			}

			//============================================================================
			// ���W�X�^�Ƀf�[�^�������݂܂��B
			//============================================================================
			// USB�ꊇ�ۑ��v��OFF
			RegisterData[0] = 0;
			rc = CMotionAPI.ymcSetRegisterData(hReg_reqUSBSv, RegisterDataNumber, RegisterData);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcSetRegisterData\nErrorCode [ 0x{0}]", rc.ToString("X")));
				return;
			}

			// �{�^���\���ؑւ�
			btn_Save.Enabled = true;
			btn_Save.Text = "Save to USB";
			btn_Save.BackColor = SystemColors.Control;
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////
		//  btn_Eject_Click
		//  USB�������̎�o��
		//////////////////////////////////////////////////////////////////////////////////////////////////
		private void btn_Eject_Click(object sender, System.EventArgs e)
		{
			UInt32 hReg_stsUSBMnt = 0;				    // ���W�X�^�f�[�^�n���h��   USB�����������X�e�[�^�X
			UInt32 hReg_reqUSBEj = 0;				    // ���W�X�^�f�[�^�n���h��   USB��������o���v��    
			string cRegName_stsUSBMnt = "SB6540";	    // ���W�X�^��				USB�����������X�e�[�^�X
			string cRegName_reqUSBEj = "SB6680";	    // ���W�X�^��				USB��o���v��
			UInt32 RegisterDataNumber;				    // �Ǎ��݃��W�X�^��
			UInt16[] wData_stsUSBMnt = new UInt16[1];	// �i�[�ϐ�					USB�����������X�e�[�^�X
			UInt32 ReadDataNumber = 0;				    // �Ǎ��݃��W�X�^���i�[�ϐ�
			Int16[] RegisterData = new Int16[1];		// ���W�X�^�ݒ�l
			UInt32 rc;								    // ���[�V����API�߂�l
			bool bStsUSBMnt;						    // USB�����������X�e�[�^�X�t���O
		
		    //============================================================================
			// ���W�X�^�f�[�^�n���h�����擾���܂��B
			//============================================================================
			rc = CMotionAPI.ymcGetRegisterDataHandle(cRegName_stsUSBMnt, ref hReg_stsUSBMnt);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle\nErrorCode [ 0x{0}]", rc.ToString("X")));
				return;
			}
			rc = CMotionAPI.ymcGetRegisterDataHandle(cRegName_reqUSBEj, ref hReg_reqUSBEj);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle\nErrorCode [ 0x{0}]", rc.ToString("X")));
				return;
			}
		
			//============================================================================
			// ���W�X�^�Ƀf�[�^�������݂܂��B
			//============================================================================
			RegisterDataNumber = 1;
			// USB��o���v��ON
			RegisterData[0] = 1;
			rc = CMotionAPI.ymcSetRegisterData(hReg_reqUSBEj, RegisterDataNumber, RegisterData);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcSetRegisterData\nErrorCode [ 0x{0}]", rc.ToString("X")));
				return;
			}

			// USB�����������X�e�[�^�X�Ď�
			bStsUSBMnt = true;
			while(bStsUSBMnt)
			{
				rc = CMotionAPI.ymcGetRegisterData(hReg_stsUSBMnt, RegisterDataNumber, wData_stsUSBMnt, ref ReadDataNumber);
				if (rc != CMotionAPI.MP_SUCCESS)
				{
					MessageBox.Show(String.Format("Error ymcGetRegisterData\nErrorCode [ 0x{0}]", rc.ToString("X")));
					return;
				}

					bStsUSBMnt = Convert.ToBoolean(wData_stsUSBMnt[0]);
			}

			//============================================================================
			// ���W�X�^�Ƀf�[�^�������݂܂��B
			//============================================================================
			// USB��o���v��OFF
			RegisterData[0] = 0;
			rc = CMotionAPI.ymcSetRegisterData(hReg_reqUSBEj, RegisterDataNumber, RegisterData);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				MessageBox.Show(String.Format("Error ymcSetRegisterData\nErrorCode [ 0x{0}]", rc.ToString("X")));
				return;
			}

		}
	}
}
