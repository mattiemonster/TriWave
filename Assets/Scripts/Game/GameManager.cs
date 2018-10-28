using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Animations;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public int wave = 1;
    public int kills = 0;

    public TextMeshProUGUI killsText;
    public TextMeshProUGUI requiredKillsText;
    public TextMeshProUGUI wavesText;

    public Slider killProgressSlider;
    
    public int spawnTime = 180;
    public int currentSpawnTime = 0;

    public int livingEnemies = 0;
    public int requiredKills = 0;

    public float killSliderIncrement = 0.0f;

    public Wave currentWave;

    public System.Random rnd;

    public List<GameObject> aliveEnemies;
    public List<Wave> availableWaves;

    // UI Objects
    public GameObject darkeningBG;
    public GameObject nextWaveUI;
    public GameObject waveCompleteText;
    public List<Animator> animators;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = availableWaves[0];
        rnd = new System.Random();
        LoadWave();
        aliveEnemies = new List<GameObject>();
    }

    void LoadWave()
    {
        spawnTime = currentWave.spawnTime * 60;
        currentSpawnTime = spawnTime;
        requiredKills = currentWave.killsRequired;
        requiredKillsText.text = "/" + requiredKills.ToString();
        killSliderIncrement = 1.0f / requiredKills;
    }
    
    void FixedUpdate()
    {
        if (currentSpawnTime == 0)
        {
            GameObject enemy = new GameObject();
            EnemyObject eo = enemy.AddComponent<EnemyObject>();

            int rndIndex = rnd.Next(0, currentWave.enemies.Count);
            Debug.Log(rndIndex);
            Enemy enemyType = currentWave.enemies[rndIndex];

            eo.Load(enemyType);
            eo.gm = this;
            enemy.transform.position = Random.insideUnitSphere * 3;
            enemy.GetComponent<Rigidbody2D>().rotation = Random.Range(1, 359);
            enemy.name = eo.enemyType.name;
            aliveEnemies.Add(enemy);
            currentSpawnTime = spawnTime;
        } else
        {
            currentSpawnTime--;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            kills++;
            killsText.text = kills.ToString();
            if (kills == requiredKills)
            {
                Reset();
                darkeningBG.SetActive(true);
                nextWaveUI.SetActive(true);
                waveCompleteText.GetComponent<Animator>().Play("Entry");
            }
            killProgressSlider.value += killSliderIncrement;
        }
    }
    
    public void EnemyKilled(GameObject enemy)
    {
        kills++;
        killsText.text = kills.ToString();

        if (kills == requiredKills)
        {
            Reset();
            darkeningBG.SetActive(true);
            nextWaveUI.SetActive(true);
            foreach (Animator anim in animators)
                anim.Play("Entry");
        }

        aliveEnemies.Remove(enemy);

        killProgressSlider.value += killSliderIncrement;
    }

    public void Reset()
    {
        foreach (GameObject enemy in aliveEnemies)
        {
            // Kill all enemies
            EnemyObject eo = enemy.GetComponent<EnemyObject>();
            // Camera.main.DOShakePosition(0.22f, 1); Camera shake looks horrible
            // TODO Instantiate death particle
        }

        for (int i = 0; i < aliveEnemies.Count; i++)
        {
            Destroy(aliveEnemies[i]);
        }

        aliveEnemies.Clear();
    }

    /// <summary>
    /// Go to the next wave
    /// </summary>
    public void NextWave(bool reset = false)
    {
        wave++;
        wavesText.text = "WAVE " + wave;

        if (reset)
            Reset();

        int newWaveIndex = rnd.Next(0, availableWaves.Count);
        ChangeWave(availableWaves[newWaveIndex]);
    }

    /// <summary>
    /// Change the current wave
    /// </summary>
    /// <param name="wave">Wave to change to</param>
    public void ChangeWave(Wave wave)
    {
        currentWave = wave;

        killProgressSlider.value = 0;
        kills = 0;
        killsText.text = 0.ToString();
        spawnTime = currentWave.spawnTime * 60;
        currentSpawnTime = spawnTime;
        requiredKills = currentWave.killsRequired;
        requiredKillsText.text = "/" + requiredKills.ToString();
        killSliderIncrement = 1.0f / requiredKills;

        AnnounceWave();
    }

    /// <summary>
    /// Announce that the wave has changed
    /// </summary>
    public void AnnounceWave()
    {
        Debug.Log("Changing wave to: " + currentWave.name);
    }
}
