using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    public ParticleSystem muzzleFlash;
    public AudioSource shootSound;
    public AudioSource hitSound;
    public GameObject levelController;
    //adds range to firing
    //public float range = 100f;
    public Camera fpsCam;
    public float fireRate = 5f;
    private float nextTimeToFire = 0f;
    Level01Controller controller;

    // Update is called once per frame
    private void Awake()
    {
        controller = levelController.GetComponent<Level01Controller>();
    }
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
        shootSound.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit)) 
        {
            Debug.Log(hit.transform.name);

            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
            if(enemy != null)
            {
                if (controller != null)
                {
                    controller.IncreaseScore(5);
                }
                hitSound.Play();
                enemy.TakeDamage(damage);
            }
        }
    }
}
