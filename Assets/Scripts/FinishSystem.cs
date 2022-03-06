using Leopotam.Ecs;

namespace Client
{
    internal class FinishSystem : IEcsRunSystem
    {
        private EcsFilter<Player> _players;
        private RuntimeData _runtimeData;
        private SceneData _sceneData;
        
        public void Run()
        {
            if (_runtimeData.GameState != GameState.Playing)
            {
                return;
            }
            
            foreach (var player in _players)
            {
                if (_players.Get1(player).value.isFinished)
                {
                    _runtimeData.GameState = GameState.Win;
                    _sceneData.UI.GameScreen.SetActive(false);
                    _sceneData.UI.WinScreen.SetActive(true);
                }
            }
        }
    }
}