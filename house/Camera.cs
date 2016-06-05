/*
 * This demo is property of vasily tserekh if you want more stuff like this you
 * can visit my blog at http://vasilydev.blogspot.com
 */
using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using System.Drawing;
using ShadowEngine; 

namespace Casa
{
    public class Camera
    {
        #region Camera constants
        const double div1 = Math.PI / 180;
        const double div2 = 180 / Math.PI;
        #endregion 
        
        #region Private atributes

        static float eyex, eyey, eyez;
        static float centerx, centery, centerz;
        static float forwardSpeed = 0.3f;
        static float yaw, pitch;
        static float rotationSpeed = 1/5f;
        static double i, j, k;

        #endregion

        public static float Pitch
        {
            get { return Camera.pitch; }
            set { Camera.pitch = value; }
        }

        public static float Yaw
        {
            get { return Camera.yaw; }
            set { Camera.yaw = value; }
        }

        public void InitCamara()
        {
            eyex = -17.1f;
            eyey = 7.3f;
            eyez = -9.4f;
            centerx = -3;
            centery = 2;
            centerz = -2; 
            Look();
        }

        public void Look()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(65, 1, 0.1f, 500);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(eyex, eyey, eyez, centerx, centery, centerz, 0, 1, 0);
        }

        static public float AngleToRad(double pAngle)
        {
            return (float)(pAngle * div1);
        }

        static public float RadToAngle(double pAngle)
        {
            return (float)(pAngle * div2);
        }

        public void UpdateDirVector()
        {
            k = Math.Cos(AngleToRad((double)yaw));
            i = -Math.Sin(AngleToRad((double)yaw));
            j = Math.Sin(AngleToRad((double)pitch));     
            
            
            centerz = eyez - (float)k;
            centerx = eyex - (float)i;
            centery = eyey - (float)j;
        }

        public static void CenterMouse()
        {
            Winapi.SetCursorPos(MainForm.FormPos.X + 512, MainForm.FormPos.Y + 384);   
        }

        public void Update(int pressedButton)
        {
            #region Camara de apuntar

                Pointer position = new Pointer();
                Winapi.GetCursorPos(ref position);   

                int difX = MainForm.FormPos.X + 512 - position.x;
                int difY = MainForm.FormPos.Y + 384 - position.y;

                if (position.y < MainForm.FormPos.Y + 384)
                {
                    pitch -= rotationSpeed * difY;
                }
                else
                    if (position.y > MainForm.FormPos.Y + 384)
                    {
                        pitch += rotationSpeed * -difY;
                    }
                if (position.x < MainForm.FormPos.X + 512)
                {
                    yaw += rotationSpeed * -difX;
                }
                else
                    if (position.x > MainForm.FormPos.X + 512)
                    {
                        yaw -= rotationSpeed * difX;
                    }
                UpdateDirVector();
                CenterMouse();


                if (pressedButton == 1) // left click pressed
                {
                    if (!Collision.CheckCollision(new Vector3(eyex - (float)i * forwardSpeed, eyez - (float)k * forwardSpeed, 0)))
                    {
                        eyex -= (float)i * forwardSpeed;
                        eyez -= (float)k * forwardSpeed;
                    }   
                }
                if (pressedButton == -1) // right click pressed
                {
                    if (!Collision.CheckCollision(new Vector3(eyex + (float)i * forwardSpeed, eyez + (float)k * forwardSpeed, 0)))
                    {
                        eyex += (float)i * forwardSpeed;
                        eyez += (float)k * forwardSpeed;
                    }
                }

            #endregion

            Look();  
        }
    }
}
