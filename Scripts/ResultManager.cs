using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI resultScoreText;

    void Start()
    {
        if (ScoreManager.instance != null)
        {
            resultScoreText.text =
                "SCORE : " + ScoreManager.instance.score.ToString();
        }
    }
}
