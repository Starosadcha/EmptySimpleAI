using UnityEngine;

/*Ten skrypt sprawia, że kamera wyprzedza gracza w kierunku jego ruchu.
Czyli patrzy trochę „do przodu”, żeby gracz widział więcej przestrzeni przed sobą.*/

public class CameraLookAhead : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float lookAheadDistance = 2f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        Vector3 targetPosition = target.position + new Vector3(direction * lookAheadDistance, 0, -10);
        /*bierzemy pozycję gracza
         dodajemy X przesunięte o kierunek *lookAheadDistance
         Y zostaje taki sam
         Z ustawiamy na - 10(typowa pozycja kamery 2D)*/

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}