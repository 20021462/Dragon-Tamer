using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private DragonController dragon;
    private List<CollectibleItem> itemList = new List<CollectibleItem>();

    private void Start()
    {
        
    }

    private Vector3 FindNextTarget()
    {
        float minDist = float.MaxValue;
        Vector3 target = new Vector3();
        foreach (CollectibleItem item in itemList)
        {
            float dist = Vector3.Distance(dragon.transform.position, item.transform.position);
            if (dist < minDist) 
            {
                minDist = dist;
                target = item.transform.position;
            }
        }

        return target;
    }

    private Vector3 FindFarTarget()
    {
        float maxDist = float.MinValue;
        Vector3 target = new Vector3();
        foreach (CollectibleItem item in itemList)
        {
            float dist = Vector3.Distance(dragon.transform.position, item.transform.position);
            if (dist > maxDist)
            {
                maxDist = dist;
                target = item.transform.position;
            }
        }

        return target;
    }

    public void AddItem(CollectibleItem item)
    {
        itemList.Add(item);
        Vector3 target = FindFarTarget();
        dragon.SetTarget(target);
    }
}
