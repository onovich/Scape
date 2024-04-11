using MortiseFrame.Swing;
using UnityEngine;

namespace TenonKit.Vista.Camera3D.Sample {

    public static class Camera3DInfra {

        public static void Tick(Main3DContext ctx, float dt) {
            ctx.core.Tick(dt);
        }

        public static void DrawGizmos(Main3DContext ctx) {
            ctx.core.DrawGizmos();
        }

        // Camera
        public static int CreateTrackCamera(Main3DContext ctx, Vector3 pos, Vector3 confinerWorldMax, Vector3 confinerWorldMin, Transform driver) {
            var mainCameraID = ctx.core.CreateTrackCamera3D(pos, confinerWorldMax, confinerWorldMin, driver);
            ctx.mainCameraID = mainCameraID;
            return mainCameraID;
        }

        public static void SetCurrentCamera(Main3DContext ctx, int cameraID) {
            ctx.core.SetCurrentCamera(cameraID);
        }

        // Move
        public static void SetMoveToTarget(Main3DContext ctx, Vector2 target, float duration, EasingType easingType = EasingType.Linear, EasingMode easingMode = EasingMode.None, System.Action onComplete = null) {
            ctx.core.FreeCamera_SetMoveToTarget(ctx.mainCameraID, target, duration, easingType, easingMode, onComplete);
        }

        // Rotate
        public static void Rotate(Main3DContext ctx, float yaw, float pitch, float roll) {
            ctx.core.Rotate(ctx.mainCameraID, yaw, pitch, roll);
        }

    }

}