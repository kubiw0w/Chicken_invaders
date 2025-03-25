using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToBeginning : MonoBehaviour
{
    public void LoadStart()
    {
        SceneManager.LoadScene("BeginningScene");
    }

}
