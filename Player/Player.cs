using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float health = 100f;
    public GameObject deathCanvas;
    public Vector3 spawnPoint = Vector3.zero;
	// Use this for initialization
	void Start () {
        deathCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        CheckDeath();
	}

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        deathCanvas.SetActive(true);
    }
    public void Respawn()
    {
        deathCanvas.SetActive(false);
        transform.position = spawnPoint;
    }
}
