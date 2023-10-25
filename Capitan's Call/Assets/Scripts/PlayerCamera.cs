using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Ссылка на трансформ игрока

    public Vector3 offset; // Смещение между камерой и игроком

    void Update()
    {
        // Проверяем, существует ли ссылка на игрока
        if (player != null)
        {
            // Получаем позицию игрока и прибавляем смещение
            Vector3 targetPosition = player.position + offset;
            
            // Устанавливаем позицию камеры на новую позицию игрока
            transform.position = targetPosition;
        }
    }
}