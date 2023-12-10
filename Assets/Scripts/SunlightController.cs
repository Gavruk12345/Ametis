using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SunlightController : MonoBehaviour
{
    [Tooltip("Об'єкт світла 2D, який буде анімований")]
    public Light2D sunlight;

    [Tooltip("Максимальна інтенсивність світла")]
    public float maxIntensity = 1.0f;

    [Tooltip("Мінімальна інтенсивність світла")]
    public float minIntensity = 0.1f;

    [Tooltip("Швидкість зміни інтенсивності")]
    public float changeSpeed = 0.5f;

    void Update()
    {
        // Перевіряємо, чи вказано об'єкт світла
        if (sunlight != null)
        {
            // Змінюємо інтенсивність світла в залежності від часу або іншого фактору
            float intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time * changeSpeed, 1.0f));
            sunlight.intensity = intensity;
        }
        else
        {
            Debug.LogError("Будь ласка, вказуйте об'єкт світла в інспекторі.");
        }
    }
}
