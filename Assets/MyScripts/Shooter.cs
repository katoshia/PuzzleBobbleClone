using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bubblePrefab;
    public float rotationSpeed = 5f;
    public float maxRotation = 75f;
    public float shootForce = 10f;

    void Update()
    {
        AimCannon();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBubble();
        }
    }

    void AimCannon()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;

        float newRotation = transform.rotation.eulerAngles.z + rotation;
        newRotation = Mathf.Repeat(newRotation + 180f, 360f) - 180f;

        float clampedRotation = Mathf.Clamp(newRotation, -maxRotation, maxRotation);

        transform.rotation = Quaternion.Euler(0f, 0f, clampedRotation);
    }
    void ShootBubble()
    {
        // Instantiate a new bubble at the shooting point
        GameObject newBubble = Instantiate(bubblePrefab, shootingPoint.position, Quaternion.identity);

        // Get the Bubble component of the new bubble
        Bubble bubbleScript = newBubble.GetComponent<Bubble>();

        // The bubbleSprites array is accessed from the Bubble script on the new bubble
        // No need to assign it here if it's already set up in the Bubble prefab
        // bubbleScript.bubbleSprites = bubbleSprites;

        // Get the rigidbody component of the bubble
        Rigidbody2D bubbleRb = newBubble.GetComponent<Rigidbody2D>();

        // Calculate the shooting direction based on the shooter's rotation
        Vector2 shootingDirection = shootingPoint.up;

        // Apply force to move the bubble in the shooting direction
        bubbleRb.AddForce(shootingDirection * shootForce, ForceMode2D.Impulse);

        // Add a script to the new bubble to handle collisions with the grid
        bubbleScript.SetupBubbleGridInteraction();
    }
}
