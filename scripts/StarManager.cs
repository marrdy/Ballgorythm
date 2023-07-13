using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class StarData
{
    public int[] starsEarned; // Array to store the stars earned for each level

    public StarData(int numLevels)
    {
        starsEarned = new int[numLevels];
    }
}

public class StarManager : MonoBehaviour
{
    public StarData starData;
    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/stardata.dat";
    }

    public void SaveStars()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(savePath);

        // Create a new StarData object and populate it with the stars earned for each level
        int numLevels = 10; // Change this to the actual number of levels in your game
        starData = new StarData(numLevels);

        // Populate the starData.starsEarned array with the stars earned for each level
        Debug.Log("star earned "+starData.starsEarned);
        // Serialize the starData object and save it to a file
        formatter.Serialize(file, starData);
        file.Close();
    }

    public void LoadStars()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);

            // Deserialize the starData object from the file
            starData = (StarData)formatter.Deserialize(file);
            file.Close();

            // Access the starData.starsEarned array to retrieve the stars earned for each level

            // Use the retrieved data as needed (e.g., display stars earned in UI)
        }
        else
        {
            Debug.Log("No star data found.");
        }
    }
}