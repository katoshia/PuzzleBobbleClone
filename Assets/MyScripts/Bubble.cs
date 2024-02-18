using UnityEngine;

public class Bubble : MonoBehaviour
{
    public int scoreVal = 10;
    public bool isFixed;
    public bool isConnected;

    private bool isSnapped = false;

    private void Start()
    {
        // Configure Rigidbody2D for bouncing and sticking
        Rigidbody2D bubbleRb = GetComponent<Rigidbody2D>();
        if (bubbleRb != null)
        {
            // Adjust the bounciness (set according to your preference)
            bubbleRb.sharedMaterial.bounciness = 0.1f;

            // Make the bubbles stick to the ceiling by adjusting gravity scale
            bubbleRb.gravityScale = 0f; // You can experiment with different values
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            Debug.Log("Bubble tag collision detected.");
            // Check if the collided bubble has the same sprite name
            if (GetSpriteName() == collision.gameObject.GetComponent<Bubble>().GetSpriteName())
            {
                // Pop both bubbles if they have the same color
                Destroy(gameObject);
                Destroy(collision.gameObject);

                // Check and destroy connected bubbles
                CheckAndDestroyConnectedBubbles();
            }
            else
            {
                // Snap the shot bubble to a fixed position based on the collision
                SnapToFixedPosition(collision);
            }
        }
        else if (collision.gameObject.CompareTag("BubbleContainer"))
        {
            // Snap the bubble to the nearest position within the bubble container
            SnapToContainer();

            // Check and destroy connected bubbles after snapping
            CheckAndDestroyConnectedBubbles();
        }
    }


    public string GetSpriteName()
    {
        return GetComponent<SpriteRenderer>().sprite.name;
    }

    private void SnapToContainer()
    {
        if (!isSnapped)
        {
            // Get the position of the collision in world coordinates
            Vector3 collisionPosition = transform.position;

            // Snap to the nearest position within the bubble container
            // You can customize this logic based on your container's shape and layout
            float snappedX = Mathf.Round(collisionPosition.x);
            float snappedY = Mathf.Round(collisionPosition.y);

            // Set the snapped position
            transform.position = new Vector3(snappedX, snappedY, collisionPosition.z);

            // Mark as snapped to prevent further movement
            isSnapped = true;
        }
    }

    private void SnapToFixedPosition(Collision2D collision)
    {
        if (!isSnapped)
        {
            // Get the position of the collision in world coordinates
            Vector3 collisionPosition = transform.position;

            // Get the collided bubble's position
            Vector3 collidedBubblePosition = collision.transform.position;

            // Calculate the relative position of the shot bubble to the collided bubble
            Vector3 relativePosition = collisionPosition - collidedBubblePosition;

            // Calculate the snapped position based on custom logic
            Vector3 snappedPosition = CalculateCustomSnapPosition(relativePosition, collidedBubblePosition);

            // Set the snapped position
            transform.position = snappedPosition;

            // Mark as snapped to prevent further movement
            isSnapped = true;
        }
    }

    private Vector3 CalculateCustomSnapPosition(Vector3 relativePosition, Vector3 collidedBubblePosition)
    {
        // Custom logic to determine the snapped position based on the relative position
        // You can adjust this logic based on your desired snapping behavior

        float diagonalThreshold = 0.1f * 0.17f; // Adjust this threshold based on your preference

        // Check if the shot bubble hits the top-left side
        if (relativePosition.x < -diagonalThreshold && relativePosition.y > diagonalThreshold)
        {
            // Snap to the top-left side of the collided bubble
            return new Vector3(collidedBubblePosition.x - 0.17f, collidedBubblePosition.y + 0.17f, collidedBubblePosition.z);
        }
        // Check if the shot bubble hits the top-right side
        else if (relativePosition.x > diagonalThreshold && relativePosition.y > diagonalThreshold)
        {
            // Snap to the top-right side of the collided bubble
            return new Vector3(collidedBubblePosition.x + 0.17f, collidedBubblePosition.y + 0.17f, collidedBubblePosition.z);
        }
        // Check if the shot bubble hits the bottom-left side
        else if (relativePosition.x < -diagonalThreshold && relativePosition.y < -diagonalThreshold)
        {
            // Snap to the bottom-left side of the collided bubble
            return new Vector3(collidedBubblePosition.x - 0.17f, collidedBubblePosition.y - 0.17f, collidedBubblePosition.z);
        }
        // Check if the shot bubble hits the bottom-right side
        else if (relativePosition.x > diagonalThreshold && relativePosition.y < -diagonalThreshold)
        {
            // Snap to the bottom-right side of the collided bubble
            return new Vector3(collidedBubblePosition.x + 0.17f, collidedBubblePosition.y - 0.17f, collidedBubblePosition.z);
        }
        // Add more conditions as needed...

        // If none of the conditions match, return the original position
        return collidedBubblePosition;
    }

    private void CheckAndDestroyConnectedBubbles()
    {
        // Implementation remains the same as before
        // ...
    }

    private bool IsConnected(GameObject obj1, GameObject obj2)
    {
        // Implementation remains the same as before
        // ...
        return false;
    }

    public void SetupBubbleGridInteraction() { }
}
