using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Dictionary<GameObject, List<GameObject>> _poolObject = new Dictionary<GameObject, List<GameObject>>();
    public static ObjectPool Instance;  // singleton patten 
     private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }

    public GameObject getObject(GameObject objKey)
    {
        if (!_poolObject.ContainsKey(objKey))
        {
            _poolObject.Add(objKey, new List<GameObject>());
        }

        foreach (GameObject g in _poolObject[objKey])
        {
            if (g.activeInHierarchy)
            {
                continue;
            }
            return g;
        }

        GameObject obj2 = Instantiate(objKey, this.transform);
        _poolObject[objKey].Add(obj2);
        return obj2;
    }
    public T getObject<T>(GameObject objKey) where T : Component
    {
        return this.getObject(objKey).GetComponent<T>();
    }

    public void CreatePool(GameObject objKey, int size)
    {
        if (_poolObject.ContainsKey(objKey))
        {
            return;
        }

        _poolObject.Add(objKey, new List<GameObject>());
        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(objKey, this.transform);
            obj.SetActive(false);
            _poolObject[objKey].Add(obj);
        }
    }
}
