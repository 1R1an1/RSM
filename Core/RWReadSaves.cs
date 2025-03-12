using Rain_save_manager.Model;
using System;
using System.Collections.Generic;
using System.IO;
using static Rain_save_manager.Model.Enums;

namespace Rain_save_manager.Core
{
    public static class RWreadSaves
    {

        private static Dictionary<RainWorldCharacter, string> characterTags = new Dictionary<RainWorldCharacter, string>()
        {
            { RainWorldCharacter.Yellow, "Yellow&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.White, "White&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.Red, "Red&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.Gourmand, "Gourmand&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.Artificer, "Artificer&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.Rivulet, "Rivulet&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.Spear, "Spear&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.Saint, "Saint&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.Inv, "Inv&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.Vinki, "Vinki&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.Darkness, "Darkness&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.SlugSpore, "SlugSpore&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.TheDroneMaster, "thedronemaster&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.Hubert, "Hubert&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.Photomaniac, "Photomaniac&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.Pearlcat, "Pearlcat&lt;svA&gt;SEED&lt;svB&gt;" },
            { RainWorldCharacter.WingCat, "WingCat&lt;svA&gt;SEED&lt;svB&gt;" }
        };

        public static Dictionary<RainWorldCharacter, RWsaveData> ReadSaveData(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            Dictionary<RainWorldCharacter, RWsaveData> allCharactersData = new Dictionary<RainWorldCharacter, RWsaveData>();

            foreach (var characterPair in characterTags)
            {
                int characterStart = fileContent.LastIndexOf(characterPair.Value, StringComparison.Ordinal);
                if (characterStart != -1)
                {
                    RWsaveData data = ReadCharacterData(fileContent, characterStart);
                    allCharactersData.Add(characterPair.Key, data);
                }
            }

            return allCharactersData;
        }

        private static RWsaveData ReadCharacterData(string fileContent, int characterStart)
        {
            RWsaveData data = new RWsaveData();

            data.CycleNumber = ReadIntValue(fileContent, characterStart, ";CYCLENUM");
            data.Deaths = ReadIntValue(fileContent, characterStart, ";DEATHS");
            //data.SurvivedCycles = ReadIntValue(fileContent, characterStart, ";SURVIVES");
            //data.AbandonedCycles = ReadIntValue(fileContent, characterStart, ";QUITS");
            data.TotalTime = ReadIntValue(fileContent, characterStart, ";TOTTIME");
            //data.TotalFood = ReadIntValue(fileContent, characterStart, ";TOTFOOD");
            //data.Food = ReadIntValue(fileContent, characterStart, ";FOOD");
            //data.DenPosition = ReadStringValue(fileContent, characterStart, ";DENPOS");
            data.KarmaLevel = ReadIntValue(fileContent, characterStart, ";KARMA");
            //data.KarmaCap = ReadIntValue(fileContent, characterStart, ";KARMACAP");
            data.ReinforcedKarma = ReadIntValue(fileContent, characterStart, ";REINFORCEDKARMA") == 1;
            //data.SlugpupSpawn = ReadIntValue(fileContent, characterStart, ";CyclesSinceSlugpup") == 100;

            return data;
        }

        private static int ReadIntValue(string fileContent, int characterStart, string statTag)
        {
            int statStart = fileContent.IndexOf(statTag, characterStart, StringComparison.Ordinal) + statTag.Length;
            string intValue = FindInt(fileContent, statStart);
            return int.Parse(intValue);
        }

        /*
        private static string ReadStringValue(string fileContent, int characterStart, string statTag)
        {
            int statStart = fileContent.IndexOf(statTag, characterStart, StringComparison.Ordinal) + statTag.Length;
            string pattern = "([A-Z]{2}_[A-Z][0-9]{2})";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(fileContent, statStart);
            return match.Groups[1].Value;
        }
        */

        private static string FindInt(string fileContent, int startIndex)
        {
            string intValue = "";
            for (int i = startIndex; i < fileContent.Length; i++)
            {
                if (char.IsDigit(fileContent[i]) || fileContent[i] == '-')
                {
                    intValue += fileContent[i];
                }
                else
                {
                    if (intValue.Length > 0)
                    {
                        break;
                    }
                }
            }
            return intValue;
        }
    }

    // Toda la clase echa con gemini :) //
}
