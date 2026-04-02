using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnZ = 100f;
    public float spawnRangeX = 10f;
    public float spawnRangeY = 5f;

    public float spawnInterval = 3f;
    public int maxEnemies = 5;

    public Transform player;

    public float difficultyUpTime = 10f; // ‰½•b‚²‚Æ‚É“ïˆÕ“xUP

    private int currentEnemies = 0;

    void Start()
    {

        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);

        // “ïˆÕ“xã¸ŠJn
        StartCoroutine(DifficultyUp());
    }

    void SpawnEnemy()
    {
        if (player == null) return;
        if (currentEnemies >= maxEnemies) return;

        float x = Random.Range(-spawnRangeX, spawnRangeX);
        float y = Random.Range(0, spawnRangeY);
        Vector3 spawnPos = new Vector3(x, y, spawnZ);

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemy.transform.LookAt(player.position);

        EnemyController ec = enemy.GetComponent<EnemyController>();
        if (ec != null)
        {
            ec.OnDestroyed += () => currentEnemies--;
        }

        currentEnemies++;
    }

    IEnumerator DifficultyUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(difficultyUpTime);

            maxEnemies+=2;  // “¯—N‚«”UP

            spawnInterval = Mathf.Max(0.5f, spawnInterval - 0.3f); // ŠÔŠu’Zk

            // InvokeRepeating ‚ğXV‚µ’¼‚·
            CancelInvoke("SpawnEnemy");
            InvokeRepeating("SpawnEnemy", 0f, spawnInterval);

            Debug.Log($"“ïˆÕ“xUP! maxEnemies={maxEnemies}, interval={spawnInterval}");
        }
    }
}
