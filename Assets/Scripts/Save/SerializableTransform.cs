using System;
using UnityEngine;

namespace Save
{
    [Serializable]
    public class SerializableTransform
    {
        public SerializableVector position { get; private set; }
        public SerializableVector rotation{ get; private set; }
        public SerializableVector scale{ get; private set; }

        public SerializableTransform(Transform t)
        {
            position = new SerializableVector(t.position);
            rotation = new SerializableVector(t.eulerAngles);
            scale =  new SerializableVector(t.lossyScale);
        }
    }
}
