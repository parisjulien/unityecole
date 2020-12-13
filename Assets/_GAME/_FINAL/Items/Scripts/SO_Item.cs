using UnityEngine;

namespace Final
{

    ///<summary>
    /// Represents an item that can be used by a character.
    ///</summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "_FINAL/Item")]
    public class SO_Item : ScriptableObject
    {

        [Header("Base Settings")]

        [SerializeField]
        [Tooltip("The name of this item, as displayed on the UI")]
        private string m_ItemName = string.Empty;

        [SerializeField, TextArea()]
        [Tooltip("The description of this item, as displayed on the UI")]
        private string m_Description = string.Empty;

        [SerializeField]
        [Tooltip("The prefab of this item")]
        private Item m_Prefab = null;

        [Header("Behaviors")]

        [SerializeField]
        private bool m_Eatable = false;

        [SerializeField]
        private SO_ItemEffect[] m_EffectsWhenEaten = { };

        /// <summary>
        /// Make the given user eat this item if possible.
        /// </summary>
        /// <param name="_User">The user of this item.</param>
        /// <returns>Returns true if this item can be eaten successfully, otherwise false;</returns>
        public virtual bool Eat(ItemUser _User)
        {
            if (!m_Eatable)
                return false;

            // If one of the item effects can't be applied, cancel operation
            foreach(SO_ItemEffect effect in m_EffectsWhenEaten)
            {
                if (!effect.CanBeApplied(this, _User))
                    return false;
            }

            // Apply all the effects of this item when eaten
            foreach (SO_ItemEffect effect in m_EffectsWhenEaten)
                effect.Apply(this, _User);

            return true;
        }

        public string Name => !string.IsNullOrEmpty(m_ItemName) ? m_ItemName : name;
        public string Description => m_Description;
        public Item Prefab => m_Prefab;

        public bool Eatable => m_Eatable;

    }

}