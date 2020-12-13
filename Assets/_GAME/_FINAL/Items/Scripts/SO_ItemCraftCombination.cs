using UnityEngine;

namespace Final
{

    ///<summary>
    /// Represents a combination (= a recipe) of items that can be crafted together.
    ///</summary>
    [CreateAssetMenu(fileName = "NewCombination", menuName = "_FINAL/Item Craft Combination")]
    public class SO_ItemCraftCombination : ScriptableObject
    {

        [SerializeField]
        [Tooltip("Deifnes the items that are part of this combination")]
        private SO_Item[] m_CraftablItems = { };

        [SerializeField]
        [Tooltip("The item that will result of the combination of the defined craftable items")]
        private SO_Item m_Result = null;

        /// <summary>
        /// Checks if the given item is part of this combination.
        /// </summary>
        public bool IsPartOfCraft(SO_Item _Item)
        {
            foreach(SO_Item item in m_CraftablItems)
            {
                if (_Item == item)
                    return true;
            }
            return false;
        }

        public SO_Item Result => m_Result;

    }

}