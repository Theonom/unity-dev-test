using System.Collections.Generic;
using UnityEngine;

public class DetectorParking : MonoBehaviour
{
    public Collider carCollider;
    public List<GameObject> parkingArea;
    public GameObject gameOverPopUp;
    public Vector3 rangeParking;
    public PrometeoCarController carController;
    public List<Collider> listColl = new List<Collider>();
    private GameObject areaSelect;

    private bool inArea = false;
    private bool collision = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int index = Random.Range(0, parkingArea.Count);
        areaSelect = parkingArea[index];
        areaSelect.SetActive(true);
        FillCollidersFromParent(areaSelect);
        gameOverPopUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InAreaParking();
        ParkingSuccess();
    }

    public void ParkingSuccess()
    {
        float absoluteCarSpeed = Mathf.Abs(carController.carSpeed);
        if (!collision && inArea && Mathf.RoundToInt(absoluteCarSpeed) == 0)
        {
            gameOverPopUp.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void InAreaParking()
    {
        float maxAreaX = areaSelect.transform.position.x + rangeParking.x;
        float minAreaX = areaSelect.transform.position.x - rangeParking.x;
        float maxAreaZ = areaSelect.transform.position.z + rangeParking.z;
        float minAreaZ = areaSelect.transform.position.z - rangeParking.z;

        if (transform.position.x < maxAreaX &&
            transform.position.x > minAreaX &&
            transform.position.z < maxAreaZ &&
            transform.position.z > minAreaZ)
        {
            inArea = true;
        }
        else
        {
            inArea = false;
        }
    }

    public void FillCollidersFromParent(GameObject parent)
    {
        listColl.Clear();
        Collider[] colliders = parent.GetComponentsInChildren<Collider>();

        foreach (Collider col in colliders)
        {
            listColl.Add(col);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (Collider col in listColl)
        {
            if (other == col)
            {
                collision = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (Collider col in listColl)
        {
            if (other == col)
            {
                collision = false;
            }
        }
    }
}
