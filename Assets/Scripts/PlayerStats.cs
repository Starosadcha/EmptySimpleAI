using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health;

    [SerializeField] private HeartBar heartBar;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float respawnDelay = 2f;

    private bool isDead = false;

    private void Start()
    {
        health = maxHealth;
        heartBar.SetMaxHealth(maxHealth);
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public void SetHealth(int value)
    {
        health = Mathf.Clamp(value, 0, maxHealth);
        heartBar.SetHealth(health);
    }
    public void TakeDamage(int damage)
    {
        if (isDead) return;
        SetHealth(health - damage);
        Debug.Log("Player HP: " + health);

        if (health <= 0)
        {
            Die();

        }
    }
    void Die()
    {
        isDead = true;
        Debug.Log("Player died");

        Time.timeScale = 0f;
        StartCoroutine(RespawnCoroutine());
    }
    IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSecondsRealtime(respawnDelay);

        transform.position = respawnPoint.position;

        health = maxHealth;
        heartBar.SetHealth(health);

        Time.timeScale = 1f;
        isDead = false;
    }
}
