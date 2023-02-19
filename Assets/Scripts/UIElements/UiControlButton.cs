using Descriptors;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UIElements
{
	public class UiControlButton : MonoBehaviour
	{
		[SerializeField]
		private ControlButton _controlButton;

		private PlayerMovement _playerMovement;
		private Image _image;
		
		private Sprite _unpressedStateSprite;
		private Sprite _pressedStateSprite;

		public void SetControlButton(UiControlButtonDescriptor descriptor)
		{
			_unpressedStateSprite = descriptor.UnpressedSprite;
			_pressedStateSprite = descriptor.PressedSprite;
			
			_image.sprite = _unpressedStateSprite;
		}

		private void Awake()
		{
			_image = GetComponent<Image>();
		}

		private void Start()
		{
			_playerMovement = FindObjectOfType<PlayerMovement>();
		}

		private void Update()
		{
			if (_pressedStateSprite == null || _unpressedStateSprite == null) {
				return;
			}
			_image.sprite = _playerMovement.PressedButtons[_controlButton] ? _pressedStateSprite : _unpressedStateSprite;
		}
		
		public ControlButton ControlButton
		{
			get { return _controlButton; }
		}
	}
}
