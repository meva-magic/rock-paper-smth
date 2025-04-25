using UnityEngine;
using UnityEngine.UI;

public class DuelUI : MonoBehaviour
{
    public Text nameText;
    public Slider hpSlider;

    public void SetUI(Unit unit)
    {
        nameText.text = unit.unitName;

        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
}
