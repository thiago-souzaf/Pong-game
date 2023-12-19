using UnityEngine;

public class GlobalLightRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.up);
    }
}
