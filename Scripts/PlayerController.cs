using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float padding = 0.05f; // ‰æ–Ê’[‚Ì—]”’
    public int maxHP = 100;
    public int currentHP;

    public Image lifeGage;
    public CameraShake cameraShake;
    public AudioSource hitSE;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
        currentHP = maxHP;
        UpdateHPUI();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime);

        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);

        viewportPos.x = Mathf.Clamp(viewportPos.x, padding, 1f - padding);
        viewportPos.y = Mathf.Clamp(viewportPos.y, padding, 1f - padding);

        Vector3 fixedPos = cam.ViewportToWorldPoint(viewportPos);
        fixedPos.z = transform.position.z;

        transform.position = fixedPos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(20);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {

        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0);
        UpdateHPUI();

        if (hitSE != null)
        {
            hitSE.Play();
        }

        if (cameraShake != null)
        {
            cameraShake.ShakeImpact();
        }

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void UpdateHPUI()
    {
        lifeGage.fillAmount = (float)currentHP / maxHP;
    }

    void Die()
    {
        Debug.Log("Player Dead");
        StartCoroutine(LoadSceneAfterDelay("GameOver", 0.4f));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
