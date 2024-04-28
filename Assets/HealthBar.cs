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
    public int Respawn;

    // Update is called once per frame
    void Update()
    {
        if(slider.value == 0) {            
            SceneManager.LoadScene(Respawn);
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
