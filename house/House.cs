/*
 * This demo is property of vasily tserekh if you want more stuff like this you
 * can visit my blog at http://vasilydev.blogspot.com
 */
using System;
using System.Collections.Generic;
using System.Text;
using ShadowEngine;
using ShadowEngine.ContentLoading;
using Tao.OpenGl; 

namespace Casa
{
    public class House
    {
        ModelContainer m;
        Mesh aspa;
        Mesh frame;
        float anguloAspa; 

        public void Create()
        {
            m = ContentManager.GetModelByName("casa.3DS");
            m.CreateDisplayList();
            aspa = m.GetMeshWithName("ventilado0");
            frame = m.GetMeshWithName("magela");
            aspa.CalcCenterPoint(); // calculo el punto medio de objeto
            m.RemoveMeshByName("ventilado0"); //quita el mesh
            m.RemoveMeshByName("magela"); //quita el mesh

        }

        public void CreateCollisions()
        {
            Collision.AddCollisionSegment(new Vector2F(-24.4f, -14.1f), new Vector2F(18.9f, -14.1f), 0.8f);
            Collision.AddCollisionSegment(new Vector2F(-24.4f, -14.1f), new Vector2F(-24.4f, 13.2f), 0.8f);
            Collision.AddCollisionSegment(new Vector2F(-20.2f, -0.1f), new Vector2F(-4.8f, -0.1f), 0.8f);
            Collision.AddCollisionSegment(new Vector2F(-0.5f, 0.7f), new Vector2F(-0.5f, -8.7f), 0.8f);
            Collision.AddCollisionSegment(new Vector2F(19.4f, 14.4f), new Vector2F(-24.4f, 14.4f), 0.8f);
            Collision.AddCollisionSegment(new Vector2F(19.4f, 14.4f), new Vector2F(19.4f, -14.4f), 0.8f);
            Collision.AddCollisionSegment(new Vector2F(-17.5f, 0.5f), new Vector2F(-17.5f, 11), 0.8f);
            Collision.AddCollisionSegment(new Vector2F(13.4f, -0.15f), new Vector2F(18.74f, -0.15f), 0.8f);
            Collision.AddCollisionSegment(new Vector2F(-0.43f, -9.1f), new Vector2F(12.4f, -9.1f), 0.8f);
            //Collision.GhostMode = true;   
        }

        public void Draw()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(0, 2.3f, 0); 
            Gl.glScalef(0.1f, 0.1f, 0.1f); 
            m.DrawWithTextures();

            Gl.glPushAttrib(Gl.GL_POLYGON_BIT);
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); 
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName(frame.Name + ".jpg"));
            frame.Draw();
            Gl.glPopAttrib(); 

            Gl.glPushMatrix();
            anguloAspa += 40;
            if (anguloAspa > 3600)
            {
                anguloAspa = 0; 
            }
            Gl.glTranslatef(aspa.CenterPoint.X, aspa.CenterPoint.Y, aspa.CenterPoint.Z);
            Gl.glRotatef(-anguloAspa, 0, 0, 1);  
            Gl.glTranslatef(-aspa.CenterPoint.X, -aspa.CenterPoint.Y, -aspa.CenterPoint.Z);

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName(aspa.Name + ".jpg"));    
            aspa.Draw(); 
            Gl.glPopMatrix(); 

            Gl.glPopMatrix(); 
        }
    }
}
