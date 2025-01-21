using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState {
        Pause = 0,
        Running = 1
    }

    static GameManager instance;
    GameState state = GameState.Running;
    public GameObject pauseMenu;

    public static GameManager Instance {
        get {
            instance = FindObjectOfType<GameManager>(); // 이미 존재하는지
            if (instance == null) {
                GameObject temp = new GameObject("GameManager");
                instance = temp.AddComponent<GameManager>();
            }
            return instance;
        }
    }

    public GameState State {
        get {
            return state;
        }
    }

    void Start() {
        if (instance == null) {
            instance = this;
        }
        else {
            GameObject.Destroy(gameObject);
        }
        state = GameState.Running;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (state == GameState.Running) {
                Pause();
            }
            else {
                Resume();
            }  
        }
    }

    void Pause() {
        pauseMenu.SetActive(true);
        state = GameState.Pause;
        Time.timeScale = 0f;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        state = GameState.Running;
        Time.timeScale = 1f;
    }

    public void Menu() {
        Resume();
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void Quit() {
        Application.Quit();
    }

    public void GameOver() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
