using UnityEngine;
using UnityEngine.Tilemaps;

public class Bubble : MonoBehaviour
{
    public int scoreVal = 10;
    public bool isFixed;
    public bool isConnected;

    public Sprite[] bubbleSprites;
    public Tilemap bubbleGrid;
    private void Start()
    {
        // Attempt to find the BubbleBoard in the scene
        GameObject bubbleBoardObject = GameObject.Find("BubbleBoard");

        // Check if the object is found and has the BubbleBoard script
        if (bubbleBoardObject != null)
        {
            bubbleGrid = bubbleBoardObject.GetComponent<BubbleBoard>()?.bubbleBoardTilemap;
        }
        else
        {
            Debug.LogError("BubbleBoard object not found.");
        }

        // Ensure the array is not null and has at least one element
        if (bubbleSprites != null && bubbleSprites.Length > 0)
        {
            SetRandomSprite();
        }
        else
        {
            Debug.LogError("BubbleSprites array is not assigned or empty.");
        }
    }

    public void SetRandomSprite()
    {
        int randomIndex = Random.Range(0, bubbleSprites.Length);
        Sprite selectedSprite = bubbleSprites[randomIndex];

        GetComponent<SpriteRenderer>().sprite = selectedSprite;
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
            }
        }
        else if (collision.gameObject.CompareTag("BubbleGrid"))
        {
            // Snap the bubble to the nearest grid cell when colliding with the bubble grid
            SnapToGrid();
        }
    }

    public string GetSpriteName()
    {
        return GetComponent<SpriteRenderer>().sprite.name;
    }

    private void SnapToGrid()
    {
        // Get the position of the collision in world coordinates
        Vector3 collisionPosition = transform.position;

        // Snap to the nearest grid cell position
        float gridCellSize = 1.0f; // Adjust this value based on your grid size
        float snappedX = Mathf.Round(collisionPosition.x / gridCellSize) * gridCellSize;
        float snappedY = Mathf.Round(collisionPosition.y / gridCellSize) * gridCellSize;

        // Set the snapped position
        transform.position = new Vector3(snappedX, snappedY, collisionPosition.z);
    }

    public void SetupBubbleGridInteraction()
    {
        if (bubbleGrid != null)
            SnapToGrid();
        else
            Debug.Log("Bubble grid reference not set");

    }
}
