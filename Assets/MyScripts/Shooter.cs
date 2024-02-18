////////
////using UnityEngine;

////public class Shooter : MonoBehaviour
////{
////    public Transform shootingPoint;
////    public GameObject[] bubblePrefabs;
////    public float rotationSpeed = 5f;
////    public float maxRotation = 75f;
////    public float shootForce = 10f;

////    private GameObject previewBubble;
////    private GameObject nextBubblePrefab;
////    private bool isBubbleShot = false;

////    void Update()
////    {
////        AimCannon();

////        if (Input.GetKeyDown(KeyCode.Space))
////        {
////            ShootBubble();
////        }
////    }

////    void AimCannon()
////    {
////        float horizontalInput = Input.GetAxis("Horizontal");
////        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;

////        float newRotation = transform.rotation.eulerAngles.z + rotation;
////        newRotation = Mathf.Repeat(newRotation + 180f, 360f) - 180f;

////        float clampedRotation = Mathf.Clamp(newRotation, -maxRotation, maxRotation);

////        transform.rotation = Quaternion.Euler(0f, 0f, clampedRotation);

////        // Instantiate or update the preview bubble only if no bubble has been shot
////        if (!isBubbleShot)
////        {
////            UpdatePreviewBubblePosition();
////        }
////    }

////    void UpdatePreviewBubblePosition()
////    {
////        // Check if the next bubble prefab is null
////        if (nextBubblePrefab == null)
////        {
////            // Select a random bubble prefab from the array for the next shot
////            nextBubblePrefab = bubblePrefabs[Random.Range(0, bubblePrefabs.Length)];
////        }

////        // Check if the preview bubble is null
////        if (previewBubble == null)
////        {
////            // Instantiate a new preview bubble using the next bubble prefab
////            previewBubble = Instantiate(nextBubblePrefab, shootingPoint.position, Quaternion.identity);
////        }

////        // Update the preview bubble's position and rotation
////        previewBubble.transform.position = shootingPoint.position;
////        previewBubble.transform.rotation = shootingPoint.rotation;
////    }

////    void ShootBubble()
////    {
////        // Instantiate a new bubble using the selected prefab at the shooting point
////        GameObject newBubble = Instantiate(nextBubblePrefab, shootingPoint.position, Quaternion.identity);

////        // Get the Bubble component of the new bubble
////        Bubble bubbleScript = newBubble.GetComponent<Bubble>();

////        // Get the rigidbody component of the bubble
////        Rigidbody2D bubbleRb = newBubble.GetComponent<Rigidbody2D>();

////        // Calculate the shooting direction based on the shooter's rotation
////        Vector2 shootingDirection = shootingPoint.up;

////        // Apply force to move the bubble in the shooting direction
////        bubbleRb.AddForce(shootingDirection * shootForce, ForceMode2D.Impulse);

////        // Add a script to the new bubble to handle collisions with the grid
////        bubbleScript.SetupBubbleGridInteraction();

////        // Destroy the preview bubble
////        DestroyPreviewBubble();

////        // Set the flag to indicate that a bubble has been shot
////        isBubbleShot = true;
////    }

////    void DestroyPreviewBubble()
////    {
////        if (previewBubble != null)
////        {
////            Destroy(previewBubble);
////            previewBubble = null;
////        }
////    }
////}
//using UnityEngine;

//public class Shooter : MonoBehaviour
//{
//    public Transform shootingPoint;
//    public GameObject[] bubblePrefabs;
//    public float rotationSpeed = 5f;
//    public float maxRotation = 75f;
//    public float shootForce = 10f;

//    private GameObject previewBubble;

//    void Update()
//    {
//        AimCannon();

//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            ShootBubble();
//        }
//    }

//    void AimCannon()
//    {
//        float horizontalInput = Input.GetAxis("Horizontal");
//        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;

//        float newRotation = transform.rotation.eulerAngles.z + rotation;
//        newRotation = Mathf.Repeat(newRotation + 180f, 360f) - 180f;

