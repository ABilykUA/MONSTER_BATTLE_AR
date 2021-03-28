using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScale : MonoBehaviour
{

    public GameObject Menu;


    // Start is called before the first frame update
    void Start()
    {

        Menu.transform.position = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
       

    }

}
