using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(SphereCollider))]
public class BallScript : MonoBehaviour
{
    [Header("Datos del disparo")]
    public float velocidad = 10f;
    public float angulo = 45f;
    public float gravedad = 9.81f;

    private float tiempo;
    private Vector3 posicionInicial;

    public bool launch = false;
    private bool usingPhysics = false;

    private float vx;
    private float vz;
    private float vy;

    private Rigidbody rb;
    private SphereCollider esfera;

    public float rotationForce = 0.2f;
    public float fuerza = 10f;
    public float incrementoVelocidad = 2f;

    [Header("Color trayectoria")]
    public float velocidadMinColor = 0f;
    public float velocidadMaxColor = 30f;

    [Header("Reset")]
    public Transform respawnPoint;

    private LineRenderer lineRenderer;
    public int puntosTrayectoria = 30;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        esfera = GetComponent<SphereCollider>();

        rb.isKinematic = true;
        rb.useGravity = false;

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.positionCount = puntosTrayectoria;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        posicionInicial = transform.position;
        DibujarTrayectoria();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetBall();

        if (usingPhysics) return;

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up * -rotationForce, Space.Self);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * rotationForce, Space.Self);
        if (Input.GetKey(KeyCode.W))
            transform.Rotate(Vector3.right * -rotationForce, Space.Self);
        if (Input.GetKey(KeyCode.S))
            transform.Rotate(Vector3.right * rotationForce, Space.Self);

        if (Input.GetKey(KeyCode.Q))
            velocidad += incrementoVelocidad * Time.deltaTime;
        if (Input.GetKey(KeyCode.E))
            velocidad -= incrementoVelocidad * Time.deltaTime;

        if (Input.GetKey(KeyCode.Z))
            transform.position += Vector3.right * Time.deltaTime;
        if (Input.GetKey(KeyCode.C))
            transform.position -= Vector3.right * Time.deltaTime;

        if (!launch)
        {
            posicionInicial = transform.position;
            DibujarTrayectoria();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tiempo = 0f;
            launch = true;
            lineRenderer.positionCount = 0;

            vx = velocidad * Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
            vz = velocidad * Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.x);
            vy = velocidad * Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.x);
        }

    }

    void FixedUpdate()
    {
        if (!launch || usingPhysics) return;

        tiempo += Time.fixedDeltaTime;

        float x = posicionInicial.x + vx * tiempo;
        float z = posicionInicial.z + vz * tiempo;
        float y = posicionInicial.y + vy * tiempo - 0.5f * gravedad * tiempo * tiempo;

        Vector3 nuevaPosicion = new Vector3(x, y, z);
        Vector3 desplazamiento = nuevaPosicion - transform.position;
        float distancia = desplazamiento.magnitude;

        if (distancia > 0.001f)
        {
            float radio = esfera.radius * transform.lossyScale.x;

            // Barrer el espacio entre posicion actual y nueva para detectar cualquier collider
            if (Physics.SphereCast(
                transform.position,
                radio,
                desplazamiento.normalized,
                out RaycastHit hit,
                distancia,
                Physics.DefaultRaycastLayers,
                QueryTriggerInteraction.Ignore))
            {
                ActivarFisica();
                return;
            }
        }

        transform.position = nuevaPosicion;
    }

    void ActivarFisica()
    {
        if (usingPhysics) return;

        Vector3 velocidadActual = new Vector3(vx, vy - gravedad * tiempo, vz);

        rb.isKinematic = false;
        rb.useGravity = true;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.linearVelocity = velocidadActual;

        usingPhysics = true;
    }

    // Fallback por si el SphereCast falla en algun caso extremo
    void OnCollisionEnter(Collision collision)
    {
        ActivarFisica();
    }

    public void ResetBall()
    {
        launch = false;
        usingPhysics = false;
        tiempo = 0f;

        rb.isKinematic = true;
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
            transform.rotation = respawnPoint.rotation;
        }

        lineRenderer.positionCount = puntosTrayectoria;
        DibujarTrayectoria();
    }

    void DibujarTrayectoria()
    {
        Vector3[] puntos = new Vector3[puntosTrayectoria];

        float vxT = velocidad * Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
        float vzT = velocidad * Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.x);
        float vyT = velocidad * Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.x);

        for (int i = 0; i < puntosTrayectoria; i++)
        {
            float t = i * 0.1f;

            float x = transform.position.x + vxT * t;
            float z = transform.position.z + vzT * t;
            float y = transform.position.y + vyT * t - 0.5f * gravedad * t * t;

            puntos[i] = new Vector3(x, y, z);
        }

        float tColor = Mathf.InverseLerp(velocidadMinColor, velocidadMaxColor, velocidad);
        Color color = Color.Lerp(Color.green, Color.red, tColor);
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;

        lineRenderer.SetPositions(puntos);
    }
}
