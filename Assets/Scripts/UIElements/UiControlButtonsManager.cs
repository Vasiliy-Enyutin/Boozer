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
		}

		private void PlaceButtons(Dictionary<MovementDirection, ControlButton> evt)
		{
			StartCoroutine(TestRoutine(evt));
		}

		private IEnumerator TestRoutine(Dictionary<MovementDirection, ControlButton> evt)
		{
			_uiControlsButtonAnimator.PlayMix();
			yield return new WaitForSeconds(1f);
			foreach (UiControlButton uiControlButton in _uiControlButtons) {
				ControlButton controlButton = evt[uiControlButton.MovementDirection];
				UiControlButtonDescriptor uiControlButtonDescriptor = _controlButtonDescriptorCollection.RequireDescriptor(controlButton);
				uiControlButton.SetControlButton(uiControlButtonDescriptor);
			}
		}
	}
}
