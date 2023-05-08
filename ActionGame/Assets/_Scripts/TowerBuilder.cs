using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public GameObject towerPrefab;

    private GameObject currentPlot; // Current plot being accessed by player
    private bool isBuilding = false;    // Determine if player char is building the tower on this plot

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentPlot != null)
        {
            if (isBuilding)
            {
                // Build the tower on the current plot
                BuildTower();
                //TowerManager.CreateTower();
                isBuilding = false;
            }
            else
            {
                // Select the current plot for building
                isBuilding = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plot"))
        {
            Debug.Log("inside plot");
            currentPlot = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Plot"))
        {
            currentPlot = null;
            isBuilding = false;
        }
    }

    void BuildTower()   // Creates the tower
    {
        towerPrefab = currentPlot.GetComponent<TowerManager>().TowerPreFab;   // grabs the prefab from the plot for instantiation
        GameObject newTower = Instantiate(towerPrefab, currentPlot.transform.position, Quaternion.identity);
        currentPlot.GetComponent<TowerManager>().CreateTower();    // Through the script component of the Enemy GameObject, set tower active    }
    }
}
