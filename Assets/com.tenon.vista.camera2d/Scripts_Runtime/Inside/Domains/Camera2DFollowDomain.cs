using System;
using MortiseFrame.Swing;
using UnityEngine;

namespace TenonKit.Vista.Camera2D {

    internal static class Camera2DFollowDomain {

        internal static void FSM_SetMoveToTarget(Camera2DContext ctx, int id, Vector2 target, float duration, EasingType easingType = EasingType.Linear, EasingMode easingMode = EasingMode.None, Action onComplete = null) {
            var has = ctx.TryGetCamera(id, out var camera);
            if (!has) {
                V2Log.Error($"SetMoveToTarget Error, Camera Not Found: ID = {id}");
                return;
            }
            var fsmCom = camera.FSMCom;
            var pos = camera.Pos;
            fsmCom.EnterMovingToTarget(pos, target, duration, easingType, easingMode, onComplete);
        }

        internal static void FSM_SetMoveByDriver(Camera2DContext ctx, int id, Transform driver) {
            var has = ctx.TryGetCamera(id, out var camera);
            if (!has) {
                V2Log.Error($"SetMoveByDriver Error, Camera Not Found: ID = {id}");
                return;
            }
            var fsmCom = camera.FSMCom;
            fsmCom.EnterMovingByDriver(driver);
        }

    }

}