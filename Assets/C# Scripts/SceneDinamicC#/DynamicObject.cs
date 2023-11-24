using System.Collections;
using UnityEngine;

public class DynamicObject : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 1f;
    public float waitTime = 2f;

    public enum MoveDirection { Up, Down, Left, Right, Forward, Backward };
    public MoveDirection moveDirection = MoveDirection.Up;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool isMoving = false;
    private Coroutine moveCoroutine;

    private void Start()
    {
        startPosition = transform.position;
        endPosition = GetEndPosition();
    }

    public void ActivateObject()
    {
        if (!isMoving)
        {
            isMoving = true;
            moveCoroutine = StartCoroutine(MoveObject());
        }
    }

    private IEnumerator MoveObject()
    {
        // Move to end position
        float startTime = Time.time;
        while (transform.position != endPosition)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / Vector3.Distance(startPosition, endPosition);
            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        // Move to start position
        startTime = Time.time;
        while (transform.position != startPosition)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / Vector3.Distance(endPosition, startPosition);
            transform.position = Vector3.Lerp(endPosition, startPosition, fractionOfJourney);
            yield return null;
        }

        isMoving = false;
        moveCoroutine = null;
    }

    private Vector3 GetEndPosition()
    {
        switch (moveDirection)
        {
            case MoveDirection.Up:
                return startPosition + Vector3.up * moveDistance;
            case MoveDirection.Down:
                return startPosition - Vector3.up * moveDistance;
            case MoveDirection.Left:
                return startPosition - Vector3.right * moveDistance;
            case MoveDirection.Right:
                return startPosition + Vector3.right * moveDistance;
            case MoveDirection.Forward:
                return startPosition + Vector3.forward * moveDistance;
            case MoveDirection.Backward:
                return startPosition - Vector3.forward * moveDistance;
            default:
                return startPosition;
        }
    }
}
