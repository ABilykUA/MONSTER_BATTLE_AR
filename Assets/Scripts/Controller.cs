using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


    public class Controller : MonoBehaviour
    {
       
   
        public GameObject EnemyUI;
        public GameObject ARcam;

        // Update is called once per frame
        void Update()
        {
        //fix look at 
        EnemyUI.transform.LookAt(ARcam.transform.position);
        EnemyUI.transform.Rotate(-90, 180, 0);
        //EnemyUI.transform.LookAt(ARcam.transform);
        }

    }
