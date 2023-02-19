using UnityEngine;

namespace UIElements
{
	public class GameOverPanel : MonoBehaviour
	{
		private GameOverPanelAnimator _animator;
		private GameManager _gameManager;

		public void Show()
		{
			gameObject.SetActive(true);
			_animator.PlayShow();
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		private void Awake()
		{
			_animator = GetComponent<GameOverPanelAnimator>();
			_gameManager = FindObjectOfType<GameManager>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.R)) {
				_gameManager.RestartLevel();
				Hide();
				
			} else if (Input.GetKeyDown(KeyCode.Escape)) {
				_gameManager.ExitToMainMenu();
				Hide();
			}
		}
	}
}
