using UnityEngine;

namespace Client
{
    public class FinishView : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            var playerView = other.GetComponentInParent<PlayerView>();
            if (playerView)
            {
                playerView.isFinished = true;
            }
        }
    }
}