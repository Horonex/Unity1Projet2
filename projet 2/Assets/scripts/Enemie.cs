using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour {


    [SerializeField] Path path;
    public float speed=8.0f;
    [SerializeField] Transform enemie;
    int pathSize;
    int currentPath=0;
    public bool isDeadly;

    public Vector3 direction;


    // Use this for initialization
    void Start () {
        pathSize = path.waypoints.Length;
        transform.position = path.waypoints[0].transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        direction = path.waypoints[(currentPath+1)%pathSize].transform.position- path.waypoints[currentPath % pathSize].transform.position;

        Move(direction);
	}

    private void Move(Vector3 direction)
    {
        enemie.position += direction.normalized *speed* Time.deltaTime;
        if(Vector3.Distance(transform.position,path.waypoints[(currentPath + 1) % pathSize].transform.position)<0.1)
        {
            currentPath++;
        }
    }
    //rend.bounds.center

    //private void OnCollisionEnter(Collision col)
    //{
    //    //Debug.Log("col2");
    //    if(col.transform.tag=="Waypoint")
    //    {
    //    }
    //    else if(col.transform.tag=="Player"&&isDeadly)
    //    {
    //        GameManager.Reset();
    //    }
    //}
}
