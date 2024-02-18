using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreText;
    private int score;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
