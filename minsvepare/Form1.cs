﻿using minsvepare.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace minsvepare
{
    public partial class Form1 : Form
    {

        public static Button[,] btn;

        public Random rand = new Random();

        public Field field;

        //Laddar in inställningar och skapar spelfält.
        public int width = Settings.Default.Width;
        public int height = Settings.Default.Height;
        public int mines = Settings.Default.Mines;

        public static int timer = 0;

        public Form1()
        {
            InitializeComponent();
            //Gör fönstret propotionellt mot rader och kollumner.
            this.Size = new Size(width * 40 + 115, height * 40 + 130);
        }

        private void Form1_Load(object send, EventArgs e)
        {
            field = new Field(width, height, mines);

            btn = new Button[field.cellVector.GetLength(0), field.cellVector.GetLength(1)];

            for (int x = 0; x < field.cellVector.GetLength(0); x++)
            {
                for (int y = 0; y < field.cellVector.GetLength(1); y++)
                {
                    btn[x, y] = new Button();

                    btn[x, y].Font = new Font("Arial", 18);
                    btn[x, y].Left = x * 40 + 50;
                    btn[x, y].Top = y * 40 + 50;
                    btn[x, y].Width = 40;
                    btn[x, y].Height = 40;
                    Controls.Add(btn[x, y]);

                    btn[x, y].MouseUp += (s, args) =>
                    {
                        Button btn = (Button)s;

                        if (args.Button == MouseButtons.Left)
                        {
                            if (field.gameOver)
                            {
                                return;
                            }

                            int c = (btn.Top - 50) / 40;
                            int r = (btn.Left - 50) / 40;

                            if (field.cellVector[r, c].flag)
                            {
                                return;
                            }

                            //Kolla rutan
                            if (r >= 0 && c >= 0)
                            {
                                field.CheckCell(r, c);
                            }
                        }
                        if (args.Button == MouseButtons.Right)
                        {
                            if (field.gameOver)
                            {
                                return;
                            }

                            //Ta reda på vilken rad och kollumn som har tryckts ned. Dela med knappstorleken för att få reda på vilken som är nedtryckt. 
                            //X = Rad, Y = Kollumn
                            int c = (btn.Top - 50) / 40;
                            int r = (btn.Left - 50) / 40;

                            if (field.cellVector[r, c].used)
                            {
                                return;
                            }

                            //Kolla rutan
                            if (r >= 0 && c >= 0)
                            {
                                field.FlagCell(r, c);
                            }
                        }
                    };
                    // btn[x, y].Click += B_Click;
                }
            }

        }


        //Händelsehanterare för knapptryckningar
        /*public void B_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Om spelet är över slutar vi ta input.
            if(field.gameOver)
            {
                return;
            }

            //Ta reda på vilken rad och kollumn som har tryckts ned. Dela med knappstorleken för att få reda på vilken som är nedtryckt. 
            //X = Rad, Y = Kollumn
            int y = (btn.Top - 50) / 40;
            int x = (btn.Left - 50) / 40;

            //Kolla rutan
            
           

            if(x >= 0 && y >= 0)
            {
                field.CheckCell(x, y);
            }
            
           
        }*/

        private void btnNewGame2_Click(object sender, EventArgs e)
        {
            NewGame Game = new NewGame();
            this.Hide();
            Game.ShowDialog();
            this.Close();
        }
    }
}
