using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject explosionPrefab;
    public int scoreValue = 10;

    public Action OnDestroyed;
    public AudioClip hitSE;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        if (transform.position.z < -20f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            // ”í’eSE
            if (hitSE != null && audioSource != null)
            {
                audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
                audioSource.PlayOneShot(hitSE);
            }

            // ”š”­
            if (explosionPrefab != null)
            {
                GameObject explosion = Instantiate(
                    explosionPrefab,
                    transform.position,
                    Quaternion.identity
                );
                Destroy(explosion, 2f);
            }

            // ƒXƒRƒA
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(scoreValue);
            }

            // ’eíœ
            Destroy(other.gameObject);

            OnDestroyed?.Invoke();

            // Ž©•ªíœ
            Destroy(gameObject, 0.1f);
        }
    }
}
