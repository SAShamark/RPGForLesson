using System.Collections.Generic;
using UnityEngine;

namespace PlayerCreator.Appearance
{
    [CreateAssetMenu(fileName = "AppearanceFeaturesSpriteStorage", menuName = "PlayerAppearance/AppearanceFeatures")]
    public class AppearanceFeaturesSpriteStorage : ScriptableObject
    {
        [SerializeField] private List<AppearanceFeatureSprites> _appearanceFeatureSprites;
        public List<AppearanceFeatureSprites> AppearanceFeatureSprites => _appearanceFeatureSprites;
    }
}