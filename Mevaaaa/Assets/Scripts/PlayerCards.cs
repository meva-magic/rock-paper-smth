using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCards : MonoBehaviour
{
    public static PlayerCards instance;

    public int card = 0;

    private void Awake()
    {
        instance = this;
    }

    public void Sword()
    {
        card = 1;

        UI.instance.narrator.text = "Ты выбрал МЕЧ";
    }

    public void Rose()
    {
        card = 2;

        UI.instance.narrator.text = "Ты выбрал РОЗУ";
    }

    public void Crow()
    {
        card = 3;

        UI.instance.narrator.text = "Ты выбрал ВОРОНА";
    }
}
