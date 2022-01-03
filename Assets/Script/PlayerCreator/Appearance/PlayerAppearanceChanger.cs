using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;
using Serialization;

namespace PlayerCreator
{

    public class PlayerAppearanceChanger : MonoBehaviour
    {
        [SerializeField] private PlayerAppearance _playerAppearance;
        [SerializeField] private PlayerAppearanceView _appearanceView;
        [SerializeField] private AppearanceFeaturesSpriteStorage _storage;

        private List<PlayerAppearanceElementController> _elementControllers;
        private string SavePath => Path.Combine(Application.dataPath, "Serialisation/Player", "PlayerAppearance.txt");
        public void Start()
        {
            Dictionary<AppearanceFeature, int> appearanceFeatures = new Dictionary<AppearanceFeature, int>();
            appearanceFeatures = Serializator.Deserializate<Dictionary<AppearanceFeature, int>>(SavePath);
            _elementControllers = new List<PlayerAppearanceElementController>();
            foreach (var featureSprite in _storage.AppearanceFeatureSprites)
            {
                int index = 0;
                appearanceFeatures.TryGetValue(featureSprite.AppearanceFeature, out index);
                PlayerAppearanceElementView elementView = Instantiate(_appearanceView.PlayerAppearanceElementView,
                    _appearanceView.ElementGrid);
                PlayerAppearanceElementController elementController =
                    new PlayerAppearanceElementController(elementView, featureSprite,
                    _playerAppearance.GetFeatureSprite(featureSprite.AppearanceFeature), index);
                _elementControllers.Add(elementController);
            }
        }
        private void OnDestroy()
        {
            Dictionary<AppearanceFeature, int> appearanceFeatures = new Dictionary<AppearanceFeature, int>();
            foreach (var element in _elementControllers)
            {
                appearanceFeatures.Add(element.AppearanceFeature, element.Index);
                element.Dispouse();
            }
            Serializator.SerealizateData(appearanceFeatures, SavePath);
        }

    }
}