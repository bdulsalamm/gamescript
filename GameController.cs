// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Models; // custom namespace


// public class GameController : MonoBehaviour
// {
//     private float cpuTemperature;
//     private float gpuTemperature;
//     private float cpuPerformance;
//     private float gpuPerformance;
//     private float ramUsage;

//     private bool isTaskRunning;

//     private float totalCpuCapacity = 100.0f;  // Percentages
//     private float totalGpuCapacity = 100.0f; // Percentages
//     private float totalRamCapacity = 64.0f; //  GB

//     private float maxTemp = 80;
//     private float minTemp = 40;

//     public TaskManager taskManager;

//     // Start is called before the first frame update
//     void Start()
//     {
//         cpuTemperature = minTemp;
//         gpuTemperature = minTemp;
//         cpuPerformance = 15.0f; 
//         gpuPerformance = 15.0f; 
//         ramUsage = 20.0f;
//         taskManager = new TaskManager();
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     void Validate()
//     {
//         if (cpuTemperature >= maxTemp || gpuTemperature >= maxTemp)
//         {
//             // Warn and stop
//         }
//     }


//     void OnAddTask( Task task )
//     {
//         taskManager.AddTask(task);
//     }

//     void OnDeleteTask(Task task)
//     {
//         taskManager.RemoveTask(task);
//     }

//     void OnBrowserAddTab(Browser browser)
//     {
//         //browser.OpenTab();
//     }

//     void OnBrowserCloseTab(Browser browser)
//     {
//         //browser.CloseTab();
//     }

//     void OnDisplay()
//     {
//         if (isTaskRunning)
//         {
//             return;
//         }
//     }
// }
