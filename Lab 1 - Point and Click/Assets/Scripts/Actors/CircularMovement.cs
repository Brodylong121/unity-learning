using UnityEngine;
using System.Collections;

public class CircularMovement : MonoBehaviour 
{
    #region Inspector Variables
    /// <summary>
    /// Object speed.
    /// </summary>
    public float speed = 0.2f;
    public float rotation = 10f;
    #endregion Inspector Variables

    #region Private Variables

    #endregion Private Variables

    #region Game Cycle Methods
    /// <summary>
    /// Initializes the object.
    /// </summary>
    void Start()
    {
    }

    /// <summary>
    /// Update is called every frame.
    /// </summary>
    void Update()
    {
        transform.Rotate(0, 0 , rotation);
        transform.Translate(speed, 0 , 0);
    }
    #endregion Game Cycle Methods

    #region Methods
    #endregion Methods
}
