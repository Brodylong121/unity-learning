using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{
    #region Inspector Variables
    /// <summary>
    /// Shield strenght.
    /// </summary>
    public int shieldStrenght = 3;
    #endregion Inspector Variables

    #region Private Variables
    #endregion Private Variables

    #region Game Cycle Methods
    /// <summary>
    /// Update is called once every frame.
    /// </summary>
    void Update()
    {
        if( shieldStrenght <= 0 )
        {
            (transform.parent.GetComponent("Player") as Player).DisableShield();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Called when another object collides with it.
    /// </summary>
    /// <param name="other">Collided object</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            shieldStrenght--;
        }
    }
    #endregion Game Cycle Methods

    #region Methods
    #endregion Methods
}
