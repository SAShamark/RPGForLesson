﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ObjectPooling;
using System;

namespace PlayerCreator.Specialization
{
    public class SkillView : MonoBehaviour,IPooliable
    {
        [SerializeField] private TMP_Text _skillName;
        [SerializeField] private TMP_Text _skillDescription;
        [SerializeField] private Image _skillImage;

        public TMP_Text SkillName=>_skillName;
        public TMP_Text SkillDescription=>_skillDescription;
        public Image SkillImage=>_skillImage;
        public Transform Transform => transform;
        public GameObject GameObject => gameObject;

        public event Action<IPooliable> OnReturnToPool;
        public void ReturnToPool()
        {
            OnReturnToPool?.Invoke(this);
        }
    }
}
