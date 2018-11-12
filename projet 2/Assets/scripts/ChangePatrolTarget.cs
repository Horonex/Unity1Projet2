using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePatrolTarget : MonoBehaviour {

    [SerializeField] FollowTarget chaser;
    //[SerializeField] GameObject patrol;
    //private FollowTarget followTarget;

	// Use this for initialization
	void Start () {
        //followTarget = chaser.GetComponent<FollowTarget>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Player")
        chaser.SetTargetPlayer();
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            chaser.SetTargetPatrol();
            //patrol.transform.position = chaser.transform.position;
        }
    }
}
