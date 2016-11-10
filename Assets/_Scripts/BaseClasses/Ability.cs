using UnityEngine;
using System.Collections;

using Mages;
using SpellControllers;

namespace Abilities {

    public class Ability {
        
        public Mage abilityOwner;

        public string abilityObjectName;

        //Defining bools

        public bool instantCast {
            get; set;
        }

        public AbilityType abilityType;

        public enum AbilityType {
            Centered,
            Projectile,
            OnClick
        }


        //Defining variables

        public float chargeDuration {
            get; set;
        }

        public float chargeEndTimer {
            get; set;
        }

        public float cooldownDuration {
            get; set;
        }

        public float cooldownEndTimer {
            get; set;
        }

        public int manaCost {
            get; set;
        }

        public int damage {
            get; set;
        }

        public float spellSpeed {
            get; set;
        }


        //Constructor

        public Ability() {

            instantCast = false;

            chargeDuration = 0;
            chargeEndTimer = 0;

            cooldownDuration = 0;
            cooldownEndTimer = 0;

            manaCost = 0;
            damage = 0;
            
        } //End Constructor


        public void InitCharge() {

            chargeEndTimer = Time.time + chargeDuration;
            abilityOwner.isCharging = true;


        } //End InitCharge()
        

        public bool CheckCharge() {

            if (chargeEndTimer < Time.time) {
                abilityOwner.isCharging = false;
                return true;
            }
            else {
                return false;
            }

        } //End CheckCharge()


        public virtual void AbilityMap() { }


        public virtual void ExitAbility() {
            cooldownEndTimer = Time.time + cooldownDuration;
        }


        public void CreateCenteredAbilityObject (Transform playerLocation) {
            
            string prefabLocation = "AbilityObjects/" + abilityObjectName;
            GameObject abilityObject = (GameObject)MonoBehaviour.Instantiate(Resources.Load(prefabLocation),
                playerLocation.position,
                Quaternion.Euler(0, 0, 0)
                );
            
        } //End CreateAbilityObject(2)


        public void CreateProjectileAbilityObject(Transform playerLocation) {

            string prefabLocation = "AbilityObjects/" + abilityObjectName;
            GameObject abilityObject = (GameObject)MonoBehaviour.Instantiate(Resources.Load(prefabLocation),
                playerLocation.position,
                Quaternion.Euler(0, 0, 0)
                );

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.y = 0;
            
            Vector3 playerPosition = new Vector3(abilityOwner.transform.position.x, 0, abilityOwner.transform.position.z);

            Vector3 direction = (mousePosition - abilityOwner.transform.position).normalized;

            abilityObject.GetComponent<Rigidbody>().velocity = direction * spellSpeed;
            

        } //End CreateAbilityObject(2)




    } //End Ability class


} //End Abilities namespace
