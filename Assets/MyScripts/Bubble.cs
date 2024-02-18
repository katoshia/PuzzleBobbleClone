using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    public int scoreVal = 10;
    public bool isFixed;
    public bool isConnected;

    public BubbleColor bubbleColor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
            Destroy(gameObject);
    }

    public enum BubbleColor
    {
        Blue, Yellow, Red, Purple, Green
    }

}
