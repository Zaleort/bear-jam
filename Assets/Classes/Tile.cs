using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
  public TileState state;
  public float timer;
  private SpriteRenderer spriteRenderer;

  public Tile(TileState _state, float _timer, SpriteRenderer _spriteRenderer)
  {
    state = _state;
    timer = _timer;
    spriteRenderer = _spriteRenderer;
  }

  public void SetState(TileState _state)
  {
    state = _state;
    switch (state)
    {
      case TileState.Normal:
        spriteRenderer.sprite = TileSprite.GetRandomNormalSprite();
        break;
      case TileState.Cracked:
        spriteRenderer.sprite = TileSprite.Cracked;
        break;
      case TileState.Broken:
        spriteRenderer.sprite = TileSprite.Broken;
        break;
      default:
        spriteRenderer.sprite = TileSprite.Normal;
        break;
    }
  }

  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    SetState(TileState.Normal);
  }

  void FixedUpdate()
  {
    if (timer <= 0)
    {
      SetState(TileState.Broken);
      return;
    }

    if (timer > 0)     
    {
      timer -= Time.deltaTime;     
    }

    if (timer < 2 && timer > 0)
    {
      SetState(TileState.Cracked);
    }
  }
}

