using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int _playerX;
    public int _playerY;
    public Vector2 _playerPosition;
    private Vector2 _previousPlayerPosition;

    private bool _canMoveUp;
    private bool _canMoveLeft;
    private bool _canMoveDown;
    private bool _canMoveRight;

    private TileTypes _playerPositionTileType;

    [SerializeField] private TileChecker _tileChecker;
    [SerializeField] private Board _board;

    public void Start()
    {
        _playerX = 0;
        _playerY = 0;
        _playerPosition = new Vector2(_playerX, _playerY);
        CheckMovementOptions();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _canMoveUp == true)
        {
            _playerY += 1;
            MovePlayer(_playerX, _playerY);
        }
        else if (Input.GetKeyDown(KeyCode.A) && _canMoveLeft == true)
        {
            _playerX -= 1;
            MovePlayer(_playerX, _playerY);
        }
        else if (Input.GetKeyDown(KeyCode.S) && _canMoveDown == true)
        {
            _playerY -= 1;
            MovePlayer(_playerX, _playerY);
        }
        else if (Input.GetKeyDown(KeyCode.D) && _canMoveRight == true)
        {
            _playerX += 1;
            MovePlayer(_playerX, _playerY);
        }
    }

    private void CheckMovementOptions()
    {
        _playerPositionTileType = _board.ReturnTileOnPosition(_playerY,_playerX);
        _canMoveUp =_tileChecker.CanMoveUp(_playerPositionTileType);
        _canMoveRight = _tileChecker.CanMoveRight(_playerPositionTileType);
        _canMoveLeft = _tileChecker.CanMoveLeft(_playerPositionTileType);
        _canMoveDown = _tileChecker.CanMoveDown(_playerPositionTileType);
        if (_playerX == 0) { _canMoveLeft = false; }
        if (_playerY == 0) { _canMoveDown = false; }

        Debug.Log(" X: " + _playerX + " Y: " + _playerY +" Tile: " + _playerPositionTileType + " Can Move Up: " + _canMoveUp + " Can Move Right: " + _canMoveRight + " Can Move Left: " + _canMoveLeft + " Can Move Down: " + _canMoveDown);
        HighlightWalkableTiles();
    }

    public void MovePlayer(int newPositionX, int newPositionY)
    {
        CheckMovementOptions();
        if (_board.ReturnPositionOfTile(newPositionY, newPositionX) != null)
        {
            transform.position = _board.ReturnPositionOfTile(newPositionY, newPositionX).transform.position;
        }
        Debug.Log(_board.ReturnPositionOfTile(newPositionY, newPositionX));
        HighlightWalkableTiles();
    }

   
    private void CalculateTileRotation()
    {
    }

    private void WalkabelTiles()
    {
        if (_canMoveRight == true)
        {

        }

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
