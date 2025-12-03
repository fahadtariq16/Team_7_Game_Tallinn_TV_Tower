using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GoalArea : MonoBehaviour
{
    public string requiredTag = "Pickable";  // Tag vom richtigen Objekt
    //public GameObject winPanel;              // UI-Panel mit Siegesnachricht

    private bool hasWon = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasWon) return;

        // Prüfen, ob das richtige Objekt in die Zone kommt
        if (other.CompareTag(requiredTag))
        {
            hasWon = true;
            Debug.Log("Ziel erreicht!");

            if (hasWon)
            {
                int currentIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene("Test");
            }
        }
    }
}

