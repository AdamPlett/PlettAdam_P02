using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float PlayerHP = 100f;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHP <= 0 || Input.GetKeyDown(KeyCode.E))
        {
            Die();
        }
    }
    public void Damage(float damage)
    {
        PlayerHP -= damage;
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
