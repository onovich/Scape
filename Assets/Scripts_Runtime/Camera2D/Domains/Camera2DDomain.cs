using System;
using MortiseFrame.Swing;
using UnityEngine;

namespace MortiseFrame.Vista {

    public static class Camera2DDomain {

        // Dead Zone
        public static void DeadZone_Set(Camera2DContext ctx, Camera2DEntity camera, Vector2 deadZoneNormalizedSize) {
            var viewSize = ctx.ViewSize;
            camera.DeadZone_Set(deadZoneNormalizedSize, viewSize);
        }

        // Soft Zone
        public static void SoftZone_Set(Camera2DContext ctx, Camera2DEntity camera, Vector2 softZoneNormalizedSize) {
            var viewSize = ctx.ViewSize;
            camera.SoftZone_Set(softZoneNormalizedSize, viewSize);
        }

        // FSM
        public static void FSM_SetMoveToTarget(Camera2DContext ctx, Camera2DEntity camera, Vector2 target, float duration, EasingType easingType = EasingType.Linear, EasingMode easingMode = EasingMode.None, Action onComplete = null) {
            var fsmCom = camera.FSMCom;
            var pos = camera.Pos;
            fsmCom.EnterMovingToTarget(pos, target, duration, easingType, easingMode, onComplete);
        }

        public static void FSM_SetMoveByDriver(Camera2DContext ctx, Camera2DEntity camera, Transform driver) {
            var fsmCom = camera.FSMCom;
            fsmCom.EnterMovingByDriver(driver);
        }

        //  Move
        public static void MoveToTarget(Camera2DContext ctx, Camera2DEntity camera, Vector2 startPos, Vector2 targetPos, float current, float duration, EasingType easingType, EasingMode easingMode) {
            var pos = EasingHelper.Easing2D(startPos, targetPos, current, duration, easingType, easingMode);
            camera.Pos_Set(pos);
            ctx.MainCamera.transform.position = new Vector3(pos.x, pos.y, ctx.MainCamera.transform.position.z);
        }

        public static void MoveByDriver(Camera2DContext ctx, Camera2DEntity currentCamera, Camera mainCamera, Vector2 driverWorldPos) {
            bool isEnable = currentCamera.DeadZone_IsEnable();
            Vector2 cameraWorldPos = currentCamera.Pos;

            if (!isEnable) {
                cameraWorldPos = driverWorldPos;
            }

            if (isEnable) {
                var driverScreenPos = PositionUtil.WorldToScreenPos(mainCamera, driverWorldPos);
                var sreenDiff = currentCamera.DeadZone_GetScreenDiff(driverScreenPos);
                var worldDiff = PositionUtil.ScreenToWorldSize(ctx.MainCamera, sreenDiff);
                cameraWorldPos += worldDiff;
            }

            currentCamera.Pos_Set(cameraWorldPos);
            ctx.MainCamera.transform.position = new Vector3(cameraWorldPos.x, cameraWorldPos.y, ctx.MainCamera.transform.position.z);
        }

    }

}