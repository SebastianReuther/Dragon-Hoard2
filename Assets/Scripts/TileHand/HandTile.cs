using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTile : MonoBehaviour {
    public TileTypes _tileType;
    public bool _isBeingDragged = false;
    [SerializeField] private Sprite[] _tileSprite;

    // Use this for initialization
    void Start () {

        _tileType = GetRandomTileType();
        GetComponent<SpriteRenderer>().sprite = _tileSprite[(int)_tileType];
    }

    public TileTypes GetRandomTileType()
    {
        return (TileTypes)Random.Range(2, 8);
    }

    // Update is called once per frame
    void Update () {

	}
}
