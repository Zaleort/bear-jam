using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator: MonoBehaviour
{
  public GameObject tile;
  public GameObject eidolonPrefab;
  private GameObject CreateTile(float x, float y, TileState state, float timer)
  {
    GameObject tileObject = Instantiate(tile, new Vector3(x * 32, y * 32, 0), Quaternion.identity, this.transform);
    Tile tileComponent = tileObject.GetComponent(typeof(Tile)) as Tile;
    tileComponent.state = state;
    tileComponent.timer = timer;

    return tileObject;
  }

  public GameObject[,] GetLevel1()
  {
    return new GameObject[8, 8] {
      // 1
      { 
        CreateTile(0, 0, TileState.Normal, 500f),
        CreateTile(0, 1, TileState.Normal, 3f),
        CreateTile(0, 2, TileState.Normal, 7f),
        CreateTile(0, 3, TileState.Normal, 12f),
        CreateTile(0, 4, TileState.Normal, 250f),
        CreateTile(0, 5, TileState.Normal, 50f),
        CreateTile(0, 6, TileState.Normal, 2f),
        CreateTile(0, 7, TileState.Normal, 9f),
      },

      // 2
      { 
        CreateTile(1, 0, TileState.Normal, 3f),
        CreateTile(1, 1, TileState.Normal, 4f),
        CreateTile(1, 2, TileState.Normal, 5f),
        CreateTile(1, 3, TileState.Normal, 6f),
        CreateTile(1, 4, TileState.Normal, 7f),
        CreateTile(1, 5, TileState.Normal, 8f),
        CreateTile(1, 6, TileState.Normal, 9f),
        CreateTile(1, 7, TileState.Normal, 10f),
      },

      // 3
      { 
        CreateTile(2, 0, TileState.Normal, 250f),
        CreateTile(2, 1, TileState.Normal, 250f),
        CreateTile(2, 2, TileState.Normal, 250f),
        CreateTile(2, 3, TileState.Normal, 250f),
        CreateTile(2, 4, TileState.Normal, 250f),
        CreateTile(2, 5, TileState.Normal, 250f),
        CreateTile(2, 6, TileState.Normal, 250f),
        CreateTile(2, 7, TileState.Normal, 250f),
      },

      // 4
      { 
        CreateTile(3, 0, TileState.Normal, 250f),
        CreateTile(3, 1, TileState.Normal, 250f),
        CreateTile(3, 2, TileState.Normal, 250f),
        CreateTile(3, 3, TileState.Normal, 250f),
        CreateTile(3, 4, TileState.Normal, 250f),
        CreateTile(3, 5, TileState.Normal, 250f),
        CreateTile(3, 6, TileState.Normal, 250f),
        CreateTile(3, 7, TileState.Normal, 250f),
      },

      // 5
      { 
        CreateTile(4, 0, TileState.Normal, 250f),
        CreateTile(4, 1, TileState.Normal, 250f),
        CreateTile(4, 2, TileState.Normal, 250f),
        CreateTile(4, 3, TileState.Normal, 250f),
        CreateTile(4, 4, TileState.Normal, 250f),
        CreateTile(4, 5, TileState.Normal, 250f),
        CreateTile(4, 6, TileState.Normal, 250f),
        CreateTile(4, 7, TileState.Normal, 250f),
      },

      // 6
      { 
        CreateTile(5, 0, TileState.Normal, 250f),
        CreateTile(5, 1, TileState.Normal, 250f),
        CreateTile(5, 2, TileState.Normal, 250f),
        CreateTile(5, 3, TileState.Normal, 250f),
        CreateTile(5, 4, TileState.Normal, 250f),
        CreateTile(5, 5, TileState.Normal, 250f),
        CreateTile(5, 6, TileState.Normal, 250f),
        CreateTile(5, 7, TileState.Normal, 250f),
      },

      // 7
      { 
        CreateTile(6, 0, TileState.Normal, 250f),
        CreateTile(6, 1, TileState.Normal, 250f),
        CreateTile(6, 2, TileState.Normal, 250f),
        CreateTile(6, 3, TileState.Normal, 250f),
        CreateTile(6, 4, TileState.Normal, 250f),
        CreateTile(6, 5, TileState.Normal, 250f),
        CreateTile(6, 6, TileState.Normal, 250f),
        CreateTile(6, 7, TileState.Normal, 250f),
      },

      // 8
      { 
        CreateTile(7, 0, TileState.Normal, 250f),
        CreateTile(7, 1, TileState.Normal, 250f),
        CreateTile(7, 2, TileState.Normal, 250f),
        CreateTile(7, 3, TileState.Normal, 250f),
        CreateTile(7, 4, TileState.Normal, 250f),
        CreateTile(7, 5, TileState.Normal, 250f),
        CreateTile(7, 6, TileState.Normal, 250f),
        CreateTile(7, 7, TileState.Normal, 250f),
      },
    };
  }

  public GameObject GetLevel1Eidolon()
  {
    GameObject eidolon = Instantiate(eidolonPrefab, this.transform);
    Eidolon component = eidolon.GetComponent<Eidolon>();
    eidolon.transform.position = new Vector3(7 * Constants.SPRITE_SIZE, 7 * Constants.SPRITE_SIZE, -1);

    return eidolon;
  }
}
