using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enter-Taste (Return)
        {
            SceneManager.LoadScene("TestLevel");
        }
    }

    public void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }
}
