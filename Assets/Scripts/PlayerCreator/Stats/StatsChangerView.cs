using System.Collections.Generic;
using CoreUI;
using UnityEngine;
using TMPro;

namespace PlayerCreator.Stats
{
    public class StatsChangerView : BaseView
    {
        [SerializeField] private List<StatController> _statControllers;
        [SerializeField] private TMP_Text _freeStatsText;
        public List<StatController> StatController => _statControllers;
        public TMP_Text FreeStatsText => _freeStatsText;
    }
}

