using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowEngine
{
    public struct Vector3
    {
        float x, y, z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void Normalize()
        {
            float len = (float)Math.Sqrt(x * x + y * y + z * z);
            len = 1.0f / len;
            this.x *= len;
            this.y *= len;
            this.z *= len;
        }

        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            float x = ((v1.Y * v2.Z) - (v1.Z * v2.Y));
            float y = ((v1.Z * v2.X) - (v1.X * v2.Z));
            float z = ((v1.X * v2.Y) - (v1.Y * v2.X));
            return new Vector3(x, y, z);
        }

        public static Vector3 operator *(Vector3 first, int other)
        {
            return new Vector3(first.X * other, first.Y * other, first.Z * other);
        }

        public static Vector3 operator /(Vector3 first, ushort other)
        {
            return new Vector3(first.X / other, first.Y / other, first.Z / other);
        }

        public static Vector3 operator +(Vector3 first, Vector3 other)
        {
            return new Vector3(first.X + other.X, first.Y + other.Y, first.Z + other.Z);
        }

        public static Vector3 operator -(Vector3 first, Vector3 other)
        {
            return new Vector3(first.X - other.X, first.Y - other.Y, first.Z - other.Z);
        }

        public float DistanceTo(Vector3 other)
        {
            return (float)Math.Sqrt((x - other.x) * (x - other.x) + (y - other.y) * (y - other.y));
        }

        /// <summary>
        /// This function  calculates 2D distances between two points
        /// <summary>
        public static float DistPointToPoint(Vector3 first, Vector3 second)
        {
            return (float)Math.Sqrt((first.x - second.x) * (first.x - second.x) + (first.y - second.y) * (first.y - second.y));
        }

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

        public float Z
        {
            get { return z; }
            set { z = value; }
        }
    }
}
