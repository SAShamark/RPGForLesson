using System;
using UnityEngine;

namespace ObjectPooling
{
    public interface IPooliable
    {
        Transform Transform { get; }
        GameObject GameObject { get; }
        event Action<IPooliable> OnReturnToPool;
        void ReturnToPool();
    }
}
