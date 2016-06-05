using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;

namespace ShadowEngine.ContentLoading
{
    public class ModelContainer : Model
    {
        string fileName;
        Vector3 centerPoint;

        #region Properties

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public string FileName
        {
            get { return fileName; }
        }

        public List<Mesh> GetMeshes
        {
            get { return base.meshes; }
        }

        public Vector3 CenterPoint
        {
            get { return centerPoint; }
            set { centerPoint = value; }
        }

        #endregion

        public ModelContainer(List<Mesh> meshes, string fileName)
        {
            base.meshes = meshes;
            this.fileName = fileName;
        }

        public void CalcCenterPoint()
        {
            List<Vector3> points = new List<Vector3>();

            foreach (var item in base.meshes)
            {
                if (item.Faces.Length != 0)
                {
                    item.CalcCenterPoint();
                    points.Add(item.CenterPoint);
                }
               
            }
            float xMiddle = 0, yMiddle = 0, zMiddle = 0;

            foreach (var item in points)
            {           
                xMiddle += item.X;
                yMiddle += item.Y;
                zMiddle += item.Z;
            }
            xMiddle /= points.Count;
            yMiddle /= points.Count;
            zMiddle /= points.Count;

            this.CenterPoint = new Vector3(xMiddle, yMiddle, zMiddle);
        }

        public float CalculateBoundingSphere()
        {
            float bigger = 0;

            foreach (var item in base.meshes)
            {
                float distance = centerPoint.DistanceTo(item.CenterPoint);

                if (distance > bigger)
                    bigger = distance; 

            }
            return bigger; 
        }

        public void RemoveMeshesWithName(string name)
        {
            for (int i = 0; i < meshes.Count; i++)
            {
                if (meshes[i].Name.Contains(name))
                {
                    meshes.RemoveAt(i);
                    i--;
                }
            }
        }

        public void RemoveMeshByName(string name)
        {
            for (int i = 0; i < meshes.Count; i++)
            {
                if (meshes[i].Name == name)
                {
                    meshes.RemoveAt(i);
                    i--;
                }
            }
        }

        public Mesh GetMeshWithName(string name)
        {
            foreach (var item in meshes)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

        public void CreateDisplayList()
        {
            foreach (var item in meshes)
            {
                item.Optimize();
            }
        }

        public void DrawWithTextures()
        {
            foreach (var item in meshes)
            {
                Gl.glEnable(Gl.GL_TEXTURE_2D);

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName(item.Name + ".jpg"));

                item.DrawOptimized();
            }
        }

        public void Draw()
        {
            foreach (var item in meshes)
            {
                item.Draw();
            }
        }

        public void DrawDisplayList()
        {
            Gl.glPushMatrix();
            Gl.glScalef(scale, scale, scale);
            foreach (var item in meshes)
            {
                item.DrawOptimized();
            }
            Gl.glPopMatrix();
        }
    }
}
