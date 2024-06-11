using System.Collections;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public KeyCode stopTimeKey = KeyCode.Z;  // Tecla para detener el tiempo
    public float stopTimeDuration = 5f; // Duración del efecto de detener el tiempo

    private bool isTimeStopped = false;

    void Update()
    {
        if (Input.GetKeyDown(stopTimeKey) && !isTimeStopped)
        {
            StartCoroutine(StopTime());
        }
    }

    IEnumerator StopTime()
    {
        isTimeStopped = true;
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale; // Ajustar fixedDeltaTime
        yield return new WaitForSecondsRealtime(stopTimeDuration); // Espera tiempo real para reanudar el tiempo
        ResumeTime();
    }

    void ResumeTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f; // Restaurar fixedDeltaTime
        isTimeStopped = false;
    }
}
