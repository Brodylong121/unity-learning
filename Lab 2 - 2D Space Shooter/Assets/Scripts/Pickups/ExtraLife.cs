using UnityEngine;
using System.Collections;

/// <summary>
/// Extra life pickup.
/// </summary>
public class ExtraLife : MonoBehaviour 
{
    #region Inspector Variables
    /// <summary>
    /// Bullet speed
    /// </summary>
    public float powerupSpeed = 1.0f;

    /// <summary>
    /// Upper limit where the bullet will be destroyed.
    /// </summary>
    public float bottomLimit = -8.0f;

    /// <summary>
    /// Explosion sound.
    /// </summary>
    public AudioClip fxSound = null;
    #endregion Inspector Variables

    #region Private Variables
    #endregion Private Variables

    #region Game Cycle Methods
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        transform.Translate(Vector3.down * (powerupSpeed * Time.deltaTime));

        if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Collision trigger was called.
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Reset the position of the enemy.
            Player player = other.GetComponent("Player") as Player;

            if (player != null)
            {
                SceneManager.lives++;
                if (fxSound != null) AudioSource.PlayClipAtPoint(fxSound, transform.position);
            }

            // Get rid of the object.
            Destroy(gameObject);
        }
    }
    #endregion Game Cycle Methods
}
