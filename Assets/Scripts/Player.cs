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
	[SerializeField] Text scoreText;
	public int currentCoins = 0;
	[SerializeField] Text coinsText;
	[SerializeField] Text highscoreText;
	[SerializeField] Text newRecordText;
	public bool isNewRecord = false;
	[SerializeField] private float scoreRate = 1f;
	public List<CoinClass> allCoins = new List<CoinClass>();
	public int counterLevel = 1;
	private int lastTrigger = 0;

	public int CurrentScore {
        get {
            return currentScore;
        }

        set {
            currentScore = value;
            UpdateHUD();
        }
    }	

	public int CurrentCoins {
        get {
            return currentCoins;
        }

        set {
            currentCoins = value;
            UpdateHUD();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(SetScore());
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

	private IEnumerator SetScore() {
        WaitForSeconds wait = new WaitForSeconds(scoreRate);

        while(true) {
            yield return wait;    
			CurrentScore+=counterLevel;
			currentHealth--;
			healthBar.SetHealth(currentHealth);			
			CheckHighscore();
        }

    }

	private void Awake()
    {
        UpdateHUD();
    }

	private void UpdateHUD()
    {
        scoreText.text = currentScore.ToString();
		coinsText.text = currentCoins.ToString();
		if(isNewRecord) {
			highscoreText.text = currentScore.ToString();
			PlayerPrefs.SetInt("Highscore", currentScore);
		} else {
			highscoreText.text = PlayerPrefs.GetInt("Highscore", currentScore).ToString();
		}
		newRecordText.gameObject.SetActive(isNewRecord);
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

		if(collision.gameObject.CompareTag("EnemyFly")) 
		{
			TakeDamage(20);
		}

		if(collision.gameObject.CompareTag("EnemyBig")) 
		{
			TakeDamage(50);
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
			if (lastTrigger == collider.gameObject.GetInstanceID())
            {
                return;
            }
            lastTrigger = collider.gameObject.GetInstanceID();
			CoinClass coin = collider.gameObject.GetComponent<CoinClass>();
			coin.Collect();
			allCoins.Add(coin);

			CurrentScore+= 10;
			CurrentCoins++;
			CheckHighscore();
		}
		else if(collider.gameObject.CompareTag("Cherry"))
		{
			if (lastTrigger == collider.gameObject.GetInstanceID())
            {
                return;
            }
            lastTrigger = collider.gameObject.GetInstanceID();
			CoinClass coin = collider.gameObject.GetComponent<CoinClass>();
			coin.Collect();
			allCoins.Add(coin);

			currentHealth+=20;
		}
		else if(collider.gameObject.CompareTag("Gem"))
		{
			if (lastTrigger == collider.gameObject.GetInstanceID())
            {
                return;
            }
            lastTrigger = collider.gameObject.GetInstanceID();
			CoinClass coin = collider.gameObject.GetComponent<CoinClass>();
			coin.CollectGem();

			CurrentScore+= 100 + currentCoins;
			currentHealth+=currentCoins;
			currentCoins = 0;
			counterLevel++;


			foreach (CoinClass obj in allCoins) {
				obj.Activate();								
			}

			allCoins.Clear();
		}
    }	

	void CheckHighscore() {
		if(currentScore >= PlayerPrefs.GetInt("Highscore", 0)) {
			isNewRecord = true;
		}
	}
}
