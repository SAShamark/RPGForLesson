using UnityEngine;

namespace PlayerCreator.PlayerCreator
{
    public class PlayerAppearanceView : MonoBehaviour
    {
        [SerializeField] private PlayerAppearanceElementView _appearanceElementView;
        [SerializeField] private Transform _elementGrid;

        public PlayerAppearanceElementView PlayerAppearanceElementView => _appearanceElementView;
        public Transform ElementGrid => _elementGrid;
    }
}
