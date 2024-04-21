using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnOnARMesh : MonoBehaviour
{
    [SerializeField] private List<CollectibleItem> itemPrefabs = new List<CollectibleItem>();
    [SerializeField] private float minVertsForSpawn;
    [SerializeField] private float scaler;
    
    [Range(0,100)]
    [SerializeField] private int spawnLikelyHood = 33; 
    private CollectibleItem spawnedObject;

    private MeshAnalyser meshAnalyser;
    private Mesh arMesh; 
    // Start is called before the first frame update
    void Start()
    {
        if(spawnLikelyHood == 0) return;
        meshAnalyser = GetComponent<MeshAnalyser>();
        meshAnalyser.analysisDone += StartSpawning;
    }

    private void OnDestroy()
    {
        meshAnalyser.analysisDone -= StartSpawning;
    }

    void StartSpawning()
    {
        arMesh = GetComponent<MeshFilter>().sharedMesh;


        int spawnLikely =  Random.Range(0, 100 / spawnLikelyHood);
        Debug.Log("Spawnlikely => " + spawnLikely);

        if (spawnLikely != 0)
        {
            return;
        }

        if (arMesh.vertexCount > minVertsForSpawn &&
            meshAnalyser.IsGround)
        {
            InstantiateItem(GetRandomItem());
        }
        
    }
    CollectibleItem GetRandomItem()
    {
        return itemPrefabs[Random.Range(0, itemPrefabs.Count)];
    }

    void InstantiateItem(CollectibleItem obj)
    {
        spawnedObject = Instantiate(obj, GetRandomVector(), Quaternion.identity);
        spawnedObject.transform.localScale *= scaler;
        //GameManager.Instance.AddItem(spawnedObject);
    }

    Vector3 GetRandomVector()
    {
        Vector3 highestVert = Vector3.zero;
        float highestY = Mathf.NegativeInfinity;

        foreach (var vert in arMesh.vertices)
        {
            if (vert.y > highestY)
            {
                highestY = vert.y;
                highestVert = transform.TransformPoint(vert);
            }
        }
        
        return highestVert;
    }
}
