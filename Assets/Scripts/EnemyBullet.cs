using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public AudioSource hitSound;
    public float _damage = 10f;
    int collisions = 0;
    private void OnTriggerEnter(Collider other)
    {
        collisions++;
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Damage(_damage);
            Debug.Log("damage applied");
        }
        if (collisions > 1)
        {
            hitSound.Play();
            Invoke(nameof(DestroyBullet), .25f);
        }
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
