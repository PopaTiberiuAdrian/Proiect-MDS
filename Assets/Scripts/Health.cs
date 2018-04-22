using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructable {

    public override void Die()
    {
        base.Die();
        print("We die");
    }
    public override void TakeDamage(float amount)
    {
        print("Remaining: " + HitPointsRemaining);
        base.TakeDamage(amount);
    }
}
