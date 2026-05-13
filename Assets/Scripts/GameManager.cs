using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject canvasPause;
    public GameObject canvasControles;
    public GameObject canvasFinish;
    public float gameTime = 180f;

    public TextMeshProUGUI scoreText;
    public RingScript RingScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasPause.SetActive(false);
        canvasControles.SetActive(true);
        Time.timeScale = 1f;
        canvasFinish.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pausa();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            canvasControles.SetActive(!canvasControles.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameTime -= 10f;
        }
        if (gameTime == 0)
        {
            Finish();

        }
    }

    void Pausa()
    {
        canvasPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reanudar()
    {
        canvasPause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Finish()
    {
        canvasFinish.SetActive(true);
        Time.timeScale = 0f;
        scoreText.text = RingScript.score.ToString();
    }
}
