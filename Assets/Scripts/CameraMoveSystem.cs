using System;
using Leopotam.Ecs;

namespace Client
{
    internal class CameraMoveSystem : IEcsRunSystem
    {
        private SceneData _sceneData;
        private RuntimeData _runtimeData;

        private EcsFilter<Player, Controllable> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var player = _filter.Get1(i);
                _sceneData.CameraRoot.transform.position = player.value.transform.position;
            }
        }
    }

    internal struct Controllable
    {
    }
}