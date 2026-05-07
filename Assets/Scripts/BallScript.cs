using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(LineRenderer))]
public class BallScript : MonoBehaviour
{
    [Header("Datos del disparo")]

    // Velocidad inicial del objeto
    public float velocidad = 10f;

    // Ángulo de disparo en grados
    public float angulo = 45f;

    // Gravedad manual
    public float gravedad = 9.81f;

    // Tiempo transcurrido desde el disparo
    private float tiempo;

    // Posición inicial del objeto
    private Vector3 posicionInicial;

    // Componentes de la velocidad
    private float vx;
    private float vy;

    private Rigidbody rb;

    public float rotationForce = 0.2f;
    public float fuerza = 10f;

    // =========================
    // VARIABLES PARA EL LINERENDERER
    // =========================

    // LineRenderer para dibujar la trayectoria
    private LineRenderer lineRenderer;

    // Número de puntos en la trayectoria
    public int puntosTrayectoria = 30;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Guardamos la posición donde inicia el objeto
        posicionInicial = transform.position;

        // Convertimos el ángulo a radianes
        // Mathf.Sin y Mathf.Cos trabajan en radianes
        float radianes = angulo * Mathf.Deg2Rad;

        // =========================
        // DESCOMPOSICIÓN DEL VECTOR
        // =========================

        // Componente horizontal
/*        vx = velocidad * Mathf.Cos(radianes);

        // Componente vertical
        vy = velocidad * Mathf.Sin(radianes);
*/
        // =========================
        // CONFIGURACIÓN DEL LINERENDERER
        // =========================

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = puntosTrayectoria;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        // Dibujar la trayectoria inicial
        DibujarTrayectoria();
    }

    void Update()
    {
        // Rotación manual sin Rigidbody
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -rotationForce, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationForce, Space.Self);
        }



        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right * -rotationForce, Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.right * rotationForce, Space.Self);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tiempo = 0f; // Reiniciamos el tiempo para el nuevo disparo

            Shoot();
        }
        DibujarTrayectoria();


    }

    private void FixedUpdate()
    {
       
    }

    void Shoot()
    {
        // Sumamos el tiempo que pasa entre frames
        tiempo += Time.deltaTime;

        // MOVIMIENTO EN X
        float x = posicionInicial.x + vx * tiempo;

        // MOVIMIENTO EN Y
        //
        // y = y0 + vy * t - 1/2 * g * t²
        //
        // Movimiento acelerado por gravedad
        float y = posicionInicial.y
                  + vy * tiempo
                  - 0.5f * gravedad * tiempo * tiempo;

        // =========================
        // ACTUALIZAR POSICIÓN
        // =========================

        transform.position = new Vector3(x, y, posicionInicial.z);
    }

    // =========================
    // MÉTODO PARA DIBUJAR LA TRAYECTORIA
    // =========================

    void DibujarTrayectoria()
    {
        Vector3[] puntos = new Vector3[puntosTrayectoria];

        // Dirección inicial basada en la rotación actual
        Vector3 direccionInicial = transform.forward * velocidad;

        // Descomposición de la dirección en componentes X e Y
        float vx = direccionInicial.x;
        float vy = direccionInicial.y;

        for (int i = 0; i < puntosTrayectoria; i++)
        {
            // Calculamos el tiempo para cada punto
            float t = i * 0.1f;

            // Calculamos la posición en X e Y
            float x = posicionInicial.x + vx * t;
            float y = posicionInicial.y + vy * t - 0.5f * gravedad * t * t;

            // Asignamos el punto calculado
            puntos[i] = new Vector3(x, y, posicionInicial.z);
        }

        // Asignamos los puntos al LineRenderer
        lineRenderer.SetPositions(puntos);
    }
}