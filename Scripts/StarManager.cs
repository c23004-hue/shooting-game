using UnityEngine;

public class StarManager : MonoBehaviour
{
    public GameObject starPrefab;
    public int starCount = 200;
    public float speed = 5f;

    public float rangeX = 30f;
    public float rangeY = 20f;
    public float startZ = 50f;
    public float endZ = -10f;

    GameObject[] stars;

    void Start()
    {
        stars = new GameObject[starCount];

        for (int i = 0; i < starCount; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-rangeX, rangeX),
                Random.Range(-rangeY, rangeY),
                Random.Range(endZ, startZ)
            );

            stars[i] = Instantiate(starPrefab, pos, Quaternion.identity, transform);
        }
    }

    void Update()
    {
        foreach (GameObject star in stars)
        {
            star.transform.position += Vector3.back * speed * Time.deltaTime;

            if (star.transform.position.z < endZ)
            {
                star.transform.position = new Vector3(
                    Random.Range(-rangeX, rangeX),
                    Random.Range(-rangeY, rangeY),
                    startZ
                );
            }
        }
    }
}
