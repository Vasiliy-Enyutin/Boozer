using System;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

namespace UIElements
{
	public class UiControlsButtonAnimator : MonoBehaviour
	{
		private const float FALL_DURATION = 0.5f;
		private const float SHAKE_DURATION = 0.5f;
		private const float FALL_END_VALUE = -500f;
		
		public event Action OnFallAnimationCompleted;

		[SerializeField]
		private RectTransform _leftButtonTransform;
		[SerializeField]
		private RectTransform _rightButtonTransform;
		[SerializeField]
		private RectTransform _upButtonTransform;
		[SerializeField]
		private RectTransform _downButtonTransform;
		
		private readonly int CardButtonMixHash = Animator.StringToHash("CardButtonMix");
		
		private Animator _animator;
		
		public void PlayMix()
		{
			_animator.Play(CardButtonMixHash);
		}

		public void PlayFall()
		{
			_animator.enabled = false;
			Sequence sequence = DOTween.Sequence();
			sequence.OnComplete(() => {
				_animator.enabled = true;
				gameObject.SetActive(false);
				OnFallAnimationCompleted?.Invoke();
			});
			
			sequence.Append(_leftButtonTransform.DOShakePosition(SHAKE_DURATION, 10f));
			sequence.Append(_leftButtonTransform.DOMoveY(FALL_END_VALUE, FALL_DURATION));
			
			sequence.Append(_rightButtonTransform.DOShakePosition(SHAKE_DURATION, 10f));
			sequence.Append(_rightButtonTransform.DOMoveY(FALL_END_VALUE, FALL_DURATION));

			sequence.Append(_downButtonTransform.DOShakePosition(SHAKE_DURATION, 10f));
			sequence.Append(_downButtonTransform.DOMoveY(FALL_END_VALUE, FALL_DURATION));
			
			sequence.Append(_upButtonTransform.DOShakePosition(SHAKE_DURATION, 10f));
			sequence.Append(_upButtonTransform.DOMoveY(FALL_END_VALUE, FALL_DURATION));
			
			sequence.Play();
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
