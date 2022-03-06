using UnityEngine;

namespace Client
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        public PlayerView Player;
        public float Speed = 10;
        public float ControlSensitivity = 0.01f;
    }
}