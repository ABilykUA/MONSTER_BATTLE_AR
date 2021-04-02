using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Controller : MonoBehaviour
{
       
    public GameObject EnemyUI;
    public GameObject BossUI;

    public GameObject PanelUI;


    public GameObject ARcam;

    private bool Booltrigger = false;



    public void SwitchValue() {

        Booltrigger = !Booltrigger;

    }
        
    
    
    public void OpenPanle() {
        
        if (Booltrigger == true)
        {

            PanelUI.SetActive(true);

        }
        else if (Booltrigger == false)
        {

            PanelUI.SetActive(false);

        }


    }


    void Update()
    {

    //fix look at 
    EnemyUI.transform.LookAt(ARcam.transform.position);
    EnemyUI.transform.Rotate(-90, 180, 0);

    BossUI.transform.LookAt(ARcam.transform.position);
    BossUI.transform.Rotate(-90, 180, 0);

    }

}
