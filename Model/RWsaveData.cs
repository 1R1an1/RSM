﻿using static Rain_save_manager.Model.Enums;

namespace Rain_save_manager.Model
{
    /*
    public class RWsaveData
    {
        public Dictionary<int, string> slugCats;
        //public List<>

        public RWsaveData(Dictionary<int, string> slugCats)
        {
            this.slugCats = slugCats;
        }

        public RWsaveData()
        {
            slugCats = new Dictionary<int, string>();
        }
    }
    */

    public class RWsaveData
    {
        public RainWorldCharacter SlugCat;
        public int CycleNumber;
        public int Deaths;
        public int TotalTime; // En segundos
        public int KarmaLevel;
        public bool ReinforcedKarma;

        //public int SurvivedCycles;
        //public int AbandonedCycles;
        //public int TotalFood;
        //public int Food;
        //public string DenPosition;
        //public int KarmaCap;
        //public bool SlugpupSpawn;
    }
}
