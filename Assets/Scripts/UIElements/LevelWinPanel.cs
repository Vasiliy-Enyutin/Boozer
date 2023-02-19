using UnityEngine;

namespace UIElements
{
	public class LevelWinPanel : MonoBehaviour
	{
		private LevelWinPanelAnimator _animator;

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
		}
	}
}
