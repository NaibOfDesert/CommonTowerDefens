using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid; 

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }
    }
    void Start()
    {
        ExploreNeighbors();
    }
    void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        foreach(var d in directions)
        {
            Vector2Int neighborsCoords = currentSearchNode.coordinates + d;
            if (grid.ContainsKey(neighborsCoords))
            {
                neighbors.Add(grid[neighborsCoords]);
                grid[neighborsCoords].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;
            }

        }
    }

}
