using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


    public class Controller : MonoBehaviour
    {
        public TextMeshProUGUI mTitle;
        public GameObject mPanleTitle;
        public GameObject mUI;

<<<<<<< HEAD
    
    private float width;
    private float height;
=======
        public GameObject EnemyUI;
        public GameObject ARcam;

        private float width;
        private float height;
>>>>>>> 37b859a13865f8033e8e6b32695e3469f9ba6cec

        // Start is called before the first frame update
        void Start()
        {
            height = Screen.height;
            width = Screen.width;

<<<<<<< HEAD
        mTitle.SetText("Level: " + height +" | "+ width);
        
=======
            mTitle.SetText("Level: " + height + " | " + width);

>>>>>>> 37b859a13865f8033e8e6b32695e3469f9ba6cec

            mPanleTitle.transform.position = new Vector2(Screen.width / 2.0f, Screen.height - 150f);
             mUI.transform.position = new Vector2(Screen.width / 2.0f, Screen.height / 6f);


        }

        // Update is called once per frame
        void Update()
        {
            //fix look at 
            EnemyUI.transform.Rotate(0f, 0.0f, 0.2f);
            //EnemyUI.transform.LookAt(ARcam.transform);
        }

    }
