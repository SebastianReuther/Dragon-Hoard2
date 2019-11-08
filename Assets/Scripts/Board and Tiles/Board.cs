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

    

	void Awake ()
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
            Debug.Log("Height " + _tileY + "/" + k_boardHeight + " Width " + _tileX + "/" +k_boardWidth);
            _tileModel[_tileY, _tileX].EnableRenderer();
        }
    }

}
