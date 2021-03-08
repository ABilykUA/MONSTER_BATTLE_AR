using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public TextMeshProUGUI mTitle;
    public GameObject mPanleTitle;
    public GameObject mStats;

    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        height = Screen.height;
        width = Screen.width;

        mTitle.SetText("Level: " + height +" | "+ width);


        mPanleTitle.transform.position = new Vector2(Screen.width / 2.0f, Screen.height -150f);
        mStats.transform.position = new Vector2(Screen.width / 2.0f, Screen.height /6f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
