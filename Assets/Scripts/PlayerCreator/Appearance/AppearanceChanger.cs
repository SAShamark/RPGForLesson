using System.Collections.Generic;
using UnityEngine;
using System.IO;
using CoreUI;
using Serialization;

namespace PlayerCreator.Appearance
{
    public class AppearanceChanger : MonoBehaviour,IViewController
    {
        [SerializeField] private Appearance _playerAppearance;
        [SerializeField] private AppearanceView _appearanceView;
        [SerializeField] private AppearanceFeaturesSpriteStorage _storage;

        private List<AppearanceElementController> _elementControllers;
        private string SavePath => Path.Combine(Application.dataPath, "Serialization/Player", "PlayerAppearance.txt");
        public void Start()
        {
            Dictionary<AppearanceFeature, int> appearanceFeatures = Serializator.Deserializate<Dictionary<AppearanceFeature, int>>(SavePath);
            _elementControllers = new List<AppearanceElementController>();
            foreach (var featureSprite in _storage.AppearanceFeatureSprites)
            {
                appearanceFeatures.TryGetValue(featureSprite.AppearanceFeature, out int index);
                AppearanceElementView elementsView = Instantiate(_appearanceView.PlayerAppearanceElementView, _appearanceView.ElementGrid);
                AppearanceElementController elementController = new AppearanceElementController(elementsView, featureSprite,
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
            Serializator.Serealizate(appearanceFeatures, SavePath);
        }

        public void Initialize(params object[] args)
        {
            throw new System.NotImplementedException();
        }

        public void Complete()
        {
            throw new System.NotImplementedException();
        }
    }
}