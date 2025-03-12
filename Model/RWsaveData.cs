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
        public int CycleNumber { get; set; }
        public int Deaths { get; set; }
        //public int SurvivedCycles { get; set; }
        //public int AbandonedCycles { get; set; }
        public int TotalTime { get; set; } // En segundos
        //public int TotalFood { get; set; }
        //public int Food { get; set; }
        //public string DenPosition { get; set; }
        public int KarmaLevel { get; set; }
        //public int KarmaCap { get; set; }
        public bool ReinforcedKarma { get; set; }
        //public bool SlugpupSpawn { get; set; }

        public RWsaveData()
        {
            // Inicialización opcional de valores predeterminados
        }
    }
}
