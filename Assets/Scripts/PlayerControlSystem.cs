using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class PlayerControlSystem : IEcsRunSystem
    {
        private EcsFilter<StartMoveX> _startMoveXFilter;
        private EcsFilter<Player, Controllable> _players;
        
        private RuntimeData _runtimeData;
        private Vector3 _startPosition;
        private EcsWorld _world;

        public void Run()
        {
            if (_runtimeData.GameState != GameState.Playing)
            {
                return;   
            }

            if (Input.GetMouseButtonDown(0))
            {
                _startPosition = Input.mousePosition;
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    var diff = Input.mousePosition - _startPosition;
                    var x = diff.x;

                    foreach (var player in _players)
                    {
                        _players.GetEntity(player).Get<DiffX>().value = x;
                    }
                }
                else
                {
                    foreach (var i in _startMoveXFilter)
                    {
                        _startMoveXFilter.GetEntity(i).Del<StartMoveX>();
                    }
                }
            }
        }
    }
}