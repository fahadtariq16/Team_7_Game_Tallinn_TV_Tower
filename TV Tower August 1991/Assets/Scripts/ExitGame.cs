using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Spiel wird beendet.");  // Nur zur Kontrolle im Editor
    }
}
