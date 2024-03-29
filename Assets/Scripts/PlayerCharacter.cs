﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
    private int health = 5;

    [SerializeField] private Text healthText;
    [SerializeField] private Text gameOverText;  

    void Start()
    {     
        gameOverText.enabled = false;
    }

    void Update()
    {
        if (health <= 0)
        {          
            gameOverText.enabled = true;
            StartCoroutine(Die());
        }
        healthText.text = "Health : " + health.ToString();
    }

    public void Hurt(int damage)
    {
        health -= damage;
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(5f);
        Application.LoadLevel(Application.loadedLevel);
    }
}
