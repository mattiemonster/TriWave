using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyObject : MonoBehaviour
{
    public Enemy enemyType;
    public GameManager gm;

    private int health;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Load(Enemy enemy)
    {
        enemyType = enemy;

        health = enemyType.startingHealth;

        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = enemyType.sprite;

        // Fade in
        sr.color = new Color(enemyType.defaultColour.r, enemyType.defaultColour.g, enemyType.defaultColour.b,
                             0f);
        sr.DOColor(enemyType.defaultColour, 0.25f);

        gameObject.AddComponent<PolygonCollider2D>();

        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        transform.localScale = new Vector3(enemyType.scale, enemyType.scale, 1);
        tag = "Enemy";
    }

    /// <summary>
    /// Hurt the enemy
    /// </summary>
    /// <param name="amount">How much health to take away</param>
    public void Hurt(int amount)
    {
        // Decrease health by hurt amount
        health -= amount;

        // Add red colour effect
        sr.color = Color.red;
        sr.DOColor(enemyType.defaultColour, 0.45f);

        if (health <= 0)
        {
            Die();
        } else
        {
            // Summon and destroy hurt particle
            Destroy(Instantiate(enemyType.hurtParticle, transform.position, Quaternion.identity), 1f);
        }
    }

    public void Die()
    {
        Debug.Log("Enemy '" + gameObject.name + "' died.");
        Destroy(gameObject);
        gm.EnemyKilled();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Hurt(2);
        }
        transform.Translate(0.02f, 0, 0);
    }
}
