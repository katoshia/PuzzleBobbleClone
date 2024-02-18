using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject[] bubblePrefabs;
    public Transform spawnPoint;
    public int rowsTut = 3; // tutorial rows
    public float yOffset = 1.5f; // offset distance y between rows
    public float xOffset = 1.0f; // offset distance x between bubbles
    public GameObject bubblesContainer; // container to hold the bubbles on the screen for the board.
    void Start()
    {
        if (bubblesContainer == null)
        {
            Debug.LogError("Bubbles container not assigned yet.");
            return;
        }
        Debug.Log("Starting to spawn bubbles.");
        SpawnTutorialBubbles();
    }

    void SpawnTutorialBubbles()
    {
        int bubblesPerRow = 10; // Number of bubbles across
        float hexRadius = 0.02f; // Radius of the hexagon (half the distance between centers of two adjacent bubbles)

        for (int row = 0; row < rowsTut; row++) // 3 rows
        {
            for (int col = 0; col < bubblesPerRow; col++) // 10 bubbles across
            {
                float xOffsetHex = hexRadius * Mathf.Sqrt(3f);
                float xPos = col * xOffsetHex + (row % 2 == 1 ? xOffsetHex / 2f : 0f);
                float yPos = row * hexRadius * 1.5f;

                Vector3 spawnPosition = spawnPoint.position + new Vector3(xPos, yPos, 0f);

                // Calculate color index based on row and col
                //int colorIndex = (row * bubblesPerRow + col) % bubblePrefabs.Length;
                int colorIndex = Random.Range(0, 3);
                GameObject newBubble = Instantiate(bubblePrefabs[colorIndex], spawnPosition, Quaternion.identity, bubblesContainer.transform);

                // Customize bubble properties (e.g., color) based on colorIndex
                SpriteRenderer bubbleComponent = newBubble.GetComponent<SpriteRenderer>();
                if (bubbleComponent != null)
                {
                    bubbleComponent.color = GetColorForcolorIndex(colorIndex);
                }
            }
        }
    }
    Color GetColorForcolorIndex(int colorIndex)
    {
        switch (colorIndex)
        {
            case 0:
                return new Color(1.0f, 1.0f, 0.0f, 1.0f); // Yellow
            case 1:
                return new Color(1.0f, 0.0f, 0.0f, 1.0f); // Red
            case 2:
                return new Color(0.0f, 0.0f, 1.0f, 1.0f); // Blue
            case 3:
                return new Color(0.0f, 1.0f, 0.0f, 1.0f); // Green
            case 4:
                return new Color(0.5f, 0.0f, 0.5f, 1.0f); // Purple (using a mix of red and blue)
            default:
                return new Color(1.0f, 1.0f, 1.0f, 1.0f); // White
        }
    }

}

