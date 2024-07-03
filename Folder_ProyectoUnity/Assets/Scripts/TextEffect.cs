using UnityEngine;
using TMPro;

public class TextEffect : MonoBehaviour
{
    public TMP_Text text; 
    public AnimationCurve scaleCurve; 
    public float duration = 2.0f; 
    private float time;

    void Start()
    {
        text = GetComponent<TMP_Text>();      
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;

        // Calcula el factor de escala basado en la curva de animación
        float scale = scaleCurve.Evaluate(time / duration);

        // Aplica la escala al texto
        text.rectTransform.localScale = new Vector3(scale, scale, scale);

        // Reinicia el tiempo si se supera la duración
        if (time > duration)
        {
            time = 0f;
        }
    }
}
