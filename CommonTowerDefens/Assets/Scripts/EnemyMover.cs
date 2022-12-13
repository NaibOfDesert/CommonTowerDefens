using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<Tile> path = new List<Tile>();
    [SerializeField] [Range(0f, 5f)]float speed = 1f;
    Enemy enemy; 
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());

    }
    void Start()
    {
        enemy = GetComponent<Enemy>();    
    }

    void FindPath()
    {
        path.Clear(); 
        GameObject parent = GameObject.FindGameObjectWithTag("Path"); 

        foreach(Transform child in parent.transform)
        {
            Tile tile = child.GetComponent<Tile>();
            if(tile != null)
            {
                path.Add(tile);

            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
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
        FinishPath();
    }
}
