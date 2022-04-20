using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Save;
using UnityEngine;

public class SaveFileHandler
{
	private string dataPath = "";
	private string dataFileName = "";

	public SaveFileHandler(string path, string filename)
	{
		dataPath = path;
		dataFileName = filename;
	}

	public GameData Load()
	{
		string fullPath = Path.Combine(dataPath, dataFileName);
		GameData loadedData = null;
		if (File.Exists(fullPath))
		{
			try
			{
				string dataToLoad = "";
				using (FileStream stream = new FileStream(fullPath, FileMode.Open))
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						dataToLoad = reader.ReadToEnd();
					}
				}

				loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
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

	public void Save(GameData data)
	{
		string fullPath = Path.Combine(dataPath, dataFileName);
		try
		{
			Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
			string dataToStore = JsonUtility.ToJson(data, true);
			using FileStream stream = new FileStream(fullPath, FileMode.Create);
			using (StreamWriter writer = new StreamWriter(stream))
			{
				writer.Write(dataToStore);
			}
		}
		catch (Exception exception)
		{
			Debug.LogError("Unable to save data to file " + fullPath + "\n" + exception);
			throw;
		}
		Debug.LogWarning("Saved successfully");

	}
}