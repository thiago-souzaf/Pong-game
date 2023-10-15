using UnityEngine;
using UnityEngine.Events;

public class PlayerBorder : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            onTriggerEnter.Invoke();
        }
    }
}
