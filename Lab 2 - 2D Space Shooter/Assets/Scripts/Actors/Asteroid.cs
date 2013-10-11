using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour 
{
    #region Inspector Variables
    /// <summary>
    /// Bullet speed
    /// </summary>
    public float asteroidSpeed = 6.0f;

    /// <summary>
    /// Bottom of screen limit.
    /// </summary>
    public float bottomLimit = -6f;

    /// <summary>
    /// Top of screen limit.
    /// </summary>
    public float topLimit = 8f;

    /// <summary>
    /// Minimum X.
    /// </summary>
    public float minX = -6f;

    /// <summary>
    /// Maximum X.
    /// </summary>
    public float maxX = 6f;

    /// <summary>
    /// Explosion called when it hits a player
    /// </summary>
    public Transform explosion = null;

    /// <summary>
    /// Shield explosion audio.
    /// </summary>
    public AudioClip shieldExplosionAudio;

    /// <summary>
    /// Player hit audio.
    /// </summary>
    public AudioClip playerHitAudio;
    #endregion Inspector Variables

    #region Private Variables
    #endregion Private Variables

    #region Game Cycle Methods

    /// <summary>
    /// Initializes the asteroid.
    /// </summary>
    void Start()
    {
        ResetPosition();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Makes the asteroid move down
        transform.Translate(Vector3.down * (asteroidSpeed * Time.deltaTime));

        // Checks for the bottom of the screen
        if (transform.position.y < bottomLimit)
        {
            // Reset the position of the enemy.
            ResetPosition();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Player" || other.tag == "Shield" )
        {
            if (other.tag == "Player")
            {
                SceneManager.SubtractLives();

                if (audio != null) audio.clip = playerHitAudio;
            }
            else
            {
                if (audio != null) audio.clip = shieldExplosionAudio;
            }

            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }

            if( audio != null )
            {
                audio.Play();
            }

            ResetPosition();
        }
    }
    #endregion Game Cycle Methods

    #region Methods
    /// <summary>
    /// Resets player position.
    /// </summary>
    public void ResetPosition()
    {
        transform.position = new Vector3(Random.Range(minX, maxX) , topLimit, 0f);
    }
    #endregion Methods
}
