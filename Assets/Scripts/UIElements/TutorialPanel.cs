using System;
using System.Collections;
using UnityEngine;

namespace UIElements
{
	public class TutorialPanel : MonoBehaviour
	{
		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		private void OnEnable()
		{
			IsWaitingForPlayerInput = true;
		}

		private void Update()
		{
			if (Input.anyKeyDown) {
				IsWaitingForPlayerInput = false;
			}
		}

		public bool IsWaitingForPlayerInput { get; private set; }
	}
}
