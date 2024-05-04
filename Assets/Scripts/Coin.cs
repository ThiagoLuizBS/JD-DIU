using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinClass : MonoBehaviour
{   
    public GameObject starEffect;

    public void Collect ()
	{
		Instantiate(starEffect, transform.position, Quaternion.identity);
		gameObject.SetActive(false);
	}

	public void CollectGem ()
	{

		Instantiate(starEffect, transform.position, Quaternion.identity);
		gameObject.SetActive(false);
		Invoke("Activate",3);
	}

	public void Activate ()
	{
		gameObject.SetActive(true);
	}
}
