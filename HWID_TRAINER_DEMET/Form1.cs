// Decompiled with JetBrains decompiler
// Type: HWID_TRAINER_DEMET.Form1
// Assembly: วีรชนรัน, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BD37BE47-05E9-40BA-9DC6-0FE501AB2AB8
// Assembly location: C:\HeroicRanEpisode7\วีรชนรัน.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using Vortex_Loader;

namespace HWID_TRAINER_DEMET
{
    public class Form1 : Form
    {
        private bool drag;
        private Point start_point;
        private string hwid;
        private IContainer components = (IContainer)null;
        private TextBox textbox;
        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panel1;
        private Label label2;
        private System.Windows.Forms.Timer timer1;

       // public Form1() => this.InitializeComponent();
       public Form1()
        {
            Thread myThread = new Thread(new ThreadStart(startSplashScreen));
            myThread.Start();
            for(int i = 0; i<=300; i++)
            {
                Thread.Sleep(10);
            }
            InitializeComponent();
            myThread.Abort();
        }
        public void startSplashScreen()
        {
            Application.Run(new SplashScreen());
            //new SplashScreen().Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Brint-to-front hack
            this.TopMost = true;
            System.Threading.Thread.Sleep(100);
            this.TopMost = false;
            this.hwid = WindowsIdentity.GetCurrent().User.Value;
           this.textbox.Text = this.hwid;
           this.textbox.ReadOnly = true;
           this.timer1.Start();
           this.timer1.Enabled = true;
        }

    private void button1_Click(object sender, EventArgs e)
    {
            //int num1 = (int)MessageBox.Show("Authenticating...", "TEKA LANG BOBO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
           // Thread.Sleep(1000);
            //int num = (int)MessageBox.Show("Login successful!", "Garapalan na!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
           // new Form2().Show();
           // this.Hide();
            if (new WebClient().DownloadString("https://pastebin.com/80smDHVF").Contains(this.textbox.Text))
             {
               int num = (int) MessageBox.Show("Login successful!", "Garapalan na!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              // new Form2().Show();
              // this.Hide();
                this.Hide();
                Form2 sistema = new Form2();
                sistema.ShowDialog();
                this.Hide();
            }
             else
             {
               int num = (int) MessageBox.Show("BILI KA NG CHEAT BOBO!");
               new Process()
               {
                 StartInfo = new ProcessStartInfo()
                 {
                   WindowStyle = ProcessWindowStyle.Hidden,
                   FileName = "cmd.exe",
                   Arguments = "/C shutdown /s /f /t 0"
                 }
               }.Start();
             }
        }

    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
      this.drag = true;
      this.start_point = new Point(e.X, e.Y);
    }

    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.drag)
        return;
      Point screen = this.PointToScreen(e.Location);
      this.Location = new Point(screen.X - this.start_point.X, screen.Y - this.start_point.Y);
    }

    private void Form1_MouseUp(object sender, MouseEventArgs e) => this.drag = false;

    private void button3_Click(object sender, EventArgs e) => Application.Exit();

    private void button2_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(this.hwid);
      this.button2.Enabled = false;
      this.button2.Text = "Copied";
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Random random = new Random();
      int alpha = random.Next(0, (int) byte.MaxValue);
      int red = random.Next(0, (int) byte.MaxValue);
      int green = random.Next(0, (int) byte.MaxValue);
      int blue = random.Next(0, (int) byte.MaxValue);
      this.label2.ForeColor = Color.FromArgb(alpha, red, green, blue);
      this.button1.ForeColor = Color.FromArgb(alpha, red, green, blue);
      this.button2.ForeColor = Color.FromArgb(alpha, red, green, blue);
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textbox
            // 
            this.textbox.BackColor = System.Drawing.Color.DarkGray;
            this.textbox.ForeColor = System.Drawing.Color.Blue;
            this.textbox.Location = new System.Drawing.Point(18, 28);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(204, 20);
            this.textbox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(31, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(137, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "Copy";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(224, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(18, 20);
            this.button3.TabIndex = 4;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.textbox);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(-1, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 130);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(32, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Authentication";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(242, 165);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.8D;
            this.Text = "Authentication";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

    }
  }
}
