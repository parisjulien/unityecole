using UnityEngine;

namespace Final
{

    ///<summary>
    /// Represents an effect that can be applied when an item is used.
    ///</summary>
    public abstract class SO_ItemEffect : ScriptableObject
    {

        /// <summary>
        /// Called when this effect should be applied. Note that if this method is used by the system, it means that CanBeApplied() had
        /// been called before and returned true.
        /// </summary>
        /// <param name="_Item">The used item that triggers this effect.</param>
        /// <param name="_User">The entity that used the item.</param>
        /// <returns>Returns true if the effect has been applied successfully, otherwise false.</returns>
        public abstract bool Apply(SO_Item _Item, ItemUser _User);

        /// <summary>
        /// Checks if this effect can be applied.
        /// If false, it means that the item can't be used at all.
        /// </summary>
        /// <param name="_Item">The used item that triggers this effect.</param>
        /// <param name="_User">The entity that used the item.</param>
        /// <returns>Returns true if the effect can be applied, otherwise false.</returns>
        public virtual bool CanBeApplied(SO_Item _Item, ItemUser _User)
        {
            return true;
        }

    }

}