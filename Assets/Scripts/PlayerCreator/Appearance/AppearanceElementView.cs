using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PlayerCreator.Appearance
{
    public class AppearanceElementView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _elementHeader;
        [SerializeField] private TMP_Text _styleHeader;
        [SerializeField] private Button _leftArrow;
        [SerializeField] private Button _rightArrow;


        public TMP_Text ElementHeader => _elementHeader;
        public TMP_Text StyleHeader => _styleHeader;
        public Button LeftArrow => _leftArrow;
        public Button RightArrow => _rightArrow;


    }
}