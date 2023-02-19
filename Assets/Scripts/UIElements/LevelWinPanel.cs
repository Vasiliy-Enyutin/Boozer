using System;
using UnityEngine;

namespace UIElements
{
	public class LevelWinPanel : MonoBehaviour
	{
		private LevelWinPanelAnimator _animator;
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
			_animator = GetComponent<LevelWinPanelAnimator>();
			_gameManager = FindObjectOfType<GameManager>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape)) {
				_gameManager.ExitToMainMenu();
				Hide();
			}
		}
	}
}
