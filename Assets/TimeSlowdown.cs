using System.Collections;
using UnityEngine;

public class TimeSlowdown : MonoBehaviour
{
    // Параметр для визначення масштабу сповільнення часу
    public float slowdownFactor = 0.5f;

    // Тривалість сповільнення часу
    public float slowdownDuration = 2f;

    // Викликається, коли сповільнення часу має відбутися
    public void StartSlowdown()
    {
        StartCoroutine(SlowdownTime());
    }

    // Корутина для сповільнення часу
    IEnumerator SlowdownTime()
    {
        // Запам'ятовуємо поточний часштамп
        float originalTimeScale = Time.timeScale;

        // Змінюємо час на заданий масштаб
        Time.timeScale = slowdownFactor;

        // Сповільнений час реального світу
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

        // Отримуємо всі об'єкти з тегом "Player" і сповільнюємо їхні рухові компоненти
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                // Змінюємо швидкість об'єктів з тегом "Player"
                playerRigidbody.velocity *= slowdownFactor;
            }
        }

        // Очікуємо задану тривалість
        yield return new WaitForSeconds(slowdownDuration);

        // Повертаємо час до його оригінального масштабу
        Time.timeScale = originalTimeScale;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

        // Повертаємо швидкість об'єктів з тегом "Player" до норми
        foreach (GameObject player in players)
        {
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity /= slowdownFactor;
            }
        }
    }
}
