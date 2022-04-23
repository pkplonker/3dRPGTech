using System;
using System.Collections;
using System.Collections.Generic;
using SO;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private ItemBase item;
    private List<GameObject> items = new List<GameObject>();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Spawn(item);
        }
    }

    public void Spawn(ItemBase item, Vector3 position = new Vector3())
    {
        if (item == null || item.material == null || item.mesh == null)
        {
            Debug.Log("Item information missing");
        }
        GameObject newGameObject = new GameObject();
        newGameObject.name = item.itemName;
        items.Add(newGameObject);
        newGameObject.transform.position = position;
        MeshFilter meshFilter = newGameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = item.mesh;
        MeshRenderer meshRenderer = newGameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = item.material;
    }
}
