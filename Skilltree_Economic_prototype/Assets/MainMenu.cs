using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
 public void playgame()
    {
        SceneManager.LoadScene((int)SceneIndex.Level1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

