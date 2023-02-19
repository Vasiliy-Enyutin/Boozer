using UIElements;
using UnityEngine;

namespace Debuggers
{
	public class UiDebugger : MonoBehaviour
	{
		private UiManager _uiManager;

		private void Start()
		{
			_uiManager = FindObjectOfType<UiManager>();
		}
		
		private void Update()
		{
			return;
			if (Input.GetKeyDown(KeyCode.W)) {
				_uiManager.ShowLevelWinPanel();
			} else if (Input.GetKeyDown(KeyCode.L)) {
				_uiManager.ShowGameOverPanel();
			} else if (Input.GetKeyDown(KeyCode.H)) {
				_uiManager.HideAll();
			}
		}
	}
}
