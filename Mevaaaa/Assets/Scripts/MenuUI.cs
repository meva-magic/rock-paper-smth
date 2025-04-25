using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public static MenuUI instance;

    [SerializeField] private Button startButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        startButton.onClick.AddListener(LoadGame);
        menuButton.onClick.AddListener(MainMenu);

        quitButton.onClick.AddListener(QuitGame);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
