using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


    public class Controller : MonoBehaviour
    {
       
        public GameObject mPanleTitle;
        public GameObject mUI;

        public GameObject EnemyUI;
        public GameObject ARcam;

        private float width;
        private float height;

        // Start is called before the first frame update
        void Start()
        {
            height = Screen.height;
            width = Screen.width;

         mPanleTitle.transform.position = new Vector2(Screen.width / 2.0f, Screen.height - 150f);
             mUI.transform.position = new Vector2(Screen.width / 2.0f, Screen.height / 6f);


        }

        // Update is called once per frame
        void Update()
        {
        //fix look at 
        EnemyUI.transform.LookAt(ARcam.transform.position);
        EnemyUI.transform.Rotate(-90, 180, 0);
        //EnemyUI.transform.LookAt(ARcam.transform);
    }

    }
