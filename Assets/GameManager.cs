using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int wave = 1;
    public int kills = 0;

    public TextMeshProUGUI killsText;

    public int spawnTime = 180;
    public int currentSpawnTime = 0;

    public Enemy enemyType;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentSpawnTime);
    }

    void FixedUpdate()
    {
        if (currentSpawnTime == 0)
        {
            GameObject enemy = new GameObject();
            EnemyObject eo = enemy.AddComponent<EnemyObject>();
            eo.Load(enemyType);
            eo.gm = this;
            enemy.transform.position = Random.insideUnitSphere * 3;
            enemy.GetComponent<Rigidbody2D>().rotation = Random.Range(1, 359);
            enemy.name = eo.enemyType.name;
            currentSpawnTime = spawnTime;
        } else
        {
            currentSpawnTime--;
        }
    }
    
    public void EnemyKilled()
    {
        kills++;
        killsText.text = kills.ToString();
    }
}
