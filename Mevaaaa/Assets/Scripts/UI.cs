using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI instance;
    
    private string currentSceneName;

    public TextMeshProUGUI narrator;
    public TextMeshProUGUI status;

    public Button SwordButton;
    public Button RoseButton;
    public Button CrowButton;

    public Button actButton;
    public Button resetButton;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        actButton.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public void ResetUI()
    {
        EnableCards();

        narrator.text = " ";
        status.text = " ";

        actButton.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(false);
    }

    public void EnableCards()
    {
        SwordButton.gameObject.SetActive(true);
        RoseButton.gameObject.SetActive(true);
        CrowButton.gameObject.SetActive(true);
    }

    public void DisableCards()
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        
        foreach (GameObject card in cards)
        {
            card.SetActive(false);
        }
    }

    public void WinScreen()
    {
        SceneManager.LoadScene("Win");
    }

    public void DeathScreen()
    {
        SceneManager.LoadScene("Death");
    }

    private void Reload()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void DisableUI()
    {
        GameObject[] uIObjects = GameObject.FindGameObjectsWithTag("UI");

        foreach (GameObject uiObject in uIObjects)
        {
            uiObject.SetActive(false);
        }
    }
}
