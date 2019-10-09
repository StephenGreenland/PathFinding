using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private int[,] grid;
    public GameObject wall;
    private bool hasStart;
    private bool hasEnd;
    public Vector2 pathBoi;
    public int height;
    public int width;
    public GameObject start;
    public GameObject end;
    private int ballout;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool hasPos;
    private Vector2 lastSpot;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        hasPos = false;
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
            lastSpot = startPos;

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

            FindPath();
            
        
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
         if (!hasPos)
         {
             pathBoi = startPos;
             hasPos = true;
         }
         if (pathBoi != endPos)
         {
             pathBoi = CheckSpaces();
         }
         else
         {
             print("you win");
         }
         
     }

      private Vector2 CheckSpaces()
      {
          Vector2 whereToMove;
          List<Vector2> isVaild;
          isVaild = new List<Vector2>();
          
          // check 4 directions
          if (pathBoi.x != width)
          {
              if (grid[(int) pathBoi.x + 1, (int) pathBoi.y] != 1)
              {
                  isVaild.Add(new Vector2(pathBoi.x + 1, pathBoi.y));
              }
          }

          if (pathBoi.y != height)
          {
              if (grid[(int) pathBoi.x, (int) pathBoi.y + 1] != 1)
              {
                  isVaild.Add(new Vector2(pathBoi.x, pathBoi.y + 1));
              }
          }

          if (pathBoi.x < 0)
          {
              if (grid[(int) pathBoi.x - 1, (int) pathBoi.y] != 1)
              {
                  isVaild.Add(new Vector2(pathBoi.x - 1, pathBoi.y));
              }
          }

          if (pathBoi.y < 0)
          {
              if (grid[(int) pathBoi.x, (int) pathBoi.y - 1] != 1)
              {
                  isVaild.Add(new Vector2(pathBoi.x, pathBoi.y - 1));
              }
          }

          if (isVaild.Count < 0)
          {
              for (int i = 0; i < isVaild.Count; i++)
              {
                  if (i == 0)
                  {
                      whereToMove = isVaild[0];
                  }

                  if (Vector2.Distance(isVaild[i], endPos < Vector2.Distance(whereToMove, endPos)))
                  {
                      whereToMove = isVaild[i];
                  }
              }
              return whereToMove;
          }

          return lastSpot;
      }


}
