
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowEngine
{
    public struct Matrix
    {
        float[,] values;

        public float[,] Values
        {
            get { return values; }
            set { values = value; }
        }

        public Matrix(float[,] values)
        {
            this.values = values;
        }

        public Matrix(float m11, float m12, float m13, float m14, float m21,
           float m22, float m23, float m24, float m31, float m32, float m33,
           float m34, float m41, float m42, float m43, float m44)
        {
            values = new float[4, 4];
            values[0, 0] = m11;
            values[0, 1] = m12;
            values[0, 2] = m13;
            values[0, 3] = m14;
            values[1, 0] = m21;
            values[1, 1] = m22;
            values[1, 2] = m23;
            values[1, 3] = m24;
            values[2, 0] = m31;
            values[2, 1] = m32;
            values[2, 2] = m33;
            values[2, 3] = m34;
            values[3, 0] = m41;
            values[3, 1] = m42;
            values[3, 2] = m43;
            values[3, 3] = m44;
        }

        public static Matrix Identity()
        {
            return new Matrix(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        }

        public static float[] IdentityF()
        {
            float[] identity = { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };
            return identity;
        }

        public static Matrix CreateTranslation(float x, float y, float z)
        {
            return new Matrix(new float[4, 4]);
        }

        public static Matrix CreateScale(float x, float y, float z)
        {
            return new Matrix(new float[4, 4]);
        }

        public static Matrix CreateFromAxisAngle(Vector3 v, float r)
        {
            return new Matrix(new float[4, 4]);
        }

        public static Matrix operator *(Matrix first, Matrix other)
        {
            float[,] values = new float[4, 4];
            values[0, 0] = first.values[0, 0] * other.values[0, 0];
            values[0, 1] = first.values[1, 0] * other.values[0, 1];
            values[0, 2] = first.values[2, 0] * other.values[0, 2];
            values[0, 3] = first.values[3, 0] * other.values[0, 3];

            values[1, 0] = first.values[0, 1] * other.values[1, 0];
            values[1, 1] = first.values[1, 1] * other.values[1, 1];
            values[1, 2] = first.values[2, 1] * other.values[1, 2];
            values[1, 3] = first.values[3, 1] * other.values[1, 3];

            values[2, 0] = first.values[0, 2] * other.values[2, 0];
            values[2, 1] = first.values[1, 2] * other.values[2, 1];
            values[2, 2] = first.values[2, 2] * other.values[2, 2];
            values[2, 3] = first.values[3, 2] * other.values[2, 3];

            values[3, 0] = first.values[0, 3] * other.values[3, 0];
            values[3, 1] = first.values[1, 3] * other.values[3, 1];
            values[3, 2] = first.values[2, 3] * other.values[3, 2];
            values[3, 3] = first.values[3, 3] * other.values[3, 3];
            return new Matrix(values);
        }
    }
}
