using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using PlayerCreator.Appearance;
using PlayerCreator.Specialization;
using PlayerCreator.Stats;

namespace PlayerCreator
{
    public class PlayerCreatorView : MonoBehaviour
    {
        [SerializeField] private List<CreationTabButton> _creationTabButtons;
        [SerializeField] private Button _saveButton;
        [SerializeField] private TMP_InputField _nameInputField;

        [SerializeField] private AppearanceView _appearanceView;
        
        [Header("Specialization")]
        [SerializeField] private SpecializationView _specializationView;
        [SerializeField] private SpecializationConfigsStorage _specializationConfigsStorage;

        [SerializeField] private StatsChangerView _statsView;
        public List<CreationTabButton> CreationTabButtons => _creationTabButtons;
        public StatsChangerView StatsView => _statsView;
        public SpecializationView SpecializationView => _specializationView;
        public SpecializationConfigsStorage SpecializationConfigsStorage => _specializationConfigsStorage;
    }
}