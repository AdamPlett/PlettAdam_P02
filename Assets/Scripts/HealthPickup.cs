using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healthBack=10f;
    public AudioSource HPSFX;
    public ParticleSystem VFX;
    public void Update()
    {
        transform.Rotate(new Vector3(0, 75, 0) * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            VFX.Play();
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
