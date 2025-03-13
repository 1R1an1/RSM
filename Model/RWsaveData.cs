using static Rain_save_manager.Model.Enums;

namespace Rain_save_manager.Model
{
    public class RWsaveData
    {
        public RainWorldCharacter SlugCat;
        public int CycleNumber;
        public int Deaths;
        public int TotalTime; // En segundos
        public int KarmaCap;
        public int KarmaLevel;
        public bool ReinforcedKarma;

        //public int SurvivedCycles;
        //public int AbandonedCycles;
        //public int TotalFood;
        //public int Food;
        //public string DenPosition;
        //public bool SlugpupSpawn;
    }
}
