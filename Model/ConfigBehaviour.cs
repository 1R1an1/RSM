﻿using Newtonsoft.Json;

namespace Rain_save_manager.Model
{
	public class ConfigBehaviour
	{
		[JsonIgnore]
		public static string fileName = "";
		public ConfigBehaviour(string fileName) { ConfigBehaviour.fileName = fileName; }
    }
}