using MalbersAnimations.Controller;
using MalbersAnimations.Controller.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private List<CollectibleItem> itemList = new List<CollectibleItem>();
    [SerializeField] private MAnimalAIControl dragon;

    private CollectibleItem FindNextTarget()
    {
        float minDist = float.MaxValue;
        CollectibleItem target = itemList[0];
        foreach (CollectibleItem item in itemList)
        {
            float dist = Vector3.Distance(dragon.transform.position, item.transform.position);
            if (dist < minDist) 
            {
                minDist = dist;
                target = item;
            }
        }

        return target;
    }

    private CollectibleItem FindFarthestTarget()
    {
        float maxDist = float.MinValue;
        CollectibleItem target = itemList[0];
        foreach (CollectibleItem item in itemList)
        {
            float dist = Vector3.Distance(dragon.transform.position, item.transform.position);
            if (dist > maxDist)
            {
                maxDist = dist;
                target = item;
            }
        }

        return target;
    }

    public void AddItem(CollectibleItem item)
    {
        itemList.Add(item);
        CollectibleItem target = FindFarthestTarget();
        dragon.SetTarget(target.waypoint.transform);
    }
}
