﻿using System;
using TMPro;
using UI.PlayerCreator.Appearance.View;
using UI.PlayerCreator.Specialization;
using UI.PlayerCreator.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI.PlayerCreator
{
    public class PlayerCreatorView : MonoBehaviour
    {
        [SerializeField] private CreationTabSwitcher _creationTabSwitcher;
        [SerializeField] private Transform _switchersContainer;
        [SerializeField] private TMP_InputField _nameInputField;
        [SerializeField] private Button _saveButton;

        [Header("Specialization")] 
        [SerializeField] private SpecializationView _specializationView;
        [SerializeField] private SpecializationConfigsStorage _specializationConfigsStorage;
        [SerializeField] private SpecializationAppearance _specializationAppearance;
        
        [Header("Stats")]
        [SerializeField] private StatsChangerView _statView;

        [Header("Appearance")] 
        [SerializeField] private AppearanceView _appearanceView;
        [SerializeField] private AppearanceChangerView _appearanceChangerView;

        public CreationTabSwitcher CreationTabSwitcher => _creationTabSwitcher;
        public Transform SwitchersContainer => _switchersContainer;
        public StatsChangerView StatView => _statView;
        public SpecializationView SpecializationView => _specializationView;
        public SpecializationConfigsStorage SpecializationConfigsStorage => _specializationConfigsStorage;
        public SpecializationAppearance SpecializationAppearance => _specializationAppearance;
        public AppearanceView AppearanceView => _appearanceView;
        public AppearanceChangerView AppearanceChangerView => _appearanceChangerView;
        
        public event Action<string> OnNameChanged;
        public event Action OnSaveClicked;

        public void Initialize()
        {
            _nameInputField.onEndEdit.AddListener((value) => OnNameChanged?.Invoke(value));
            _saveButton.onClick.AddListener(() => OnSaveClicked?.Invoke());
        }

        private void OnDestroy()
        {
            _nameInputField.onEndEdit.RemoveAllListeners();
            _saveButton.onClick.RemoveAllListeners();
        }
    }
}