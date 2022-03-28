using UnityEngine;

namespace PlayerCreator.Appearance
{
    public class AppearanceView : MonoBehaviour
    {
        [SerializeField] private AppearanceElementView _appearanceElementView;
        [SerializeField] private Transform _elementGrid;

        public AppearanceElementView PlayerAppearanceElementView => _appearanceElementView;
        public Transform ElementGrid => _elementGrid;
    }
}
