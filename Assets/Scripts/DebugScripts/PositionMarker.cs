
using UnityEditor;
using UnityEngine;

namespace DebugScripts
{
    public class PositionMarker : MonoBehaviour
    {
        Color color;
        private string text;

        public void Init(Color color, string text= "Marker")
        {
            this.text = text;
            this.color = color;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = color;
            Handles.color = color;
            Handles.DrawSolidDisc(transform.position,Vector3.up, .25f);
            Handles.Label(transform.position, text);

        }
    }
}

