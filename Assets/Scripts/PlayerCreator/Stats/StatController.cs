using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayerCreator.Stats
{
    public class StatController : MonoBehaviour
    {
        private readonly StatView _view;
        private List<StatButton> _statsButtons;

        public StatController(StatView view)
        {
            _view = view;
        }

        public int MaxValue => _statsButtons.Count;
        
        public event Action<StatController> OnStatViewIncreaseClicked;
        public event Action<StatController> OnStatViewDecreaseClicked;
        public event Action<StatController, int> OnStatViewValueClicked;

        public void Initialize(string statText)
        {
            _statsButtons = _view.StatButtonsContainer.GetComponentsInChildren<StatButton>().ToList();
           _view.StatHeader.text = statText;
           _view.DecreaseButton.onClick.AddListener(OnDecreaseButtonClicked);
           _view.IncreaseButton.onClick.AddListener(OnIncreaseButtonClicked);
            foreach (var statButton in _statsButtons)
            {
                statButton.Initialize();
                statButton.OnClicked += OnStatButtonClicked;
            }
        }

        public void Dispose()
        {
          _view.DecreaseButton.onClick.RemoveListener(OnDecreaseButtonClicked);
          _view.IncreaseButton.onClick.RemoveListener(OnIncreaseButtonClicked);
            foreach (var statButton in _statsButtons)
            {
                statButton.OnClicked -= OnStatButtonClicked;
            }
        }
        private void OnIncreaseButtonClicked()
        {
            OnStatViewIncreaseClicked?.Invoke(this);
        }

        private void OnDecreaseButtonClicked()
        {
            OnStatViewDecreaseClicked?.Invoke(this);
        }

        private void OnStatButtonClicked(StatButton statButton)
        {
            OnStatViewValueClicked?.Invoke(this, _statsButtons.IndexOf(statButton));
        }
        private void SetButtonsState(int value)
        {
            foreach (var statButton in _statsButtons)
            {
                statButton.SetState(_statsButtons.IndexOf(statButton) < value);
            }
        }
        public void UpdateView(bool canIncrease, bool canDecrease, int value)
        {
           _view.DecreaseButton.enabled = canDecrease;
           _view.IncreaseButton.enabled = canIncrease;
            ChangeStat(value);
        }

        private void ChangeStat(int statValue)
        {
            _view.StatValue.text = statValue.ToString();
            SetButtonsState(statValue);
        }
    }
}