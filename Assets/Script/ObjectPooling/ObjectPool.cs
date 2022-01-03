using UnityEngine;
using System.Collections.Generic;
using System;

namespace ObjectPooling
{
    public class ObjectPool
    {
        private readonly Dictionary<IPooliable, PoolTask> _activePoolTask;
        private readonly Transform _objectPoolTransform;

        private static ObjectPool instance;
        public static ObjectPool Instance => instance ??= new ObjectPool();
        public ObjectPool()
        {
            _activePoolTask = new Dictionary<IPooliable, PoolTask>();
            _objectPoolTransform = new GameObject().transform;
            _objectPoolTransform.name = "ObjectPool";
        }
        public T GetObject<T>(T prefab) where T : MonoBehaviour, IPooliable
        {

            if (!_activePoolTask.TryGetValue(prefab, out var poolTask))
            {
                AddTaskToPool(prefab, out poolTask);
            }
            return poolTask.GetFreeObject<T>(prefab);
        }
        private void AddTaskToPool<T>(T prefab, out PoolTask poolTask) where T : MonoBehaviour, IPooliable
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

