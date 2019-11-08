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

    [SerializeField] private PlayerMovement _playerMovement;

    private void Start()
    {
        _handTile = GetComponent<HandTile>();
        _gameTiles = GameObject.FindGameObjectsWithTag("BoardTile");
        _tiles = FindObjectsOfType<TileModel>();
    }

    private void Update()
    {
        
    }

    void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        _handTile._isBeingDragged = true;
        //start position speichern
    }

    private void OnMouseUp()
    {
        _handTile._isBeingDragged = false;
        //zurück zu start positionen
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("BoardTile"))
        {
            return;
        }


        Debug.Log("collided");
        Debug.Log(_handTile._isBeingDragged);
        _otherTile = other.gameObject;

        if (_handTile._isBeingDragged == false)
        {
            Debug.Log(_otherTile);
           
            if (_otherTile.GetComponent<TileModel>()._tileType == TileTypes.None && _otherTile.GetComponent<TileModel>()._tileHighlighted == true)
            {
                Debug.Log("Dropped");
                if (_otherTile == FindClosestTile())
                {
                    Debug.Log("Tilefound");
                    FindClosestTile().GetComponent<TileModel>().AssignType((int)_handTile._tileType);
                    Destroy(gameObject);
                }
            }
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
