using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShadowEngine;
using ShadowEngine.OpenGL; 
using Tao.OpenGl;
using ShadowEngine.Sound; 

namespace Casa
{
    public partial class MainForm : Form
    {
        //handle del viewport
        uint hdc;
        Controller controladora = new Controller();
        int moviendo;
        static Vector2 formPos;
        bool lineas;

        public static Vector2 FormPos
        {
            get { return MainForm.formPos; }
            set { MainForm.formPos = value; }
        }

        public MainForm()
        {
            InitializeComponent();
            hdc = (uint)pnlViewPort.Handle;
            string error = "";
            OpenGLControl.OpenGLInit(ref hdc, pnlViewPort.Width, pnlViewPort.Height, ref error);

            if (error != "")
            {
                MessageBox.Show(error);
            }
            controladora.Camara.InitCamara();
            //lights
            Lighting.SetupLighting();  
            ContentManager.SetTextureList("texturas\\"); //specify texture location
            ContentManager.LoadTextures(); //load it
            ContentManager.SetModelList("modelo\\"); // specify model location
            ContentManager.LoadModels(); //load it   
            AudioPlayback.SoundDir = "sonidos\\";
  
            Camera.CenterMouse();
            controladora.CrearObjetos();  
        }

        private void tmrPaint_Tick(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            controladora.Camara.Update(moviendo);   
            controladora.DrawScene();
            Winapi.SwapBuffers(hdc);
            Gl.glFlush();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            formPos = new Vector2(this.Left, this.Top);   
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close(); 
            }
            if (e.KeyCode == Keys.W)
            {
                 moviendo = 1;
            }

            if (e.KeyCode == Keys.L)
            {
                if (lineas)
                {
                    Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); 
                    lineas = false;
                }
                else
                {
                    Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE); 
                    lineas = true; 
                }
            }
        }

        private void pnlViewPort_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moviendo = 1;  
            }
            if (e.Button == MouseButtons.Right)
            {
                moviendo = -1;
            }
        }

        private void pnlViewPort_MouseUp(object sender, MouseEventArgs e)
        {
            moviendo = 0;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            moviendo = 0;
        }
    }
}
