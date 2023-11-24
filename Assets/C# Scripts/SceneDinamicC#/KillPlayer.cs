using UnityEngine;
using UnityEngine.Events;

public class KillPlayer : MonoBehaviour
{
    public GameObject playerPrefab; // ������ ������
    [SerializeField] private UnityEvent functionsList; // UnityEvent ��� ������ �������

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // ���� ����� ����� � �������
        {
            GameObject player = other.gameObject;

            // �������� UnityEvent functionsList
            functionsList.Invoke();

            // ������� ����� ������ �� ����� ������
            Instantiate(playerPrefab, player.transform.position, player.transform.rotation);

            // ��������� ������
            player.SetActive(false);
        }
    }
}
