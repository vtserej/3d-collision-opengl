using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowEngine
{
    public struct Segment
    {
        public Vector2F first;
        public Vector2F second;
        float angleSegment;
        float m1, m2;
        float n1;

        public Segment(Vector2F first, Vector2F second)
        {
            this.first = first;
            this.second = second;

            //avoid that the M is 0 or undefined
            if (first.Y == second.Y)
            {
                this.first.Y += 0.001f;
            }
            if (second.X == first.X)
            {
                this.second.X += 0.001f;
            }
            //calculate the pendient of the function a the perpendicular
            //pendient
            m1 = (this.second.Y - this.first.Y) / (this.second.X - this.first.X);
            m2 = -1 / m1;
            //calculate the y intersection
            n1 = this.first.Y - m1 * this.first.X;
            //calculate the angle with the x axis
            this.angleSegment = Helper.RadToDegree(Math.Atan((float)m1));
        }

        /// <summary>
        /// This function  calculates the distance between a point
        /// and a segment
        /// <summary>
        public float DistToSegment(Vector3 other)
        {
            //calculate the distances to each point
            float dist1 = Vector3.DistPointToPoint(new Vector3(other.X, other.Y, 0), new Vector3(first.X, first.Y, 0));
            float dist2 = Vector3.DistPointToPoint(new Vector3(other.X, other.Y, 0), new Vector3(second.X, second.Y, 0));

            //calculate the two linear functions
            float n2 = other.Y - m2 * other.X;   //y = m2x + n   m2 = -1/m1

            //calculate the intersection point(i.p.)
            Vector3 intersectionPoint = new Vector3();
            intersectionPoint.X = (n2 - n1) / (m1 - m2);
            intersectionPoint.Y = m1 * intersectionPoint.X + n1;
            float d = Vector3.DistPointToPoint(intersectionPoint, other);

            //if the i.p. is contained in the rect segment return d else 
            //the minimun value between dist1 and dist2
            if ((intersectionPoint.X <= first.X && intersectionPoint.X >= second.X) ||
                (intersectionPoint.X >= first.X && intersectionPoint.X <= second.X))
            {
                return d;
            }
            else
                return 100;//Math.Min(dist1, dist2);
        }

        /// <summary>
        /// If you hit against a wall this method will give you and alternative point
        /// to move if there is one
        /// <summary>
        public Vector3 PosibleMove(float inc, float angle, Vector3 pos)
        {
            float xInc = 0;
            float yInc = 0;

            if (angle <= 90 && angle > 270)
            {
                xInc = inc * -(float)Math.Cos((float)angleSegment);
            }
            else
            {
                xInc = inc * (float)Math.Cos((float)angleSegment);
            }
            if (angle < 180 && angle > 0)
            {
                yInc = -inc * (float)Math.Sin((float)angleSegment);
            }
            else
            {
                yInc = inc * (float)Math.Sin((float)angleSegment);
            }
            return new Vector3(pos.X + xInc, pos.Y + yInc, 0);
        }
    }

    public struct CollisionPoint
    {
        public int objectID;
        public bool enabled;
        public Vector3 point;
        float colitionDistance;

        public float ColitionDistance
        {
            get
            {
                if (enabled)
                {
                    return colitionDistance;
                }
                else
                {
                    return -1;
                }
            }
            set { colitionDistance = value; }
        }
    }

    public struct CollisionSegment
    {
        public int objectID;
        private bool enabled;
        public Segment segment;
        float colitionDistance;

        public void Enabled(bool enabled)
        {
            this.enabled = enabled;
        }

        public float ColitionDistance
        {
            get
            {
                if (enabled)
                {
                    return colitionDistance;
                }
                else
                {
                    return -1;
                }
            }
            set { colitionDistance = value; }
        }
    }


}
