using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    void Start()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.SetScoreText(
                GetComponent<TextMeshProUGUI>()
            );
        }
    }
}
