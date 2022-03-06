using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class AnalyzeGameStartSystem : IEcsRunSystem
    {
        private RuntimeData _runtimeData;
        private SceneData _sceneData;
        
        public void Run()
        {
            if (_runtimeData.GameState == GameState.BeforeStart && Input.GetMouseButtonDown(0))
            {
                _runtimeData.GameState = GameState.Playing;
                
                _sceneData.UI.MenuScreen.SetActive(false);
                _sceneData.UI.GameScreen.SetActive(true);
            }
        }
    }
}