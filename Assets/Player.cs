using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;
	public int currentScore = 0;
	[SerializeField] Text pointText;

	public int CurrentScore {
        get {
            return currentScore;
        }

        set {
            currentScore = value;
            UpdateHUD();
        }
    }	

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

	private void Awake()
    {
        UpdateHUD();
    }

	private void UpdateHUD()
    {
        pointText.text = currentScore.ToString();
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

	private void OnCollisionEnter2D(Collision2D collision) 
    {

		if(collision.gameObject.CompareTag("Enemy")) 
		{
			KillPlayer enemy = collision.gameObject.GetComponent<KillPlayer>();
			TakeDamage(5);
			enemy.TakeDamage(100);
		}

		if(collision.gameObject.CompareTag("EnemyPhantom")) 
		{
			TakeDamage(10);
		}

		if(collision.gameObject.CompareTag("EnemyThorns")) 
		{
			TakeDamage(100);
		}	
    }

	private void OnTriggerEnter2D(Collider2D collider) 
    {

		if(collider.gameObject.CompareTag("Coin")) 
		{
			CoinClass coin = collider.gameObject.GetComponent<CoinClass>();
			coin.Collect();
			CurrentScore++;
		}		
    }	
}
