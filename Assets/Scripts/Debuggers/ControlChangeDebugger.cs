using Player;
using UnityEngine;

namespace Debuggers
{
	public class ControlChangeDebugger : MonoBehaviour
	{
		private PlayerMovement _playerMovement;

		private void Start()
		{
			_playerMovement = FindObjectOfType<PlayerMovement>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.C)) {
				_playerMovement.ChangeControlButtons();
			}
		}
	}
}
