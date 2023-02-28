using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace HWID_TRAINER_DEMET
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // metroProgressBar1.Increment(5);
           // if (progressBar1.Value == 100)
             //   timer1.Stop();
            if (metroProgressBar1.Value == 100)
            timer1.Stop();

        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
        }
    }
}
