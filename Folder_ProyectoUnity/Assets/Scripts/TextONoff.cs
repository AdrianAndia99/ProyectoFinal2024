using UnityEngine;
using System.Collections;
using TMPro;

public class TextONoff : MonoBehaviour
{
    public TextMeshProUGUI textToBlink; 
    public float blinkInterval = 0.5f;

    private void Start()
    {
        if (textToBlink != null)
        {
            StartCoroutine(Blink());
        }
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            textToBlink.enabled = !textToBlink.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}