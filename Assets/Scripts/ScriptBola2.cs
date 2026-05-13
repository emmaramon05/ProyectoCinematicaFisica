using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LineRenderer))]
public class ScriptBola2 : MonoBehaviour
{
    [Header("Disparo")]
    public float velocidad = 10f;
    public float gravedad = 9.81f;

    [Header("Rotacion")]
    public float rotationForce = 2f;

    [Header("Trayectoria")]
    public int puntosTrayectoria = 30;
    public float tiempoEntrePuntos = 0.1f;

    [Header("Reset")]
    public Transform respawnPoint;

    private Rigidbody rb;
    private LineRenderer lineRenderer;

    private bool launch = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();

        rb.useGravity = true;
        rb.isKinematic = true;

        // IMPORTANTE para evitar atravesar objetos
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        lineRenderer.positionCount = puntosTrayectoria;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        DibujarTrayectoria();
    }

    void Update()
    {
        if (!launch)
        {
            Rotacion();

            DibujarTrayectoria();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBall();
        }
    }

    void Rotacion()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -rotationForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right * -rotationForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.right * rotationForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            velocidad += Time.deltaTime * 5f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            velocidad -= Time.deltaTime * 5f;
        }
    }

    void Shoot()
    {
        launch = true;

        rb.isKinematic = false;

        // Direccion hacia delante
        Vector3 direccion = transform.forward;

        // Aplicar velocidad inicial
        rb.linearVelocity = direccion * velocidad;
    }

    public void ResetBall()
    {
        launch = false;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.isKinematic = true;

        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
    }

    void DibujarTrayectoria()
    {
        Vector3[] puntos = new Vector3[puntosTrayectoria];

        Vector3 velocidadInicial = transform.forward * velocidad;

        for (int i = 0; i < puntosTrayectoria; i++)
        {
            float t = i * tiempoEntrePuntos;

            Vector3 punto =
                transform.position +
                velocidadInicial * t +
                0.5f * Physics.gravity * t * t;

            puntos[i] = punto;
        }

        lineRenderer.SetPositions(puntos);
    }
}