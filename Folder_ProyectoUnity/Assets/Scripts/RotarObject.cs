using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed;
    public float moveSpeed;
    public float moveAmplitude;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
 
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}