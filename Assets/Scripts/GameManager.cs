using System.Collections;
using Enemy;
using Player;
using UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private EndgameInformer _endgameInformer;
	private UiManager _uiManager;

	private bool _finishReached;
	
	public void RestartLevel()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}
	
	public IEnumerator LoadNextLevel()
	{
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(2);
	}

	private IEnumerator Start()
	{
		_uiManager = FindObjectOfType<UiManager>();
		_uiManager.ShowTutorialPanel();
		
		_endgameInformer = FindObjectOfType<EndgameInformer>();
		_endgameInformer.OnFinishReached += OnFinishReached;
		_endgameInformer.OnCatched += OnCatched;
		
		PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
		playerMovement.PauseMoving();
		EnemyCatcher enemyCatcher = FindObjectOfType<EnemyCatcher>();
		enemyCatcher.PausePathfinding();
		yield return new WaitWhile(() => _uiManager.IsWaitingForPlayerInput);
		playerMovement.UnpauseMoving();
		enemyCatcher.UnpausePathfinding();
		_uiManager.HideAll();
		_uiManager.ShowUiControlButtons();
		playerMovement.SetDefaultButtons();
	}

	private void OnFinishReached()
	{
		_uiManager.HideAll();
		_uiManager.ShowLevelWinPanel();
		_finishReached = true;
		if (SceneManager.GetActiveScene().buildIndex == 2)
		{
			return;
		}
		StartCoroutine(LoadNextLevel());
	}

	private void OnCatched()
	{
		if (_finishReached) {
			return;
		}
		FindObjectOfType<EnemyCatcher>().PausePathfinding();
		_uiManager.HideAll();
		_uiManager.ShowGameOverPanel();
	}

	public void ExitToMainMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}
