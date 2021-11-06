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
    SetMap(1);
  }

  public void SetMap(int level)
  {
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
}
