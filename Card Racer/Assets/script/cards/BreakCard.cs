using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Break Card")]
public class BreakCard : Card {

    public override void use(Player player)
    {
        base.use(player);
        Car car = player.car.GetComponent<Car>();
        car.useBreak();
    }
}
