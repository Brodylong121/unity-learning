using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
    #region Inspector Variables
    /// <summary>
    /// Bullet speed
    /// </summary>
    public float bulletSpeed = 15.0f;

    /// <summary>
    /// Upper limit where the bullet will be destroyed.
    /// </summary>
    public float upperLimit = 10.0f;

    /// <summary>
    /// Explosion effect.
    /// </summary>
    public Transform explosion = null;

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
        transform.Translate( Vector3.up * (bulletSpeed * Time.deltaTime) );

        if( transform.position.y > upperLimit )
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Collision trigger was called.
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            // Reset the position of the enemy.
            Asteroid asteroid = other.GetComponent("Asteroid") as Asteroid;
            if (asteroid != null) asteroid.ResetPosition();

            if (explosion != null)
            {
                // Create an explosion on impact.
                Instantiate(explosion, transform.position, transform.rotation);

                if (fxSound != null) AudioSource.PlayClipAtPoint(fxSound, transform.position);
            }

            // Adds to the score.
            SceneManager.AddScore();

            // Get rid of the object.
            Destroy(gameObject);
        }
    }
    #endregion Game Cycle Methods
}
