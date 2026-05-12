using UnityEngine;

public class BasketTrigger : MonoBehaviour
{
    public RingScript ringScript;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bola"))
        {
            ringScript.Encestar();
        }
    }
}