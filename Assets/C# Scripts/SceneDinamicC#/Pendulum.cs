using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float amplitude = 45f; // амплитуда колебаний
    public float speed = 2f; // скорость колебаний
    public SawAxis SawAxis = SawAxis.X; // выбранная ось

    private Quaternion startRotation; // начальное положение булавы

    void Start()
    {
        startRotation = transform.rotation; // сохраняем начальное положение булавы
    }

    void Update()
    {
        float angle = amplitude * Mathf.Sin(Time.time * speed); // рассчитываем угол поворота

        Quaternion targetRotation;

        switch (SawAxis)
        {
            case SawAxis.X:
                targetRotation = startRotation * Quaternion.Euler(angle, 0f, 0f); // создаем целевую кватернионную поворот вокруг оси X
                break;
            case SawAxis.Y:
                targetRotation = startRotation * Quaternion.Euler(0f, angle, 0f); // создаем целевую кватернионную поворот вокруг оси Y
                break;
            case SawAxis.Z:
                targetRotation = startRotation * Quaternion.Euler(0f, 0f, angle); // создаем целевую кватернионную поворот вокруг оси Z
                break;
            default:
                targetRotation = Quaternion.identity; // если выбрана недопустимая ось, то оставляем текущее положение булавы
                break;
        }

        transform.rotation = targetRotation; // поворачиваем булаву
    }
}

public enum SawAxis // перечисление доступных осей
{
    X,
    Y,
    Z
}
