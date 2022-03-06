using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class InitSystem : IEcsInitSystem
    {
        private StaticData _staticData;
        private RuntimeData _runtimeData;
        private SceneData _sceneData;

        private EcsWorld _world;
        
        public void Init()
        {
            for (var index = 0; index < _sceneData.EnemyPositions.Length; index++)
            {
                var enemyDescription = _sceneData.EnemyPositions[index];
                var player = Object.Instantiate(_staticData.Player, enemyDescription.StartPosition.position,
                    enemyDescription.StartPosition.rotation);

                var entity = _world.NewEntity();
                entity.Get<Player>().value = player;
                entity.Get<Speed>().value = enemyDescription.Speed;
            }

            {
                var player = Object.Instantiate(_staticData.Player, _sceneData.PlayerStartPosition.position,
                    _sceneData.PlayerStartPosition.rotation);

                var entity = _world.NewEntity();
                entity.Get<Player>().value = player;
                entity.Get<Speed>().value = _staticData.Speed;
                entity.Get<Controllable>();
            }
            
            _sceneData.UI.MenuScreen.SetActive(true);

        }
    }
}