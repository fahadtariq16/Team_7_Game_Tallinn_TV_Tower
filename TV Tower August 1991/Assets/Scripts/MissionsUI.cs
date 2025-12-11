using UnityEngine;
using TMPro;

public class MissionsUI : MonoBehaviour
{
    public GameObject missionsPanel;
    public TMP_Text missionText;

    public float delayBeforeShow = 4f; // 4 Sekunden warten, bevor es erscheint
    public float showDuration = 4f;    // 4 Sekunden sichtbar bleiben

    public void ShowMission(string text)
    {
        missionText.text = text;
        StopAllCoroutines();                      // Alte Timer abbrechen
        StartCoroutine(ShowMissionRoutine());     // Neue Anzeige starten
    }

    System.Collections.IEnumerator ShowMissionRoutine()
    {
        // Panel sicher ausblenden
        //missionsPanel.SetActive(false);

        // 4 Sekunden warten, bevor das Panel gezeigt wird
        yield return new WaitForSeconds(delayBeforeShow);

        missionsPanel.SetActive(true);   // Panel anzeigen

        // 4 Sekunden sichtbar bleiben
        yield return new WaitForSeconds(showDuration);

        missionsPanel.SetActive(false);  // Panel wieder ausblenden
    }
}
