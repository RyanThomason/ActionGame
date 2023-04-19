using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [Header("Properties")]
    public int TowerHealth;
    public int TowerRange;
    public int TowerDamage;
    

    [Header("Objects")]
    public GameObject TowerPreFab;
    public GameObject CurrentTarget;

    private void DestroyTower()
    {

    }

    private GameObject GetNearestTarget()
    {
        GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag("Enemy");

        if (possibleTargets.Length == 0)
        {
            return null;
        }

        GameObject nearestTarget = possibleTargets[0]; // Grab the first element of the possibleTargets array as it is presumably the earliest and closest
        float shortestTargetDist = Vector3.Distance(TowerPreFab.transform.position, nearestTarget.transform.position);
        
        foreach (GameObject possibleTarget in possibleTargets)
        {
            float distanceFromTower = Vector3.Distance(TowerPreFab.transform.position, possibleTarget.transform.position);

            if (distanceFromTower < shortestTargetDist)
            {  
                shortestTargetDist = distanceFromTower; // Replace the shortestTargetDist
                nearestTarget = possibleTarget;
            }
        }

        return nearestTarget;
    }

    void Update()
    {
        GetNearestTarget();
        if (TowerHealth < 0)
        {
            DestroyTower();
        }
        CurrentTarget = GetNearestTarget();
        if (CurrentTarget != null)
        {
            
        }
    }



}
