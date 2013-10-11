using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    #region Inspector Variables
    /// <summary>
    /// Player Speed
    /// </summary>
    public Vector2 playerSpeed = new Vector2(10f, 10f);

    /// <summary>
    /// Number of shields the player can use.
    /// </summary>
    public int numberOfShields = 4;

    /// <summary>
    /// Shield mesh.
    /// </summary>
    public Transform shieldMesh = null;

    #region Position Limit Variables
    /// <summary>
    /// Screen boundaries (Min X)
    /// </summary>
    public float minX = -6f;

    /// <summary>
    /// Screen boundaries (Max X)
    /// </summary>
    public float maxX = 6f;

    /// <summary>
    /// Screen boundaries (Min Y)
    /// </summary>
    public float minY = -4f;

    /// <summary>
    /// Screen boundaries (Max Y)
    /// </summary>
    public float maxY = 4f;
    #endregion Position Limit Variables

    #region Projectible Variables
    /// <summary>
    /// Bullet to be shot.
    /// </summary>
    public Transform projectile = null;

    /// <summary>
    /// The projectile socket.
    /// </summary>
    public Transform projectileSocket = null;
    #endregion Projectible Variables

    #endregion Inspector Variables

    #region Private Variables
    /// <summary>
    /// Is the shield on?
    /// </summary>
    private bool shieldOn = false;
    #endregion Private Variables

    #region Game Cycle Methods
    /// <summary>
    /// Update is called once per frame
    /// </summary>
	void Update ()
    {
        #region Movement
        // Move Player based on input
        float transHorizontal = Input.GetAxis("Horizontal") * playerSpeed.y * Time.deltaTime;
        float transVertical = Input.GetAxis("Vertical") * playerSpeed.x * Time.deltaTime;
        transform.Translate(transHorizontal, transVertical, 0);

        // If position is out of bounds, make it stop.
        float posX = Mathf.Clamp(transform.position.x, minX, maxX);
        float posY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(posX, posY, 0);
        #endregion Movement

        #region Shooting
        // Create a bullet.
        if( Input.GetKeyDown(KeyCode.Space) )
        {
            if (projectile != null && projectileSocket != null)
            {
                Instantiate(projectile, projectileSocket.position, transform.rotation);
                if( audio != null ) audio.Play();
            }
        }
        #endregion Shooting

        #region Shield
        if( Input.GetKeyDown(KeyCode.E) )
        {
            if( shieldMesh != null )
            {
                if (!shieldOn && numberOfShields > 0)
                {
                    Transform shield = Instantiate(shieldMesh, transform.position, transform.rotation) as Transform;
                    shield.transform.parent = gameObject.transform;

                    numberOfShields--;

                    shieldOn = true;
                }
            }
        }
        #endregion Shield
    }
    #endregion Game Cycle Methods

    #region Methods
    public void DisableShield()
    {
        shieldOn = false;
    }
    #endregion Methods
}
