using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AICards : MonoBehaviour
{
    public static AICards instance;
    public Sprite[] sprites;
    public Image aiImage;

    private int aiCard = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        aiImage.sprite = sprites[0];
    }

    public void ActButton()
    {
        aiImage.gameObject.SetActive(true);
        aiCard = Random.Range(1, sprites.Length);

        aiImage.sprite = sprites[aiCard];

        if (aiCard == PlayerCards.instance.card)
        {
            UI.instance.status.text = "ничья";
        }

        else if ((aiCard == 3 && PlayerCards.instance.card == 1 )|| (aiCard == 1 && PlayerCards.instance.card == 2) || (aiCard == 2 && PlayerCards.instance.card == 3))
        {
            UI.instance.status.text = "победа";
            EnemyHealth.instance.TakeDamage(1);
        }

        else if ((aiCard == 1 && PlayerCards.instance.card == 3) || (aiCard == 2 && PlayerCards.instance.card == 1) || (aiCard == 3 && PlayerCards.instance.card == 2) || PlayerCards.instance.card == 0)
        {
            UI.instance.status.text = "проигрыш";
            PlayerHealth.instance.TakeDamage(1);
        }
        
        UI.instance.DisableCards();
        UI.instance.actButton.gameObject.SetActive(false);
        UI.instance.resetButton.gameObject.SetActive(true);
    }

    public void Reset()
    {
        aiCard = 0;
        aiImage.sprite = sprites[0];
        PlayerCards.instance.card = 0;

        UI.instance.ResetUI();
    }
}
