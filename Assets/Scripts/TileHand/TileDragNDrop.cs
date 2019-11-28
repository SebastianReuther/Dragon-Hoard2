using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileDragNDrop : MonoBehaviour
{
    private HandTile _handTile;
    private GameObject _otherTile;

    List<GameObject> _draggedOnTileList;

    private GameObject[] _gameTiles;
    private TileModel[] _tiles;
    private GameObject _closestDraggedOnTile;

    private float _closestDraggedOnTileDistance = 0;
    private float _closestDraggedOnTileMinDistance = 9999999999;
    private Vector3 _startDragPosition;
    private bool _bringBackToDragPosition;

    [SerializeField] private PlayerMovement _playerMovement;

    private void Start()
    {
        _handTile = GetComponent<HandTile>();
        _gameTiles = GameObject.FindGameObjectsWithTag("BoardTile");
        _tiles = FindObjectsOfType<TileModel>();
        _bringBackToDragPosition = true;
    }

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        _startDragPosition = transform.position;
    }

    void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        _handTile._isBeingDragged = true;
        
    }

    private void OnMouseUp()
    {
        _handTile._isBeingDragged = false;
        if (_bringBackToDragPosition == true)
        {
            Debug.Log("DropBack");
          //  transform.position = _startDragPosition;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("BoardTile"))
        {
            return;
        }

        Debug.Log("collided");
        _otherTile = other.gameObject;
       

        _bringBackToDragPosition = false;

        if (_otherTile.GetComponent<TileModel>()._tileType == TileTypes.None && _otherTile.GetComponent<TileModel>()._tileHighlighted == true && _otherTile == FindClosestTile())
        {
            Debug.Log(_bringBackToDragPosition);
            if (_handTile._isBeingDragged == false)
            {
                Debug.Log("Dropped");
                Debug.Log("Tilefound");
                
                FindClosestTile().GetComponent<TileModel>().AssignType((int)_handTile._tileType);
                Debug.Log(_otherTile);
                Debug.Log("collision pos of tile: " + _otherTile.transform.position);
                _playerMovement.MovePlayer(_otherTile.transform.position, _otherTile.GetComponent<TileModel>()._tileBoardXPosition, _otherTile.GetComponent<TileModel>()._tileBoardYPosition);
                Destroy(gameObject);

            }

        }
        else
        {
         //   _bringBackToDragPosition = true;
        }
    }

    private GameObject FindClosestTile()
    {
        for(var i = 0; i < _gameTiles.Length; i++)
        {
            TileModel model = _gameTiles[i].GetComponent<TileModel>();
            if (model._tileHighlighted == true && model._tileType == TileTypes.None)
            {
                _closestDraggedOnTileDistance = Vector2.Distance(_gameTiles[i].transform.position, transform.position);
                if (_closestDraggedOnTileDistance < _closestDraggedOnTileMinDistance)
                {
                    _closestDraggedOnTileMinDistance = _closestDraggedOnTileDistance;
                    _closestDraggedOnTile = _gameTiles[i];
                }
            }

        }
        return _closestDraggedOnTile;
        //add all colliding objects to a list
        //compare distance to object
        //return closest tile
    }
}
