using System.IO;

using UnityEngine;
using UnityEditor;

namespace Final
{

	///<summary>
	/// 
	///</summary>
	[CustomEditor(typeof(Item))]
	[CanEditMultipleObjects]
	public class ItemEditor : Editor
	{

		[MenuItem("GameObject/_FINAL/Items/Create Item Asset")]
		private static void CreateItemAssetGameObjectMenu()
        {
			CreateItemAsset(Selection.gameObjects);
		}

		[MenuItem("Assets/_FINAL/Items/Create Item Asset")]
		private static void CreateItemAssetAssetsMenu()
        {
			CreateItemAsset(Selection.gameObjects);
        }

		[MenuItem("GameObject/_FINAL/Items/Create Item Asset", true)]
		private static bool CreateItemAssetGameObjectMenuValidation()
        {
			return CreateItemAssetValidation(Selection.gameObjects);
		}

		[MenuItem("Assets/_FINAL/Items/Create Item Asset", true)]
		private static bool CreateItemAssetAssetsMenuValidation()
		{
			return CreateItemAssetValidation(Selection.gameObjects);
		}

		/// <summary>
		/// Creates an item asset for the selected items' GameObjects.
		/// </summary>
		/// <param name="_SelectedObjects">The current GameObjects selection.</param>
		private static void CreateItemAsset(GameObject[] _SelectedObjects)
        {
			foreach (GameObject go in _SelectedObjects)
			{
				if (go.TryGetComponent(out Item item))
				{
					// Get the original prefab of the selected GameObject
					Item source = PrefabUtility.GetCorrespondingObjectFromOriginalSource(item);
					if (source == null)
						continue;

					// Get the path of the original item GameObject prefab
					string sourcePath = AssetDatabase.GetAssetPath(source);
					sourcePath = $"{Path.GetDirectoryName(sourcePath)}/{source.name}.asset";

					// Create and save the new item asset
                    SO_Item itemAsset = CreateInstance<SO_Item>();
					AssetDatabase.CreateAsset(itemAsset, sourcePath);

					// Assign the item assets' prefab property
					SerializedObject itemAssetSerialized = new SerializedObject(itemAsset);
                    itemAssetSerialized.FindProperty("m_Prefab").objectReferenceInstanceIDValue = source.GetInstanceID();
					itemAssetSerialized.ApplyModifiedProperties();
					
					// Assign the new item asset to the selected GameObject
					SerializedObject sourceSerialized = new SerializedObject(source);
					sourceSerialized.FindProperty("m_ItemAsset").objectReferenceInstanceIDValue = itemAsset.GetInstanceID();

					// Update assets and save database
					itemAssetSerialized.ApplyModifiedProperties();
					sourceSerialized.ApplyModifiedProperties();
					AssetDatabase.SaveAssets();
                }
			}
		}

		/// <summary>
		/// Checks if the "Create Item Asset" option can be used.
		/// </summary>
		/// <param name="_SelectedObjects">The current GameObjects selection.</param>
		/// <returns>Returns true if Item assets can be created from at least one of the selected objects.</returns>
		private static bool CreateItemAssetValidation(GameObject[] _SelectedObjects)
		{
			foreach (GameObject go in _SelectedObjects)
			{
				if (go.GetComponent<Item>() != null)
					return true;
			}
			return false;
		}

	}

}