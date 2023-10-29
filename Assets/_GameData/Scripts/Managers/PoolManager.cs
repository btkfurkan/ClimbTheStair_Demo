using System;
using System.Collections.Generic;
using UnityEngine;
public class PoolManager : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> _pooledObject;
        public GameObject objectPrefab;
        public int poolSize;
        public Transform poolTransform;
    }

    public Pool[] pools = null;

    private void Awake()
    {
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j]._pooledObject = new Queue<GameObject>();

            for (int i = 0; i < pools[j].poolSize; i++)
            {
                var obj = Instantiate(pools[j].objectPrefab, pools[j].poolTransform);

                obj.SetActive(false);

                pools[j]._pooledObject.Enqueue(obj);
            }
        }
    }
    public GameObject GetPooledObject(int objectType)
    {
        if (objectType >= pools.Length)
        {
            return null;
        }

        GameObject obj = pools[objectType]._pooledObject.Dequeue();

        obj.SetActive(true);

        pools[objectType]._pooledObject.Enqueue(obj);

        return obj;
    }
}
