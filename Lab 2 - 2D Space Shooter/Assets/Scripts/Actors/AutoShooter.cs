using UnityEngine;
using System.Collections;

public class AutoShooter : MonoBehaviour
{
    #region Inspector Variables
    /// <summary>
    /// Weapon sockets.
    /// </summary>
    public Transform[] sockets;

    /// <summary>
    /// Minimum wait time.
    /// </summary>
    public float minWaitTime = 2f;

    /// <summary>
    /// Maximum wait time.
    /// </summary>
    public float maxWaitTime = 3f;

    /// <summary>
    /// Bullet.
    /// </summary>
    public Transform bullet;
    #endregion Inspector Variables

    #region Protected Variables
    /// <summary>
    /// Bullet speed
    /// </summary>
    protected float shootingTime;
    #endregion Protected Variables

    #region Game Cycle Methods
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        shootingTime -= Time.deltaTime;

        if( shootingTime < 0f )
        {
            // Shoot
            foreach( Transform socket in sockets )
            {
                if (bullet != null)
                    Instantiate(bullet, socket.position, socket.rotation);
            }

            shootingTime = Random.Range(minWaitTime, maxWaitTime);
        }
    }
    #endregion Game Cycle Methods

    #region Methods
    #endregion Methods
}