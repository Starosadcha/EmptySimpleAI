using UnityEngine;

// Ten skrypt steruje zachowaniem przeciwnika.
// Wróg potrafi: patrolować, gonić gracza i atakować.

public class EnemyAI : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 2f;
    public float chaseDistance = 3f;
    public float attackDistance = 1f;

    [Header("Patrol")]
    public Transform[] patrolPoints;
    private int currentPoint = 0;

    [Header("Attack")]
    public int damage = 10;
    public float attackCooldown = 1f;
    public float lastAttackTime = 0f;

    [Header("References")]
    public Transform player;
    public Animator anim;
    public ParticleSystem hitVFX;
    public Transform attackPoint;

    [Header("Audio")]
    public AudioSource audioSource;  
    public AudioClip attackClip;
    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= attackDistance)
        {
            Attack();
        }
        else if (distanceToPlayer <= chaseDistance)
        {
            Chase();
        }
        else if (distanceToPlayer > chaseDistance * 1.5f)
        {
            Patrol();
        }
    }
    void Patrol()
    {
        anim.SetBool("IsMoving", true);
        Transform targetPoint = patrolPoints[currentPoint];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }
    void Chase()
    {
        anim.SetBool("IsMoving", true);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);


    }
    void Attack()
    {
        anim.SetBool("Attack", true);
        if (Time.time < lastAttackTime + attackCooldown)
        {
            return;
        }
        if (audioSource != null && attackClip != null)
        {
            audioSource.PlayOneShot(attackClip);
        }
        if (hitVFX != null && attackPoint != null)
        {
            Instantiate(hitVFX, attackPoint.position, Quaternion.identity);
        }

        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.TakeDamage(damage);

        }
        lastAttackTime = Time.time;
    }
    void Flip(float direction)
    {
        if (Mathf.Abs(direction) < 0.01f) return;
        transform.localScale = new Vector3(1, 1, 1);
    }

}
