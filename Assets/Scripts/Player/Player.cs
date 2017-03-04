using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float health = 100f;
    public float hunger = 100f;
    public float thirst = 100f;

    public bool isDying = false;

    public Image healthBar;
    public Image hungerBar;
    public Image thirstBar;

    public float hungerSpeedMultiplier = 0.10f;
    public float thirstSpeedMultiplier = 0.25f;
    public float healthSpeedMultiplier = 0.25f;

    public GameObject deathCanvas;
    public Vector3 spawnPoint = Vector3.zero;
	// Use this for initialization
	void Start () {
        deathCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        CheckDeath();

        if(hunger > 0)
        {
            hunger -= Time.deltaTime * hungerSpeedMultiplier;
        }
        if(thirst > 0)
        {
            thirst -= Time.deltaTime * thirstSpeedMultiplier;
        }
        if(hunger <= 0 || thirst <= 0)
        {
            isDying = true;
        
        }
        else { isDying = false; }

        if(isDying == true)
        {
            health -= Time.deltaTime * healthSpeedMultiplier;
        }

        hungerBar.fillAmount = hunger / 100;
        thirstBar.fillAmount = thirst / 100;
        healthBar.fillAmount = health / 100;
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
        hunger = 100;
        thirst = 100;
    }

    public void AddHunger(float amount)
    {
        hunger += amount;
    }
    public void AddThirst(float amount)
    {
        thirst += amount;
    }
}
