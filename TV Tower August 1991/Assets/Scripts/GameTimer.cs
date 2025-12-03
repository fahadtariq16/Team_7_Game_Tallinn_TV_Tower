using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;  // TextMeshPro Namespace

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // Explizite TextMeshPro-Referenz
    //public GameObject losePanel; // Panel mit "Verloren" + Restart Button

    public float timeLimit = 120f; // 2 Minuten in Sekunden

    private float timeRemaining;
    private bool timerRunning = true;

    void Start()
    {
        timeRemaining = timeLimit;
        //losePanel.SetActive(false);
    }

    void Update()
    {

        string currentScene = SceneManager.GetActiveScene().name;


        if (Input.GetKeyDown(KeyCode.Return) && currentScene == "GameOver") // Enter-Taste (Return)
        {
            SceneManager.LoadScene("TestLevel");
        }

        if (timerRunning)
        {
            timeRemaining -= Time.deltaTime;

            // Timer-Text aktualisieren (MM:SS)
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Zeit abgelaufen?
            if (timeRemaining <= 0 )
            {
                GameOver();
            }
        }

       
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    // Öffentliche Methode für Restart-Button
    public void RestartGame()
    {
        SceneManager.LoadScene("TestLevel");
    }
}
