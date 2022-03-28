using CoreUI;
using Player.Config;
using PlayerCreator.Appearance;
using PlayerCreator.Specialization;
using PlayerCreator.Stats;
using Serialization;
using UnityEngine;

namespace PlayerCreator
{
    public class PlayerCreatorController : MonoBehaviour
    {
        [SerializeField] private PlayerCreatorView _creatorView;

        private StatsChanger _statChanger;
        private StatsModel _statsModel;

        private SpecializationChanger _specializationChanger;
        private SpecializationModel _specializationModel;

        private AppearanceChanger _appearanceChanger;
        private AppearanceModel _appearanceModel;

        private PlayerConfig _playerConfig;
        private IViewController _currentController;

        private void Start()
        {
            _playerConfig = new PlayerConfig();
            _statsModel = new StatsModel(_playerConfig.Stats, 10);
            _specializationModel = new SpecializationModel(_playerConfig.Stats);
            //_appearanceModel= new AppearanceModel();

            _statChanger = new StatsChanger(_creatorView.StatsView);
            _specializationChanger = new SpecializationChanger(_creatorView.SpecializationView,
                _creatorView.SpecializationConfigsStorage);
            //_appearanceChanger = new AppearanceChanger();
            foreach (var button in _creatorView.CreationTabButtons)
            {
                button.Initialize();
                button.OnButtonClicked += OnTabChanger;
            }

            _currentController = GetAndInitializeController(CreationTab.Specialization);
        }

        private void OnTabChanger(CreationTab creationTab)
        {
            _currentController?.Complete();
            _currentController = GetAndInitializeController(creationTab);
        }

        private IViewController GetAndInitializeController(CreationTab creationTab)
        {
            switch (creationTab)
            {
                case CreationTab.Appearance:
                    _appearanceChanger.Initialize(_appearanceModel);
                    return _appearanceChanger;
                case CreationTab.Specialization:
                    _specializationChanger.Initialize(_specializationModel);
                    return _specializationChanger;
                case CreationTab.Stats:
                    _statChanger.Initialize(_statsModel);
                    return _statChanger;
                default:
                    return null;
            }
        }

        private void OnDestroy()
        {
            foreach (var button in _creatorView.CreationTabButtons)
            {
                button.OnButtonClicked -= OnTabChanger;
            }

            _playerConfig.SetSpecialization(_specializationModel.SpecializationType);
            Debug.LogError(_playerConfig.SpecializationType);
            foreach (var stat in _playerConfig.Stats)
            {
                Debug.LogError($"{stat.StatType}={stat.Value}");
            }
        }

        private void OnStartGameClick()
        {
            Serializator.Serealizate(_playerConfig, "PlayerConfig");
        }
    }
}