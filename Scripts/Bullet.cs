using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public float assistAngle = 10f;   
    public float searchRadius = 20f;

    public float maxDistance = 50f;
    Vector3 startPos;

    Rigidbody rb;

    void Start()
    {
        startPos = transform.position;

        rb = GetComponent<Rigidbody>();

        Vector3 shootDir = transform.forward;

        EnemyController target = FindNearestEnemy();
        if (target != null)
        {
            Vector3 dirToEnemy =
                (target.transform.position - transform.position).normalized;

            shootDir = Vector3.RotateTowards(
                shootDir,
                dirToEnemy,
                assistAngle * Mathf.Deg2Rad,
                0f
            );
        }

        rb.linearVelocity = shootDir * speed;

    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // ˆê’è‹——£‚ð’´‚¦‚½‚çÁ‚¦‚é
        if (Vector3.Distance(startPos, transform.position) > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    EnemyController FindNearestEnemy()
    {
        EnemyController[] enemies =
            FindObjectsByType<EnemyController>(FindObjectsSortMode.None);

        EnemyController nearest = null;
        float minDist = searchRadius;

        foreach (var e in enemies)
        {
            float dist = Vector3.Distance(transform.position, e.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = e;
            }
        }
        return nearest;
    }
}
