using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    int score;

    public  Egg egg;
    Text scoreText;

    void Start()
    {
//        egg = FindObjectOfType<Egg>();
        egg.CathedEgg += Catched;

        scoreText = GetComponent<Text>();
        score = 0;
    }

    void Catched()
    {
        score++;
        scoreText.text = score.ToString();
    }

    void Broken()
    {
    }
}
