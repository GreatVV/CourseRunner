using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class MovePlayerSideSystem : IEcsRunSystem
    {
        private EcsFilter<Player, DiffX> _filter;
        private SceneData _sceneData;
        private StaticData _staticData;

        public void Run()
        {
            foreach (var filterIndex in _filter)
            {
                var x = _filter.Get2(filterIndex);
                var entity = _filter.GetEntity(filterIndex);
                var playerTransform = _filter.Get1(filterIndex).value.transform;
                var position = playerTransform.position;

                if (!entity.Has<StartMoveX>())
                {
                    entity.Get<StartMoveX>().value = position.x;
                }
                else
                {
                    var startX = entity.Get<StartMoveX>().value;
                    position.x = Mathf.Clamp(startX + x.value * _staticData.ControlSensitivity, _sceneData.MinX,
                        _sceneData.MaxX);
                    playerTransform.position = position;
                }

                _filter.GetEntity(filterIndex).Del<DiffX>();
            }
        }
    }
}