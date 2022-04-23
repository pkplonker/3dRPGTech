using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Save
{
	public class SaveFileHandler
	{
		private readonly string dataPath;
		private readonly string dataFileName;

		public SaveFileHandler(string path, string filename)
		{
			dataPath = path;
			dataFileName = filename;
		}

		public Dictionary<string, object> Load()
		{
			string fullPath = Path.Combine(dataPath, dataFileName);
			if (string.IsNullOrWhiteSpace(fullPath)) throw new Exception("No Filepath supplied");
			Dictionary<string, object> loadedData = new Dictionary<string, object>();
			if (File.Exists(fullPath))
			{
				try
				{
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

		public void Clear()
		{
			string fullPath = Path.Combine(dataPath, dataFileName);
			try
			{
				if (!File.Exists(fullPath)) return;
				File.Delete(fullPath);
			}
			catch (Exception exception)
			{
				Debug.LogError("Unable to clear save data file " + fullPath + "\n" + exception);
				throw;
			}
		}
	}
}