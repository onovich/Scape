using UnityEngine;

namespace MortiseFrame.Vista.Sample {

    public class RoleEntity : MonoBehaviour {

        public float speed = 1;

        public void Move(Vector2 axis, float dt) {
            transform.position += (Vector3)axis * speed * dt;
        }

    }

}