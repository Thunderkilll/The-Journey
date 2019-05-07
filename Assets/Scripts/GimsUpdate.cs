using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GimsUpdate : MonoBehaviour
{

    private TextMeshProUGUI ScoreUI;
     
    public float score = 0;

    void Start()
    {
        ScoreUI = GetComponent<TextMeshProUGUI>();
      
         
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerMovement.scoreGim;
        updateScore(score);

    }

    void updateScore(float score)
    {
    
        ScoreUI.text = score.ToString();
       
    }
}
