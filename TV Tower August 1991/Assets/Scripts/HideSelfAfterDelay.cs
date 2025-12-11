using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSelfAfterDelay : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(HideAfterDelay());
    }

    System.Collections.IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    
}
