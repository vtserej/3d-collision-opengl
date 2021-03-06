﻿/*
 * This demo is property of vasily tserekh if you want more stuff like this you
 * can visit my blog at http://vasilydev.blogspot.com
 */
using System;
using System.Collections.Generic;
using System.Text;
using ShadowEngine;
using Tao.OpenGl;

namespace Casa
{
    class Exterior
    {
        public void Draw()
        {
            //tamaño altura y longitud
            int width = 240;
            int height = 200;
            int length = 240;

            //empieze en estas coordenadas
            int x = 10;
            int y = -3;
            int z = 7;

            //encentrar el cuadrado
            x = x - width / 2;
            y = y - height / 2;
            z = z - length / 2;

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName("back.jpg"));

            //empieza a dibujar cuadrados
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3d(-1, 1, 1);
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3d(x + width, y, z);
            Gl.glNormal3d(-1, -1, 1);
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3d(x + width, y + height, z);
            Gl.glNormal3d(1, -1, 1);
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3d(x, y + height, z);
            Gl.glNormal3d(1, 1, 1);
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3d(x, y, z);
            Gl.glEnd();

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName("front.jpg"));
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3d(1, 1, -1);
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3d(x, y, z + length);
            Gl.glNormal3d(1, -1, -1);
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3d(x, y + height, z + length);
            Gl.glNormal3d(-1, -1, -1);
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3d(x + width, y + height, z + length);
            Gl.glNormal3d(-1, 1, -1);
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3d(x + width, y, z + length);
            Gl.glEnd();

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName("top.jpg"));
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3d(-1, -1, 1);
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3d(x + width, y + height, z);
            Gl.glNormal3d(-1, -1, -1);
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3d(x + width, y + height, z + length);
            Gl.glNormal3d(1, -1, -1);
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3d(x, y + height, z + length);
            Gl.glNormal3d(1, -1, 1);
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3d(x, y + height, z);
            Gl.glEnd();

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName("left.jpg"));
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3d(1, -1, 1);
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3d(x, y + height, z);
            Gl.glNormal3d(1, -1, -1);
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3d(x, y + height, z + length);
            Gl.glNormal3d(1, 1, -1);
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3d(x, y, z + length);
            Gl.glNormal3d(1, 1, 1);
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3d(x, y, z);
            Gl.glEnd();

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName("right.jpg"));
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3d(-1, 1, 1);
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3d(x + width, y, z);
            Gl.glNormal3d(-1, 1, -1);
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3d(x + width, y, z + length);
            Gl.glNormal3d(-1, -1, -1);
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3d(x + width, y + height, z + length);
            Gl.glNormal3d(-1, -1, 1);
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3d(x + width, y + height, z);
            Gl.glEnd();

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName("GRASS2.JPG"));
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3d(1, 1, 1);
            Gl.glTexCoord2f(8.0f, 0.0f); Gl.glVertex3d(x, 1, z);
            Gl.glNormal3d(1, 1, -1);
            Gl.glTexCoord2f(8.0f, 8.0f); Gl.glVertex3d(x, 1, z + length);
            Gl.glNormal3d(-1, 1, -1);
            Gl.glTexCoord2f(0.0f, 8.0f); Gl.glVertex3d(x + width, 1, z + length);
            Gl.glNormal3d(-1, 1, 1);
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3d(x + width, 1, z);
            Gl.glEnd();
        }
    }
}
