using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    //private static CSVWriter instance;

    //// Ensure only one instance of the class exists
    //public static CSVWriter Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = new CSVWriter();
    //        }
    //        return instance;
    //    }
    //}

    //private CSVWriter() { } // Private constructor to prevent instantiation

    private static CSVWriter instance;

    public static CSVWriter Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject("CSVWriter");
                instance = singletonObject.AddComponent<CSVWriter>();
            }
            return instance;
        }
    }

    static string filePath;
    private string level = "9000";
    private List<DateTime> startTimes = new List<DateTime>();
    private List<DateTime> endTimes = new List<DateTime>();
    //private List<List<string>> interruptionTimes = new List<List<string>>();
    private Dictionary<int, List<string>> interruptionTimes = new Dictionary<int, List<string>>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        //filePath = Application.dataPath + "/Statistics.csv";
        filePath = Application.dataPath + "/" + System.DateTime.Now.ToFileTime() + ".csv";
        //filePath = Application.dataPath + "/" + System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + ".csv";

        WriteStartTime();
        WriteLevel(Statistics.instane.level.ToString());
    }

    private void OnApplicationQuit()
    {
        //WriteEndTime();

       WriteCSV();
    }

    //// Reset data when a new scene is loaded
    //private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    // Reset your data here
    //    score = 0;
    //    playerName = "DefaultPlayer";

    //    Debug.Log("Data Reset on Scene Change");
    //}

    public void WriteStartTime()
    {
        //TextWriter sw = new StreamWriter(filePath, true);
        //string startTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
        //sw.WriteLine("Garden_Do_Session_Start_Time," + startTime);
        //sw.Close();

        //startTimes.Add(System.DateTime.Now);
    }

    public void WriteEndTime()
    {
        //TextWriter sw = new StreamWriter(filePath, true);
        //string endTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
        //sw.WriteLine("Garden_Do_Session_End_Time," + endTime);
        //sw.Close();

        //endTimes.Add(System.DateTime.Now);
    }

    public void WriteLevel(string level)
    {
        //TextWriter sw = new StreamWriter(filePath, true);

        //sw.WriteLine("Level," + level);
        //sw.Close();
        this.level = level;

    }

    public void WriteFlowerWateringTime(string flowerWateringTime)
    {
        TextWriter sw = new StreamWriter(filePath, true);

        sw.WriteLine($"Flower_{Statistics.instane.currentFlowerIndex + 1}_Watering_Time," + flowerWateringTime);
        sw.Close();
    }

    public void WriteFlowerInteruptionTime(string flowerInteruptionTime)
    {
        TextWriter sw = new StreamWriter(filePath, true);

        sw.WriteLine($"Flower_{Statistics.instane.currentFlowerIndex + 1}_Interuption_Time," + flowerInteruptionTime);
        sw.Close();
    }

    public void WriteDistractorTime(string distractorName, string distractionTime)
    {
        TextWriter sw = new StreamWriter(filePath, true);

        sw.WriteLine($"{distractorName}_Distraction_Time," + distractionTime);
        sw.Close();
    }

    public void WriteFlowerStartAndEndTimes(DateTime flowerStartTime, DateTime flowerEndTime)
    {
        startTimes.Add(flowerStartTime);
        endTimes.Add(flowerEndTime);
    }

    public void WriteFlowerInteruptionTimes(string interruptionTime)
    {
        int key = Statistics.instane.currentFlowerIndex;
        // Check if the key exists in the dictionary
        if (interruptionTimes.ContainsKey(Statistics.instane.currentFlowerIndex))
        {
            // Retrieve the list, add the new item, and update the dictionary
            List<string> originalList = interruptionTimes[key];
            originalList.Add(interruptionTime);
        }
        else
        {
            // If the key doesn't exist, create a new entry with an empty list
            interruptionTimes[key] = new List<string> { interruptionTime };
        }
    }

    public void WriteCSV()
    {
        TextWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine("Garden_Do, " + level);
        sw.WriteLine("Target Starting Time" + ", " + "Target Hitting Time " + ", " + "Interruption Durations");
        for (int i = 0; i < endTimes.Count; i++)
        {
            if (interruptionTimes.TryGetValue(i, out List<string> listOfInterruptions))
            {
                sw.WriteLine(startTimes[i].ToString() + ", " + endTimes[i].ToString() + ", " + string.Join(",", interruptionTimes[i]));
            }
            else
            {
                sw.WriteLine(startTimes[i].ToString() + ", " + endTimes[i].ToString());
            }
        }
        ////for (int i = 0; i < interruptionDurations.Count; i++)
        ////{
        ////    tw.WriteLine(interruptionDurations[i].ToString());
        ////}
        //sw.WriteLine("Distractor Name          " + ", " + "Time Following It");
        //for (int i = 0; i < DistractorsName.Count; i++)
        //{
        //    sw.WriteLine(DistractorsName[i].ToFixedString(25, ' ') + ", " + TimeFollowingDistractors[i].ToString());
        //}
        sw.Close();
    }

    //public void AppendToCSV(string filePath, string[][] newData)
    //{
    //    // Append data to an existing CSV file
    //    using (StreamWriter sw = new StreamWriter(filePath, true))
    //    {
    //        // Write each row to the file
    //        foreach (string[] line in newData)
    //        {
    //            sw.WriteLine(string.Join(",", line));
    //        }
    //    }

    //    Debug.Log("Data appended to CSV file: " + filePath);
    //}
}

