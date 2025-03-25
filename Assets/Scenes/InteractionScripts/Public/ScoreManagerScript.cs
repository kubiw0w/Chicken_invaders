using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManagerScript
{
    public static int score_level2 = 0;
    public static int score_level1 = 0;

    public static void Reset()
    {
        score_level2 = 0;
        score_level1 = 0;
    }

    public static void AddScore_level2()
    {
        score_level2 += 1;
        Debug.Log("Score(Level2): " + score_level2);
    }

    public static void AddScore_level1()
    {
        score_level1 += 1;
        Debug.Log("Score(Level1): " + score_level1);
    }

    public static void SubScore_level1()
    {
        score_level1 -= 1;
        Debug.Log("Score(Level2): " + score_level2);
    }

    public static void SubScore_level2()
    {
        score_level2 -= 1;
        Debug.Log("Score(Level2): " + score_level2);
    }
}
