using UnityEngine;
using System.Collections.Generic;

namespace PlayerCreator.Specialization
{
    [CreateAssetMenu(fileName = "SpecializationConfigStorage", menuName = "PlayerCreator/SpecializationConfigs")]
    public class SpecializationConfigsStorage : ScriptableObject
    {
        [SerializeField] private List<SpecializationConfig> _specializationConfigs;

        public List<SpecializationConfig> SpecializationConfigs => _specializationConfigs;

    }
}
