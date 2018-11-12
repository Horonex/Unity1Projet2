using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    [SerializeField] bool isPlayer = true;
    [SerializeField] GameObject prefabCreature;
    FollowTarget[] patrolers;

    public void Spawning(GameObject toDestroy)
    {
        GameObject creature = Instantiate(prefabCreature, transform.position, transform.rotation);
        foreach(var p in patrolers)
        {
            p.player = creature.transform;
            p.SetTargetPatrol();
        }
        Destroy(toDestroy);
    }
    public void Spawning()
    {
        GameObject creature = Instantiate(prefabCreature, transform.position, transform.rotation);
        foreach (var p in patrolers)
        {
            p.player = creature.transform;
            p.SetTargetPatrol();
        }
    }

    void Start()
    {
        GameObject[] p = GameObject.FindGameObjectsWithTag("Chaser");
        patrolers = new FollowTarget[p.Length];
        for(int i=0;i<patrolers.Length;i++)
        {
            patrolers[i]=p[i].GetComponent<FollowTarget>();
        }
        Spawning();
    }
    
}
