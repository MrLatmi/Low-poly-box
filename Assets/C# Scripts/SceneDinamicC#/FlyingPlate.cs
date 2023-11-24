using UnityEngine;

public class FlyingPlate : MonoBehaviour
{
    public float moveDistance = 2f; // ����������, �� ������� ������ ������������� ������
    public float moveSpeed = 1f; // �������� �������� ������

    private bool movingDown = true; // ����, �����������, �������� �� ������ ���� ��� �����
    private Vector3 startPosition; // ��������� ������� ������
    private Vector3 endPosition; // �������� ������� ������

    void Start()
    {
        // ��������� ��������� � �������� ������� ������
        startPosition = transform.position;
        endPosition = transform.position - new Vector3(0, moveDistance, 0);
    }

    void LateUpdate()
    {
        // ���������� ����������� ��������
        Vector3 direction = movingDown ? endPosition : startPosition;

        // ���������� ������ � ������� Lerp
        transform.position = Vector3.Lerp(transform.position, direction, moveSpeed * Time.deltaTime);

        // ���� ������ �������� �������� �������, ������ ����������� ��������
        if (Vector3.Distance(transform.position, direction) < 0.01f)
        {
            movingDown = !movingDown;
        }
    }
}
