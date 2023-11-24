using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeMagnitude = 0.5f;
    [SerializeField] private float shakeInterval = 0.05f;

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void Shake(float shakeDuration)
    {
        StartCoroutine(ShakeCoroutine(shakeDuration));
    }

    private IEnumerator ShakeCoroutine(float shakeDuration)
    {
        originalPosition = transform.localPosition;
        float elapsedTime = 0f;
        while (elapsedTime < shakeDuration)
        {
            Vector3 randomVector = Random.insideUnitSphere * shakeMagnitude;
            transform.localPosition = originalPosition + randomVector;
            elapsedTime += shakeInterval;
            yield return new WaitForSeconds(shakeInterval);
            originalPosition = transform.localPosition;
        }
        transform.localPosition = originalPosition;
    }
}
