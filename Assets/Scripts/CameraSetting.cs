using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    public List<GameObject> listCamera;
    public int cameraNumber;

    private void Start()
    {
        listCamera[0].SetActive(true);
        cameraNumber = 0;
    }

    private void Update()
    {
        if (cameraNumber == 0)
        {
            listCamera[0].SetActive(true);
            listCamera[1].SetActive(false);
            listCamera[2].SetActive(false);
        }
        if (cameraNumber == 1)
        {
            listCamera[0].SetActive(false);
            listCamera[1].SetActive(true);
            listCamera[2].SetActive(false);
        }
        if (cameraNumber == 2)
        {
            listCamera[0].SetActive(false);
            listCamera[1].SetActive(false);
            listCamera[2].SetActive(true);
        }
    }

    public void ChageCamera()
    {
        cameraNumber += 1;
        if (cameraNumber > listCamera.Count - 1)
        {
            cameraNumber = 0;
        }
    }
}
