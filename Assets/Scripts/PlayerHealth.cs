﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float PlayerHP = 100f;
    public GameObject Player;
    public Slider slider;
    public AudioSource hit;
    public AudioSource death;
    // Start is called before the first frame update

    public void SetHealth()
    {
        slider.value = PlayerHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHP <= 0 || Input.GetKeyDown(KeyCode.E))
        {
            death.Play();
            Die();
        }
    }
    public void Damage(float damage)
    {
        hit.Play();
        PlayerHP -= damage;
        SetHealth();
    }
    public void giveHealth(float addedHealth)
    {
        if (PlayerHP+addedHealth<=100)
        {
            PlayerHP += addedHealth;
            SetHealth();
        }
    }
    void Die()
    {
        StartCoroutine(DeathSequence());
    }
    IEnumerator DeathSequence()
    {
        Player.SetActive(false);
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Level01");
    }
}
