﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using minsvepare.Properties;

namespace minsvepare
{
    public partial class NewGame : Form
    {
        public NewGame()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(Math.Round(numericWidth.Value, 0));
            int height = Convert.ToInt32(Math.Round(numericHeight.Value, 0));
            int mines = Convert.ToInt32(Math.Round(numericMines.Value, 0));

            Settings.Default.Width = width;
            Settings.Default.Height = height;
            Settings.Default.Mines = mines;

            if(mines >= width * height)
            {
                MessageBox.Show("Too many mines!");
                return;
            }

            Settings.Default.Save();

            Form1 f1 = new Form1();
            
            this.Hide();
            f1.ShowDialog();
            this.Close();
            
        }
    }
}
