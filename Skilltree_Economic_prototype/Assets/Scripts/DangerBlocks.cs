using UnityEngine.SceneManagement;
using UnityEngine;

public class DangerBlocks : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene((int)SceneIndex.Level2);
        }
    }
 
}
