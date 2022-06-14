using System;
using UnityEngine;

namespace Maze
{
    [Serializable]
    public struct SVect3
    {
        public float X;
        public float Y;
        public float Z;

        public SVect3(float x, float y, float z)
        {
            X = x;
            Y = y;  
            Z = z;  
        }

        public static implicit operator SVect3(Vector3 value)
        {
            return new SVect3(value.x, value.y, value.z);
        }

        public static implicit operator Vector3(SVect3 value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public override string ToString()
        {
            return $"{X} {Y} {Z}";
        }

        public static explicit operator SVect3(string str)
        {
            var values = str.Split();
            return new SVect3 { X = float.Parse(values[0]), Y = float.Parse(values[1]), Z = float.Parse(values[2]) };
        }
    }

    [Serializable]
    public struct SQuater
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public SQuater(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static implicit operator SQuater(Quaternion value)
        {
            return new SQuater(value.x, value.y, value.z, value.w);
        }

        public static implicit operator Quaternion(SQuater value)
        {
            return new Quaternion(value.X, value.Y, value.Z, value.W);
        }
    }

    [Serializable]
    public struct SObject
    {
        public string Name;
        public SVect3 Position;
        public SQuater Rotation;
        public SVect3 Scale;
    }
}