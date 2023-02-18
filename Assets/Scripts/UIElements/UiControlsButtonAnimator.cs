using JetBrains.Annotations;
using UnityEngine;

namespace UIElements
{
	public class UiControlsButtonAnimator : MonoBehaviour
	{
		[SerializeField]
		private Transform _leftButtonTransform;
		[SerializeField]
		private Transform _rightButtonTransform;
		
		private readonly int CardButtonMixHash = Animator.StringToHash("CardButtonMix");
		
		private Animator _animator;
		
		public void PlayMix()
		{
			_animator.Play(CardButtonMixHash);
		}

		[UsedImplicitly]
		public void PlaceLeftButtonOnTop()
		{
			_leftButtonTransform.SetAsLastSibling();
		}

		[UsedImplicitly]
		public void OnAnimationEnd()
		{
			_rightButtonTransform.SetAsLastSibling();
		}

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}
	}
}
