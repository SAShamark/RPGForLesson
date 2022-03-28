using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PlayerCreator.Stats
{
    public class StatView : MonoBehaviour
    {
        [SerializeField] private Transform _statButtonsContainer;
        [SerializeField] private Button _decreaseButton;
        [SerializeField] private Button _increaseButton;
        [SerializeField] private TMP_Text _statHeader;
        [SerializeField] private TMP_Text _statValue;
        
        public Transform StatButtonsContainer => _statButtonsContainer;
        public Button DecreaseButton => _decreaseButton;
        public Button IncreaseButton => _increaseButton;
        public TMP_Text StatHeader => _statHeader;
        public TMP_Text StatValue => _statValue;
    }
}