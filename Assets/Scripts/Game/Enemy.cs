using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "TriWave/Enemy")]
public class Enemy : ScriptableObject
{
    /// <summary>
    /// Name of the enemy
    /// </summary>
    [Tooltip("Name of the enemy")]
    public string enemyName;
    /// <summary>
    /// Amount of health the enemy should start with
    /// </summary>
    [Tooltip("Amount of health the enemy should start with")]
    public int startingHealth;
    /// <summary>
    /// Sprite to render the enemy with
    /// </summary>
    [Tooltip("Sprite to render the enemy with")]
    public Sprite sprite;
    /// <summary>
    /// Scale to render the enemy at
    /// </summary>
    [Tooltip("Scale to render the enemy at")]
    public float scale;
    /// <summary>
    /// Colour to render the enemy with by default
    /// </summary>
    [Tooltip("Colour to render the enemy with by default")]
    public Color defaultColour;
    /// <summary>
    /// Particle to spawn when enemy is hurt
    /// </summary>
    [Tooltip("Particle to spawn when enemy is hurt")]
    public GameObject hurtParticle;
}
