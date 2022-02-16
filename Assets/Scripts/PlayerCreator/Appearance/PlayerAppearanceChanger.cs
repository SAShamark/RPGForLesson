using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Serialization;

namespace PlayerCreator.Appearance
{
    public class PlayerAppearanceChanger : MonoBehaviour
    {
        [SerializeField] private PlayerAppearance _playerAppearance;
        [SerializeField] private PlayerAppearanceView _appearanceView;
        [SerializeField] private AppearanceFeaturesSpriteStorage _storage;

        private List<PlayerAppearanceElementController> _elementControllers;
        private string SavePath => Path.Combine(Application.dataPath, "Serialization/Player", "PlayerAppearance.txt");
        public void Start()
        {
            Dictionary<AppearanceFeature, int> appearanceFeatures = Serializator.Deserializate<Dictionary<AppearanceFeature, int>>(SavePath);
            _elementControllers = new List<PlayerAppearanceElementController>();
            foreach (var featureSprite in _storage.AppearanceFeatureSprites)
            {
                appearanceFeatures.TryGetValue(featureSprite.AppearanceFeature, out int index);
                PlayerAppearanceElementView elementsView = Instantiate(_appearanceView.PlayerAppearanceElementView, _appearanceView.ElementGrid);
                PlayerAppearanceElementController elementController = new PlayerAppearanceElementController(elementsView, featureSprite,
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
                element.Dispose();
            }
            Serializator.SerealizateData(appearanceFeatures, SavePath);
        }

    }
}