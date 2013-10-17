using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
    #region Inspector Variables
    /// <summary>
    /// Bullet speed
    /// </summary>
    public float bulletSpeed = 15.0f;

    /// <summary>
    /// Upper limit where the bullet will be destroyed.
    /// </summary>
    public float lowerLimit = -10.0f;

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
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        transform.Translate(Vector3.down * (bulletSpeed * Time.deltaTime));

        if (transform.position.y < lowerLimit)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Collision trigger was called.
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Shield" || other.tag == "Block")
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

            if (audio != null) audio.Play();

            // Get rid of the object.
            Destroy(gameObject);
        }
    }
    #endregion Game Cycle Methods

    #region Methods

    #endregion Methods
}
