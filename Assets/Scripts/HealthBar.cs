using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;    
    public bool isDead;
    public GameOver gameOver;

    // Update is called once per frame
    void Update()
    {
        if(slider.value == 0 && !isDead) {      
            isDead = true;      
            gameOver.gameOver();
        }
    }

    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;

       fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health) {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
