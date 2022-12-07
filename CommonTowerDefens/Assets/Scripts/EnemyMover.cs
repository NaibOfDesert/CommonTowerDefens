using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)]float speed = 1f;
    
    void Start()
    {
        StartCoroutine(FollowPath());

    }

    IEnumerator FollowPath()
    {
        foreach(var p in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = p.transform.position;
            float travelpercent = 0f;
            transform.LookAt(endPosition);

            while(travelpercent < 1f)
            {
                travelpercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelpercent);
                yield return new WaitForEndOfFrame();
            }
            
        }
    }
}
