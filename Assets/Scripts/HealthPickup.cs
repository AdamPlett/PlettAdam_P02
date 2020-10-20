using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healthBack=10f;
    public AudioSource HPSFX;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            HPSFX.Play();
            playerHealth.giveHealth(healthBack);
            Debug.Log("Giving health");
            Invoke(nameof(DestroyPickup), .35f);
        }
    }
    private void DestroyPickup()
    {
        Destroy(gameObject);
    }
}
