using Descriptors;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UIElements
{
	public class UiControlButton : MonoBehaviour
	{
		[SerializeField]
		private MovementDirection _movementDirection;

		private PlayerMovement _playerMovement;
		private Image _image;
		
		private ControlButton _controlButton;
		private Sprite _unpressedStateSprite;
		private Sprite _pressedStateSprite;

		public void SetControlButton(UiControlButtonDescriptor descriptor)
		{
			_controlButton = descriptor.Button;
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
		
		public MovementDirection MovementDirection
		{
			get { return _movementDirection; }
		}
	}
}
