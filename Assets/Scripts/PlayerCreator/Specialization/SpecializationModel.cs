using System.Collections.Generic;
using GamePlay;
using Player;

namespace PlayerCreator.Specialization
{
    public class SpecializationModel
    {
        public List<Stat> Stats { get; }

        public SpecializationType SpecializationType { get; private set; }

        public SpecializationModel(List<Stat> stats)
        {
            Stats = stats;

            /*_specializationStats.Add(new SpecializationStats(new List<Stat> {new Stat(StatType.Agility, 2),
                    new Stat(StatType.Intelligence, 1), new Stat(StatType.Strength, 1)}, SpecializationType.Assassin));

            _specializationStats.Add(new SpecializationStats(new List<Stat> {new Stat(StatType.Agility, 1),
                new Stat(StatType.Intelligence, 0), new Stat(StatType.Strength, 3)}, SpecializationType.Warrior));
                */
        }

        public void ChangeSpecialization(SpecializationType specializationType, List<Stat> stats)
        {
            SpecializationType = specializationType;
            Stats.Clear();
            foreach (var stat in stats)
            {
                Stats.Add(new Stat(stat.StatType, stat.Value));
            }
        }
    }
}