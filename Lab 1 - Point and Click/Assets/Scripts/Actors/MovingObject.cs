using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour
{
    #region Inspector Variables
    /// <summary>
    /// Maximum speed.
    /// </summary>
    public Vector3 maxSpeed = new Vector3(1f, 1f, 0f);

    /// <summary>
    /// How much time until the object changes direction.
    /// </summary>
    public float directionChangeTime = 0f;
    #endregion Inspector Variables

    #region Private Variables
    /// <summary>
    /// Current speed.
    /// </summary>
    private Vector3 currentSpeed;
    #endregion Private Variables

    #region Game Cycle Methods
    /// <summary>
    /// Initializes the object.
    /// </summary>
    void Start()
    {
        if (directionChangeTime > 0f)
        {
            InvokeRepeating("RandomDirection", 0.0f, directionChangeTime);
        }
        else
        {
            RandomDirection();
        }
    }

    /// <summary>
    /// Update is called every frame.
    /// </summary>
    void Update()
    {
        transform.position += currentSpeed;

        if( System.Math.Abs(transform.position.x) > 6f )
        {
            currentSpeed = Multiply(currentSpeed, -1, 1, 1);
        }
        else if (System.Math.Abs(transform.position.y) > 4f)
        {
            currentSpeed = Multiply(currentSpeed, 1, -1, 1);
        }
        else if (System.Math.Abs(transform.position.z) > 2f)
        {
            currentSpeed = Multiply(currentSpeed, 1, 1, -1);
        }
    }
    #endregion Game Cycle Methods

    #region Methods
    /// <summary>
    /// Multiplies the vector on the axis.
    /// </summary>
    /// <param name="vector">Vector</param>
    /// <param name="x">X position</param>
    /// <param name="y">Y position</param>
    /// <param name="z">Z position</param>
    /// <returns>Multiplied vector.</returns>
    Vector3 Multiply(Vector3 vector, float x, float y, float z)
    {
        return new Vector3(vector.x * x, vector.y * y, vector.z * z);
    }

    /// <summary>
    /// Changes to a random direction.
    /// </summary>
    void RandomDirection()
    {
        currentSpeed = new Vector3(Random.Range(-maxSpeed.x, maxSpeed.x),
                                   Random.Range(-maxSpeed.y, maxSpeed.y),
                                   Random.Range(-maxSpeed.z, maxSpeed.z));
    }
    #endregion Methods
}
