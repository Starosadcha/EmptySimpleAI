using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Max(health, 0);

        Debug.Log("Player HP: " + health);

        if (health <= 0)
        {
            Debug.Log("Player died");
            // tutaj można dodać respawn / checkpoint
        }
    }
}
