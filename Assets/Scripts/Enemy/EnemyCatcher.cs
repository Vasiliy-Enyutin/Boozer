using Pathfinding;
using Player;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(AIPath))]
    public class EnemyCatcher : MonoBehaviour
    {
        private AIPath _aiPath;
        private EndgameInformer _endgameInformer;

        private void Awake()
        {
            _aiPath = GetComponent<AIPath>();
        }

        private void Start()
        {
            _endgameInformer = FindObjectOfType<EndgameInformer>();
        }

        private void Update()
        {
            if (_aiPath.reachedEndOfPath)
            {
                _endgameInformer.InvokeOnCatched();
            }
        }
    }
}
