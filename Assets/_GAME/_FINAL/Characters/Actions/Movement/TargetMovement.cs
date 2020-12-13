using UnityEngine;

namespace Final
{

    ///<summary>
    /// Represents a movement based on a given target to reach.
    ///</summary>
    public abstract class TargetMovement : Movement
    {

        /// <summary>
        /// Makes the object move to the given target.
        /// </summary>
        /// <param name="_Target">The target position to reach.</param>
        /// <returns>Returns true if the object can move to the target position, otherwise false.</returns>
        public abstract bool MoveTo(Vector3 _Target);

        /// <summary>
        /// Makes the object move to the given target.
        /// </summary>
        /// <param name="_Target">The target Transform's position to reach.</param>
        /// <returns>Returns true if the object can move to the target position, otherwise false.</returns>
        public virtual bool MoveTo(Transform _Target)
        {
            return MoveTo(_Target.position);
        }

    }

}