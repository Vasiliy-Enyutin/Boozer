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
		
		private MovementDirection _movementDirection;
		private Sprite _unpressedStateSprite;
		private Sprite _pressedStateSprite;

		public void SetControlButton(UiControlButtonDescriptor descriptor)
		{
			_movementDirection = descriptor.MovementDirection;
			_unpressedStateSprite = descriptor.UnpressedSprite;
			_pressedStateSprite = descriptor.PressedSprite;
		}

		private void Awake()
		{
			_image = GetComponent<Image>();
			_image.sprite = _unpressedStateSprite;
		}

		private void Start()
		{
			_playerMovement = FindObjectOfType<PlayerMovement>();
		}

		private void Update()
		{
			_image.sprite = _playerMovement.PressedButtons[_controlButton] ? _pressedStateSprite : _unpressedStateSprite;
		}
		
		public ControlButton ControlButton
		{
			get { return _controlButton; }
		}
	}
}
