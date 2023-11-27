using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    static string filePath;

    private static CSVWriter instance;

    // Ensure only one instance of the class exists
    public static CSVWriter Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CSVWriter();
            }
            return instance;
        }
    }

    private CSVWriter() { } // Private constructor to prevent instantiation

    void Start()
    {
        filePath = Application.dataPath + "/Statistics.csv";
        WriteStartTime();
        WriteLevel(Statistics.instane.level.ToString());
    }

    private void OnApplicationQuit()
    {
        WriteEndTime();
    }

    public void WriteStartTime()
    {
        TextWriter sw = new StreamWriter(filePath, true);
        string startTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
        sw.WriteLine("Garden_Do_Session_Start_Time," + startTime);
        sw.Close();
    }

    public void WriteEndTime()
    {
        TextWriter sw = new StreamWriter(filePath, true);
        string endTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
        sw.WriteLine("Garden_Do_Session_End_Time," + endTime);
        sw.Close();
    }

    public void WriteLevel(string level)
    {
        TextWriter sw = new StreamWriter(filePath, true);

        sw.WriteLine("Level," + level);
        sw.Close();
    }

    public void WriteFlowerWateringTime(string flowerWateringTime)
    {
        TextWriter sw = new StreamWriter(filePath, true);

        sw.WriteLine($"Flower{Statistics.instane.currentFlowerIndex}_Watering_Time," + flowerWateringTime);
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

