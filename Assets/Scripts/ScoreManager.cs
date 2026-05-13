using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;

    public TMP_Text scoreGameplayText;
    public TMP_Text scoreFinalText;

    public GameObject finalCanvas;

    void Update()
    {
        scoreGameplayText.text = score.ToString();
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void ShowFinalScore()
    {
        finalCanvas.SetActive(true);
        scoreFinalText.text = score.ToString();
    }
}