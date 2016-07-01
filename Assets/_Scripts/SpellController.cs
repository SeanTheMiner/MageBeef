using UnityEngine;
using System.Collections;

using Abilities;
using Mages;

namespace SpellControllers {

    public class SpellController : MonoBehaviour {

        public bool staticSize, staticPosition, staticVelocity, staticDamage,
            fizzlesOnCollision;

        public float spellElapsedTime, spellDuration,
            endSizeScale, endVelocityScale;
        
        public SpellController() {

            staticSize = true;
            staticPosition = true;
            staticVelocity = true;
            staticDamage = true;

            fizzlesOnCollision = true;

        } //End Constructor()


        void Start() {

            Rigidbody rb = GetComponent<Rigidbody>();

            if (!staticSize) {
                StartCoroutine(LerpSizeScale());
            }

            if (!staticVelocity) {

            }


        }

        // Update is called once per frame
        void Update() {

            


        }


        IEnumerator LerpSizeScale() {

            while (spellElapsedTime < spellDuration) {
                float t = spellElapsedTime / spellDuration;
                Vector3 startSizeScaleVector = new Vector3(1, 1, 1);
                Vector3 endSizeScaleVector = new Vector3(endSizeScale, endSizeScale, endSizeScale);
                gameObject.transform.localScale = Vector3.Lerp(startSizeScaleVector, endSizeScaleVector, t);
                yield return null;
            }

        } //End LerpSizeScale()


        IEnumerator LerpVelocityScale() {

            while (spellElapsedTime < spellDuration) {
                float t = spellElapsedTime / spellDuration;
                Vector3 startVelocityScaleVector = new Vector3(1, 1, 1);
                Vector3 endVelocityScaleVector = new Vector3(endVelocityScale, endVelocityScale, endVelocityScale);
                gameObject.transform.localScale = Vector3.Lerp(startVelocityScaleVector, endVelocityScaleVector, t);
                yield return null;
            }

        } //End LerpSizeScale()



    } //End SpellController class

} //End SpellControllers namespace