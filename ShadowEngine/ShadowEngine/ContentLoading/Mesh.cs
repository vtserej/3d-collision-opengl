using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;

namespace ShadowEngine.ContentLoading
{
    public class Mesh
    {
        #region Private Attributes

        string name;
        int textureName;
        int displayList;
        Vector3 centerPoint;
        Material mat;
        Face[] faces;
        string textureDir = "";
        float[] localMatrix = new float[16];
        bool hasTranslation;

        #endregion

        #region Properties

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int TextureName
        {
            get { return textureName; }
            set { textureName = value; }
        }

        public int DisplayList
        {
            get { return displayList; }
        }

        public Vector3 CenterPoint
        {
            get { return centerPoint; }
            set { centerPoint = value; }
        }

        public Face[] Faces
        {
            get { return faces; }
            set { faces = value; }
        }

        public Material Mat
        {
            get { return mat; }
            set { mat = value; }
        }

        public string TextureDir
        {
            get { return textureDir; }
            set { textureDir = value; }
        }

        #endregion

        public void SetMatrix(Matrix Local)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    localMatrix[(i * 4) + j] = Local.Values[i, j];
                    if (Local.Values[i, j] != 0)
                        hasTranslation = true;
                }
            }
        }

        /// <summary>
        /// This function loads the mesh into an openGL display list
        /// </summary>
        public void Optimize()
        {
            Gl.glPushMatrix();
            displayList = Gl.glGenLists(1);

            Gl.glNewList(displayList, Gl.GL_COMPILE);

            this.Draw();
            Gl.glEndList();
            Gl.glPopMatrix();
        }

        /// <summary>
        /// This function calls the display list
        /// </summary>
        public void DrawOptimized()
        {
            if (mat.name == "notnull")
            {
                float[] ambientLightPosition = { 1000, 1000, 1000, 1.0F };
                float[] materialShininess = { 128F };
                float[] lightAmbient = { 0.8F, 0.8F, 0.8F, 1.0F };

                //Gl.glEnable(Gl.GL_COLOR_MATERIAL);

                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, mat.ambientf);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mat.diffusef);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, mat.specularf);

                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, materialShininess);
                Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, ambientLightPosition);
                Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, lightAmbient);
                Gl.glShadeModel(Gl.GL_SMOOTH);


                Gl.glEnable(Gl.GL_LIGHTING);
                Gl.glEnable(Gl.GL_LIGHT0);


                //Gl.glColor3b(mat.ambient[0], mat.ambient[1], mat.ambient[2]);
            }
            //if (hasTranslation)
            //{

            Gl.glPushMatrix();
            //Gl.glMultMatrixf(localMatrix);
            //Gl.glTranslatef(-localMatrix[13], -localMatrix[14], -localMatrix[15]);
          
            Gl.glCallList(displayList);
            Gl.glPopMatrix();
            //}
        }

        public void CalcCenterPoint()
        {
            float xMiddle = 0, yMiddle = 0, zMiddle = 0;
            foreach (Face item in faces)
            {
                for (int i = 0; i < 3; i++)
                {
                    xMiddle += item.vertex[i].x;
                    yMiddle += item.vertex[i].y;
                    zMiddle += item.vertex[i].z;
                }
            }
            float count = faces.Length * 3;
            xMiddle /= count;
            yMiddle /= count;
            zMiddle /= count;

            this.centerPoint = new Vector3(xMiddle, yMiddle, zMiddle);
        }

        /// <summary>
        /// This function overrides equality operator
        /// </summary>
        public override bool Equals(object obj)
        {
            if (((Mesh)obj).name == name)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This function draws the list of faces of the mesh
        /// </summary>
        public void Draw()
        {
            Gl.glBegin(Gl.GL_TRIANGLES);
            for (int i = 0; i < faces.Length; i++)
            {
                //draw the three points with their texture coordinates
                for (int j = 0; j < 3; j++)
                {
                    Gl.glNormal3f(faces[i].normal[j].X, faces[i].normal[j].Y, faces[i].normal[j].Z);
                    Gl.glTexCoord2f(faces[i].vertex[j].v, faces[i].vertex[j].u);
                    Gl.glVertex3f(faces[i].vertex[j].x, faces[i].vertex[j].y, faces[i].vertex[j].z);
                }
            }
            Gl.glEnd();
        }
    }
}
