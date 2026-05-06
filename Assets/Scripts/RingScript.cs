using UnityEngine;

public class RingScript : MonoBehaviour
{
    public float velocidad = 2f;
    public float rangoMovimiento = 5f;
    public float tiempoCambio = 2f;

    private float objetivoX;
    private float tiempoSiguienteCambio;

    void Start()
    {
        ElegirNuevoObjetivo();
    }

    void Update()
    {
        // Mover hacia el objetivo
        Vector3 posicion = transform.position;
        posicion.x = Mathf.MoveTowards(posicion.x, objetivoX, velocidad * Time.deltaTime);
        transform.position = posicion;

        // Cambiar objetivo cada cierto tiempo
        if (Time.time >= tiempoSiguienteCambio)
        {
            ElegirNuevoObjetivo();
        }
    }

    void ElegirNuevoObjetivo()
    {
        float xInicial = transform.position.x;
        objetivoX = xInicial + Random.Range(-rangoMovimiento, rangoMovimiento);
        tiempoSiguienteCambio = Time.time + tiempoCambio;
    }
}