using System.Collections;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

public class AlcoBottle : MonoBehaviour
{
	private Animator _animator;
	
	private static readonly int BottleIdleHash = Animator.StringToHash("BottleIdle");

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(Random.Range(0f, 1f));
		_animator.Play(BottleIdleHash);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (!col.TryGetComponent(out PlayerMovement playerMovement)) {
			return;
		}
		playerMovement.ChangeControlButtons();
		Destroy(gameObject);
	}
}
