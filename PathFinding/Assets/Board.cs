using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private int[,] grid;
    public GameObject wall;
    private bool hasStart;
    private bool hasEnd;
    public GameObject pathBoi;
    public int height;
    public int width;
    public GameObject start;
    public GameObject end;
    private int ballout;
    private Vector2 startPos;
    private Vector2 endPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        hasEnd = false;
        hasStart = false;    
        grid = new int[height,width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                grid[i,j] = number(3);
                if (grid[i,j] == 1)
                {
                    Instantiate(wall, new Vector3(i, 0, j), Quaternion.identity);
                }
            }
        }

        while (!hasStart)
        {
            startPos = FindRandomEmptyLocation();
            hasStart = true;
            Instantiate(start, new Vector3(startPos.x, 0, startPos.y), Quaternion.identity);
        }
        ballout = 0;
        while (!hasEnd)
        {
            endPos = FindRandomEmptyLocation();
            if (startPos != endPos)
            {
                hasEnd = true;
                Instantiate(end, new Vector3(endPos.x, 0, endPos.y), Quaternion.identity);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Space"))
        {
            FindPath();
        }
        
        
    }

    int number(int max)
    {
       int i = Random.Range(0, max);
       return i;
    }

     private Vector2 FindRandomEmptyLocation()
     {
         bool keeplooking = true;
        while(keeplooking)
        {
            int h = number(height);
            int w = number(width);

            if (grid[h, w] == 0)
            {
                return new Vector2(h,w);
            }
        }
        return new Vector2(11,11);
     }

     private void FindPath()
     {
         
         
     }

}
