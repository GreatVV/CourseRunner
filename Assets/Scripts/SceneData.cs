using System;
using UnityEngine;

namespace Client
{
    public class SceneData : MonoBehaviour
    {
        public EnemyDescription[] EnemyPositions;
        public Transform PlayerStartPosition;
        
        public float MinX;
        public float MaxX;

        public Transform CameraRoot;

        public UI UI;
    }

    [Serializable]
    public class EnemyDescription
    {
        public Transform StartPosition;
        public float Speed;
    }
}