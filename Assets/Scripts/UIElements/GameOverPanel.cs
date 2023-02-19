using UnityEngine;

namespace UIElements
{
	public class GameOverPanel : MonoBehaviour
	{
		private GameOverPanelAnimator _animator;

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
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.R)) {
				// Restart Level
				
			} else if (Input.GetKeyDown(KeyCode.Escape)) {
				// Exit to Main Menu
				
			}
		}
	}
}
