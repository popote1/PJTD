﻿using System.Collections;
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

    public Vector3 GetWorldPosition(int x, int y)
    {
        return  new Vector3(x,0,y*_cellSize)+_worldPosition;
    }
    public Vector3 GetWorldPositionCenter(int x, int y)
    {
        return  new Vector3(x,0,y*_cellSize)+_worldPosition+new Vector3(_cellSize/2,0,_cellSize/2);
    }
    public Vector3 GetWorldPositionCenter(Vector3 pos)
    {
        GetXY(pos , out int x , out int y);
        return  new Vector3(x,0,y*_cellSize)+_worldPosition+new Vector3(_cellSize/2,0,_cellSize/2);
    }
    

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x=Mathf.FloorToInt((worldPosition-_worldPosition).x / _cellSize);
        y=Mathf.FloorToInt((worldPosition-_worldPosition).z / _cellSize);
        
       // Debug.Log("X= "+x +"         Y="+y);
    }

    public GameObject GetGameObjectForWorldPosition(Vector3 worldpos)
    {
        GetXY(worldpos, out int x, out int y);
        return _gridArray[x, y];
    }

    public GameObject[,] ObjectsOnGrid()
    {
        return _gridArray;
    }

    public GameObject GetObjectOnGrid(int x, int y)
    {
        return _gridArray[x, y];
    }

    public void SetGameObjectOnGrid(GameObject gameObject,int x, int y)
    {
        _gridArray[x, y] = gameObject;
    }

    public void SetGameObjectOnGrid(GameObject obj, Vector3 worldPosition)
    {
        GetXY(worldPosition, out int x, out int y);
        SetGameObjectOnGrid(obj, x, y);
    }

    public List<Vector2> CheckFreeCells()
    {
        List<Vector2> freeCells = new List<Vector2>();
        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++)
            {
                if (_gridArray[x, y] == null)
                {
                    freeCells.Add(new Vector2(x,y));
                }
            }
        }

        return freeCells;
    }

    public bool CheckIfCellIsFree(Vector3 pos)
    {
        GetXY(pos, out int x , out int y);
        if (_gridArray[x, y] == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   
}
