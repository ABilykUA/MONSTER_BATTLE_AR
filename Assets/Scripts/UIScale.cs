using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScale : MonoBehaviour
{

    public GameObject Menu;

    public GameObject Disabilty;


    // Start is called before the first frame update
    void Start()
    {

        Menu.transform.position = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
        Disabilty.transform.position = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);

    }

}
