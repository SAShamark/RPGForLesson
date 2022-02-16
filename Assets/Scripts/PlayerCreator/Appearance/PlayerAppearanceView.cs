using UnityEngine;

namespace PlayerCreator.Appearance
{
    public class PlayerAppearanceView : MonoBehaviour
    {
        [SerializeField] private PlayerAppearanceElementView _appearanceElementView;
        [SerializeField] private Transform _elementGrid;

        public PlayerAppearanceElementView PlayerAppearanceElementView => _appearanceElementView;
        public Transform ElementGrid => _elementGrid;
    }
}
