using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowEngine
{
    public struct Vector2
    {
        int x, y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public struct Vector2F
    {
        float x, y;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public Vector2F(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
