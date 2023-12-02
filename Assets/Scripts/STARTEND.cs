using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STARTEND : MonoBehaviour
{
    public void End()
    {
        Application.Quit();
    }
    public void ReLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
