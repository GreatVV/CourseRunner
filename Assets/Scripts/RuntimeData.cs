using System;

namespace Client
{
    [Serializable]
    public class RuntimeData
    {
        public float DeltaTime;
        public GameState GameState = GameState.BeforeStart;
    }
}