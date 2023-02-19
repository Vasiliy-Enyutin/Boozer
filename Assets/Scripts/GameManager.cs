using Player;
using UIElements;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private EndgameInformer _endgameInformer;
	private UiManager _uiManager;

	private bool _finishReached;

	public void RestartLevel()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}
	
	public void LoadLevel()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}

	private void Start()
	{
		_uiManager = FindObjectOfType<UiManager>();
		_uiManager.ShowUiControlButtons();
		
		_endgameInformer = FindObjectOfType<EndgameInformer>();
		_endgameInformer.OnFinishReached += OnFinishReached;
		_endgameInformer.OnCatched += OnCatched;
	}

	private void OnFinishReached()
	{
		_uiManager.HideAll();
		_uiManager.ShowLevelWinPanel();
		_finishReached = true;
	}

	private void OnCatched()
	{
		if (_finishReached) {
			return;
		}
		_uiManager.HideAll();
		_uiManager.ShowGameOverPanel();
	}

	public void ExitToMainMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}
