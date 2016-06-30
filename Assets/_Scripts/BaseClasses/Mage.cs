using UnityEngine;
using System.Collections;
using Abilities;

namespace Mages {

    public class Mage : MonoBehaviour {


        public int maxHealth {
            get; set;
        }

        public int currentHealth {
            get; set;
        }

        public int healthRegenPerSecond {
            get; set;
        }


        public int maxMana {
            get; set;
        }

        public int currentMana {
            get; set;
        }

        public int manaRegenPerSecond {
            get; set;
        }


        public int moveSpeed {
            get; set;
        }


        public bool isCharging {
            get; set;
        }

        public Ability currentAbility;
        
        public Ability abilityOne;
        public Ability abilityTwo;
        public Ability abilityThree;

        
        public Mage() {

            maxHealth = 0;
            currentHealth = 0;
            healthRegenPerSecond = 0;

            maxMana = 0;
            currentMana = 0;
            manaRegenPerSecond = 0;

            moveSpeed = 0;

        } //End Constructor()


        public virtual void BattleStart() {

            currentHealth = maxHealth;
            currentMana = maxMana;

            InvokeRepeating("ApplyHealthAndManaRegen", 1, 1);

            abilityOne.abilityOwner = this;
            abilityTwo.abilityOwner = this;
            abilityThree.abilityOwner = this;

        } //End BattleStart()


        public virtual void ApplyHealthAndManaRegen() {

            RefineApplication(currentHealth, maxHealth, healthRegenPerSecond);
            RefineApplication(currentMana, maxMana, manaRegenPerSecond);

        } //End ApplyHealthAndManaRegen()


        void RefineApplication(float current, float max, float regen) {

            if (current < max) {
                if ((current + regen) < max) {
                    current += regen;
                }
                else {
                    current = max;
                }
            }

        } //End RefineApplication(3)
        

    } //End Mage class


} //End Mages namespace
