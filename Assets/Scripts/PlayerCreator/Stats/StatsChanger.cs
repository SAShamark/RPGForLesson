using System;
using System.Collections.Generic;
using System.Linq;
using CoreUI;
using UnityEngine;

namespace PlayerCreator.Stats
{
    public class StatsChanger : IViewController
    {
        private readonly StatsChangerView _changerView;
        private List<StatViewData> _statViewsData;
        
        private int _freeStats;
        
        public StatsChanger(StatsChangerView changerView)
        {
            _changerView = changerView;
        }

        public void Initialize(params object[] args)
        {
            if (args == null || args.Length < 1 || !args.Any(arg => arg is StatsModel))
            {
                throw new NullReferenceException($"There is no args for{nameof(StatsChanger)}");
            }

            object model = args.First(arg => arg is StatsModel);
            StatsModel statsModel = model as StatsModel;

            _statViewsData = new List<StatViewData>();

            if (statsModel != null)
            {
                _freeStats = statsModel.FreeStats;
                _changerView.FreeStatsText.text = $"Stats left:{_freeStats}";
                for (int i = 0; i < statsModel.Stats.Count; i++)
                {
                    if (i >= _changerView.StatController.Count)
                    {
                        break;
                    }

                    _changerView.StatController[i].Initialize(statsModel.Stats[i].StatType.ToString());
                    _changerView.StatController[i].OnStatViewDecreaseClicked += DecreaseStatValue;
                    _changerView.StatController[i].OnStatViewIncreaseClicked += IncreaseStatValue;
                    _changerView.StatController[i].OnStatViewValueClicked += ChangeStatValue;
                    _statViewsData.Add(new StatViewData(_changerView.StatController[i], statsModel.Stats[i],
                        statsModel.Stats[i].Value));
                }
            }

            UpdateStatViews();
            _changerView.Show();
        }

        public void Complete()
        {
            foreach (var statViewData in _statViewsData)
            {
                statViewData.StatController.Dispose();
                statViewData.StatController.OnStatViewDecreaseClicked -= DecreaseStatValue;
                statViewData.StatController.OnStatViewIncreaseClicked -= IncreaseStatValue;
                statViewData.StatController.OnStatViewValueClicked -= ChangeStatValue;
            }
            _changerView.Hide();
        }

        public void ChangeFreeStats(int value)
        {
            _freeStats += value;
            _changerView.FreeStatsText.text = $"Stats left:{_freeStats}";
        }

        private void IncreaseStatValue(StatController statController)
        {
            StatViewData statViewData = _statViewsData.Find(data => data.StatController == statController);
            ChangeStat(statViewData, statViewData.Stat.Value + 1);
        }

        private void DecreaseStatValue(StatController statController)
        {
            StatViewData statViewData = _statViewsData.Find(data => data.StatController == statController);
            ChangeStat(statViewData, statViewData.Stat.Value - 1);
        }

        private void ChangeStatValue(StatController statController, int value)
        {
            StatViewData statViewData = _statViewsData.Find(data => data.StatController == statController);
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
            _changerView.FreeStatsText.text = $"Stats left:{_freeStats}";
            statViewData.Stat.SetValue(value);
            UpdateStatViews();
        }

        private void UpdateStatViews()
        {
            foreach (var statViewData in _statViewsData)
            {
                int value = statViewData.Stat.Value;

                statViewData.StatController.UpdateView(_freeStats > 0 &&
                                                 value < statViewData.StatController.MaxValue, value > statViewData.MinValue,
                    value);
            }
        }
    }
}