using System.Collections.Generic;
using System.Linq;
using Descriptors;
using Player;
using UnityEngine;

namespace UIElements
{
	public class UiControlButtonsManager : MonoBehaviour
	{
		[SerializeField]
		private UiControlButtonDescriptorCollection _controlButtonDescriptorCollection;

		private List<UiControlButton> _uiControlButtons;
		private PlayerMovement _playerMovement;

		private void OnEnable()
		{
			_playerMovement = FindObjectOfType<PlayerMovement>();
			_playerMovement.OnControlsChanged += PlaceButtons;
		}

		private void OnDisable()
		{
			_playerMovement.OnControlsChanged -= PlaceButtons;
		}

		private void Start()
		{
			_uiControlButtons = FindObjectsOfType<UiControlButton>().ToList();
		}

		private void PlaceButtons(Dictionary<MovementDirection, ControlButton> evt)
		{
			foreach (UiControlButton uiControlButton in _uiControlButtons) {
				ControlButton controlButton = evt[uiControlButton.MovementDirection];
				UiControlButtonDescriptor uiControlButtonDescriptor = _controlButtonDescriptorCollection.RequireDescriptor(controlButton);
				uiControlButton.SetControlButton(uiControlButtonDescriptor);
			}
		}
	}
}
