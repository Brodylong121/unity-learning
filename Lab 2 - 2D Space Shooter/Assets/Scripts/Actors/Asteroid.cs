using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour 
{
    #region Inspector Variables

    #region RandomLimitsVariables
    /// <summary>
    /// Minimum speed.
    /// </summary>
    public float minSpeed = 4f;

    /// <summary>
    /// Maximum speed.
    /// </summary>
    public float maxSpeed = 10f;

    /// <summary>
    /// Minimum scale.
    /// </summary>
    public float minScale = 0.5f;

    /// <summary>
    /// Maximum Scale.
    /// </summary>
    public float maxScale = 3f;

    #endregion RandomLimitsVariables

    #region Position Variables
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
    #endregion Position Variables

    #region Powerups
    /// <summary>
    /// The powerups.
    /// </summary>
    public Transform[] powerups;

    /// <summary>
    /// Powerup chance, from 0 to 1.
    /// </summary>
    public float powerupChance = 0.03f;
    #endregion Powerups

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
    /// <summary>
    /// Bullet speed
    /// </summary>
    private float asteroidSpeed = 6.0f;
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
        if( other.tag == "Player" || other.tag == "Shield" || other.tag == "Block" )
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
        asteroidSpeed = Random.Range(minSpeed, maxSpeed);
        float scale = Random.Range(minScale, maxScale);

        transform.localScale = new Vector3(scale, scale, scale);


        transform.position = new Vector3(Random.Range(minX, maxX) , topLimit, 0f);
    }

    /// <summary>
    /// Generates powerup randomly.
    /// </summary>
    public void GeneratePowerup()
    {
        float rand = Random.Range(0f, 1f);

        if (rand <= powerupChance)
        {
            if (powerups.Length > 0)
            {
                int value = Random.Range(0, powerups.Length);

                // Generates one Power Up.
                Instantiate(powerups[value], transform.position, transform.rotation);
            }

        }

    }
    #endregion Methods
}
