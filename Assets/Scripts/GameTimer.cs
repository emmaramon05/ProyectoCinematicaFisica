using System.Collections;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI timerText;

    GameManager gameManager;

    public float gameTime = 180f; // 3 minutos

    private bool gameStarted = false;

    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (gameStarted)
        {
            gameTime -= Time.deltaTime;

            if (gameTime < 0)
            {
                gameTime = 0;
                gameStarted = false;

                Debug.Log("Fin del juego");
            }

            UpdateTimerUI();
        }
        if (gameTime <= 10)
        {
            timerText.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameTime -= 10f;
        }
        

    }


    IEnumerator StartCountdown()
    {
        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSeconds(1);

        countdownText.text = "2";
        yield return new WaitForSeconds(1);

        countdownText.text = "1";
        yield return new WaitForSeconds(1);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1);

        countdownText.gameObject.SetActive(false);

        gameStarted = true;
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}