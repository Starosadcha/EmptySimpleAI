using UnityEngine;

/*Ten skrypt sprawia, że kamera płynnie podąża za graczem.
Nie skacze, nie teleportuje się — tylko porusza się miękko i z przyjemną inercją.*/

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;           
    public float smoothTime = 0.2f;  

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
       /* bierze aktualną pozycję kamery
          bierze pozycję celu(gracza)
          płynnie przesuwa kamerę
          z uwzględnieniem smoothTime
          korzysta z velocity, żeby ruch był naturalny*/
    }
}
