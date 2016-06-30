using UnityEngine;
using System.Collections;

using Abilities;

public class FireRing : Ability {
    
    public FireRing() {

        abilityObjectName = "FireRingObject";
        abilityType = AbilityType.Centered;

        instantCast = false;

        chargeDuration = 0.5f;

        cooldownDuration = 2;
        
        manaCost = 10;
        damage = 10;
        
    } //End Constructor ()


    public override void AbilityMap() {
        CreateCenteredAbilityObject(abilityOwner.transform);
        ExitAbility();
    }


} //End FireRing class
