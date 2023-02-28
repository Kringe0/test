// Decompiled with JetBrains decompiler
// Type: HWID_TRAINER_DEMET.Form2
// Assembly: วีรชนรัน, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BD37BE47-05E9-40BA-9DC6-0FE501AB2AB8
// Assembly location: C:\HeroicRanEpisode7\วีรชนรัน.exe

using Memory;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace HWID_TRAINER_DEMET
{
  public class Form2 : Form
  {
    public Mem m = new Mem();
    private bool drag;
    private Point start_point;
    private KeyHelper kh = new KeyHelper();
    private bool ctrl;
    private bool shift;
    private bool alt;
    private bool isRunning = true;
    private bool on = true;
    private bool ProcOpen = false;
    private IContainer components = (IContainer) null;
    private BackgroundWorker BGWorker;
    private Label OpenLabel;
    private Button button2;
    private Button button1;
    private GroupBox groupBox1;
    private Button button4;
    private Button button6;
    private GroupBox groupBox4;
    private TextBox attackspeed;
    private Button button10;
    private GroupBox groupBox5;
    private TextBox lr;
    private Button button3;
    private GroupBox groupBox8;
    private Button button7;
    private Button button9;
    private Label libil;
    private Label label1;
    private GroupBox groupBox3;
    private Label label3;
    private Label label2;
    private LinkLabel linkLabel1;
    private GroupBox groupBox10;
    private ComboBox comboBox2;
    private GroupBox groupBox11;
    private Button button14;
    private Button button15;
    private GroupBox groupBox12;
    private Button button16;
    private Button button17;
    private GroupBox groupBox9;
    private Button button18;
    private Panel panel1;
    private GroupBox groupBox2;
    private Button button5;
    private Button button8;
    private System.Windows.Forms.Timer timer1;
    private GroupBox groupBox13;
    private ComboBox comboBox1;
    private GroupBox groupBox7;
    private Button button11;
    private Button button12;
    private GroupBox groupBox6;
    private Button button13;
    private GroupBox groupBox14;
    private Button button19;
        private GroupBox groupBox16;
        private Button button23;
        private Button button24;
        private GroupBox groupBox15;
        private Button button21;
        private Button button22;
        private LinkLabel linkLabel2;
        private Label label4;
        private Button button20;
        private GroupBox groupBox17;
        private string hwid;
        public Form2() => this.InitializeComponent();

    private void Form2_Load(object sender, EventArgs e)
    {
      this.hwid = WindowsIdentity.GetCurrent().User.Value;
      this.label4.Text = this.hwid;
      this.KeyPreview = true;
      Control.CheckForIllegalCrossThreadCalls = false;
      Thread thread = new Thread(new ThreadStart(this.keyboardd));
      thread.SetApartmentState(ApartmentState.STA);
      thread.Start();
      this.timer1.Start();
      this.timer1.Enabled = true;
    }

    private void keyboardd()
    {
      while (this.isRunning)
      {
        Thread.Sleep(1);
        if ((Keyboard.GetKeyStates(Key.LeftCtrl) & KeyStates.Down) > KeyStates.None)
        {
          this.m.WriteMemory("0076E75C", "bytes", "0", "", (Encoding)null);
         // this.m.WriteMemory("0076BCDB", "bytes", "41", "", (Encoding)null);
          this.libil.ForeColor = Color.LightGreen;
          this.libil.Text = "ON";
          this.on = false;
          Thread.Sleep(10);
        }
        else
        {
          this.m.WriteMemory("0076E75C", "bytes", "97", "", (Encoding)null);
          //this.m.WriteMemory("0076BCDB", "bytes", "48", "", (Encoding)null);
          this.libil.ForeColor = Color.Red;
          this.libil.Text = "OFF";
          this.on = true;
          Thread.Sleep(10);
        }
      }
    }

    private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      this.ProcOpen = this.m.OpenProcess("MiniA");
      if (!this.ProcOpen)
      {
        Thread.Sleep(1000);
      }
      else
      {
        this.m.WriteMemory("", "bytes", "10 00 fd", "", (Encoding) null);
        this.m.WriteMemory("", "bytes", "10 00 fd", "", (Encoding) null);
        this.m.WriteMemory("", "bytes", "10 00 fd", "", (Encoding) null);
        this.m.WriteMemory("", "bytes", "10 00 fd", "", (Encoding) null);
        this.m.WriteMemory("", "bytes", "10 00 fd", "", (Encoding) null);
        this.m.WriteMemory("", "bytes", "10 00 fd", "", (Encoding) null);
        this.m.WriteMemory("", "bytes", "10 00 fd", "", (Encoding) null);
        this.m.WriteMemory("", "bytes", "10 00 fd", "", (Encoding) null);
        this.m.WriteMemory("", "bytes", "10 00 fd", "", (Encoding) null);
        this.m.WriteMemory("", "bytes", "10 00 fd", "", (Encoding) null);
        this.m.WriteMemory("", "bytes", "00 00 fd", "", (Encoding) null);
        Thread.Sleep(1000);
        this.BGWorker.ReportProgress(0);
      }
    }

    private void Form2_Shown(object sender, EventArgs e) => this.BGWorker.RunWorkerAsync();

    private void BGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      if (this.ProcOpen)
      {
        this.OpenLabel.ForeColor = Color.LightGreen;
        this.OpenLabel.Text = "Game Connected";
      }
      else
      {
        this.OpenLabel.ForeColor = Color.Red;
        this.OpenLabel.Text = "Not Connected";
      }
    }

    private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => this.BGWorker.RunWorkerAsync();

    private void button2_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Are you sure you want to Close?", "Exit Application", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
            //Application.Exit();
            System.Environment.Exit(1);
        }

    private void button1_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

    private void Form2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
      this.drag = true;
      this.start_point = new Point(e.X, e.Y);
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://www.fuq.com/");

    private void button8_Click(object sender, EventArgs e)
    {
    }

    private void button5_Click(object sender, EventArgs e)
    {
    }

    private void APON_Click(object sender, EventArgs e)
    {
    }

    private void APOFF_Click(object sender, EventArgs e)
    {
    }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.ForeColor = Color.Lime;
            button4.ForeColor = Color.Aqua;
            this.m.WriteMemory("0071B9A0", "float", "0", "", (Encoding)null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.ForeColor = Color.Lime;
            button6.ForeColor = Color.Aqua;
            this.m.WriteMemory("0071B9A0", "float", "10", "", (Encoding)null);
        }

    private void button9_Click(object sender, EventArgs e) => this.m.WriteMemory("004BA100", "bytes", "d8", "", (Encoding) null);

    private void button7_Click(object sender, EventArgs e) => this.m.WriteMemory("004BA100", "bytes", "d9", "", (Encoding) null);

    private void button12_Click(object sender, EventArgs e)
    {
    }

    private void button11_Click(object sender, EventArgs e)
    {
    }

    private void button10_Click(object sender, EventArgs e)
    {
            button10.ForeColor = Color.Lime;
            if (this.attackspeed.Text != "")
     this.m.FreezeValue("00FD0000", "float", this.attackspeed.Text, "");
    // this.m.FreezeValue("00FD0010", "float", this.attackspeed.Text, "");
     //this.m.FreezeValue("00FD0030", "float", this.attackspeed.Text, "");
    // this.m.WriteMemory("005ED901", "float", "-3.293102172E-29", "", (Encoding) null);
     //this.m.WriteMemory("005ED905", "float", "-107372640", "", (Encoding) null);
     this.m.WriteMemory("004EE3EC", "bytes", "00 00 FD", "", (Encoding) null);
      this.m.WriteMemory("004EE3F5", "bytes", "00 00 FD", "", (Encoding) null);
      this.m.WriteMemory("004EE170", "bytes", "00 00 FD", "", (Encoding) null);
      this.m.WriteMemory("004EDD3F", "bytes", "00 00 FD", "", (Encoding) null);
      this.m.WriteMemory("004EDAE1", "bytes", "00 00 FD", "", (Encoding) null);
      this.m.WriteMemory("004ED877", "bytes", "00 00 FD", "", (Encoding) null);
      this.m.WriteMemory("004ED466", "bytes", "00 00 FD", "", (Encoding) null);
     }

    private void attackspeed_TextChanged(object sender, EventArgs e)
    {
    }

    private void button3_Click(object sender, EventArgs e)
    {
            button3.ForeColor = Color.Lime;
            if (this.lr.Text != "")
                this.m.FreezeValue("00FF0000", "float", this.lr.Text, "");
            //this.m.WriteMemory("004E1096", "float", "-5.702071897E-29", "", (Encoding)null);
            //this.m.WriteMemory("004E1CBC", "float", "-1.271604525E15", "", (Encoding)null);
            this.m.WriteMemory("004E1F08", "bytes", "00 00 FF", "", (Encoding)null);
            this.m.WriteMemory("004E1CB8", "bytes", "90 90 90 90 90 90 90", "", (Encoding)null);
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            button9.ForeColor = Color.Lime;
            button7.ForeColor = Color.Aqua;
            this.m.FreezeValue("00D3406C", "float", "18000", "");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            button7.ForeColor = Color.Lime;
            button9.ForeColor = Color.Aqua;
            this.m.FreezeValue("00D3406C", "float", "38", "");
        }

    private void button13_Click(object sender, EventArgs e)
    {
    }

    private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://www.facebook.com/gaming/JutsuGamingzxc");

    private void groupBox5_Enter(object sender, EventArgs e)
    {
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboBox2.SelectedIndex == 0)
        this.m.WriteMemory("00D3402C", "bytes", "1A 00 00 00", "", (Encoding) null);
      else if (this.comboBox2.SelectedIndex == 1)
        this.m.WriteMemory("00D3402C", "bytes", "1A 00 01 00", "", (Encoding) null);
      else if (this.comboBox2.SelectedIndex == 2)
        this.m.WriteMemory("00D3402C", "bytes", "1A 00 02 00", "", (Encoding) null);
      else if (this.comboBox2.SelectedIndex == 3)
        this.m.WriteMemory("00D3402C", "bytes", "1A 00 03 00", "", (Encoding) null);
      else if (this.comboBox2.SelectedIndex == 4)
        this.m.WriteMemory("00D3402C", "bytes", "1A 00 04 00", "", (Encoding) null);
      else if (this.comboBox2.SelectedIndex == 5)
        this.m.WriteMemory("00D3402C", "bytes", "1A 00 05 00", "", (Encoding) null);
      else if (this.comboBox2.SelectedIndex == 6)
        this.m.WriteMemory("00D3402C", "bytes", "1A 00 06 00", "", (Encoding) null);
      else if (this.comboBox2.SelectedIndex == 7)
        this.m.WriteMemory("00D3402C", "bytes", "1A 00 07 00", "", (Encoding) null);
      else if (this.comboBox2.SelectedIndex == 8)
        this.m.WriteMemory("00D3402C", "bytes", "1A 00 08 00", "", (Encoding) null);
      else if (this.comboBox2.SelectedIndex == 9)
      {
        this.m.WriteMemory("00D3402C", "bytes", "1A 00 09 00", "", (Encoding) null);
      }
      else
      {
        if (this.comboBox2.SelectedIndex != 10)
          return;
        this.m.WriteMemory("00D3402C", "bytes", "1A 00 0a 00", "", (Encoding) null);
      }
    }

        private void button15_Click(object sender, EventArgs e)
        {
            button15.ForeColor = Color.Lime;
            button14.ForeColor = Color.Aqua;
            this.m.WriteMemory("00477454", "bytes", "EB", "", (Encoding)null);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button14.ForeColor = Color.Lime;
            button15.ForeColor = Color.Aqua;
            this.m.WriteMemory("00477454", "bytes", "74", "", (Encoding)null);
        }

    private void groupBox12_Enter(object sender, EventArgs e) => this.m.WriteMemory("", "bytes", "74", "", (Encoding) null);

        private void button16_Click(object sender, EventArgs e)
        {
            button16.ForeColor = Color.Lime;
            button17.ForeColor = Color.Aqua;
            this.m.WriteMemory("005CCF01", "bytes", "74", "", (Encoding)null);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            button17.ForeColor = Color.Lime;
            button16.ForeColor = Color.Aqua;
            this.m.WriteMemory("005CCF01", "bytes", "EB", "", (Encoding)null);
        }

    private void groupBox3_Enter(object sender, EventArgs e)
    {
    }

    private void button18_Click(object sender, EventArgs e)
    {
            button18.ForeColor = Color.Lime;
      this.m.FreezeValue("00B83725", "bytes", "0", "");
      this.m.FreezeValue("004A3812", "bytes", "0", "");
    }

    private void button13_Click_1(object sender, EventArgs e)
    {
    }

    private void libil_Click(object sender, EventArgs e)
    {
    }

    private void button20_Click(object sender, EventArgs e)
    {
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Random random = new Random();
      int alpha = random.Next(0, (int) byte.MaxValue);
      int red = random.Next(0, (int) byte.MaxValue);
      int green = random.Next(0, (int) byte.MaxValue);
      int blue = random.Next(0, (int) byte.MaxValue);
           // this.label4.ForeColor = Color.FromArgb(alpha, red, green, blue);
            this.OpenLabel.ForeColor = Color.FromArgb(alpha, red, green, blue);
      this.linkLabel1.ForeColor = Color.FromArgb(alpha, red, green, blue);
    }

    private void OpenLabel_Click(object sender, EventArgs e)
    {
    }

        private void button8_Click_1(object sender, EventArgs e)
        {
            button8.ForeColor = Color.Lime;
            button5.ForeColor = Color.Aqua;
            this.m.WriteMemory("007CD050", "bytes", "EB", "", (Encoding)null);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            button5.ForeColor = Color.Lime;
            button8.ForeColor = Color.Aqua;
            this.m.WriteMemory("007CD050", "bytes", "74", "", (Encoding)null);
        }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboBox1.SelectedIndex == 0)
        this.m.WriteMemory("00B837D8", "float", "0", "", (Encoding) null);
      else if (this.comboBox1.SelectedIndex == 1)
        this.m.FreezeValue("00B837D8", "float", "1", "");
      else if (this.comboBox1.SelectedIndex == 2)
        this.m.FreezeValue("00B837D8", "float", "2", "");
      else if (this.comboBox1.SelectedIndex == 3)
      {
        this.m.FreezeValue("00B837D8", "float", "3", "");
      }
      else
      {
        if (this.comboBox1.SelectedIndex != 4)
          return;
        this.m.FreezeValue("00B837D8", "float", "4", "");
      }
    }

    private void button12_Click_1(object sender, EventArgs e)
    {
       this.m.FreezeValue("02EA6178", "float", "9999", "");
       this.m.WriteMemory("02EA618C", "float", "300", "", (Encoding) null);
            button12.ForeColor = Color.Lime;
            button11.ForeColor = Color.Aqua;
    }

        private void button11_Click_1(object sender, EventArgs e)
    {
            this.m.FreezeValue("02EA6178", "float", "200", "");
            this.m.WriteMemory("02EA618C", "float", "80", "", (Encoding) null);
            button12.ForeColor = Color.Aqua;
            button11.ForeColor = Color.Lime;
    }

    private void button13_Click_2(object sender, EventArgs e)
    {
    }

        private void button13_Click_3(object sender, EventArgs e)
        {
            button13.ForeColor = Color.Lime;
            this.m.FreezeValue("00B83694", "bytes", "0", "");
        }

    private void button20_Click_1(object sender, EventArgs e)
        {
            button20.ForeColor = Color.Lime;
            button19.ForeColor = Color.Aqua;
            //this.m.FreezeValue("02E9F34C", "bytes", "3", "");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            button19.ForeColor = Color.Lime;
            button20.ForeColor = Color.Aqua;
            this.m.FreezeValue("", "bytes", "1", "");
        }

    private void Form2_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    {
      if (!this.drag)
        return;
      Point screen = this.PointToScreen(e.Location);
      this.Location = new Point(screen.X - this.start_point.X, screen.Y - this.start_point.Y);
    }

    private void Form2_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) => this.drag = false;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.OpenLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.attackspeed = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lr = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.libil = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button18 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BGWorker
            // 
            this.BGWorker.WorkerReportsProgress = true;
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGWorker_ProgressChanged);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            // 
            // OpenLabel
            // 
            this.OpenLabel.AutoSize = true;
            this.OpenLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OpenLabel.Location = new System.Drawing.Point(5, 4);
            this.OpenLabel.Name = "OpenLabel";
            this.OpenLabel.Size = new System.Drawing.Size(166, 16);
            this.OpenLabel.TabIndex = 30;
            this.OpenLabel.Text = "GAME NOT CONNECTED";
            this.OpenLabel.Click += new System.EventHandler(this.OpenLabel_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(217, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 20);
            this.button2.TabIndex = 32;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(202, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(14, 20);
            this.button1.TabIndex = 33;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox1.Location = new System.Drawing.Point(12, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(95, 44);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fast Tele";
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(50, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(38, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Off";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(6, 15);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(38, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "On";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.attackspeed);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox4.Location = new System.Drawing.Point(12, 53);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(95, 41);
            this.groupBox4.TabIndex = 56;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "AOE";
            // 
            // attackspeed
            // 
            this.attackspeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.attackspeed.Location = new System.Drawing.Point(3, 16);
            this.attackspeed.Name = "attackspeed";
            this.attackspeed.Size = new System.Drawing.Size(48, 20);
            this.attackspeed.TabIndex = 15;
            this.attackspeed.TextChanged += new System.EventHandler(this.attackspeed_TextChanged);
            // 
            // button10
            // 
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.ForeColor = System.Drawing.Color.Aqua;
            this.button10.Location = new System.Drawing.Point(57, 16);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(34, 21);
            this.button10.TabIndex = 14;
            this.button10.Text = "OK";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lr);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox5.Location = new System.Drawing.Point(128, 101);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(105, 41);
            this.groupBox5.TabIndex = 58;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Long-Range";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // lr
            // 
            this.lr.Cursor = System.Windows.Forms.Cursors.No;
            this.lr.Location = new System.Drawing.Point(3, 16);
            this.lr.Name = "lr";
            this.lr.Size = new System.Drawing.Size(56, 20);
            this.lr.TabIndex = 15;
            this.lr.Text = "DISABLED";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.No;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(67, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 21);
            this.button3.TabIndex = 14;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button7);
            this.groupBox8.Controls.Add(this.button9);
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox8.Location = new System.Drawing.Point(127, 204);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(106, 44);
            this.groupBox8.TabIndex = 59;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Pet Speed";
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.No;
            this.button7.Enabled = false;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(59, 15);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(38, 23);
            this.button7.TabIndex = 1;
            this.button7.Text = "Off";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // button9
            // 
            this.button9.Cursor = System.Windows.Forms.Cursors.No;
            this.button9.Enabled = false;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(13, 15);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(38, 23);
            this.button9.TabIndex = 0;
            this.button9.Text = "On";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // libil
            // 
            this.libil.AutoSize = true;
            this.libil.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libil.ForeColor = System.Drawing.Color.Crimson;
            this.libil.Location = new System.Drawing.Point(6, 15);
            this.libil.Name = "libil";
            this.libil.Size = new System.Drawing.Size(52, 24);
            this.libil.TabIndex = 0;
            this.libil.Text = "OFF";
            this.libil.Click += new System.EventHandler(this.libil_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.libil);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox3.Location = new System.Drawing.Point(12, 402);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(106, 57);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fast Revive Tw";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(41, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "To Activate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(55, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Hold Ctrl";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel1.Location = new System.Drawing.Point(24, 469);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(198, 20);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Follow Me on Facebook";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.comboBox2);
            this.groupBox10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox10.Location = new System.Drawing.Point(127, 154);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(106, 41);
            this.groupBox10.TabIndex = 62;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Pet Skill A";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.DarkGray;
            this.comboBox2.Cursor = System.Windows.Forms.Cursors.No;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Recovery HP",
            "Recovery HP+MP+SP",
            "Help Attack",
            "Help Defense",
            "Auto Use Potion",
            "Prevent Character Item",
            "Pickup All Items",
            "Pick up Rare Items",
            "Pick up Medicine Items",
            "Pick up Money",
            "Pick up Polishing items"});
            this.comboBox2.Location = new System.Drawing.Point(6, 14);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(86, 21);
            this.comboBox2.TabIndex = 52;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.button14);
            this.groupBox11.Controls.Add(this.button15);
            this.groupBox11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox11.Location = new System.Drawing.Point(12, 255);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(95, 44);
            this.groupBox11.TabIndex = 63;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Start Point";
            // 
            // button14
            // 
            this.button14.Cursor = System.Windows.Forms.Cursors.No;
            this.button14.Enabled = false;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Location = new System.Drawing.Point(50, 15);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(38, 23);
            this.button14.TabIndex = 1;
            this.button14.Text = "Off";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Cursor = System.Windows.Forms.Cursors.No;
            this.button15.Enabled = false;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Location = new System.Drawing.Point(6, 15);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(38, 23);
            this.button15.TabIndex = 0;
            this.button15.Text = "On";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.button16);
            this.groupBox12.Controls.Add(this.button17);
            this.groupBox12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox12.Location = new System.Drawing.Point(12, 205);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(95, 44);
            this.groupBox12.TabIndex = 64;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Name Display";
            this.groupBox12.Enter += new System.EventHandler(this.groupBox12_Enter);
            // 
            // button16
            // 
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Location = new System.Drawing.Point(50, 15);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(38, 23);
            this.button16.TabIndex = 1;
            this.button16.Text = "Off";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Location = new System.Drawing.Point(6, 15);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(38, 23);
            this.button17.TabIndex = 0;
            this.button17.Text = "On";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.button18);
            this.groupBox9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox9.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox9.Location = new System.Drawing.Point(12, 305);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(95, 44);
            this.groupBox9.TabIndex = 65;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Anti-Stun";
            // 
            // button18
            // 
            this.button18.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Location = new System.Drawing.Point(6, 15);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(82, 23);
            this.button18.TabIndex = 0;
            this.button18.Text = "Activate";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.groupBox17);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.groupBox16);
            this.panel1.Controls.Add(this.groupBox15);
            this.panel1.Controls.Add(this.groupBox14);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.groupBox13);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox8);
            this.panel1.Controls.Add(this.groupBox9);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox10);
            this.panel1.Controls.Add(this.groupBox12);
            this.panel1.Controls.Add(this.groupBox11);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 509);
            this.panel1.TabIndex = 66;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.label4);
            this.groupBox17.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox17.Location = new System.Drawing.Point(0, 3);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(241, 44);
            this.groupBox17.TabIndex = 77;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "HWID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(9, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 76;
            this.label4.Text = "label4";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel2.Location = new System.Drawing.Point(3, 491);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(17, 13);
            this.linkLabel2.TabIndex = 75;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Hi";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.button23);
            this.groupBox16.Controls.Add(this.button24);
            this.groupBox16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox16.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox16.Location = new System.Drawing.Point(128, 402);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(106, 44);
            this.groupBox16.TabIndex = 74;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "DD-mobs";
            // 
            // button23
            // 
            this.button23.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.Location = new System.Drawing.Point(59, 15);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(38, 23);
            this.button23.TabIndex = 1;
            this.button23.Text = "Off";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button24
            // 
            this.button24.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button24.Location = new System.Drawing.Point(13, 15);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(38, 23);
            this.button24.TabIndex = 0;
            this.button24.Text = "On";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.button21);
            this.groupBox15.Controls.Add(this.button22);
            this.groupBox15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox15.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox15.Location = new System.Drawing.Point(128, 352);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(106, 44);
            this.groupBox15.TabIndex = 73;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "DD-Player";
            // 
            // button21
            // 
            this.button21.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Location = new System.Drawing.Point(59, 15);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(38, 23);
            this.button21.TabIndex = 1;
            this.button21.Text = "Off";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button22
            // 
            this.button22.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.Location = new System.Drawing.Point(13, 15);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(38, 23);
            this.button22.TabIndex = 0;
            this.button22.Text = "On";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.button19);
            this.groupBox14.Controls.Add(this.button20);
            this.groupBox14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox14.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox14.Location = new System.Drawing.Point(128, 303);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(106, 44);
            this.groupBox14.TabIndex = 72;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Auto-Pots";
            // 
            // button19
            // 
            this.button19.Cursor = System.Windows.Forms.Cursors.No;
            this.button19.Enabled = false;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Location = new System.Drawing.Point(59, 15);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(38, 23);
            this.button19.TabIndex = 1;
            this.button19.Text = "Off";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Cursor = System.Windows.Forms.Cursors.No;
            this.button20.Enabled = false;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Location = new System.Drawing.Point(13, 15);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(38, 23);
            this.button20.TabIndex = 0;
            this.button20.Text = "On";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click_1);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button13);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox6.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox6.Location = new System.Drawing.Point(12, 355);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(95, 44);
            this.groupBox6.TabIndex = 71;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Anti-Pots";
            // 
            // button13
            // 
            this.button13.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Location = new System.Drawing.Point(6, 15);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(82, 23);
            this.button13.TabIndex = 0;
            this.button13.Text = "Activate";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click_3);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button11);
            this.groupBox7.Controls.Add(this.button12);
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox7.Location = new System.Drawing.Point(12, 102);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(95, 47);
            this.groupBox7.TabIndex = 70;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Drone";
            // 
            // button11
            // 
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(50, 15);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(38, 23);
            this.button11.TabIndex = 1;
            this.button11.Text = "Off";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click_1);
            // 
            // button12
            // 
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(6, 15);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(38, 23);
            this.button12.TabIndex = 0;
            this.button12.Text = "On";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click_1);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.comboBox1);
            this.groupBox13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox13.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox13.Location = new System.Drawing.Point(130, 53);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(103, 41);
            this.groupBox13.TabIndex = 69;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Attack Speed";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.DarkGray;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "LEVEL 1",
            "LEVEL 2 ",
            "LEVEL 3 ",
            "LEVEL 4",
            "LEVEL 5"});
            this.comboBox1.Location = new System.Drawing.Point(3, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 21);
            this.comboBox1.TabIndex = 53;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox2.Location = new System.Drawing.Point(127, 254);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(106, 44);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "No Chat Block";
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(59, 15);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(38, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "Off";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(13, 15);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(38, 23);
            this.button8.TabIndex = 0;
            this.button8.Text = "On";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(242, 533);
            this.Controls.Add(this.OpenLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Opacity = 0.8D;
            this.Text = "Google Chrome";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

        private void button22_Click(object sender, EventArgs e)
        {
            button22.ForeColor = Color.Lime;
            button21.ForeColor = Color.Aqua;
            this.m.WriteMemory("004EDE5E", "bytes", "0", "", (Encoding)null);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            button21.ForeColor = Color.Lime;
            button22.ForeColor = Color.Aqua;
            this.m.WriteMemory("004EDE5E", "bytes", "2", "", (Encoding)null);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            button24.ForeColor = Color.Lime;
            button23.ForeColor = Color.Aqua;
            this.m.WriteMemory("004EDD87", "bytes", "2", "", (Encoding)null);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            button23.ForeColor = Color.Lime;
            button24.ForeColor = Color.Aqua;
            this.m.WriteMemory("004EDD87", "bytes", "0", "", (Encoding)null);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           Process.Start("https://www.fuq.com/");
        }
    }
}
