using UnityEngine;
using System;

namespace PlayerCreator.PlayerCreator
{
    public class PlayerAppearance : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _hair;
        [SerializeField] private SpriteRenderer _eyes;
        [SerializeField] private SpriteRenderer _mouth;
        [SerializeField] private SpriteRenderer _beard;
        [SerializeField] private SpriteRenderer _ears;
        [SerializeField] private SpriteRenderer _eyebrows;

        
        public SpriteRenderer GetFeatureSprite(AppearanceFeature feature)
        {
            switch (feature)
            {
                case AppearanceFeature.Hair:
                    return _hair;
                case AppearanceFeature.Eyes:
                    return _eyes;
                case AppearanceFeature.Mouth:
                    return _mouth;
                case AppearanceFeature.Beard:
                    return _beard;
                case AppearanceFeature.Ears:
                    return _ears;
                case AppearanceFeature.Eyebrows:
                    return _eyebrows;
                default:
                    throw new NullReferenceException(message: $"There is not spriteRenderer for feature{feature.ToString()}");
            }
        }
    }
}
