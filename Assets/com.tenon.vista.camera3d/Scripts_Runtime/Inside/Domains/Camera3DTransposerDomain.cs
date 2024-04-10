using System;
using MortiseFrame.Swing;
using UnityEngine;

namespace TenonKit.Vista.Camera3D {

    internal static class Camera3DTransposerDomain {

        internal static void SetDeadZone(Camera3DContext ctx, int id, Vector2 normalizedSize) {
            var has = ctx.TryGetCamera(id, out var camera);
            if (!has) {
                V3Log.Error($"SetDeadZone Error, Camera Not Found: ID = {id}");
                return;
            }
            camera.Transposer_DeadZone_Set(normalizedSize, ctx.ViewSize);
        }

        internal static void EnableDeadZone(Camera3DContext ctx, int id, bool enable) {
            var has = ctx.TryGetCamera(id, out var camera);
            if (!has) {
                V3Log.Error($"EnableDeadZone Error, Camera Not Found: ID = {id}");
                return;
            }
            camera.Transposer_DeadZone_Enable(enable);
        }

        internal static bool IsDeadZoneEnable(Camera3DContext ctx, int id) {
            var has = ctx.TryGetCamera(id, out var camera);
            if (!has) {
                V3Log.Error($"IsDeadZoneEnable Error, Camera Not Found: ID = {id}");
                return false;
            }
            return camera.Transposer_DeadZone_IsEnable();
        }

        // SoftZone
        internal static void SetSoftZone(Camera3DContext ctx, int id, Vector2 normalizedSize, Vector3 dampingFactor) {
            var has = ctx.TryGetCamera(id, out var camera);
            if (!has) {
                V3Log.Error($"SetSoftZone Error, Camera Not Found: ID = {id}");
                return;
            }
            camera.Transposer_SoftZone_Set(normalizedSize, ctx.ViewSize, dampingFactor);
        }

        internal static void EnableSoftZone(Camera3DContext ctx, int id, bool enable) {
            var has = ctx.TryGetCamera(id, out var camera);
            if (!has) {
                V3Log.Error($"EnableSoftZone Error, Camera Not Found: ID = {id}");
                return;
            }
            camera.Transposer_SoftZone_Enable(enable);
        }

        internal static bool IsSoftZoneEnable(Camera3DContext ctx, int id) {
            var has = ctx.TryGetCamera(id, out var camera);
            if (!has) {
                V3Log.Error($"IsSoftZoneEnable Error, Camera Not Found: ID = {id}");
                return false;
            }
            return camera.Transposer_SoftZone_IsEnable();
        }

    }

}