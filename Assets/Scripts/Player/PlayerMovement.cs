using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int _playerX;
    public int _playerY;
    private int _previousPlayerX;
    private int _previousPlayerY;

    public Vector2 _playerPosition;
    private Vector2 _previousPlayerPosition;

    private bool _canMoveUp;
    private bool _canMoveLeft;
    private bool _canMoveDown;
    private bool _canMoveRight;

    private TileTypes _playerPositionTileType;

    [SerializeField] private TileChecker _tileChecker;
    [SerializeField] private Board _board;
    [SerializeField] private PrincessModel _princessModel;

    public bool _collectedPrincess = false;

    public void Start()
    {
        _playerX = 0;
        _playerY = 0;
        _playerPosition = new Vector2(_playerX, _playerY);
        CheckMovementOptions();
    }

    private void CheckMovementOptions()
    {
        //RemoveWalkableTiles();

        _playerPositionTileType = _board.ReturnTileOnPosition(_playerY,_playerX);
        _canMoveUp =_tileChecker.CanMoveUp(_playerPositionTileType);
        _canMoveRight = _tileChecker.CanMoveRight(_playerPositionTileType);
        _canMoveLeft = _tileChecker.CanMoveLeft(_playerPositionTileType);
        _canMoveDown = _tileChecker.CanMoveDown(_playerPositionTileType);
        if (_playerX == 0) { _canMoveLeft = false; }
        if (_playerY == 0) { _canMoveDown = false; }

        Debug.Log(" X: " + _playerX + " Y: " + _playerY +" Tile: " + _playerPositionTileType + " Can Move Up: " + _canMoveUp + " Can Move Right: " + _canMoveRight + " Can Move Left: " + _canMoveLeft + " Can Move Down: " + _canMoveDown);
        HighlightWalkableTiles();
        if (_collectedPrincess == false)
        {
            CheckForPrincessTile();
        }
    }

    public void MovePlayer(Vector3 positionOfTile, int _tileX, int _tileY)
    {
        Debug.LogWarning("plazer pos of tile: " + positionOfTile);
        CheckMovementOptions();

        if (_collectedPrincess == true)
        {
            _princessModel.MovePrincess(transform.position);
        }

        transform.position = positionOfTile;
     //   UpdateOldPosition(_playerX, _playerY);
        _playerX = _tileY;
        _playerY = _tileX;
        Debug.Log("X " +_playerX + " und Y: " + _playerY);


        CheckMovementOptions();
    }

    private void UpdateOldPosition(int _pX, int _pY)
    {
        _previousPlayerX = _pX;
        _previousPlayerY = _pY;
    }

    public void CheckForPrincessTile()
    {
        //if can move up true, if y+ returns princess tile
        //same for other directions
        if (_canMoveUp == true && _board.IsPrincessTile(_playerY + 1, _playerX))
        {
            // move up
            _collectedPrincess = true;
            MovePlayer(_board.ReturnPrincessTile(_playerY + 1, _playerX).transform.position, _playerY +1, _playerX);
        }
        if (_canMoveDown == true && _board.IsPrincessTile(_playerY - 1, _playerX))
        {
            // move down
            _collectedPrincess = true;
            MovePlayer(_board.ReturnPrincessTile(_playerY - 1, _playerX).transform.position, _playerY -1, _playerX);
        }
        if (_canMoveLeft == true && _board.IsPrincessTile(_playerY, _playerX - 1))
        {
            // move left
            _collectedPrincess = true;
            MovePlayer(_board.ReturnPrincessTile(_playerY, _playerX - 1).transform.position, _playerY, _playerX -1);
        }
        if (_canMoveRight == true && _board.IsPrincessTile(_playerY, _playerX + 1))
        {
            // move left
            _collectedPrincess = true;
            MovePlayer(_board.ReturnPrincessTile(_playerY, _playerX + 1).transform.position, _playerY, _playerX +1);
        }

        if (_collectedPrincess == true)
        {
            _board.FindStairRoom();
        }

        Debug.Log("CollectedPrincess: " + _collectedPrincess);
    }
   
    private void CalculateTileRotation()
    {
    }


    private void HighlightWalkableTiles()
    {
        if (_canMoveRight == true)
        {
            _board.WalkableTile(_playerY, _playerX + 1);
        }
        if (_canMoveDown == true)
        {
            _board.WalkableTile(_playerY - 1, _playerX);
        }
        if (_canMoveUp == true)
        {
            _board.WalkableTile(_playerY + 1, _playerX);
        }
        if (_canMoveLeft == true)
        {
            _board.WalkableTile(_playerY, _playerX - 1);
        }
    }

}
