using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChecker : MonoBehaviour {

    public bool CanMoveRight(TileTypes _tileType)
    {
        switch (_tileType)
        {
            case TileTypes.Starter: return (true);
            case TileTypes.Normal3: return (true);
            case TileTypes.Normal2Left: return (true);
            case TileTypes.Normal2Up: return (true);
            case TileTypes.Normal1UpLeft: return (true);
            case TileTypes.PrincessTileLeft: return (true);
            case TileTypes.PrincessTileRight: return (true);
            default: return (false);
        }

    }
    public bool CanMoveLeft(TileTypes _tileType)
    {
        switch (_tileType)
        {
            case TileTypes.Normal3: return (true);
            case TileTypes.Normal2Right: return (true);
            case TileTypes.Normal2Up: return (true);
            case TileTypes.Normal1UpRight: return (true);
            case TileTypes.PrincessTileLeft: return (true);
            case TileTypes.PrincessTileRight: return (true);
            default: return (false);
        }

    }
    public bool CanMoveUp(TileTypes _tileType)
    {
        switch (_tileType)
        {
            case TileTypes.Starter: return (true);
            case TileTypes.Normal3: return (true);
            case TileTypes.Normal2Left: return (true);
            case TileTypes.Normal2Right: return (true);
            case TileTypes.Normal1RightLeft: return (true);
            case TileTypes.PrincessTileLeft: return (true);
            case TileTypes.PrincessTileRight: return (true);
            default: return (false);
        }

    }
    public bool CanMoveDown(TileTypes _tileType)
    {
        switch (_tileType)
        {
            default: return (true);
        }

    }
}
