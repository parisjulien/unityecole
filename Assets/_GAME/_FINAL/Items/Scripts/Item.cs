using UnityEngine;

namespace Final
{

    ///<summary>
    /// Represents an item in the scene.
    ///</summary>
    [AddComponentMenu("_FINAL/Items/Item")]
    public class Item : MonoBehaviour
    {

        [SerializeField]
        [Tooltip("The item asset represented by this GameObject")]
        private SO_Item m_ItemAsset = null;

        public SO_Item ItemAsset => m_ItemAsset;

    }

}