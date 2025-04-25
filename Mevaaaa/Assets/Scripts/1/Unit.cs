using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitDamage;
    public int maxHP;
    public int currentHP;

    private void Start()
    {
        currentHP = maxHP;
    }

    public bool TakeDamage(int damage)
    {
        currentHP -= damage;

        if(currentHP <= 0)
            return true;
        
        else
            return false;
    }
}
