using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace New_Street_Phone_Missions.Classes
{
    public struct Vector4 
    {
        public float X;
        public float Y;
        public float Z;
        public float R;

        public Vector4(float x, float y, float z, float r)
        {
            X = x; Y = y; Z = z; R = r;
        }
    }
}
