using UnityEngine;
using UnityEngine.Events;

public class KillPlayer : MonoBehaviour
{
    public GameObject playerPrefab; // префаб игрока
    [SerializeField] private UnityEvent functionsList; // UnityEvent для вызова функций

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // если игрок попал в триггер
        {
            GameObject player = other.gameObject;

            // Вызываем UnityEvent functionsList
            functionsList.Invoke();

            // Создаем новый префаб на месте игрока
            Instantiate(playerPrefab, player.transform.position, player.transform.rotation);

            // Отключаем игрока
            player.SetActive(false);
        }
    }
}
