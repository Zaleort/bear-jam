using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSprite
{
  public static Sprite Safe = Resources.Load<Sprite>("Sprites/tile1");
  public static Sprite Normal = Resources.Load<Sprite>("Sprites/tile1");
  public static Sprite Normal2 = Resources.Load<Sprite>("Sprites/tile2");
  public static Sprite Normal3 = Resources.Load<Sprite>("Sprites/tile3");
  public static Sprite Cracked1 = Resources.Load<Sprite>("Sprites/cracked1");
  public static Sprite Cracked2 = Resources.Load<Sprite>("Sprites/cracked2");
  public static Sprite Cracked3 = Resources.Load<Sprite>("Sprites/cracked3");
  public static Sprite Broken = Resources.Load<Sprite>("Sprites/broken");

  public static Sprite GetRandomNormalSprite()
  {
    System.Random random = new System.Random();
    int num = random.Next(1, 4);

    switch (num)
    {
      case 2: 
        return TileSprite.Normal2;
      case 3:
        return TileSprite.Normal3;
      default:
        return TileSprite.Normal;
    }
  }
}