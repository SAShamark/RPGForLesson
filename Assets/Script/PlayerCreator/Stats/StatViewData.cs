using GamePlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerCreator.Stats
{
    public class StatViewData
    {
        public StatView StatView { get; }
        public Stat Stat { get; }
        public int MinValue { get; }
        public StatViewData(StatView statView, Stat stat, int minValue)
        {
            StatView = statView;
            Stat = stat;
            MinValue = minValue;
        }
    }
}
