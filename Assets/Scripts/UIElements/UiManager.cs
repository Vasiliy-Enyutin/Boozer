using UnityEngine;

namespace UIElements
{
	public class UiManager : MonoBehaviour
	{
		[SerializeField]
		private LevelWinPanel _levelWinPanelPrefab;
		[SerializeField]
		private GameOverPanel _gameOverPanelPrefab;
		
		private LevelWinPanel _levelWinPanel;
		private GameOverPanel _gameOverPanel;
		
		private void Awake()
		{
			_levelWinPanel = Instantiate(_levelWinPanelPrefab, transform);
			_gameOverPanel = Instantiate(_gameOverPanelPrefab, transform);
			HideAll();
		}
		
		public void ShowLevelWinPanel()
		{
			_levelWinPanel.Show();
		}
		
		public void ShowGameOverPanel()
		{
			_gameOverPanel.Show();
		}

		public void HideAll()
		{
			_levelWinPanel.Hide();
			_gameOverPanel.Hide();
		}
	}
}
