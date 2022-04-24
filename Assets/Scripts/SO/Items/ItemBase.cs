using System;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace SO
{
	public abstract class ItemBase : ScriptableObject, ISerializationCallbackReceiver
	{
		static Dictionary<string, ItemBase> itemLookupCache;
		public string itemID = "";

		public string itemName;
		[TextArea(5, 10)] public string description;
		public uint maxQuantity = uint.MaxValue;

		[Header("Graphical representation - 2D")]
		public Sprite sprite;

		[Header("Graphical representation - 3D")]
		public List<MeshDetails> meshDetailsList;


		public float scaleFactor = 1f;
		public Quaternion spawnRotation = Quaternion.identity;

		public void OnBeforeSerialize()
		{
			if (string.IsNullOrWhiteSpace(itemID))
			{
				itemID = System.Guid.NewGuid().ToString();
			}
		}

		public void OnAfterDeserialize()
		{
		}

		public abstract bool Use(Inventory inventory);

		public static ItemBase GetItemFromID(string id)
		{
			if (id == null) return null;
			if (itemLookupCache == null)
			{
				itemLookupCache = new Dictionary<string, ItemBase>();
				var itemList = Resources.LoadAll<ItemBase>("");
				foreach (var item in itemList)
				{
					if (itemLookupCache.ContainsKey(item.itemID))
					{
						Debug.LogError(
							string.Format("Duplicate items: {0} and {1}", itemLookupCache[item.itemID], item));
						continue;
					}

					itemLookupCache[item.itemID] = item;
				}
			}

			return !itemLookupCache.ContainsKey(id) ? null : itemLookupCache[id];
		}
		[Serializable]
		public class MeshDetails
		{
			public Mesh mesh;
			public Material material;
		}
	}

}