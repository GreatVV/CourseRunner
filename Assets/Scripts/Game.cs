using Leopotam.Ecs;
using TMPro;
using UnityEngine;

namespace Client {
    sealed class Game : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;

        public StaticData StaticData;
        public RuntimeData RuntimeData;
        public SceneData SceneData;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.

            RuntimeData = new RuntimeData();
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                // register your systems here, for example:
                .Add(new InitSystem())
                .Add(new MoveSystem())
                .Add(new AnalyzeGameStartSystem())
                .Add(new PlayerControlSystem())
                .Add(new MovePlayerSideSystem())
                .Add(new CameraMoveSystem())
                .Add(new FinishSystem())
                
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                
                // inject service instances here (order doesn't important), for example:
                .Inject (StaticData)
                .Inject (RuntimeData)
                .Inject (SceneData)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}