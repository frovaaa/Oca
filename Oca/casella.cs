﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oca
{
    public class casella : PictureBox
    {
        private Size dimensioni = new Size(100, 100);
        private int numeroCasella = 0;
        private int tipoCasella = 0;  //-1 -> Indietro | 0 -> Normale | 1 -> Avanza
        private int distanzaMovimento = 0;
        private Point posizione = new Point(400, 400);

        public casella(int nDistanza, int nCasella)
        {
            distanzaMovimento = nDistanza;
            //Imposto il tipo di casella per riconoscerla in futuro
            if (distanzaMovimento < 0) tipoCasella = -1;
            else if (distanzaMovimento > 0) tipoCasella = -1;
            else tipoCasella = 0;

            numeroCasella = nCasella;

            BorderStyle = BorderStyle.FixedSingle;
            Location = posizione;   //Imposto la posizione
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = dimensioni;      //Imposto la dimensione della picturebox
            BackColor = Color.FromArgb(255, 186, 73, 255);

            Paint += new PaintEventHandler(Picturebox_Paint);
            Click += onClick;
        }

        private void Picturebox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Font drawFont = new Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel);
            SizeF textSize = e.Graphics.MeasureString(Convert.ToString(numeroCasella), drawFont);
            PointF locationToDraw = new PointF();
            locationToDraw.X = (Width / 2) - (textSize.Width / 2);
            locationToDraw.Y = (Height / 2) - (textSize.Height / 2);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString(Convert.ToString(numeroCasella), drawFont, drawBrush, locationToDraw);
        }

        public void CambiaTesto(string testo)
        {
            Invalidate();
        }

        private void onClick(object sender, EventArgs e)
        {
            Random rand = new Random();
            numeroCasella = rand.Next(1, 51);
            Invalidate();
        }
    }
}