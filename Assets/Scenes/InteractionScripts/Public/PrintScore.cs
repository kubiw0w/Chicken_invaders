using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrintScore : MonoBehaviour
{
    public TMP_Text text;

    private void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "LEVEL1":
                ScoreManagerScript.Reset();
                text.text = ScoreManagerScript.score_level1.ToString();
                break;
            case "LEVEL2":
                ScoreManagerScript.Reset();
                text.text = ScoreManagerScript.score_level2.ToString();
                break;
            default:
                text.text = "Unknown";
                break;
        }
        
    }
    void Update()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "LEVEL1":
                text.text = ScoreManagerScript.score_level1.ToString();
                break;
            case "LEVEL2":
                text.text = ScoreManagerScript.score_level2.ToString();
                break;
            default:
                text.text = "Unknown";
                break;
        }
    }
}
