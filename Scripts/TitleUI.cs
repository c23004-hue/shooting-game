using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    // ゲーム再開（最初のステージ）
    public void StartGame()
    {
        StartCoroutine(LoadSceneAfterDelay("SampleScene", 1.5f));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
