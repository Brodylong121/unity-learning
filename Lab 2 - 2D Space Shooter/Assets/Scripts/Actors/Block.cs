using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
{
    #region Inspector Variables
    /// <summary>
    /// Speed.
    /// </summary>
    public float speed = 4f;

    #region Position Variables
    /// <summary>
    /// X position limit.
    /// </summary>
    public float xLimit = 8f;

    public float xMultiplier = 1f;
    #endregion Position Variables

    #endregion Inspector Variables

    #region Private Variables
    #endregion Private Variables

    #region Game Cycle Methods

    /// <summary>
    /// Initializes the block.
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Makes the block move down
        transform.Translate(Vector3.right * (speed * xMultiplier * Time.deltaTime));

        // Checks for the bottom of the screen
        if (transform.position.x * xMultiplier > xLimit)
        {
            // Changes direction.
            xMultiplier *= -1;
        }
    }
    #endregion Game Cycle Methods

    #region Methods
    #endregion Methods
}
