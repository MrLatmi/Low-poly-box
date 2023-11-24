using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionActivator : MonoBehaviour
{
    public enum ActivationMode
    {
        OnEnter,
        OnEnterOnce
    }

    public enum TegPlayer // добавлено перечисление TegPlayer
    {
        Player, // тег игрока
        All     // все объекты
    }

    [SerializeField] private ActivationMode mode;
    [SerializeField] private TegPlayer playerTag; // добавлено поле для выбора тега игрока
    [SerializeField] private UnityEvent functionsList;

    private bool hasEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (playerTag == TegPlayer.All || other.gameObject.CompareTag("Player")) // проверяем выбранный тег игрока
        {
            if (mode == ActivationMode.OnEnter || (mode == ActivationMode.OnEnterOnce && !hasEntered))
            {
                functionsList.Invoke();
                hasEntered = true;
            }
        }
    }
}
