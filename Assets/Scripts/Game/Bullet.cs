using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "TriWave/Bullet")]
public class Bullet : ScriptableObject
{
    /// <summary>
    /// Speed of the bullet
    /// </summary>
    [Tooltip("Speed of the bullet")]
    public float speed;

    /// <summary>
    /// Damage the bullet does to an enemy
    /// </summary>
    [Tooltip("Damage the bullet does to an enemy")]
    public int damage;

    /// <summary>
    /// Sprite the bullet uses
    /// </summary>
    [Tooltip("Sprite the bullet uses")]
    public Sprite sprite;

    /// <summary>
    /// Colour the bullet should be by default
    /// </summary>
    [Tooltip("Colour the bullet should be by default")]
    public Color defaultColour;

    /// <summary>
    /// Particle to play when the bullet hits something
    /// </summary>
    [Tooltip("Particle to play when the bullet hits something")]
    public GameObject brokenParticle;
}
