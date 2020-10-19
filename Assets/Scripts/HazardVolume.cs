using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardVolume : MonoBehaviour
{
    public float _damage = 10f;
    private void OnTriggerEnter(Collider other)
    {
        //detect if it's the player
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        //if we found something valid, continue
        if (playerHealth != null )
        {
            playerHealth.Damage(_damage);
        }
    }
}
