using UnityEngine;

namespace UIElements
{
	public class MainMenuPanel : MonoBehaviour
	{
		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		private void Update()
		{
			if (!Input.anyKeyDown) {
				return;
			}
			UnityEngine.SceneManagement.SceneManager.LoadScene(1);
			Hide();
		}
	}
}
