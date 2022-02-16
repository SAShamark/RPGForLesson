using System.Collections.Generic;
using UnityEngine;
using GamePlay;

namespace PlayerCreator.Stats
{
    public class StatsChanger : MonoBehaviour
    {
        [SerializeField] private StatsView _statsView;
        private List<StatViewData> _statViewsData;
        private int _freeStats;

        private void Start()
        {
            _statViewsData = new List<StatViewData>();

            List<Stat> stats = new List<Stat>
                {new Stat(StatType.Agility, 2), new Stat(StatType.Intelligence, 1), new Stat(StatType.Strength, 1)};

            _freeStats = 10;


            _statsView.FreeStatsText.text = $"Stats left:{_freeStats}";
            for (int i = 0; i < stats.Count; i++)
            {
                if (i >= _statsView.StatViews.Count)
                {
                    break;
                }

                _statsView.StatViews[i].Initialize(stats[i].StatType.ToString());
                _statsView.StatViews[i].OnStatViewDecreaseClicked += DecreaseStatValue;
                _statsView.StatViews[i].OnStatViewIncreaseClicked += IncreaseStatValue;
                _statsView.StatViews[i].OnStatViewValueClicked += ChangeStatValue;
                _statViewsData.Add(new StatViewData(_statsView.StatViews[i], stats[i], stats[i].Value));
            }

            UpdateStatViews();
        }

        public void ChangeFreeStats(int value)
        {
            _freeStats += value;
            _statsView.FreeStatsText.text = $"Stats left:{_freeStats}";
        }

        private void IncreaseStatValue(StatView statView)
        {
            StatViewData statViewData = _statViewsData.Find(data => data.StatView == statView);
            ChangeStat(statViewData, statViewData.Stat.Value + 1);
        }

        private void DecreaseStatValue(StatView statView)
        {
            StatViewData statViewData = _statViewsData.Find(data => data.StatView == statView);
            ChangeStat(statViewData, statViewData.Stat.Value - 1);
        }

        private void ChangeStatValue(StatView statView, int value)
        {
            StatViewData statViewData = _statViewsData.Find(data => data.StatView == statView);
            ChangeStat(statViewData, value);
        }

        private void ChangeStat(StatViewData statViewData, int value)
        {
            int oldValue = statViewData.Stat.Value;
            if (_freeStats < 0 && value > oldValue)
            {
                return;
            }

            if (value < statViewData.MinValue)
            {
                return;
            }

            value = Mathf.Clamp(value, statViewData.MinValue, oldValue + _freeStats);
            _freeStats += oldValue - value;
            _statsView.FreeStatsText.text = $"Stats left:{_freeStats}";
            statViewData.Stat.SetValue(value);
            UpdateStatViews();
        }

        private void UpdateStatViews()
        {
            foreach (var statViewData in _statViewsData)
            {
                int value = statViewData.Stat.Value;

                statViewData.StatView.UpdateView(_freeStats > 0 &&
                                                 value < statViewData.StatView.MaxValue, value > statViewData.MinValue,
                    value);
            }
        }
    }
}