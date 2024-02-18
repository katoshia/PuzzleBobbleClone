using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform shootingPoint;  // Reference to the point where the bubbles will be spawned
    public GameObject bubblePrefab;  // Reference to the bubble prefab
    public float rotationSpeed = 5f;  // Adjust the rotation speed as needed
    public float shootForce = 10f;
    public float maxRotation = 75f;
    // Update is called once per frame
    void Update()
    {
        AimCannon();  // Implement a function to handle aiming

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBubble();  // Implement a function to handle shooting bubbles
        }
    }
    void AimCannon()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;

        // Calculate the new rotation after applying input
        float newRotation = transform.rotation.eulerAngles.z + rotation;

        // Normalize the rotation to be between -180 and 180 degrees
        newRotation = Mathf.Repeat(newRotation + 180f, 360f) - 180f;

        // Clamp the rotation between -maxRotation and maxRotation
        float clampedRotation = Mathf.Clamp(newRotation, -maxRotation, maxRotation);

        // Apply the clamped rotation
        transform.rotation = Quaternion.Euler(0f, 0f, clampedRotation);
    }
    //void AimCannon()
    //{
    //    float horizontalInput = Input.GetAxis("Horizontal");
    //    float rotation = horizontalInput * rotationSpeed * Time.deltaTime;

    //    // Calculate the new rotation after applying input
    //    float newRotation = transform.rotation.eulerAngles.z + rotation;

    //    // Clamp the rotation between -maxRotation and maxRotation
    //    float clampedRotation = Mathf.Clamp(newRotation, -maxRotation, maxRotation);

    //    // Apply the clamped rotation
    //    transform.rotation = Quaternion.Euler(0f, 0f, clampedRotation);
    //}
    //void AimCannon()
    //{
    //    float horizontalInput = Input.GetAxis("Horizontal");
    //    float rotation = horizontalInput * rotationSpeed * Time.deltaTime;

    //    // Limit the rotation between -75 and 75 degrees on the Z-axis
    //    float clampedRotation = Mathf.Clamp(transform.rotation.eulerAngles.z + rotation, -75f, 75f);

    //    // Apply the clamped rotation
    //    transform.rotation = Quaternion.Euler(0f, 0f, clampedRotation);
    //}

    void ShootBubble()
    {
        // Calculate the shooting direction based on the rotation of the shooter
        Vector2 shootDirection = shootingPoint.up;

        // Instantiate a new bubble at the shooting point
        GameObject newBubble = Instantiate(bubblePrefab, shootingPoint.position, Quaternion.identity);
        Rigidbody2D bubbleRb = newBubble.GetComponent<Rigidbody2D>();

        if (bubbleRb != null)
        {
            // Apply force in the calculated direction
            bubbleRb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }
    }
}
