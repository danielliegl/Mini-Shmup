using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAmmo : PowerUp
{
  public override void applyPowerUp(PlayerController player)
  {
    player.addBombAmmo(1);
  }
}
