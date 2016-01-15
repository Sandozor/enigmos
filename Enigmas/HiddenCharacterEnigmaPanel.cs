﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class HiddenCharacterEnigmalPanel : EnigmaPanel
    {
        //Déclaration des variables
        private GraphicsPath P, P1, P2, P3;
        int iLastX, iLastY;

        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public HiddenCharacterEnigmalPanel()
        {
            Label lblHC = new Label();
            lblHC.Text = "CPLN";
            lblHC.Font = new Font(FontFamily.GenericSerif, 30, FontStyle.Bold);
            lblHC.ForeColor = Color.White;
            lblHC.BackColor = Color.Transparent;
            lblHC.Location = new Point(600, 400);
            lblHC.Size = TextRenderer.MeasureText(lblHC.Text, lblHC.Font);
            lblHC.MouseMove += new MouseEventHandler(MoveMouse);
            Controls.Add(lblHC);

            //Création d'évènements
            this.MouseMove += new MouseEventHandler(MoveMouse);      //Lors d'un mouvement de la souris
            this.MouseEnter += new EventHandler(EnterPanel);    //Lors de l'entrée de la souris dans le panel 
            this.Paint += new PaintEventHandler(PaintBlue);     //Peindre les chemins graphiques

            DoubleBuffered = true;  //Elimination du scintillement
        }

        public override void Load()
        {
            P = new GraphicsPath();
            P1 = new GraphicsPath();
            P2 = new GraphicsPath();
            P3 = new GraphicsPath();
        }

        private void EnterPanel(object sender, EventArgs e)
        {
            //Valeurs de départ du positionnement de la souris
            iLastX = PointToClient(MousePosition).X;
            iLastY = PointToClient(MousePosition).Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveMouse(object sender, EventArgs e)
        {
            //Valeurs du positionnement de la souris
            int iX = PointToClient(MousePosition).X;
            int iY = PointToClient(MousePosition).Y;

            int iDiff = 15; //Taille des lignes graphiques

            //Création des chemins (lignes) graphiques
            P.AddLine(iLastX - iDiff, iLastY - iDiff, iX + iDiff, iY + iDiff);
            P1.AddLine(iLastX + iDiff, iLastY + iDiff, iX - iDiff, iY - iDiff);
            P2.AddLine(iLastX - iDiff, iLastY - iDiff, iX - iDiff, iY - iDiff);
            P3.AddLine(iLastX + iDiff, iLastY + iDiff, iX + iDiff, iY + iDiff);

            //Dernières valeurs du positionnement de la souris
            iLastX = iX;
            iLastY = iY;

            Invalidate(); //Mise à jour des chemins graphiques
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaintBlue(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Dessiner les chemins graphiques
            g.DrawPath(new Pen(Color.Blue), P);
            g.DrawPath(new Pen(Color.Blue), P1);
            g.DrawPath(new Pen(Color.Blue), P2);
            g.DrawPath(new Pen(Color.Blue), P3);

            g.Flush(); //Forçage de l'éxecution
        }
    }
}