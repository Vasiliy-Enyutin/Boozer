using UnityEngine;

namespace UIElements
{
	public class UiControlsPanel : MonoBehaviour
	{
		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}
	}
}
