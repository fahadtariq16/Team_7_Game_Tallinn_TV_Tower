using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enter-Taste (Return)
        {
            Application.Quit();
        }
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Spiel wird beendet.");  // Nur zur Kontrolle im Editor
    }
}
