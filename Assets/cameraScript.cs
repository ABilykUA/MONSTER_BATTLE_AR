using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraScript : MonoBehaviour
{
    private bool cam;
    private WebCamTexture backcam;
    private Texture back;

    public RawImage backg;
    public AspectRatioFitter fit;

    private void Start()
    {
        back = backg.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0) {

            cam = false;
            return;
        }



        for (int i = 0; i < devices.Length; i++) {

            if (!devices[i].isFrontFacing)
            {
                backcam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);            
            }

        }

        if (backcam == null) {
            return;
        }

        backcam.Play();
        backg.texture = backcam;

        cam = true;
    }

    private void Update()
    {
        if (!cam) {

            return;
        }

        fit.aspectRatio = (float)backcam.width / (float)backcam.height;

        float scaleY = backcam.videoVerticallyMirrored ? -1f : 1f;
        backg.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orio = -backcam.videoRotationAngle;
        backg.rectTransform.localEulerAngles = new Vector3(0, 0, orio);
    }

}
