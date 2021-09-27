using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Storm.Utils
{
    public class LengthDirection : MonoBehaviour
    {
        public static float X(float dist, float angle)
        {
            float x;
            float rAngle = angle * Mathf.Deg2Rad;
            x = (dist / Mathf.Rad2Deg) * (Mathf.Cos(rAngle) * Mathf.Rad2Deg);

            return x;
        }
        public static float Y(float dist, float angle)
        {
            float y;

            float rAngle = angle * Mathf.Deg2Rad;
            y = (dist / Mathf.Rad2Deg) * (Mathf.Sin(rAngle) * Mathf.Rad2Deg);
            return y;
        }

        public static float XZ_Angle(Vector3 p1, Vector3 p2)
        {
            float angle;
            angle = Mathf.Atan2(p2.z - p1.z, p2.x - p1.x) * 180 / Mathf.PI;
            return angle;
        }

        public static float Distance(Vector3 p1, Vector3 p2)
        {
            float dist;
            dist = Vector2.Distance(new Vector2(p1.x, p1.z), new Vector2(p2.x, p2.z));
            return dist;
        }
        public static Vector3 SetMagnitude(Vector3 A, float desiredLength)
        {
            Vector3 B = A;
            B *= (1 - desiredLength / A.magnitude);
            return B;
        }
        public static Vector3 ClampMagnitude(Vector3 A, float min, float max)
        {
            Vector3 B = A;
            if (A.magnitude < min)
            {
                B = SetMagnitude(A, min);
            }
            else if (A.magnitude > max)
            {
                B = SetMagnitude(A, max);
            }
            return B;
        }
    }
}
