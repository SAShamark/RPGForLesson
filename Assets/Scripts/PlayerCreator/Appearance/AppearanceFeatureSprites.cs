using System.Collections.Generic;
using UnityEngine;
using System;

namespace PlayerCreator.Appearance
{
    [Serializable]
    public class AppearanceFeatureSprites
    {
        [SerializeField] private AppearanceFeature _appearanceFeature;
        [SerializeField] private List<Sprite> _sprites;

        public AppearanceFeature AppearanceFeature => _appearanceFeature;
        public List<Sprite> Sprites => _sprites;

    }
}