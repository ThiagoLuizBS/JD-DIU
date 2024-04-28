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
		Destroy(gameObject);
	}
}
