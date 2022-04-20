using System;
using UnityEngine;

namespace Save
{
    [Serializable]

    public class SerializableVector
    {
        private float x;
        private float y;
        private float z;

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
