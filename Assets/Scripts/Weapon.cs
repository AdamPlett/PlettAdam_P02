using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    public ParticleSystem muzzleFlash;
    public AudioSource SFX;
    //adds range to firing
    //public float range = 100f;
    public Camera fpsCam;
    public float fireRate = 4f;
    private float nextTimeToFire = 0f; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();
        SFX.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit)) 
        {
            Debug.Log(hit.transform.name);
        }
    }
}
