using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchboxLogic : MonoBehaviour
{
    public bool matchbox = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.E)) // Taste zum Aufheben/Loslassen
        {
                TryPickUp();
        }
    }

    void TryPickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            if (hit.collider.gameObject.CompareTag("Pickable")) //if the object has the "Pickable" tag
            {
                matchbox = true;
                hit.collider.gameObject.SetActive(false); //disable the picked up object
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
                int currentIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene("Endscreen-Scene");
        }
    }
}
