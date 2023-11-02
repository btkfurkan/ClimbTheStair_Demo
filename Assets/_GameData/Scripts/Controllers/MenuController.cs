using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController Instance;
    private bool _isGameActive;

    [SerializeField] GameObject pauseMenu;

    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        EventManager.Instance.OnGameStarted += OnGameStartedHandler;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnGameStarted -= OnGameStartedHandler;
    }

    private void OnGameStartedHandler()
    {
        _isGameActive = true;
    }

    public bool GetGameState()
    {
        return _isGameActive;
    }

    public void PauseGame()
    {
        _isGameActive = false;

        Time.timeScale = 0f;

        pauseMenu.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);

        _isGameActive = true;

        Time.timeScale = 1f;
    }
}
