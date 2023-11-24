using UnityEngine;

public class FlyingPlate : MonoBehaviour
{
    public float moveDistance = 2f; // расстояние, на которое должна переместиться панель
    public float moveSpeed = 1f; // скорость движения панели

    private bool movingDown = true; // флаг, указывающий, движется ли панель вниз или вверх
    private Vector3 startPosition; // начальная позиция панели
    private Vector3 endPosition; // конечная позиция панели

    void Start()
    {
        // сохраняем начальную и конечную позиции панели
        startPosition = transform.position;
        endPosition = transform.position - new Vector3(0, moveDistance, 0);
    }

    void LateUpdate()
    {
        // определяем направление движения
        Vector3 direction = movingDown ? endPosition : startPosition;

        // перемещаем панель с помощью Lerp
        transform.position = Vector3.Lerp(transform.position, direction, moveSpeed * Time.deltaTime);

        // если панель достигла конечной позиции, меняем направление движения
        if (Vector3.Distance(transform.position, direction) < 0.01f)
        {
            movingDown = !movingDown;
        }
    }
}
