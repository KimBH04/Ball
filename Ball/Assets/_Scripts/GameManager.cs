using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private long score;

    [SerializeField] private TextMeshProUGUI scoreTxt;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetScore(long addScore)
    {
        score += addScore;
        if (score < 0)
        {
            score = 0;
        }

        scoreTxt.text = $"Score : {score:#,###}";
    }
}
