using UnityEngine;
using System.Collections.Generic;

namespace ObjectPooling
{
    public class ObjectPool
    {
        private readonly Dictionary<IPoolable, PoolTask> _activePoolTask;
        private readonly Transform _objectPoolTransform;

        private static ObjectPool _instance;
        public static ObjectPool Instance => _instance ??= new ObjectPool();
        private ObjectPool()
        {
            _activePoolTask = new Dictionary<IPoolable, PoolTask>();
            _objectPoolTransform = new GameObject().transform;
            _objectPoolTransform.name = "ObjectPool";
        }
        public T GetObject<T>(T prefab) where T : MonoBehaviour, IPoolable
        {

            if (!_activePoolTask.TryGetValue(prefab, out var poolTask))
            {
                AddTaskToPool(prefab, out poolTask);
            }
            return poolTask.GetFreeObject(prefab);
        }
        private void AddTaskToPool<T>(T prefab, out PoolTask poolTask) where T : MonoBehaviour, IPoolable
        {
            GameObject container = new GameObject()
            {
                name = $"{prefab.name}s_pool"
            };
            container.transform.SetParent(_objectPoolTransform);
            poolTask = new PoolTask(container.transform);
            _activePoolTask.Add(prefab, poolTask);
        }

    }

}

