using UnityEngine;

namespace UIElements
{
	public class UiManager : MonoBehaviour
	{
		[SerializeField]
		private LevelWinPanel _levelWinPanelPrefab;
		[SerializeField]
		private GameOverPanel _gameOverPanelPrefab;
		[SerializeField]
		private UiControlsPanel _controlsPanelPrefab;
		[SerializeField]
		private MainMenuPanel _mainMenuPanelPrefab;
		[SerializeField]
		private TutorialPanel _tutorialPanelPrefab;
		
		private LevelWinPanel _levelWinPanel;
		private GameOverPanel _gameOverPanel;
		private UiControlsPanel _controlsPanel;
		private MainMenuPanel _mainMenuPanel;
		private TutorialPanel _tutorialPanel;

		public void ShowMainMenu()
		{
			_mainMenuPanel.Show();
		}

		public void ShowLevelWinPanel()
		{
			_levelWinPanel.Show();
		}

		public void ShowGameOverPanel()
		{
			_gameOverPanel.Show();
		}

		public void ShowUiControlButtons()
		{
			_controlsPanel.Show();
		}

		public void ShowTutorialPanel()
		{
			_tutorialPanel.Show();
		}

		public void HideAll()
		{
			_levelWinPanel.Hide();
			_gameOverPanel.Hide();
			_controlsPanel.Hide();
			_mainMenuPanel.Hide();
			_tutorialPanel.Hide();
		}

		private void Awake()
		{
			_levelWinPanel = Instantiate(_levelWinPanelPrefab, transform);
			_gameOverPanel = Instantiate(_gameOverPanelPrefab, transform);
			_controlsPanel = Instantiate(_controlsPanelPrefab, transform);
			_mainMenuPanel = Instantiate(_mainMenuPanelPrefab, transform);
			_tutorialPanel = Instantiate(_tutorialPanelPrefab, transform);
			HideAll();
		}

		public bool IsWaitingForPlayerInput
		{
			get
			{
				return _tutorialPanel.IsWaitingForPlayerInput;
			}
		}
	}
}
