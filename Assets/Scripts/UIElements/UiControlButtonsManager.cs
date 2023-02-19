using System.Collections;
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

		private UiControlsButtonAnimator _uiControlsButtonAnimator;

		private void Awake()
		{
			_uiControlButtons = FindObjectsOfType<UiControlButton>().ToList();
			_playerMovement = FindObjectOfType<PlayerMovement>();
			_uiControlsButtonAnimator = GetComponent<UiControlsButtonAnimator>();
			_playerMovement.OnControlsChanged += PlaceButtons;
			_playerMovement.OnDefaultControlsSet += PlaceButtonsWithoutMix;
		}

		private void PlaceButtons(Dictionary<MovementDirection, ControlButton> evt)
		{
			_uiControlsButtonAnimator.PlayMix();
			StartCoroutine(PlaceButtonsRoutine(evt));
		}

		private void PlaceButtonsWithoutMix(Dictionary<MovementDirection, ControlButton> evt)
		{
			StartCoroutine(PlaceButtonsRoutine(evt));
		}

		private IEnumerator PlaceButtonsRoutine(Dictionary<MovementDirection, ControlButton> evt)
		{
			yield return new WaitForSeconds(1f);
			foreach (UiControlButton uiControlButton in _uiControlButtons) {
				MovementDirection movementDirection = evt.FirstOrDefault(x => x.Value == uiControlButton.ControlButton).Key;
				UiControlButtonDescriptor uiControlButtonDescriptor = _controlButtonDescriptorCollection.RequireDescriptor(movementDirection);
				uiControlButton.SetControlButton(uiControlButtonDescriptor);
			}
		}
	}
}
