using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "TriWave/Wave")]
public class Wave : ScriptableObject
{
    /// <summary>
    /// Name of the wave
    /// </summary>
    [Tooltip("Name of the wave")]
    public string waveName;
    /// <summary>
    /// Description of the wave to be displayed when the wave is chosen
    /// </summary>
    [Tooltip("Description of the wave to be displayed when the wave is chosen")]
    public string waveDesc;
    /// <summary>
    /// The maximum amount of enemies that can be alive at one time
    /// </summary>
    [Tooltip("The maximum amount of enemies that can be alive at one time")]
    public int maxAliveEnemies;
    /// <summary>
    /// Amount of kills required for the wave to end
    /// </summary>
    [Tooltip("Amount of kills required for the wave to end")]
    public int killsRequired;
    /// <summary>
    /// Time between enemy spawns in seconds
    /// </summary>
    [Tooltip("Time between enemy spawns in seconds")]
    public int spawnTime;
    /// <summary>
    /// List of possible enemy spawns
    /// </summary>
    [Tooltip("List of possible enemy spawns")]
    public List<Enemy> enemies;
}
