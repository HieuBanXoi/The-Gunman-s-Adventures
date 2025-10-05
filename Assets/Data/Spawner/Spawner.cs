using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : CoreMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected Transform holder;
    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected virtual void LoadHolder()
    {
        if(this.holder != null) return;
        this.holder = transform.Find("Holder");
    }
    protected virtual void LoadPrefabs()
    {
        if(this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach(Transform child in prefabObj)
        {
            this.prefabs.Add(child);
        }
        HidePrefabs();
    }
    protected virtual void HidePrefabs()
    {
        foreach(Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    public virtual Transform Spawn(string prefabName,Vector3 position, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if(prefab == null) return null;

        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(position, rotation);

        newPrefab.SetParent(this.holder);
        return newPrefab;
    }
    public virtual void Despawn(Transform obj)
    {
        obj.gameObject.SetActive(false);
        this.poolObjs.Add(obj);
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach(Transform poolObj in this.poolObjs)
        {
            if(poolObj.name == prefab.name)
            {
                poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newObj = Instantiate(prefab);
        newObj.name = prefab.name;
        return newObj;
    }
    public virtual Transform GetPrefabByName(string name)
    {
        foreach(Transform prefab in this.prefabs)
        {
            if(prefab.name == name) return prefab;
        }
        Debug.LogWarning("Can't find prefab with name: " + name);
        return null;
    }
    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
}
