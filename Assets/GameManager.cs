using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int wave = 1;
    public int kills = 0;

    public TextMeshProUGUI killsText;
    public TextMeshProUGUI requiredKillsText;

    public int spawnTime = 180;
    public int currentSpawnTime = 0;

    public int livingEnemies = 0;
    public int requiredKills = 0;

    public Wave startingWave;

    public System.Random rnd;

    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
        LoadWave();
    }

    void LoadWave()
    {
        spawnTime = startingWave.spawnTime * 60;
        currentSpawnTime = spawnTime;
        requiredKills = startingWave.killsRequired;
        requiredKillsText.text = "/" + requiredKills.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (currentSpawnTime == 0)
        {
            GameObject enemy = new GameObject();
            EnemyObject eo = enemy.AddComponent<EnemyObject>();

            int rndIndex = rnd.Next(0, startingWave.enemies.Count);
            Debug.Log(rndIndex);
            Enemy enemyType = startingWave.enemies[rndIndex];

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
