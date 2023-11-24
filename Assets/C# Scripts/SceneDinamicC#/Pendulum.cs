using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float amplitude = 45f; // ��������� ���������
    public float speed = 2f; // �������� ���������
    public SawAxis SawAxis = SawAxis.X; // ��������� ���

    private Quaternion startRotation; // ��������� ��������� ������

    void Start()
    {
        startRotation = transform.rotation; // ��������� ��������� ��������� ������
    }

    void Update()
    {
        float angle = amplitude * Mathf.Sin(Time.time * speed); // ������������ ���� ��������

        Quaternion targetRotation;

        switch (SawAxis)
        {
            case SawAxis.X:
                targetRotation = startRotation * Quaternion.Euler(angle, 0f, 0f); // ������� ������� ������������� ������� ������ ��� X
                break;
            case SawAxis.Y:
                targetRotation = startRotation * Quaternion.Euler(0f, angle, 0f); // ������� ������� ������������� ������� ������ ��� Y
                break;
            case SawAxis.Z:
                targetRotation = startRotation * Quaternion.Euler(0f, 0f, angle); // ������� ������� ������������� ������� ������ ��� Z
                break;
            default:
                targetRotation = Quaternion.identity; // ���� ������� ������������ ���, �� ��������� ������� ��������� ������
                break;
        }

        transform.rotation = targetRotation; // ������������ ������
    }
}

public enum SawAxis // ������������ ��������� ����
{
    X,
    Y,
    Z
}
