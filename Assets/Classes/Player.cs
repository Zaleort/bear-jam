using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public Rigidbody2D body;
  private SpriteRenderer spriteRenderer;
  public Map map;
  public int start;
  public int end;

  private float timeSinceLastMovement = 0f;
  private bool isCollidingEidolon = false;
  private Collider2D playerCollider;

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

  private void FixedUpdate()
  {
    CheckCollision();
  }

  private void OnTriggerEnter2D(Collider2D _collider)
  {
    playerCollider = _collider;
    if (IsWinner(playerCollider) && !isCollidingEidolon)
    {
      isCollidingEidolon = true;
      SendMessageUpwards("Win");
    }
  }

  private void Move()
  {
     timeSinceLastMovement += Time.deltaTime;

    if (
      Input.GetKeyDown("left") 
      && IsLegalTime()
      && IsLegalMove(this.transform.position.x, -Constants.SPRITE_SIZE)
    ) {
      this.transform.position += new Vector3(-Constants.SPRITE_SIZE, 0, 0);
      spriteRenderer.flipX = true;
      spriteRenderer.sprite = PlayerSprite.Side;
    }

    if (Input.GetKeyDown("right") 
      && IsLegalTime()
      && IsLegalMove(this.transform.position.x, Constants.SPRITE_SIZE)
    ) {
      this.transform.position += new Vector3(Constants.SPRITE_SIZE, 0, 0);
      spriteRenderer.flipX = false;
      spriteRenderer.sprite = PlayerSprite.Side;
    }

    if (Input.GetKeyDown("up") 
      && IsLegalTime()
      && IsLegalMove(this.transform.position.y, Constants.SPRITE_SIZE)
    ) {
      this.transform.position += new Vector3(0, Constants.SPRITE_SIZE, 0);
      spriteRenderer.sprite = PlayerSprite.Up;
    }

    if (Input.GetKeyDown("down") 
      && IsLegalTime()
      && IsLegalMove(this.transform.position.y, -Constants.SPRITE_SIZE)
    ) {
      this.transform.position += new Vector3(0, -Constants.SPRITE_SIZE, 0);
      spriteRenderer.sprite = PlayerSprite.Down;
    }
  }

  private bool IsLegalMove(float position, float delta)
  {
    float res = position + delta;
    return !(res < start || res >= end);
  }

  private bool IsLegalTime()
  {
    if (timeSinceLastMovement > 0.04f) {
      timeSinceLastMovement = 0;
      return true;
    }

    return false;
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
    Debug.Log(eidolon);
    if (eidolon != null)
    {
      return true;
    }

    return false;
  }

  private void RestartPlayerPosition()
  {
    isCollidingEidolon = false;
    this.transform.position = new Vector3(0, 0, -1);
  }

  private void CheckCollision()
  {
    if (playerCollider == null) return;

    if (IsDead(playerCollider))
    {
      SendMessageUpwards("Die");
    }
  }
}
