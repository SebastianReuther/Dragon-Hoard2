using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModel : MonoBehaviour {

    public TileTypes _tileType;
    private Vector2 _tilePosition;
    public bool _tileHighlighted = false;
    [SerializeField]private Sprite[] _tileSprite;
    [SerializeField]private TileChecker _tileChecker;

    public int _tileBoardXPosition;
    public int _tileBoardYPosition;
    public bool _isPrincessTile = false;

    public bool _isStairTile = false;
    

    public void SetupTile(int _width, int _height)
    { 

        _tilePosition = new Vector2(_width, _height);

        _tileBoardXPosition = _width;
        _tileBoardYPosition = _height;

        if (_width == 0 && _height == 0)
        {
            _tileType = TileTypes.Starter;
            GetComponent<SpriteRenderer>().sprite = _tileSprite[(int)_tileType];
            GetComponent<BoxCollider2D>().enabled = false;
        }

        if (_tileType != TileTypes.Starter)
        {
            AssignType(0);
            Debug.Log(_width + " " + _height + " " +_tileType);
            gameObject.GetComponent<Renderer>().enabled = false;
            
        }

    }

    public void AssignType(int AssignedTile)
    {
        _tileType = (TileTypes)AssignedTile;
        GetComponent<SpriteRenderer>().sprite = _tileSprite[(int)_tileType];

        if (_tileType != (int)0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    public void EnableRenderer()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        _tileHighlighted = true;
        
    }

    public void DisableRenderer()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        _tileHighlighted = false;
    }

    public TileTypes ReturnTile()
    {
        return _tileType;
    }

    public void BecomePrincessTile(bool _isRightTile)
    {   
        if (_isRightTile)
        {
            AssignType((int)TileTypes.PrincessTileRight);
        }
        else
        {
            AssignType((int)TileTypes.PrincessTileLeft);
        }
        
        EnableRenderer();
        _isPrincessTile = true;
    }

    public void BecomeStairTile()
    {
        AssignType((int)TileTypes.Stair);
        EnableRenderer();
        _isStairTile = true;
    }


// brauchen wir wahrscheinlich nicht mehr
    public TileTypes GetRandomTileType()
    {
        return (TileTypes)Random.Range(2, 8);
    }
}