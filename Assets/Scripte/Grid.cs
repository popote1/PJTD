using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{

    private int _width;
    private int _height;
    private GameObject[,] _gridArray;
    private float _cellSize;
    private Vector3 _worldPosition;

    public  Grid(int width, int height, float cellSize , Vector3 worldPosition)
    {
        _width = width;
        _height = height;
        _gridArray = new GameObject [width, height];
        _cellSize = cellSize;
        _worldPosition = worldPosition;

        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gridArray.GetLength(1) ;y++)
            {
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x,y+1 ),Color.white,100f);
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x+1,y ),Color.white,100f);
            }
            
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return  new Vector3(x,0,y*_cellSize);
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x=Mathf.FloorToInt(_worldPosition.x / _cellSize);
        y=Mathf.FloorToInt(_worldPosition.z / _cellSize);
    }

    public GameObject GetGameObjectForWorldPosition(Vector3 worldpos)
    {
        GetXY(worldpos, out int x, out int y);
        return _gridArray[x, y];
    }
   
}
