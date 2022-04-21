using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Save
{
	public class SaveFileHandler
	{
		private string dataPath = "";
		private string dataFileName = "";

		public SaveFileHandler(string path, string filename)
		{
			dataPath = path;
			dataFileName = filename;
		}

		public Dictionary<string, object> Load()
		{
			string fullPath = Path.Combine(dataPath, dataFileName);
			Dictionary<string, object> loadedData = new Dictionary<string, object>();
			if (File.Exists(fullPath))
			{
				try
				{
					string dataToLoad = "";
					using (FileStream stream = new FileStream(fullPath, FileMode.Open))
					{
						BinaryFormatter formatter = new BinaryFormatter();
						loadedData = (Dictionary<string, object>) formatter.Deserialize(stream);
					}
				}
				catch (Exception exception)
				{
					Debug.LogError("Unable to load data from " + fullPath + "\n" + exception);
					throw;
				}
			}
			
			Debug.LogWarning("Load successfully read");
			return loadedData;
		}

		public void Save(object data)
		{
			string fullPath = Path.Combine(dataPath, dataFileName);
			try
			{
				Directory.CreateDirectory(Path.GetDirectoryName(fullPath) ?? string.Empty);
				BinaryFormatter formatter = new BinaryFormatter();
				using FileStream stream = new FileStream(fullPath, FileMode.Create);
				formatter.Serialize(stream, data);
			}
			catch (Exception exception)
			{
				Debug.LogError("Unable to save data to file " + fullPath + "\n" + exception);
				throw;
			}

			Debug.LogWarning("Saved successfully");
		}
	}
}