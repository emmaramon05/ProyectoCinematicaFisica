using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject canvasPause;
    public GameObject canvasControles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasPause.SetActive(false);
        canvasControles.SetActive(true);
        Time.timeScale = 1f;


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
}
