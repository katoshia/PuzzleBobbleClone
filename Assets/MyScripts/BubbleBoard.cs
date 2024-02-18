using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BubbleBoard : MonoBehaviour
{
    public Tilemap bubbleBoardTilemap;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collsion detected.");
        if (other.CompareTag("Bubble"))
        {
            Debug.Log("Bubble found.");
            // Get the sprite name of the colliding bubble
            string bubbleSpriteName = other.GetComponent<Bubble>().GetSpriteName();
            Debug.Log("Bubble sprite name: " + bubbleSpriteName);
            // Get the tile position in the world coordinates
            Vector3Int tilePosition = bubbleBoardTilemap.WorldToCell(other.transform.position);

            // Get the TileBase at the specified position
            TileBase tile = bubbleBoardTilemap.GetTile(tilePosition);

            // Check if the tile exists and compare its sprite name
            if (tile != null && bubbleSpriteName == tile.name)
            {
                Debug.Log("sprites match...");
                // Destroy both the tile and the colliding bubble
                Destroy(other.gameObject);  // Destroy the colliding bubble
                bubbleBoardTilemap.SetTile(tilePosition, null);  // Destroy the tile
            }
        }
    }

}
