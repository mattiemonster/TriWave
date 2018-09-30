using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Scene Objects")]
    public Camera cameraObj;
    public GameObject origin;

    [Header("Particles")]
    public GameObject shootParticle;

    [Header("Weapons")]
    public Bullet basicBullet;

    private Rigidbody2D rb;
    //private LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!rb)
        {
            Debug.LogError("Player (named '" + gameObject.name + "') doesn't have a Rigidbody2D");
        }
        
        //lr = GetComponent<LineRenderer>();
        //if (!lr)
        //{
        //    Debug.LogError("Player (named '" + gameObject.name + "') doesn't have a LineRenderer");
        //}
        //lr.positionCount = 2;
        //lr.SetPosition(0, transform.position + new Vector3(0, 0.5f, 0));
        //lr.startColor = new Color(0, 0, 0, 0.5f);
        //lr.endColor = new Color(0, 0, 0, 0.5f);
    }

    void Update()
    {
    //    lr.SetPosition(0, transform.position + new Vector3(0, 0.5f, 0));

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0.05f, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -0.05f, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.05f, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.05f, 0, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Destroy(Instantiate(shootParticle, origin.transform.position, Quaternion.identity, origin.transform), 0.5f);
        GameObject bullet = new GameObject("Bullet");
        bullet.AddComponent<BulletObject>().Load(basicBullet, transform.rotation, origin.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Distance from camera to object.  We need this to get the proper calculation.
        float camDis = cameraObj.transform.position.y - transform.position.y;

        // Get the mouse position in world space. Using camDis for the Z axis.
        Vector3 mouse = cameraObj.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        // lr.SetPosition(1, mouse);

        //transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        rb.rotation = angle - 90;
    }
}
