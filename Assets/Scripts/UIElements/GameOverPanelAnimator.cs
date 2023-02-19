using UnityEngine;

namespace UIElements
{
	public class GameOverPanelAnimator : MonoBehaviour
	{
		private Animator _animator;
		private UiControlsButtonAnimator _uiControlsButtonAnimator;
		
		private readonly int GameOverShowHash = Animator.StringToHash("GameOverShow");
		
		public void PlayShow()
		{
			_animator = GetComponent<Animator>();
			_animator.Play(GameOverShowHash);
		}
	}
}
