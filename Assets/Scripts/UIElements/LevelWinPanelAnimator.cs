using UnityEngine;

namespace UIElements
{
	public class LevelWinPanelAnimator : MonoBehaviour
	{
		private readonly int LevelWinPanelShowHash = Animator.StringToHash("LevelWinPanelShow");
		
		public void PlayShow()
		{
			Animator animator = GetComponent<Animator>();
			animator.Play(LevelWinPanelShowHash);
		}
	}
}
