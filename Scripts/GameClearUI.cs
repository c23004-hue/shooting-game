using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearUI : MonoBehaviour
{
    // タイトルへ戻る
    public void GoToTitle()
    {
        ScoreManager.instance.ResetScore();
        StartCoroutine(LoadSceneAfterDelay("Title", 1.5f));
    }

    // ゲーム再開（最初のステージ）
    public void RestartGame()
    {
        ScoreManager.instance.ResetScore();
        StartCoroutine(LoadSceneAfterDelay("SampleScene", 1.5f));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
