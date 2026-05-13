using UnityEngine;
using TMPro;

public class RingScript : MonoBehaviour
{
    public Transform limiteIzquierdo;
    public Transform limiteDerecho;

    public float velocidad = 2f;
    public int score = 0;

    public TextMeshProUGUI scoreText;

    private Transform objetivoActual;

    private bool encestado = false;

    void Start()
    {
        objetivoActual = limiteDerecho;

        ActualizarScore();
    }

    void Update()
    {
        if (encestado)
        {
            velocidad += 0.5f;
            encestado = false;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            objetivoActual.position,
            velocidad * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, objetivoActual.position) < 0.01f)
        {
            objetivoActual = (objetivoActual == limiteDerecho)
                ? limiteIzquierdo
                : limiteDerecho;
        }
    }

    public void Encestar()
    {
        score += 10;

        encestado = true;

        ActualizarScore();
    }

    void ActualizarScore()
    {
        scoreText.text = "" + score;
    }
}