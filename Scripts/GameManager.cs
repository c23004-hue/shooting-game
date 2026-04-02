using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float timeLimit = 60f;
    float timer;

    public TextMeshProUGUI timeText;

    void Update()
    {
        timer += Time.deltaTime;

        float remainingTime = timeLimit - timer;
        remainingTime = Mathf.Max(remainingTime, 0);

        // ï\é¶çXêV
        timeText.text = "TIME : " + Mathf.CeilToInt(remainingTime).ToString();

        if (remainingTime <= 0)
        {
            GameClear();
        }
    }


    void GameClear()
    {
        StartCoroutine(LoadSceneAfterDelay("GameClear", 1.0f));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
