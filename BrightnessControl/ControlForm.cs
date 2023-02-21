using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;



namespace BrightnessControl
{
  public partial class ControlForm : Form
  {
    public Program program;
    double i = 0.1;
    public ControlForm()
    {
       InitializeComponent();
      
    }
  
    void UpdateBrightness()
    {
      float f = trackBarBrightness.Value * 0.01f;
      if (f < 0.5f)
      {
        program.screenForm.Opacity = 1 - 2 * f;
        program.screenForm.BackColor = Color.Black;
      }
      else
      {
        program.screenForm.Opacity = 2 * (f - 0.5f);
        program.screenForm.BackColor = Color.White;    
      }
    }
    private void brightnessBar_ValueChanged(object sender, EventArgs e)
    {
      UpdateBrightness();
    }

    private void ControlForm_FormClosed_1(object sender, FormClosedEventArgs e)
    {
      program.ExitThread();
    }

   

    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void btnMinimize_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    private void trackBarBrightness_Scroll(object sender, EventArgs e)
    {

    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start("https://nobodyshare77.glitch.me");
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
        this.Controls.Clear();
        this.InitializeComponent();
    }

    private void roundButton1_Click(object sender, EventArgs e)
    {
        Application.Restart();
    }

   
    private void ControlForm_Load(object sender, EventArgs e)
    {
        UpdateBrightness();
        this.Opacity = 0;
        timerFadeIn.Enabled = true;//Enable the timerFadeIn to start Fade In Effect
        timerFadeOut.Enabled = false;
        notifyIcon1.Visible = false;
    }

    private void timerFadeIn_Tick(object sender, EventArgs e)
    {
       
        i += 0.05;
        if (i >= 1)
        {//if form is fully visible, we execute the Fade Out Effect
            this.Opacity = 1;
            timerFadeIn.Enabled = false;//stop the Fade In Effect
            timerFadeOut.Enabled = true;//start the Fade Out Effect
            return;
        }
        this.Opacity = i;
    }

    private void timerFadeOut_Tick(object sender, EventArgs e)
    {

    }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        // private void MinimzedTray()
        //{
        // notifyIcon1.Visible = true;
        // notifyIcon1.BalloonTipText = "Minimized";
        // notifyIcon1.BalloonTipTitle = "Your Application is Running in BackGround";
        //  notifyIcon1.ShowBalloonTip(1000);

        // }

        //private void MaxmizedFromTray()
        // {
        //notifyIcon1.Visible = true;
        //notifyIcon1.BalloonTipText = "Maximized";
        //notifyIcon1.BalloonTipTitle = "Application is Running in Foreground";
        // notifyIcon1.ShowBalloonTip(1000);


        //}

        //private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        //{
        //this.WindowState = FormWindowState.Normal;
        //}
        //private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        //{
        //this.WindowState = FormWindowState.Normal;
        // notifyIcon1.BalloonTipText = "Normal";
        //notifyIcon1.ShowBalloonTip(1000);
        //}
        //private void ControlForm_Resize(object sender, EventArgs e)
        //{
        //if (FormWindowState.Minimized == this.WindowState)
        //{
        //MinimzedTray();
        //}
        //else if (FormWindowState.Normal == this.WindowState)
        //{

        //MaxmizedFromTray();
        //}
        //}




    }

     
}
