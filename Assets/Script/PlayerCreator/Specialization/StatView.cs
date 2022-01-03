using TMPro;
using UnityEngine;
using ObjectPooling;
using System;

namespace PlayerCreator.Specialization
{
    public class StatView : MonoBehaviour,IPooliable
    {
        [SerializeField] private TMP_Text _statType;
        [SerializeField] private TMP_Text _statAmount;

        public TMP_Text StatType => _statType;
        public TMP_Text StatAmount => _statAmount;

        public Transform Transform => transform;

        public GameObject GameObject => gameObject;

        public event Action<IPooliable> OnReturnToPool;
        public void ReturnToPool()
        {
            OnReturnToPool?.Invoke(this);
        }
    }
}