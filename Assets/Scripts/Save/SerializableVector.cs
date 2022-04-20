using System;
using UnityEngine;

namespace Save
{
    [Serializable]

    public class SerializableVector
    {
        public float x;
        public float y;
        public float z;

        public SerializableVector(Vector3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }

        public Vector3 GetVector()
        {
            return new Vector3(x, y, z);
        }
    }
}