//        float clampedRotation = Mathf.Clamp(newRotation, -maxRotation, maxRotation);

//        transform.rotation = Quaternion.Euler(0f, 0f, clampedRotation);

//        // Update the preview bubble
//        UpdatePreviewBubblePosition();
//    }

//    void UpdatePreviewBubblePosition()
//    {
//        // Check if the preview bubble is null
//        if (previewBubble == null)
//        {
//            // Select a random bubble prefab from the array for the preview
//            GameObject nextBubblePrefab = bubblePrefabs[Random.Range(0, bubblePrefabs.Length)];

//            // Instantiate a new preview bubble using the selected prefab
//            previewBubble = Instantiate(nextBubblePrefab, shootingPoint.position, Quaternion.identity);
//        }

//        // Update the preview bubble's position and rotation
//        previewBubble.transform.position = shootingPoint.position;
//        previewBubble.transform.rotation = shootingPoint.rotation;
//    }

//    void ShootBubble()
//    {
//        // Select a random bubble prefab from the array for the next shot
//        GameObject nextBubblePrefab = bubblePrefabs[Random.Range(0, bubblePrefabs.Length)];

//        // Instantiate a new bubble using the selected prefab at the shooting point
//        GameObject newBubble = Instantiate(nextBubblePrefab, shootingPoint.position, Quaternion.identity);

//        // Get the Bubble component of the new bubble
//        Bubble bubbleScript = newBubble.GetComponent<Bubble>();

//        // Get the rigidbody component of the bubble
//        Rigidbody2D bubbleRb = newBubble.GetComponent<Rigidbody2D>();

//        // Calculate the shooting direction based on the shooter's rotation
//        Vector2 shootingDirection = shootingPoint.up;

//        // Apply force to move the bubble in the shooting direction
//        bubbleRb.AddForce(shootingDirection * shootForce, ForceMode2D.Impulse);

//        // Add a script to the new bubble to handle collisions with the grid
//        bubbleScript.SetupBubbleGridInteraction();

//        // Destroy the preview bubble
//        Destroy(previewBubble);

//        // Set the preview bubble to null
//        previewBubble = null;
//    }
//}
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject[] bubblePrefabs;
    public float rotationSpeed = 5f;
    public float maxRotation = 75f;
    public float shootForce = 10f;

    private GameObject previewBubble;

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

        // Update the preview bubble
        UpdatePreviewBubblePosition();
    }

    void UpdatePreviewBubblePosition()
    {
        // Check if the preview bubble is null
        if (previewBubble == null)
        {
            // Select a random bubble prefab from the array for the next shot
            GameObject nextBubblePrefab = bubblePrefabs[Random.Range(0, bubblePrefabs.Length)];

            // Instantiate a new preview bubble using the selected prefab
            previewBubble = Instantiate(nextBubblePrefab, shootingPoint.position, Quaternion.identity);
        }

        // Update the preview bubble's position and rotation
        previewBubble.transform.position = shootingPoint.position;
        previewBubble.transform.rotation = shootingPoint.rotation;
    }

    void ShootBubble()
    {
        // Instantiate a new bubble using the preview bubble as the prefab at the shooting point
        GameObject newBubble = Instantiate(previewBubble, shootingPoint.position, Quaternion.identity);

        // Get the Bubble component of the new bubble
        Bubble bubbleScript = newBubble.GetComponent<Bubble>();

        // Get the rigidbody component of the bubble
        Rigidbody2D bubbleRb = newBubble.GetComponent<Rigidbody2D>();

        // Calculate the shooting direction based on the shooter's rotation
        Vector2 shootingDirection = shootingPoint.up;

        // Apply force to move the bubble in the shooting direction
        bubbleRb.AddForce(shootingDirection * shootForce, ForceMode2D.Impulse);

        // Add a script to the new bubble to handle collisions with the grid
        bubbleScript.SetupBubbleGridInteraction();

        // Destroy the preview bubble
        Destroy(previewBubble);

        // Set the preview bubble to null
        previewBubble = null;
    }
}




