using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static EnemyHealth instance;

    private int maxHealth = 3;
    public int health;
    [SerializeField] private float lerpSpeed;
    
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider healthSliderDelay;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;
    }

    private void Update() 
    {
        if(healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if (healthSlider != healthSliderDelay)
        {
            healthSliderDelay.value = Mathf.Lerp(healthSliderDelay.value, health, lerpSpeed);
        }
    }

        public void TakeDamage(int damage)
    {
        health -= 1;

        if (health <= 0)
        {
            //player dead
        }
    }
}
