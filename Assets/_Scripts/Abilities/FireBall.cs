using UnityEngine;
using System.Collections;

using Abilities;

public class FireBall : Ability {

    public FireBall() {

        abilityObjectName = "FireBallObject";
        abilityType = AbilityType.Projectile;

        instantCast = true;
        
        cooldownDuration = 0.3f;

        manaCost = 10;
        damage = 10;

        spellSpeed = 10;

    } //End Constructor ()


    public override void AbilityMap() {
        CreateProjectileAbilityObject(abilityOwner.transform);
        ExitAbility();
    }


} //End FireRing class
