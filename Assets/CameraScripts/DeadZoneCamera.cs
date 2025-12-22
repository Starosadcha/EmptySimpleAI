using UnityEngine;

public class DeadZoneCamera : MonoBehaviour
{
    public Transform target;
    public Vector2 deadZoneSize = new Vector2(2f, 1f);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        Vector3 diff = target.position - transform.position;

        if (Mathf.Abs(diff.x) > deadZoneSize.x)
            pos.x = Mathf.Lerp(pos.x, target.position.x, Time.deltaTime * smoothSpeed);

        if (Mathf.Abs(diff.y) > deadZoneSize.y)
            pos.y = Mathf.Lerp(pos.y, target.position.y, Time.deltaTime * smoothSpeed);

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}