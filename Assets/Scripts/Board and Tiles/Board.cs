using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Board : MonoBehaviour {

    [Serializable]
    private class BoardRows
    {
        public TileModel[] RowTile;
    }
    [SerializeField] private BoardRows[] _grid;
    private TileModel[,] _tileModel;

    private const int k_boardHeight = 6;
    private const int k_boardWidth = 4;

    private int _princessTileX = 0;
    private int _princessTileX2 = 0;
    private int _princessTileY = 3;

    private int _stairTileX = 0;
    private int _stairTileY = 0;

    [SerializeField] private PrincessModel _princessModel;

    void Awake()
    {
        _tileModel = new TileModel[k_boardHeight, k_boardWidth];
        for (var height = 0; height < k_boardHeight; height++)
        {
            for (var width = 0; width < k_boardWidth; width++)
            {
                _tileModel[height, width] = _grid[height].RowTile[width];
                _tileModel[height, width].SetupTile(height, width);
            }
        }


        StartCoroutine(FindPrincessRoom());
    }
    
    public TileTypes ReturnTileOnPosition(int _tileY, int _tileX)
    {
        if (k_boardHeight > _tileY && k_boardWidth > _tileX)
        {
            return _tileModel[_tileY, _tileX].ReturnTile();
        }
        else
        {
            return 0;
        }

    }
    public GameObject ReturnPositionOfTile(int _tileY, int _tileX)
    {
        if (k_boardHeight > _tileY && k_boardWidth > _tileX)
        {
            return _tileModel[_tileY, _tileX].gameObject;
        }
        else
        {
            return null;
        }

    }

    public void WalkableTile(int _tileY, int _tileX)
    {
        if (_tileY < k_boardHeight && _tileX < k_boardWidth)
        {
            Debug.Log("Height " + _tileY + "/" + k_boardHeight + " Width " + _tileX + "/" + k_boardWidth);
            _tileModel[_tileY, _tileX].EnableRenderer();
        }
    }

    public void RemoveWalkableTile(int _tileY, int _tileX)
    {
        if (_tileY < k_boardHeight && _tileX < k_boardWidth)
        {
            _tileModel[_tileY, _tileX].DisableRenderer();
        }
    }


    public void FindStairRoom()
    {
        int _randomX = UnityEngine.Random.Range(0, 5);
        int _randomY = UnityEngine.Random.Range(4, 6);

        _stairTileX = _randomX;
        _stairTileY = _randomY;

        _tileModel[_stairTileY, _stairTileX].BecomeStairTile();
      
    }




    private IEnumerator FindPrincessRoom()
    {
        yield return new WaitForSeconds(1);

        int _randomStart = UnityEngine.Random.Range(0, 2);
        int _randomModifier = UnityEngine.Random.Range(0,2);

        if (_randomStart == 0)
        {
            _princessTileX = 1;
        }
        else
        {
            _princessTileX = 2;
        }
        if (_randomModifier == 0)
        {
            _princessTileX2 = _princessTileX + 1;
        }
        else
        {
            _princessTileX2 = _princessTileX - 1;
        }

        if (_princessTileX2 > _princessTileX)
        {
            _tileModel[_princessTileY, _princessTileX].BecomePrincessTile( false);
            _tileModel[_princessTileY, _princessTileX2].BecomePrincessTile( true);
        }
        else
        {
            _tileModel[_princessTileY, _princessTileX].BecomePrincessTile(true);
            _tileModel[_princessTileY, _princessTileX2].BecomePrincessTile(false);
        }



        Debug.Log("Princesstile1: " + _tileModel[_princessTileY, _princessTileX] + " PrincessTile2: " + _tileModel[_princessTileY, _princessTileX2]);

        Debug.Log(_tileModel[_princessTileY, _princessTileX].transform.position);
        Debug.Log(_tileModel[_princessTileY, _princessTileX].transform.localPosition);
        Debug.Log("x´: " + _princessTileX);
        
        _princessModel.SpawnPrincess(_tileModel[_princessTileY, _princessTileX].transform.position);

    }

    public bool IsPrincessTile(int _tileCheckX, int _tileCheckY)
    {
        if (_tileModel[_tileCheckX, _tileCheckY]._tileType == TileTypes.PrincessTileLeft || _tileModel[_tileCheckX, _tileCheckY]._tileType == TileTypes.PrincessTileRight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public GameObject ReturnPrincessTile(int _tileCheckX, int _tileCheckY)
    {
        return _tileModel[_tileCheckX, _tileCheckY].gameObject;
    }

}




