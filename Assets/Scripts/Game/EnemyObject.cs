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
		// Removed for now cause sometimes the animation doesn't play and the enemy remains invisible
        // sr.color = new Color(enemyType.defaultColour.r, enemyType.defaultColour.g, enemyType.defaultColour.b,
        //                      1f);
		sr.color = enemyType.defaultColour;
        // .DOColor(enemyType.defaultColour, 0.25f);

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
        sr.DOComplete();
        sr.color = Color.red;
        sr.DOColor(enemyType.defaultColour, 0.45f);

        if (health <= 0)
        {
            Die(true);
        } else
        {
            // Summon and destroy hurt particle
            Destroy(Instantiate(enemyType.hurtParticle, transform.position, Quaternion.identity), 1f);
        }
    }

    public void Die(bool destroy)
    {
        health = 0;
        Debug.Log("Enemy '" + gameObject.name + "' died.");
        Destroy(gameObject);
        gm.EnemyKilled(gameObject);
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
