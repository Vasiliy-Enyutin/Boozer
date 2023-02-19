using Player;
using UnityEngine;

public class AlcoBottle : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (!col.TryGetComponent(out PlayerMovement playerMovement)) {
			return;
		}
		playerMovement.ChangeControlButtons();
		Destroy(gameObject);
	}
}
