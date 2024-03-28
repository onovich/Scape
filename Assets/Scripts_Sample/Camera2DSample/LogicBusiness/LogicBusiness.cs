using UnityEngine;

namespace MortiseFrame.Vista.Sample {

    public static class LogicBusiness {

        public static void EnterGame(MainContext ctx) {
            ctx.isGameStart = true;
        }

        public static void ProcessInput(MainContext ctx) {
            if (!ctx.isGameStart) return;

            if (Input.GetKey(KeyCode.W)) {
                ctx.roleMoveAxis = Vector2.up;
            }
            if (Input.GetKey(KeyCode.S)) {
                ctx.roleMoveAxis = Vector2.down;
            }
            if (Input.GetKey(KeyCode.A)) {
                ctx.roleMoveAxis = Vector2.left;
            }
            if (Input.GetKey(KeyCode.D)) {
                ctx.roleMoveAxis = Vector2.right;
            }
        }

        public static void ResetInput(MainContext ctx) {
            if (!ctx.isGameStart) return;

            ctx.roleMoveAxis = Vector2.zero;
        }

        public static void RoleMove(MainContext ctx, float dt) {
            if (!ctx.isGameStart) return;

            var role = ctx.roleEntity;
            var axis = ctx.roleMoveAxis;
            role.Move(axis, dt);
        }

    }

}