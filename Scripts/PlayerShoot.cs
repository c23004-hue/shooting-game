using UnityEngine;
using UnityEngine.Audio;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform shootPoint;    
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;  

    private float nextFireTime = 0f;

    public AudioClip shootSE;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * bulletSpeed;

        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        if (shootSE != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSE);
        }

        Destroy(bullet, 5f);

  
        
           

       
    }
}
