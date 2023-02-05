using UnityEngine;

namespace TopDown.Gameplay.Movement
{
    public class SlerpFollow : MonoBehaviour
    {
        [SerializeField] private Transform followObject;
        [SerializeField] private float lerpTime;

        private void LateUpdate()
        {
            var moveTo = Vector3.Lerp(transform.position, followObject.position, lerpTime * Time.deltaTime);
            moveTo.z = transform.position.z;
            transform.position = moveTo;
        }
    }
}