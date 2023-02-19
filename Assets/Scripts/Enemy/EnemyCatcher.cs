using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Player;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(AIPath))]
    public class EnemyCatcher : MonoBehaviour
    {
        private const float WAIT_DURATION = 2f;
        private AIPath _aiPath;
        private EndgameInformer _endgameInformer;
        private PlayerMovement _playerMovement;
        
        private bool _catched;
        
        public void PausePathfinding()
        {
            _aiPath.isStopped = true;
        }
        
        public void UnpausePathfinding()
        {
            _aiPath.isStopped = false;
        }

        private void Awake()
        {
            _aiPath = GetComponent<AIPath>();
        }

        private void Start()
        {
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _playerMovement.OnControlsChanged += PausePathfinding;
            _endgameInformer = FindObjectOfType<EndgameInformer>();
        }

        private void Update()
        {
            if (_catched) {
                return;
            }
            if (_aiPath.reachedEndOfPath) {
                _endgameInformer.InvokeOnCatched();
                _catched = true;
            }
        }

        private void PausePathfinding(Dictionary<MovementDirection, ControlButton> obj)
        {
            StartCoroutine(WaitRoutine(WAIT_DURATION));
        }

        private IEnumerator WaitRoutine(float waitDuration)
        {
            _aiPath.isStopped = true;
            yield return new WaitForSeconds(waitDuration);
            _aiPath.isStopped = false;
        }
    }
}
