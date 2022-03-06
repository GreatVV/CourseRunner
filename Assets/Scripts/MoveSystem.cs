using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<Player, Speed> _filter;
        private RuntimeData _runtimeData;
        
        public void Run()
        {
            _runtimeData.DeltaTime = Time.deltaTime;

            if (_runtimeData.GameState != GameState.Playing)
            {
                return;
            }

            foreach (var i in _filter)
            {
                var player = _filter.Get1(i);
                var speed = _filter.Get2(i);

                player.value.transform.position += Vector3.forward * _runtimeData.DeltaTime * speed.value;
            }
        }
    }
}