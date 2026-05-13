using UnityEngine;

public class BasketTrigger : MonoBehaviour
{
    public RingScript ringScript;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bola"))
        {
            ringScript.Encestar();
            other.GetComponent<ScriptBola2>().Invoke("ResetBall", 1f);

        }
    }
}