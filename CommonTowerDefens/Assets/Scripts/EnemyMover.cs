using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;
    
    void Start()
    {
        StartCoroutine(FollowPath());

    }

    IEnumerator FollowPath()
    {

        foreach(var p in path)
        {
            //Debug.Log(p.name);
            transform.position = p.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
