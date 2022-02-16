using UnityEngine;
using TMPro;

namespace NameController
{
    public class NameAssignment : MonoBehaviour
    {
        private string _saveName;

        private TMP_InputField _inputText;

        [SerializeField] private TMP_Text _loadedName;
        private void Start()
        {
            _inputText = GameObject.Find("InputName").GetComponent<TMP_InputField>();

            _loadedName.text = PlayerPrefs.GetString("name", "none");
        }
        public void SetName()
        {
            if (_inputText.text == "")
            {
                Debug.Log("Error");
            }
            else
            {
                _saveName = _inputText.text;
                PlayerPrefs.SetString("name", _saveName);
                _loadedName.text = PlayerPrefs.GetString("name", "none");
            }
        }
    }
}