using PlayerCreator;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AppearanceFeaturesSpriteStorage", menuName = "PlayerAppearance/AppearanceFeatures")]
public class AppearanceFeaturesSpriteStorage : ScriptableObject
{
    [SerializeField] private List<AppearanceFeatureSprites> _appearanceFeatureSprites;
    public List<AppearanceFeatureSprites> AppearanceFeatureSprites => _appearanceFeatureSprites;
}
