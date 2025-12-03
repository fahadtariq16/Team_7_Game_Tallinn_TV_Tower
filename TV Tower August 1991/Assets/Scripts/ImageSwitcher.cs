using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Image targetImage;      // Das UI Image (drag & drop)
    public Sprite[] images;        // Array mit allen Sprites (drag & drop)

    public float switchTime = 4f;  // Sekunden bis Wechsel (4 Sekunden)

    private float timer = 0f;
    private int currentIndex = -1;
    private bool reachedEnd = false;  // NEU: Stoppt Wechsel nach letztem Bild

    void Update()
    {
        if (reachedEnd) return;  // Nach letztem Bild: nichts mehr tun

        timer += Time.deltaTime;
        if (timer >= switchTime)
        {
            currentIndex++;
            if (currentIndex < images.Length)  // Solange nicht letztes Bild
            {
                targetImage.sprite = images[currentIndex];
                timer = 0f;
                Debug.Log(images[currentIndex]);
            }
            else
            {
                targetImage.sprite = images[images.Length - 1];  // Letztes Bild setzen
                reachedEnd = true;  // Wechsel stoppen
            }
        }
    }
}
