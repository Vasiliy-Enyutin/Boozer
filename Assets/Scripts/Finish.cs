using Player;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private EndgameInformer _endgameInformer;

    private void Start()
    {
        _endgameInformer = FindObjectOfType<EndgameInformer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out PlayerMovement playerMovement)) {
            return;
        }
        _endgameInformer.InvokeOnFinishReached();
        playerMovement.GetComponent<Collider2D>().enabled = false;
    }
}
