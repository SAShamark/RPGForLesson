using System;
using PlayerCreator.Appearance;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class AppearanceFeatureSprite : MonoBehaviour
    {
        [SerializeField] private AppearanceFeature _appearanceFeature;
        [SerializeField] private int _spritesIndex;

        public AppearanceFeature AppearanceFeature => _appearanceFeature;
        public int SpritesIndex => _spritesIndex; 
    }
}