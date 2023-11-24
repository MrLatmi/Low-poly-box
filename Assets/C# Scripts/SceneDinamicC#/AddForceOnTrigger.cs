using UnityEngine;

public class AddForceOnTrigger : MonoBehaviour
{
    public float forceMagnitude = 10f; // Магнитуда силы, которую мы добавим
    public Vector3 forceDirection = Vector3.up; // Направление, в котором мы добавим силу

    private void ApplyForce(Rigidbody rb)
    {
        if (rb != null)
        {
            // Добавляем силу
            rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Получаем Rigidbody объекта, попавшего в триггер
        Rigidbody rb = other.GetComponent<Rigidbody>();
        ApplyForce(rb);
    }

}
