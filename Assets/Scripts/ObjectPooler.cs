using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {


    public Dictionary<string, Queue<GameObject>> poolDictionary;

    [System.Serializable]
    public class Pool {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    #region Singleton
    public static ObjectPooler Instance;
    private void Awake() {
        Instance = this;
    }
    #endregion


    public List<Pool> pools;

    void Start() {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }


    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        if (!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
            return null;
        }
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.SetPositionAndRotation(position, rotation);
        IProjectile projectile = objectToSpawn.GetComponent<IProjectile>();
        projectile?.OnObjectSpawn();
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
