using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
  public GameObject[,] tiles;
  public GameObject eidolon;
  public int size;
  public MapGenerator generator;

  // Start is called before the first frame update
  void Start()
  {
    generator = this.GetComponent<MapGenerator>();
    SetLevel(1);
  }

  public void SetLevel(int level)
  {
    DestroyTiles();
    DestroyEidolon();

    switch (level)
    {
      case 1:
        tiles = generator.GetLevel1();
        eidolon = generator.GetLevel1Eidolon();
        size = tiles.GetLength(1);
        break;
      default:
        tiles = generator.GetLevel1();
        eidolon = generator.GetLevel1Eidolon();
        size = tiles.GetLength(1);
        break;
    }
  }

  private void DestroyTiles()
  {
    if (tiles == null) return;

    for (int i = 0; i < tiles.GetLength(0); i++)
    {
      for (int j = 0; j < tiles.GetLength(1); j++)
      {
        Destroy(tiles[i, j]);
      }
    }
  }

  private void DestroyEidolon()
  {
    if (eidolon == null) return;
    Destroy(eidolon);
  }
}
