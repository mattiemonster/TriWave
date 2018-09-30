using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletObject : MonoBehaviour
{
    private SpriteRenderer sr;
    private Bullet bullet;

    private bool loaded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (loaded)
        {
            if (!transform)
                Debug.LogError("Transform null");
            if (!bullet)
                Debug.LogError("Bullet null");
            transform.Translate(Vector3.up * bullet.speed);
        }
    }

    public void Load(Bullet bullet, Quaternion rotation, Vector3 position)
    {
        this.bullet = bullet;
        tag = "Bullet";

        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = bullet.sprite;
        sr.color = bullet.defaultColour;
        sr.DOColor(Color.black, 3f);

        gameObject.AddComponent<CircleCollider2D>();

        transform.rotation = rotation;
        transform.position = position;

        loaded = true;

        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(Instantiate(bullet.brokenParticle, collision.transform.position, Quaternion.identity), 2f);
            collision.gameObject.GetComponent<EnemyObject>().Hurt(bullet.damage);
            Destroy(gameObject);
        }
    }
}
