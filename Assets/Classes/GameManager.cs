using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public int level = 1;
  public GameObject map;
  public GameObject player;

  public void Win()
  {
    map.SendMessage("SetLevel", level++);
    player.SendMessage("RestartPlayerPosition");
  }

  public void Die()
  {
    map.SendMessage("SetLevel", level);
    player.SendMessage("RestartPlayerPosition");
  }
}
