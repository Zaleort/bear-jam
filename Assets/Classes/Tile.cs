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
    switch (_state)
    {
      case TileState.Normal:
        spriteRenderer.sprite = TileSprite.GetRandomNormalSprite();
        break;
      case TileState.Cracked:
        spriteRenderer.sprite = TileSprite.Cracked1;
        break;
      case TileState.Broken:
        spriteRenderer.sprite = TileSprite.Broken;
        break;
      default:
        spriteRenderer.sprite = TileSprite.Normal;
        break;
    }

    state = _state;
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

