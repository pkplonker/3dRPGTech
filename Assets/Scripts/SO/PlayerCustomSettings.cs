using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "PlayerCustomSettings", menuName = "SO/Settings/PlayerCustomSettings")]
    public class PlayerCustomSettings : ScriptableObject
    {
        [Header("PlayerCamera")]
        [Range(.1f,2)] public float cameraZoomSpeed=.3f;
        [Range(10,200)]public float cameraRotationSpeed=100f;
    }
}
