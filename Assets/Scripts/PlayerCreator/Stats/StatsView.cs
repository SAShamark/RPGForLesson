using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PlayerCreator.Stats
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private List<StatView> _statViews;
        [SerializeField] private TMP_Text _freeStatsText;
        public List<StatView> StatViews => _statViews;
        public TMP_Text FreeStatsText => _freeStatsText;
    }
}

