using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public Rigidbody2D body;
  public Map map;
  public int start;
  public int end;
  private SpriteRenderer spriteRenderer; 

  void Start()
  {
    body = GetComponent<Rigidbody2D>(); 
    spriteRenderer = GetComponent<SpriteRenderer>();
    start = 0;
    end = map.size * 32;
  }

  void Update()
  {
    Move();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (IsWinner(collision))
    {
      print("He ganao");
    }

    if (IsDead(collision))
    {
      print("Me he murido");
    }
  }

  private void Move()
  {
    if (Input.GetKeyDown("left") && IsLegalMove(this.transform.position.x, -Constants.SPRITE_SIZE))
    {
      this.transform.position += new Vector3(-Constants.SPRITE_SIZE, 0, 0);
      spriteRenderer.sprite = PlayerSprite.Left;
    }

    if (Input.GetKeyDown("right") && IsLegalMove(this.transform.position.x, Constants.SPRITE_SIZE))
    {
      this.transform.position += new Vector3(Constants.SPRITE_SIZE, 0, 0);
      spriteRenderer.sprite = PlayerSprite.Right;
    }

    if (Input.GetKeyDown("up") && IsLegalMove(this.transform.position.y, Constants.SPRITE_SIZE))
    {
      this.transform.position += new Vector3(0, Constants.SPRITE_SIZE, 0);
      spriteRenderer.sprite = PlayerSprite.Up;
    }

    if (Input.GetKeyDown("down") && IsLegalMove(this.transform.position.y, -Constants.SPRITE_SIZE))
    {
      this.transform.position += new Vector3(0, -Constants.SPRITE_SIZE, 0);
      spriteRenderer.sprite = PlayerSprite.Down;
    }
  }

  private bool IsLegalMove(float position, float delta)
  {
    float res = position + delta;
    return !(res < start || res >= end);
  }

  private bool IsDead(Collider2D collision)
  {
    Tile tile = collision.GetComponent<Tile>();

    if (tile != null)
    {
      return tile.state == TileState.Broken;
    }

    return false;
  }

  private bool IsWinner(Collider2D collision)
  {
    Eidolon eidolon = collision.GetComponent<Eidolon>();
    if (eidolon != null)
    {
      return true;
    }

    return false;
  }
}
