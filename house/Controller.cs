/*
 * This demo is property of vasily tserekh if you want more stuff like this you
 * can visit my blog at http://vasilydev.blogspot.com
 */
using System;
using System.Collections.Generic;
using System.Text;
using ShadowEngine;


namespace Casa
{
    public class Controller
    { 
        Camera camara = new Camera();
        House house = new House();
        Exterior sky = new Exterior(); 

        public void CrearObjetos()
        {
            house.Create();
            house.CreateCollisions();  
            Sprite.Create();  //draw text on the screen
        }

        public Camera Camara
        {
            get { return camara; }
        }

        public void DrawScene()
        {    
            house.Draw();
            sky.Draw();  
            //DebugMode.WriteCamaraPos(200, 200);
            //Collision.DrawColissions();
        }
    }
}
