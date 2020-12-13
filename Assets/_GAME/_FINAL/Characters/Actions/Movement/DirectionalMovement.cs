using UnityEngine;

namespace Final
{

    ///<summary>
    /// Represents a movement based on a given direction.
    ///</summary>
    public abstract class DirectionalMovement : Movement
    {

        /// <summary>
        /// Makes the object move in the given direction, by changing its transform position.
        /// </summary>
        /// <param name="_Direction">The direction you want the object to move.</param>
        /// <param name="_DeltaTime">The elapsed time since the last frame.</param>
        /// <returns>Returns true if the object has moved successfully, otherwise false.</returns>
        public abstract bool Move(Vector3 _Direction, float _DeltaTime);

    }

}